using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Company_Tasks_Manager
{
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
        }
        db_Task_ManagerEntities dbmanager = new db_Task_ManagerEntities();
        private void frm_main_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
        }
        bool showpw = false;
        private void btn_showpw_Click(object sender, EventArgs e)
        {
            if (showpw)
            {
                showpw = false;
                btn_showpw.BackgroundImage = Properties.Resources.download__1_;
                btn_showpw.BackColor = Color.Blue;
                txtb_pw.PasswordChar = '\0';

            }
            else
            {
                showpw = true;
                btn_showpw.BackgroundImage = Properties.Resources.download1;
                txtb_pw.PasswordChar = '*';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private bool authorization(string savedPasswordHash)
        {
            bool x = false;
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(txtb_pw.Text, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    x = false;
                }
                else
                {
                    x = true;
                }
            }
            return x;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txtb_pw.Text.Length>=10 && txtb_username.Text.Length>=7)
                //{
                    if (radio_e.Checked == true)
                    {
                        tbl_employeis tble = dbmanager.tbl_employeis.FirstOrDefault(x => x.username.Trim().ToLower() == txtb_username.Text.Trim().ToLower());

                        if (tble != null && authorization(tble.password))
                        {
                            Properties.Settings.Default.emploeeid = Convert.ToInt32(tble.id);
                            Properties.Settings.Default.Save();
                            frm_employee frme = new frm_employee();
                            frme.Show();
                            this.Visible = false;
                            this.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("نام کاربری یا رمز عبور صحیح نیست");
                        }
                    }
                    else if (radio_m.Checked == true)
                    {
                        tbl_managers tblm = dbmanager.tbl_managers.FirstOrDefault(x => x.username.Trim().ToLower() == txtb_username.Text.Trim().ToLower());

                        if (tblm != null && authorization(tblm.password))
                        {
                            Properties.Settings.Default.managerid = Convert.ToInt32(tblm.id);
                            Properties.Settings.Default.Save();
                            frm_Manager frmm = new frm_Manager();
                            frmm.Show();
                            this.Visible = false;
                            this.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("نام کاربری یا رمز عبور صحیح نیست");
                        }
                    }
                    else if (radio_a.Checked == true)
                    {
                        tbl_admins tbla = dbmanager.tbl_admins.FirstOrDefault(x => x.username.Trim().ToLower() == txtb_username.Text.Trim().ToLower());

                        if (tbla != null && authorization(tbla.password))
                        {
                            frm_admin frma = new frm_admin();
                            frma.Show();
                            this.Visible = false;
                            this.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("نام کاربری یا رمز عبور صحیح نیست");
                        }
                    }
                    else
                    {
                        MessageBox.Show("لطفا نوع کاربری خود را مشخص کنید");
                    }

                //}
                //else
                //{
                //    MessageBox.Show("نام کاربری باید حداقل 7 و رمز عبور حداقل 10 حرف باشد");
                //}
            }
            catch (Exception)
            {
            }
        }

        private void txtb_pw_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
