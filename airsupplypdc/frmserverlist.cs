using AirSupplyPDC.TCP_IP;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DataSave = AirSupplyPDC.Properties.Settings;

namespace AirSupplyPDC
{
    public partial class frmServerList : DevExpress.XtraEditors.XtraForm
    {
        public delegate void CloseHandler(Client client, bool isconnect);
        public CloseHandler iConnect = delegate { };
        public delegate void StreamData(Guid GuidStr, string iDataConnect, string content, string respond, bool isSuccess);
        public StreamData DataStream = delegate { };
        public delegate void UpdateCabinet(int _idCabinet);
        public delegate void UpdateListCaninet(int[] _idCabinet);
        public UpdateCabinet updateCab = delegate { };
        public UpdateListCaninet updatelsCab = delegate { };

        public bool isClosing { get; set; } = false;

        public frmServerList()
        {
            InitializeComponent();
            try
            {
                if (DataSave.Default.portint.Length > 0)
                {
                    int[] listPort = JsonConvert.DeserializeObject<int[]>(DataSave.Default.portint);
                    serverInforBindingSource.DataSource = listPort.Select(x => new ServerInfor() { Port = x }).ToArray();
                }
            }
            catch
            {
                DataSave.Default.portint = JsonConvert.SerializeObject(new int[0]);
                DataSave.Default.Save();
                serverInforBindingSource.DataSource = new int[0].Select(x => new ServerInfor() { Port = x }).ToArray(); ;
            }
        }

        private void gridView_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.RowHandle > -1)
            {
                if (e.Column == colOn)
                {
                    if (e.RepositoryItem is RepositoryItemButtonEdit itemButtonEdit)
                        if (gridView.GetRow(e.RowHandle) is ServerInfor serverInfor)
                        {
                            if (serverInfor.isStart)
                            {
                                RepositoryItemButtonEdit repositoryItemButtonEdit = (RepositoryItemButtonEdit)itemButtonEdit.Clone();
                                repositoryItemButtonEdit.Buttons.Clear();
                                e.RepositoryItem = repositoryItemButtonEdit;
                            }
                        }
                }
                else if (e.Column == colOff)
                {
                    if (e.RepositoryItem is RepositoryItemButtonEdit itemButtonEdit)
                        if (gridView.GetRow(e.RowHandle) is ServerInfor serverInfor)
                        {
                            if (!serverInfor.isStart)
                            {
                                RepositoryItemButtonEdit repositoryItemButtonEdit = (RepositoryItemButtonEdit)itemButtonEdit.Clone();
                                repositoryItemButtonEdit.Buttons.Clear();
                                e.RepositoryItem = repositoryItemButtonEdit;
                            }
                        }
                }
            }
        }

        private void repOff_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridView.BeginDataUpdate();
            EditorButton editorButton_ = e.Button;
            switch (editorButton_.Kind)
            {
                case ButtonPredefines.Glyph:
                    {
                        if (serverInforBindingSource.Current is ServerInfor fileInfor)
                        {
                            if (fileInfor.isStart)
                                if (fileInfor.Stop())
                                    fileInfor.isStart = false;
                        }
                        break;
                    }
            }
            //gridView.FocusedColumn = colPort;
            //gridView.RefreshRow(gridView.FocusedRowHandle);
            gridView.EndDataUpdate();
        }

        private void repOn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridView.BeginDataUpdate();
            EditorButton editorButton_ = e.Button;
            switch (editorButton_.Kind)
            {
                case ButtonPredefines.Glyph:
                    {
                        if (serverInforBindingSource.Current is ServerInfor fileInfor)
                        {

                            if (!fileInfor.isStart)
                                if (fileInfor.Start())
                                {
                                    fileInfor.Server.DataStream = (a, b, c, d, f) => DataStream(a, b, c, d, f);
                                    fileInfor.Server.iConnect = (a, b) => iConnect(a, b);
                                    fileInfor.Server.updateCab = (a) => updateCab(a);
                                    fileInfor.Server.updatelsCab = (a) => updatelsCab(a);
                                    fileInfor.isStart = true;
                                }

                        }
                        break;
                    }
            }
            gridView.EndDataUpdate();
            //gridView.FocusedColumn = colPort;
            //gridView.RefreshRow(gridView.FocusedRowHandle);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (serverInforBindingSource.DataSource is ServerInfor[] listport)
            {
                if (spinEditPort.Value > 0)
                    if (!listport.Any(x => x.Port == spinEditPort.Value))
                    {
                        List<ServerInfor> data = new List<ServerInfor>();
                        data.AddRange(listport);
                        data.Add(new ServerInfor()
                        {
                            Port = Convert.ToInt32(spinEditPort.Value)
                        });
                        serverInforBindingSource.DataSource = data.ToArray();
                        DataSave.Default.portint = JsonConvert.SerializeObject(data.Select(x => x.Port).ToArray());
                        DataSave.Default.Save();
                    }
            }
            else
            {
                if (spinEditPort.Value > 0)
                {
                    List<ServerInfor> data = new List<ServerInfor>
                    {
                        new ServerInfor()
                        {
                            Port = Convert.ToInt32(spinEditPort.Value)
                        }
                    };
                    serverInforBindingSource.DataSource = data.ToArray();
                    DataSave.Default.portint = JsonConvert.SerializeObject(data.Select(x => x.Port).ToArray());
                    DataSave.Default.Save();
                }
            }
        }
        public void CloseAllPort()
        {
            if (serverInforBindingSource.DataSource is ServerInfor[] listport)
                foreach (ServerInfor server in listport.Where(x => x.isStart))
                    server.Stop();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            CloseAllPort();
            serverInforBindingSource.DataSource = new ServerInfor[0];
            DataSave.Default.portint = JsonConvert.SerializeObject(new int[0]);
            DataSave.Default.Save();
        }

        private void frmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !isClosing;
        }
    }
}