using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirSupplyPDC.AsynProcess
{
    public class Processing
    {
        public static void SetListBoxValue(ListBoxControl coltrl, string item_)
        {
            if (coltrl == null)
            {
                throw new ArgumentNullException("uiElement");
            }
            if (coltrl.InvokeRequired)
                coltrl.Invoke(new MethodInvoker(() => SetListBoxValue(coltrl, item_)));
            else
            {
                if (coltrl.IsDisposed)
                {
                    throw new ObjectDisposedException("Control is already disposed.");
                }
                try
                {
                    coltrl.Items.Add(item_);
                    coltrl.SetSelected(coltrl.Items.Count - 1, true);
                }
                catch { }
                finally { }
            }
        }
        public static void SetLabelValue(LabelControl coltrl, string item_)
        {
            if (coltrl == null)
            {
                throw new ArgumentNullException("uiElement");
            }
            if (coltrl.InvokeRequired)
                coltrl.Invoke(new MethodInvoker(() => SetLabelValue(coltrl, item_)));
            else
            {
                if (coltrl.IsDisposed)
                {
                    throw new ObjectDisposedException("Control is already disposed.");
                }
                try
                {
                    if (coltrl.Text != item_)
                        coltrl.Text = item_;
                }
                catch { }
                finally { }
            }
        }
        public static void SetLabelColor(LabelControl coltrl, Color item_)
        {
            if (coltrl == null)
            {
                throw new ArgumentNullException("uiElement");
            }
            if (coltrl.InvokeRequired)
                coltrl.Invoke(new MethodInvoker(() => SetLabelColor(coltrl, item_)));
            else
            {
                if (coltrl.IsDisposed)
                {
                    throw new ObjectDisposedException("Control is already disposed.");
                }
                try
                {
                    if (coltrl.BackColor != item_)
                        coltrl.BackColor = item_;
                }
                catch { }
                finally { }
            }
        }
        public static void SetUserControlColor(XtraUserControl coltrl, Color item_)
        {
            if (coltrl == null)
            {
                throw new ArgumentNullException("uiElement");
            }
            if (coltrl.InvokeRequired)
                coltrl.Invoke(new MethodInvoker(() => SetUserControlColor(coltrl, item_)));
            else
            {
                if (coltrl.IsDisposed)
                {
                    throw new ObjectDisposedException("Control is already disposed.");
                }
                try
                {
                    coltrl.BackColor = item_;
                }
                catch { }
                finally { }
            }
        }
        public static void SetToggleValue(ToggleSwitch coltrl, object item_)
        {
            if (coltrl == null)
            {
                throw new ArgumentNullException("uiElement");
            }
            if (coltrl.InvokeRequired)
                coltrl.Invoke(new MethodInvoker(() => SetToggleValue(coltrl, item_)));
            else
            {
                if (coltrl.IsDisposed)
                {
                    throw new ObjectDisposedException("Control is already disposed.");
                }
                try
                {
                    coltrl.EditValue = item_;
                }
                catch { }
                finally { }
            }
        }
        public static void SetValue(SpinEdit coltrl, object item_)
        {
            if (coltrl == null)
            {
                throw new ArgumentNullException("uiElement");
            }
            if (coltrl.InvokeRequired)
                coltrl.Invoke(new MethodInvoker(() => SetValue(coltrl, item_)));
            else
            {
                if (coltrl.IsDisposed)
                {
                    throw new ObjectDisposedException("Control is already disposed.");
                }
                try
                {
                    coltrl.EditValue = item_;
                }
                catch { }
                finally { }
            }
        }
        public static void SetValue(XtraForm coltrl, string item_)
        {
            if (coltrl == null)
            {
                throw new ArgumentNullException("uiElement");
            }
            if (coltrl.InvokeRequired)
                coltrl.Invoke(new MethodInvoker(() => SetValue(coltrl, item_)));
            else
            {
                if (coltrl.IsDisposed)
                {
                    throw new ObjectDisposedException("Control is already disposed.");
                }
                try
                {
                    if (coltrl.Text != item_)
                        coltrl.Text = item_;
                }
                catch { }
                finally { }
            }
        }
        public static void RemoveListBoxValue(ListBoxControl coltrl, string item_)
        {
            if (coltrl == null)
            {
                throw new ArgumentNullException("uiElement");
            }
            if (coltrl.InvokeRequired)
                coltrl.Invoke(new MethodInvoker(() => RemoveListBoxValue(coltrl, item_)));
            else
            {
                if (coltrl.IsDisposed)
                {
                    throw new ObjectDisposedException("Control is already disposed.");
                }
                try
                {
                    coltrl.Items.Remove(item_);
                }
                catch { }
                finally { }
            }
        }
        public static async void DoAction(params Action[] actions)
        {
            await Task.Delay(1);
        }
        public static void SetFlowLayoutPanel(FlowLayoutPanel coltrl, bool isClear, params UserControl[] controls_)
        {
            if (coltrl == null)
            {
                throw new ArgumentNullException("uiElement");
            }
            if (coltrl.InvokeRequired)
                coltrl.Invoke(new MethodInvoker(() => SetFlowLayoutPanel(coltrl, isClear, controls_)));
            else
            {
                if (coltrl.IsDisposed)
                {
                    throw new ObjectDisposedException("Control is already disposed.");
                }
                try
                {
                    if (isClear && coltrl != null)
                    {
                        foreach (Control control in coltrl.Controls)
                        {
                            coltrl.Controls.Remove(control);
                            control.Dispose();
                        }
                        coltrl.Controls.Clear();
                    }
                    if (controls_ != null)
                        coltrl.Controls.AddRange(controls_);
                }
                catch { }
                finally { }
            }
        }
        public static void AddGridItem(GridControl gridControl_, BindingSource dataSet_, object data)
        {
            if (gridControl_ == null)
            {
                throw new ArgumentNullException("uiElement");
            }
            if (gridControl_.InvokeRequired)
                gridControl_.Invoke(new MethodInvoker(() => AddGridItem(gridControl_, dataSet_, data)));
            else
            {
                if (gridControl_.IsDisposed)
                {
                    // throw new ObjectDisposedException("Control is already disposed.");
                }
                try
                {
                    while (dataSet_.Count >= 500)
                        dataSet_.RemoveAt(0);
                    dataSet_.Add(data);
                    gridControl_.RefreshDataSource();
                    if (gridControl_.DefaultView is GridView gridView)
                        if (!gridControl_.IsFocused)
                            gridView.MoveLast();
                    //gridView.BestFitColumns();
                }
                catch { }
                finally { }
            }
        }
        public static System.Drawing.Color GetSystemDrawingColorFromHexString(string hexString)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(hexString, @"[#]([0-9]|[a-f]|[A-F]){6}\b"))
                throw new ArgumentException();
            int red = int.Parse(hexString.Substring(1, 2), NumberStyles.HexNumber);
            int green = int.Parse(hexString.Substring(3, 2), NumberStyles.HexNumber);
            int blue = int.Parse(hexString.Substring(5, 2), NumberStyles.HexNumber);
            return Color.FromArgb(red, green, blue);
        }
        public static void SetGrid(GridControl list_, object[] obj)
        {
            if (list_.InvokeRequired)
                list_.Invoke(new MethodInvoker(delegate { SetGrid(list_, obj); }));
            else
            {
                try
                {
                    if (list_.MainView is GridView gridView)
                    {
                        gridView.BeginDataUpdate();
                        int focusrow = gridView.FocusedRowHandle;
                        list_.DataSource = obj;
                        if (obj != null)
                            if (focusrow <= obj.Length)
                                gridView.FocusedRowHandle = focusrow;
                        gridView.EndDataUpdate();
                        gridView.BestFitColumns();
                    }


                }
                finally { }
            }
        }
        public static void SetFlowLayout(FlowLayoutPanel layout, itemCabinet index)
        {
            if (layout.InvokeRequired)
                layout.Invoke(new MethodInvoker(delegate { SetFlowLayout(layout, index); }));
            else
            {
                try
                {
                    var loc = index.Location - new Size(layout.AutoScrollPosition);
                    loc -= new Size(index.Margin.Left, index.Margin.Top);
                    layout.AutoScrollPosition = loc;
                    //index.Focus();
                }
                finally { }
            }
        }
    }
}
