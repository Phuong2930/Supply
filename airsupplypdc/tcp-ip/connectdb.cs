

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirSupplyPDC.TCP_IP
{
    public class ConnecttoDb
    {
        public string ConnectString { get; set; }
        public bool OpenConnect(SqlConnection _co)
        {
            try
            {
                if (_co != null)
                    if (_co.State != ConnectionState.Open)
                    {
                        _co.Open();
                        return true;
                    }
            }
            catch//(Exception ex)
            {

            }
            return false;
        }
        // Close Connect MySQL
        public bool CloseConnect(SqlConnection _co)
        {
            try
            {
                if (_co != null)
                    if (_co.State != ConnectionState.Closed)
                        _co.Close();
                return true;
            }
            catch { }
            return false;
        }
        public DataTable GetDataByConnection(string command, SqlConnection _co)
        {
            DataTable dt = new DataTable();
            try
            {
                using (var commandExe = _co.CreateCommand())
                {
                    commandExe.CommandText = command;
                    new SqlDataAdapter(commandExe).Fill(dt);
                }
            }
            catch (Exception)
            {
                dt = null;
            };
            //Thread.Sleep(50);
            return dt;
        }
        // Execite Command from Db MSSQL
        public DataTable GetData(string command)
        {

            //string Datad = string.Format("Task {0} Thread {1}", Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
            DataTable dtback = new DataTable();
            using (SqlConnection _conn = new SqlConnection(ConnectString))
            {
                if (OpenConnect(_conn))
                {
                    using (var commanddetex = _conn.CreateCommand())
                        try
                        {
                            commanddetex.CommandText = command;
                            var reader = commanddetex.ExecuteReader();
                            dtback.Load(reader);
                        }
                        catch
                        {
                            //dtback = null;
                        };
                }
                GC.Collect();
            }
            return dtback;
        }
        public DataTable GetData(string command, params SqlParameter[] datas)
        {

            //string Datad = string.Format("Task {0} Thread {1}", Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
            DataTable dtback = new DataTable();
            using (SqlConnection _conn = new SqlConnection(ConnectString))
            {
                if (OpenConnect(_conn))
                {
                    using (var commanddetex = _conn.CreateCommand())
                        try
                        {
                            commanddetex.CommandText = command;
                            commanddetex.Parameters.AddRange(datas);
                            var reader = commanddetex.ExecuteReader();
                            dtback.Load(reader);
                        }
                        catch (Exception ex)
                        {
                            //dtback = null;
                        };
                }
                GC.Collect();
            }
            return dtback;
        }
        public Task<DataTable> GetDataSync(string command)
        {
            return
                Task<DataTable>.Run(() =>
                {
                    DataTable dtback = new DataTable();
                    using (SqlConnection _conn = new SqlConnection(ConnectString))
                    {
                        if (OpenConnect(_conn))
                        {
                            using (var commanddetex = _conn.CreateCommand())
                                try
                                {
                                    commanddetex.CommandText = command;
                                    var reader = commanddetex.ExecuteReader();
                                    dtback.Load(reader);
                                }
                                catch
                                {

                                };
                        }
                        GC.Collect();
                    }
                    return dtback;
                });
        }

        public Task<DataTable[]> GetDataSyncParavel(params string[] command)
        {
            return Task.WhenAll(command.Select(x => Task.Run(() => GetData(x))));
        }

        // Execite Command from Db MSSQL
        public Task<DataTable[]> GetDataSync(params string[] command)
        {
            return
                Task<DataTable>.Run(() =>
                {
                    //string Datad = string.Format("Task {0} Thread {1}", Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
                    DataTable[] dtbacklist = new DataTable[command.Length];
                    using (SqlConnection _conn = new SqlConnection(ConnectString))
                    {
                        if (OpenConnect(_conn))
                        {
                            for (int i = 0; i < command.Length; i++)
                            {
                                DataTable dtitem = new DataTable();
                                using (var commanddetex = _conn.CreateCommand())
                                    try
                                    {
                                        commanddetex.CommandText = command[i];
                                        var reader = commanddetex.ExecuteReader();
                                        dtitem.Load(reader);
                                    }
                                    catch
                                    {

                                    };
                                dtbacklist[i] = dtitem;
                            }
                        }
                        GC.Collect();
                    }
                    return dtbacklist;
                });
        }
    }
}
