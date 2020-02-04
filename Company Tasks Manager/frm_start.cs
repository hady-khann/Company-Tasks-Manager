using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Company_Tasks_Manager
{
    public partial class frm_start : Form
    {
        public frm_start()
        {
            InitializeComponent();
        }

        private void frm_start_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            this.Refresh();
            int ranservices = 0;
            int time = 3000;
            while (ranservices != 6)
            {
                ranservices = 0;



                if (Services.Servicestatus("MSSQLFDLauncher"))
                {
                    lbl_status.Text = "starting MSSQLFDLauncher"; lbl_status.Refresh();
                    Services.StartService("MSSQLFDLauncher", time);
                    ranservices++;
                    lbl_number.Text = ranservices + " / 6"; lbl_number.Refresh();
                }
                else
                {
                    ranservices++;
                    lbl_status.Text = "MSSQLFDLauncher is already started"; lbl_status.Refresh();
                    lbl_number.Text = ranservices + " / 6"; lbl_number.Refresh();
                    Thread.Sleep(time);
                }




                if (Services.Servicestatus("MSSQLSERVER"))
                {
                    lbl_status.Text = "starting MSSQLSERVER"; lbl_status.Refresh();
                    Services.StartService("MSSQLSERVER", time);
                    ranservices++;
                    lbl_number.Text = ranservices + " / 6"; lbl_number.Refresh();
                }
                else
                {
                    ranservices++;
                    lbl_status.Text = "MSSQLSERVER is already started"; lbl_status.Refresh();
                    lbl_number.Text = ranservices + " / 6"; lbl_number.Refresh();
                    Thread.Sleep(time);
                }




                if (Services.Servicestatus("SQLSERVERAGENT"))
                {
                    lbl_status.Text = "starting SQLSERVERAGENT"; lbl_status.Refresh();
                    Services.StartService("SQLSERVERAGENT", time);
                    lbl_number.Text = ranservices + " / 6"; lbl_number.Refresh();
                    ranservices++;
                }
                else
                {
                    ranservices++;
                    lbl_status.Text = "SQLSERVERAGENT is already started"; lbl_status.Refresh();
                    lbl_number.Text = ranservices + " / 6"; lbl_number.Refresh();
                    Thread.Sleep(time);
                }




                if (Services.Servicestatus("MSSQLServerOLAPService"))
                {
                    lbl_status.Text = "starting MSSQLServerOLAPService"; lbl_status.Refresh();
                    Services.StartService("MSSQLServerOLAPService", time);
                    lbl_number.Text = ranservices + " / 6"; lbl_number.Refresh();
                    ranservices++;
                }
                else
                {
                    ranservices++;
                    lbl_status.Text = "MSSQLServerOLAPService is already started"; lbl_status.Refresh();
                    lbl_number.Text = ranservices + " / 6"; lbl_number.Refresh();
                    Thread.Sleep(time);
                }




                if (Services.Servicestatus("SSASTELEMETRY"))
                {
                    lbl_status.Text = "starting SSASTELEMETRY"; lbl_status.Refresh();
                    Services.StartService("SSASTELEMETRY", time);
                    lbl_number.Text = ranservices + " / 6"; lbl_number.Refresh();
                    ranservices++;
                }
                else
                {
                    ranservices++;
                    lbl_status.Text = "SSASTELEMETRY is already started"; lbl_status.Refresh();
                    lbl_number.Text = ranservices + " / 6"; lbl_number.Refresh();
                    Thread.Sleep(time);
                }




                if (Services.Servicestatus("SQLBrowser"))
                {
                    lbl_status.Text = "starting SQLBrowser"; lbl_status.Refresh();
                    Services.StartService("SQLBrowser", time);
                    lbl_number.Text = ranservices + " / 6"; lbl_number.Refresh();
                    ranservices++;
                }
                else
                {
                    ranservices++;
                    lbl_status.Text = "SQLBrowser is already started"; lbl_status.Refresh();
                    lbl_number.Text = ranservices + " / 6"; lbl_number.Refresh();
                    Thread.Sleep(time);
                }

            }

            lbl_status.Text = "ALL SERVICES ARE STARTED ...."; lbl_status.Refresh();

            this.Close();


        }
        class Services
        {
            public static void StartService(string serviceName, int timeoutMilliseconds)
            {
                ServiceController service = new ServiceController(serviceName);

                try
                {
                    TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);
                    if ((service.Status.Equals(ServiceControllerStatus.Stopped)) || (service.Status.Equals(ServiceControllerStatus.StopPending)))
                    {
                        service.Start();
                    }

                    service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                }
                catch (Exception ex)
                {
                  
                }

            }

            public static bool Servicestatus(string serviceName)
            {
                ServiceController service = new ServiceController(serviceName);

                try
                {
                    if ((service.Status.Equals(ServiceControllerStatus.Stopped)) || (service.Status.Equals(ServiceControllerStatus.StopPending)))
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

                return false;
            }
        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.Refresh();
            pictureBox1.Refresh();
        }
    }
}
