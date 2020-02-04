using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Company_Tasks_Manager
{
    public partial class frm_Manager : Form
    {
        public frm_Manager()
        {
            InitializeComponent();
        }
        db_Task_ManagerEntities dbmanager = new db_Task_ManagerEntities();
        int userid = Properties.Settings.Default.managerid;
        private void frm_Manager_Load(object sender, EventArgs e)
        {
            dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.e_status == "جدید" && x.mid == userid).OrderBy(o => o.title).ToList();
            dgv2.DataSource = dbmanager.tbl_employeis.SqlQuery("select * from tbl_employeis order by l_name , f_name ").ToList();

            dgv1.Columns[0].Visible=false;
            dgv1.Columns[1].Visible = false;
            dgv1.Columns[2].Visible = false;
            dgv1.Columns[3].HeaderText = "کارفرما";
            dgv1.Columns[4].HeaderText = "نام کارمند";
            dgv1.Columns[5].HeaderText = "نام خانوادگی کارمند";
            dgv1.Columns[6].HeaderText = "عنوان";
            dgv1.Columns[7].HeaderText = "پیشرفت";
            dgv1.Columns[8].HeaderText = "وضعیت کارفرما";
            dgv1.Columns[9].HeaderText = "وضعیت کارمند";
            dgv1.Columns[10].HeaderText = "توضیحات";

            dgv2.Columns[0].Visible = false;
            dgv2.Columns[1].HeaderText = "نام";
            dgv2.Columns[2].HeaderText = "نام خانوادگی";
            dgv2.Columns[3].Visible = false;
            dgv2.Columns[4].Visible = false;
        }

        private void txt_search_lname_TextChanged(object sender, EventArgs e)
        {

            if (txt_search_lname.Text != "" || txt_search_lname.Text != " ")
                dgv2.DataSource = dbmanager.tbl_employeis.Where(x => x.l_name.Contains(txt_search_lname.Text)).ToList();
            if (txt_search_lname.Text == "" || txt_search_lname.Text == " ")
                dgv2.DataSource = dbmanager.tbl_employeis.SqlQuery("select * from tbl_employeis order by l_name , f_name ").ToList();
            else
                dgv2.DataSource = dbmanager.tbl_employeis.Where(x => x.l_name.Contains(txt_search_lname.Text)).ToList();
        }

        private void txt_search_title_TextChanged(object sender, EventArgs e)
        {

            dgv1.Refresh();
            if (txt_search_title.Text == "" || txt_search_title.Text == " ")
                dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.e_status == "جدید" && x.mid == userid).OrderBy(o => o.title).ToList();
            else
                dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.e_status == "جدید" && x.mid == userid).OrderBy(o => o.title).ToList();
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

        private void dgv1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dgv1.SelectedCells[0].Value.ToString());

                tbl_tasks tblt = dbmanager.tbl_tasks.FirstOrDefault(x => x.id == id);

                txt_title.Text = tblt.title;
                txt_efname.Text = tblt.employeef_name;
                txt_elname.Text = tblt.employeel_name;
                rtxt.Text = tblt.explanation;

            }
            catch (Exception)
            {
            }
        }

        private void dgv2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dgv2.SelectedCells[0].Value.ToString());
                tbl_employeis tble = dbmanager.tbl_employeis.FirstOrDefault(x => x.id == id);

                Properties.Settings.Default.eid = id;
                Properties.Settings.Default.Save();

                txt_efname.Text = tble.f_name;
                txt_elname.Text = tble.l_name;
            }
            catch (Exception)
            {
            }
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {

            try
            {
                tbl_tasks tblt = new tbl_tasks();
                tbl_tasks tblt2 = dbmanager.tbl_tasks.FirstOrDefault(x => x.title == txt_title.Text);
                tbl_managers tblm = dbmanager.tbl_managers.FirstOrDefault(x => x.id == Properties.Settings.Default.managerid);

                if (tblt2 != null)
                {
                    MessageBox.Show("عنوان مورد نظر از قبل در سیستم موجود است . لطفا در عنوان مورد نظر بازنگری شود");
                }
                else if (Properties.Settings.Default.eid  != Convert.ToInt32(dgv2.SelectedCells[0].Value.ToString()))
                {
                    MessageBox.Show("لطفا به روی کارمند مورد نظر کلیک کنید");
                }
                else
                {
                    string temp = tblm.f_name + "  |  " + tblm.l_name;

                    tblt.title = txt_title.Text;
                    tblt.employeel_name = txt_elname.Text;
                    tblt.employeef_name = txt_efname.Text;
                    tblt.explanation = rtxt.Text.ToString();
                    tblt.mid = Properties.Settings.Default.managerid;
                    tblt.eid = Convert.ToInt32(dgv2.SelectedCells[0].Value.ToString());
                    tblt.progress = "0%";
                    tblt.e_status = "جدید";
                    tblt.m_status = "در حال انتظار";
                    tblt.manager = temp;



                    dbmanager.tbl_tasks.Add(tblt);
                    dbmanager.SaveChanges();

                }

                dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.e_status == "جدید" && x.mid == userid).OrderBy(o => o.title).ToList();
            }
            catch (Exception)
            {

                MessageBox.Show("لطفا برای اضافه کردن وظیفه جدید تمام مقادیر را وارد کنید  ");
            }

        }

        private void btn_del1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dgv1.SelectedCells[0].Value.ToString());
                tbl_tasks tblt = dbmanager.tbl_tasks.FirstOrDefault(x => x.id == id);


                string mtemp = string.Format("  آیا مایل به حذف وظیفه با " + "id : {0} " + "با نام : {1} و نام خانوادگی : {2} هستید ؟؟", tblt.id, tblt.title, tblt.employeel_name);
                DialogResult dres = MessageBox.Show(mtemp, "هشدار حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dres == DialogResult.Yes)
                {
                    dbmanager.tbl_tasks.Remove(tblt);
                    dbmanager.SaveChanges();
                    dgv1.Refresh();
                    dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.e_status == "جدید" && x.mid == userid).OrderBy(o => o.title).ToList();
                }

            }
            catch (Exception)
            {
            }
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dgv1.SelectedCells[0].Value.ToString());
                tbl_tasks tblt = new tbl_tasks();
                tblt = dbmanager.tbl_tasks.FirstOrDefault(x => x.id == id);

                tblt.eid = Properties.Settings.Default.eid;
                tblt.title = txt_title.Text;
                tblt.employeef_name = txt_elname.Text;
                tblt.employeef_name = txt_efname.Text;
                tblt.explanation = rtxt.Text;
                tblt.e_status = "جدید";
                dbmanager.SaveChanges();

                dgv1.Refresh();
                if (comboBox1.Text == "وظایف جدید")
                    dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.e_status == "جدید" && x.mid == userid).OrderBy(o => o.title).ToList();
                if (comboBox1.Text == "وظایف در حال انجام")
                    dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.e_status == "در حال انجام" && x.mid == userid).OrderBy(o => o.title).ToList();
                if (comboBox1.Text == "وظایف تمام شده")
                    dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.e_status == "تمام شده" && x.mid == userid).OrderBy(o => o.title).ToList();
            }
            catch (Exception)
            {
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "وظایف جدید")
                dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.e_status == "جدید" && x.mid == userid).OrderBy(o => o.title).ToList();
            if (comboBox1.Text == "وظایف در حال انجام")
                dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.e_status == "در حال انجام" && x.mid == userid).OrderBy(o => o.title).ToList();
            if (comboBox1.Text == "وظایف تمام شده")
                dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.e_status == "تمام شده" && x.mid == userid).OrderBy(o => o.title).ToList();
        }

        private void txt_search_lname2_TextChanged(object sender, EventArgs e)
        {

            if (txt_search_lname2.Text != "" || txt_search_lname2.Text != " ")
                dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.employeel_name.Contains(txt_search_lname2.Text)).ToList();
            else if (txt_search_lname2.Text == "" || txt_search_lname2.Text == " ")
                dgv1.DataSource = dbmanager.tbl_tasks.SqlQuery("select * from tbl_tasks order by employeel_name , employeef_name ").ToList();
            else
                dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.employeel_name.Contains(txt_search_lname2.Text)).ToList();
        }
    }
}
