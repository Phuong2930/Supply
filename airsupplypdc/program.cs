using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using AirSupplyPDC.TCP_IP;
using System.IO;

namespace AirSupplyPDC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static InforCommon inforCommon { get; set; } = new InforCommon();
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            Application.Run(new frmMain());
        }
        public static class Log
        {
            public static void WriteLogError(string filename, string content)
            {
                string Filename = string.Format("{0}{1}.txt", AppDomain.CurrentDomain.BaseDirectory, filename.Replace(" ", ""));
                if (File.Exists(Filename))
                    if (new FileInfo(Filename).Length > 10000000)
                        File.Delete(Filename);
                StreamWriter sw = null;
                try
                {
                    sw = new StreamWriter(Filename, true);
                    sw.WriteLine(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + ": " + content);
                    sw.Flush();
                    sw.Close();
                }
                catch
                {
                    // ignored
                }
                finally
                {
                    sw = null;
                }
            }
        }
    }
}
