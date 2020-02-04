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
    public partial class frm_admin : Form
    {
        public frm_admin()
        {
            InitializeComponent();
        }
        db_Task_ManagerEntities dbmanager = new db_Task_ManagerEntities();
        private void frm_admin_Load(object sender, EventArgs e)
        {
            try
            {
                dgv1.DataSource = dbmanager.tbl_admins.SqlQuery("select * from tbl_admins order by l_name , f_name ").ToList();
                dgv2.DataSource = dbmanager.tbl_managers.SqlQuery("select * from tbl_managers order by l_name , f_name ").ToList();
                dgv3.DataSource = dbmanager.tbl_employeis.SqlQuery("select * from tbl_employeis order by l_name , f_name ").ToList();


                dgv1.Columns[0].HeaderText = "ID";
                dgv1.Columns[1].HeaderText = "نام";
                dgv1.Columns[2].HeaderText = "نام خانوادگی";
                dgv1.Columns[3].HeaderText = "نام کاربری";
                dgv1.Columns[4].HeaderText = "رمز عبور";

                dgv2.Columns[0].HeaderText = "ID";
                dgv2.Columns[1].HeaderText = "نام";
                dgv2.Columns[2].HeaderText = "نام خانوادگی";
                dgv2.Columns[3].HeaderText = "نام کاربری";
                dgv2.Columns[4].HeaderText = "رمز عبور";

                dgv3.Columns[0].HeaderText = "ID";
                dgv3.Columns[1].HeaderText = "نام";
                dgv3.Columns[2].HeaderText = "نام خانوادگی";
                dgv3.Columns[3].HeaderText = "نام کاربری";
                dgv3.Columns[4].HeaderText = "رمز عبور";

            }
            catch (Exception)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView3_Click(object sender, EventArgs e)
        {

        }

        private void dgv_Click(object sender, EventArgs e)
        {
            try
            {
                int row = 0;
                row = int.Parse(dgv3.SelectedCells[0].Value.ToString());

                tbl_employeis tble = dbmanager.tbl_employeis.FirstOrDefault(x => x.id == row);

                txt_fname3.Text = tble.f_name;
                txt_lname3.Text = tble.l_name;
                txt_us3.Text = tble.username;
                txt_pw3.Text = tble.password;
                lbl_id3.Text = "کد کاربری :  " + tble.id.ToString();
                lbl_fname3.Text = "نام :  " + tble.f_name;
                lbl_lname3.Text = "نام خانواگی :  " + tble.l_name;

            }
            catch (Exception)
            {
            }
        }

        private string hash(string pass)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(pass, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txt_fname3.Text.Length >= 3 && txt_lname3.Text.Length >= 5 && txt_pw3.Text.Length >= 10 && txt_us3.Text.Length >= 7)
                //{
                tbl_employeis tble = new tbl_employeis();
                tbl_employeis tble2 = new tbl_employeis();
                tble2 = dbmanager.tbl_employeis.FirstOrDefault(x => x.username == txt_us3.Text);

                if (tble2 != null)
                {
                    MessageBox.Show("نام کاربری در سیستم موجود است . لطفا نام دیگری انتخاب کنید");
                }
                else
                {
                    tble.f_name = txt_fname3.Text;
                    tble.l_name = txt_lname3.Text;
                    tble.username = txt_us3.Text;
                    tble.password = hash(txt_pw3.Text);
                    dbmanager.tbl_employeis.Add(tble);
                    dbmanager.SaveChanges();
                }

                dgv3.DataSource = dbmanager.tbl_employeis.SqlQuery("select * from tbl_employeis order by l_name , f_name ").ToList();
                //}
                //else
                //{
                //    MessageBox.Show("نام باید حداقل 3 حرف نام خانوادگی حداقل 5 حرف و نام کاربری باید حداقل 7 و رمز عبور حداقل 10 حرف باشد");
                //}
            }
            catch (Exception)
            {
                MessageBox.Show("لطفا برای اضافه کردن کارمند جدید تمام مقادیر را وارد کنید  ");
            }

        }

        private void btn_add2_Click(object sender, EventArgs e)
        {

            try
            {
                //if (txt_fname2.Text.Length >= 3 && txt_lname2.Text.Length >= 5 && txt_pw2.Text.Length >= 10 && txt_us2.Text.Length >= 7)
                //{

                tbl_managers tblm = new tbl_managers();
                tbl_managers tblm2 = new tbl_managers();
                tblm2 = dbmanager.tbl_managers.FirstOrDefault(x => x.username == txt_us2.Text);

                if (tblm2 != null)
                {
                    MessageBox.Show("نام کاربری در سیستم موجود است . لطفا نام دیگری انتخاب کنید");
                }
                else
                {
                    tblm.f_name = txt_fname2.Text;
                    tblm.l_name = txt_lname2.Text;
                    tblm.username = txt_us2.Text;
                    tblm.password = hash(txt_pw2.Text);
                    dbmanager.tbl_managers.Add(tblm);
                    dbmanager.SaveChanges();
                }

                dgv2.DataSource = dbmanager.tbl_managers.SqlQuery("select * from tbl_managers order by l_name , f_name ").ToList();
                ////}
                ///      //else
                //{
                //    MessageBox.Show("نام باید حداقل 3 حرف نام خانوادگی حداقل 5 حرف و نام کاربری باید حداقل 7 و رمز عبور حداقل 10 حرف باشد");
                //}
            }
            catch (Exception)
            {
                MessageBox.Show("لطفا برای اضافه کردن کارمند جدید تمام مقادیر را وارد کنید  ");
            }

        }

        private void btn_add1_Click(object sender, EventArgs e)
        {

            try
            {
                //if (txt_fname1.Text.Length >= 3 && txt_lname1.Text.Length >= 5 && txt_pw1.Text.Length >= 10 && txt_us1.Text.Length >= 7)
                //{
                tbl_admins tbla = new tbl_admins();
                tbl_admins tbla2 = new tbl_admins();
                tbla2 = dbmanager.tbl_admins.FirstOrDefault(x => x.username == txt_us1.Text);

                if (tbla2 != null)
                {
                    MessageBox.Show("نام کاربری در سیستم موجود است . لطفا نام دیگری انتخاب کنید");
                }
                else
                {
                    tbla.f_name = txt_fname1.Text;
                    tbla.l_name = txt_lname1.Text;
                    tbla.username = txt_us1.Text;
                    tbla.password = hash(txt_pw1.Text);
                    dbmanager.tbl_admins.Add(tbla);
                    dbmanager.SaveChanges();
                }

                dgv1.DataSource = dbmanager.tbl_admins.SqlQuery("select * from tbl_admins order by l_name , f_name ").ToList();
                //}
                //else
                //{
                //    MessageBox.Show("نام باید حداقل 3 حرف نام خانوادگی حداقل 5 حرف و نام کاربری باید حداقل 7 و رمز عبور حداقل 10 حرف باشد");
                //}
            }
            catch (Exception)
            {
                MessageBox.Show("لطفا برای اضافه کردن کارمند جدید تمام مقادیر را وارد کنید  ");
            }

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txt_fname3.Text.Length >= 3 && txt_lname3.Text.Length >= 5 && txt_pw3.Text.Length >= 10 && txt_us3.Text.Length >= 7)
                //{
                int id = int.Parse(dgv3.SelectedCells[0].Value.ToString());
                tbl_employeis tble = new tbl_employeis();

                tble = dbmanager.tbl_employeis.FirstOrDefault(x => x.id == id);
                tble.f_name = txt_fname3.Text;
                tble.l_name = txt_lname3.Text;
                tble.username = txt_us3.Text;
                tble.password = hash(txt_pw3.Text);
                dbmanager.SaveChanges();

                dgv3.DataSource = dbmanager.tbl_employeis.SqlQuery("select * from tbl_employeis order by l_name , f_name ").ToList();
                //}
                //else
                //{
                //    MessageBox.Show("نام باید حداقل 3 حرف نام خانوادگی حداقل 5 حرف و نام کاربری باید حداقل 7 و رمز عبور حداقل 10 حرف باشد");
                //}
            }
            catch (Exception)
            {
            }
        }

        private void btn_up1_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txt_fname1.Text.Length >= 3 && txt_lname1.Text.Length >= 5 && txt_pw1.Text.Length >= 10 && txt_us1.Text.Length >= 7)
                //{
                int id = int.Parse(dgv1.SelectedCells[0].Value.ToString());
                tbl_admins tbla = new tbl_admins();

                tbla = dbmanager.tbl_admins.FirstOrDefault(x => x.id == id);
                tbla.f_name = txt_fname1.Text;
                tbla.l_name = txt_lname1.Text;
                tbla.username = txt_us1.Text;
                tbla.password = hash(txt_pw1.Text);
                dbmanager.SaveChanges();

                dgv1.DataSource = dbmanager.tbl_admins.SqlQuery("select * from tbl_admins order by l_name , f_name ").ToList();
                //}
                //else
                //{
                //    MessageBox.Show("نام باید حداقل 3 حرف نام خانوادگی حداقل 5 حرف و نام کاربری باید حداقل 7 و رمز عبور حداقل 10 حرف باشد");
                //}
            }
            catch (Exception)
            {
            }
        }


        private void btn_up2_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txt_fname2.Text.Length >= 3 && txt_lname2.Text.Length >= 5 && txt_pw2.Text.Length >= 10 && txt_us2.Text.Length >= 7)
                //{
                int id = int.Parse(dgv2.SelectedCells[0].Value.ToString());
                tbl_managers tblm = new tbl_managers();

                tblm = dbmanager.tbl_managers.FirstOrDefault(x => x.id == id);
                tblm.f_name = txt_fname2.Text;
                tblm.l_name = txt_lname2.Text;
                tblm.username = txt_us2.Text;
                tblm.password = hash(txt_pw2.Text);
                dbmanager.SaveChanges();

                dgv2.DataSource = dbmanager.tbl_managers.SqlQuery("select * from tbl_managers order by l_name , f_name ").ToList();
                //}
                //else
                //{
                //    MessageBox.Show("نام باید حداقل 3 حرف نام خانوادگی حداقل 5 حرف و نام کاربری باید حداقل 7 و رمز عبور حداقل 10 حرف باشد");
                //}
            }
            catch (Exception)
            {
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            try
            {
                int row = int.Parse(dgv3.SelectedCells[0].Value.ToString());
                tbl_employeis tble = dbmanager.tbl_employeis.FirstOrDefault(x => x.id == row);


                string mtemp = string.Format("  آیا مایل به حذف id : {0} با نام : {1} و نام خانوادگی : {2} هستید ؟؟", tble.id, tble.f_name, tble.l_name);
                DialogResult dres = MessageBox.Show(mtemp, "هشدار حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dres == DialogResult.Yes)
                {
                    dbmanager.tbl_employeis.Remove(tble);
                    dbmanager.SaveChanges();
                    dgv3.Refresh();
                    dgv3.DataSource = dbmanager.tbl_employeis.SqlQuery("select * from tbl_employeis order by l_name , f_name ").ToList();
                    dgv3.Refresh();


                }


            }
            catch (Exception)
            {
            }
        }


        private void btn_del1_Click(object sender, EventArgs e)
        {
            try
            {
                int row = int.Parse(dgv1.SelectedCells[0].Value.ToString());
                tbl_admins tbla = dbmanager.tbl_admins.FirstOrDefault(x => x.id == row);


                string mtemp = string.Format("  آیا مایل به حذف id : {0} با نام : {1} و نام خانوادگی : {2} هستید ؟؟", tbla.id, tbla.f_name, tbla.l_name);
                DialogResult dres = MessageBox.Show(mtemp, "هشدار حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dres == DialogResult.Yes)
                {
                    dbmanager.tbl_admins.Remove(tbla);
                    dbmanager.SaveChanges();
                    dgv1.Refresh();
                    dgv1.DataSource = dbmanager.tbl_admins.SqlQuery("select * from tbl_admins order by l_name , f_name ").ToList();
                }

            }
            catch (Exception)
            {
            }
        }


        private void btn_del2_Click(object sender, EventArgs e)
        {
            try
            {
                int row = int.Parse(dgv2.SelectedCells[0].Value.ToString());
                tbl_managers tblm = dbmanager.tbl_managers.FirstOrDefault(x => x.id == row);


                string mtemp = string.Format("  آیا مایل به حذف id : {0} با نام : {1} و نام خانوادگی : {2} هستید ؟؟", tblm.id, tblm.f_name, tblm.l_name);
                DialogResult dres = MessageBox.Show(mtemp, "هشدار حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dres == DialogResult.Yes)
                {
                    dbmanager.tbl_managers.Remove(tblm);
                    dbmanager.SaveChanges();
                    dgv2.Refresh();
                    dgv2.DataSource = dbmanager.tbl_managers.SqlQuery("select * from tbl_managers order by l_name , f_name ").ToList();
                }

            }
            catch (Exception)
            {
            }
        }







        private void dgv2_Click(object sender, EventArgs e)
        {
            try
            {
                int row = 0;
                row = int.Parse(dgv2.SelectedCells[0].Value.ToString());

                tbl_managers tblm = dbmanager.tbl_managers.FirstOrDefault(x => x.id == row);

                txt_fname2.Text = tblm.f_name;
                txt_lname2.Text = tblm.l_name;
                txt_us2.Text = tblm.username;
                txt_pw2.Text = tblm.password;
                lbl_id2.Text = "کد کاربری :  " + tblm.id.ToString();
                lbl_fname2.Text = "نام :  " + tblm.f_name;
                lbl_lname2.Text = "نام خانواگی :  " + tblm.l_name;

            }
            catch (Exception)
            {
            }
        }

        private void dgv1_Click(object sender, EventArgs e)
        {
            try
            {
                int row = int.Parse(dgv1.SelectedCells[0].Value.ToString());

                tbl_admins tbla = dbmanager.tbl_admins.FirstOrDefault(x => x.id == row);

                txt_fname1.Text = tbla.f_name;
                txt_lname1.Text = tbla.l_name;
                txt_us1.Text = tbla.username;
                txt_pw1.Text = tbla.password;
                lbl_id1.Text = "کد کاربری :  " + tbla.id.ToString();
                lbl_fname1.Text = "نام :  " + tbla.f_name;
                lbl_lname1.Text = "نام خانواگی :  " + tbla.l_name;

            }
            catch (Exception)
            {
            }
        }

        private void tab1_TabIndexChanged(object sender, EventArgs e)
        {
            dgv1.DataSource = dbmanager.tbl_admins.SqlQuery("select * from tbl_admins order by l_name , f_name ").ToList();
            dgv2.DataSource = dbmanager.tbl_managers.SqlQuery("select * from tbl_managers order by l_name , f_name ").ToList();
            dgv3.DataSource = dbmanager.tbl_employeis.SqlQuery("select * from tbl_employeis order by l_name , f_name ").ToList();
        }

        private void dgv3_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    btn_del3.PerformClick();
                }
            }
            catch (Exception)
            {
            }
        }

        private void dgv2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    btn_del2.PerformClick();
                }
            }
            catch (Exception)
            {
            }
        }

        private void dgv1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    btn_del1.PerformClick();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
