using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Company_Tasks_Manager
{
    public partial class frm_employee : Form
    {
        public frm_employee()
        {
            InitializeComponent();
        }

        db_Task_ManagerEntities dbmanager = new db_Task_ManagerEntities();
        int userid = Properties.Settings.Default.emploeeid;
        private void frm_employee_Load(object sender, EventArgs e)
        {
            dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.eid == userid).OrderBy(o => o.title).ToList();
            dgv1.Columns[0].Visible = false;
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
        }

        private void dgv1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dgv1.SelectedCells[0].Value.ToString());
                tbl_tasks tblt = dbmanager.tbl_tasks.FirstOrDefault(x => x.id == id);
                txt_title.Text = tblt.title;
                richTextBox1.Text = tblt.explanation;
            }
            catch (Exception)
            {
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "وظایف جدید")
                dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.e_status == "جدید" && x.eid == userid).OrderBy(o => o.title).ToList();
            else if (comboBox1.Text == "وظایف در حال انجام")
                dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.e_status == "در حال انجام" && x.eid == userid).OrderBy(o => o.title).ToList();
            else if (comboBox1.Text == "وظایف تمام شده")
                dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.e_status == "تمام شده" && x.eid == userid).OrderBy(o => o.title).ToList();
            else
                dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.eid == userid).OrderBy(o => o.title).ToList();
        }

        private void txt_search_title_TextChanged(object sender, EventArgs e)
        {
            dgv1.Refresh();
            if (comboBox1.Text == "وظایف جدید")
                dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.title.Contains(txt_search_title.Text) && x.e_status == "جدید" && x.eid == userid).OrderBy(o => o.title).ToList();
            if (comboBox1.Text == "وظایف در حال انجام")
                dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.title.Contains(txt_search_title.Text) && x.e_status == "در حال انجام" && x.eid == userid).OrderBy(o => o.title).ToList();
            if (comboBox1.Text == "وظایف تمام شده")
                dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.title.Contains(txt_search_title.Text) && x.e_status == "تمام شده" && x.eid == userid).OrderBy(o => o.title).ToList();
            if (txt_search_title.Text == "" || txt_search_title.Text == " ")
                dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.e_status == "جدید" && x.eid == userid).OrderBy(o => o.title).ToList();
            else
                dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.title.Contains(txt_search_title.Text) && x.eid == userid).OrderBy(o => o.title).ToList();

        }

        private void btn_start_tsk_Click(object sender, EventArgs e)
        {

            try
            {
                int id = int.Parse(dgv1.SelectedCells[0].Value.ToString());
                tbl_tasks tblt = new tbl_tasks();
                tblt = dbmanager.tbl_tasks.FirstOrDefault(x => x.id == id);

                tblt.e_status = "در حال انجام";
                dbmanager.SaveChanges();

                dgv1.Refresh();
                if (comboBox1.Text == "وظایف جدید")
                    dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.e_status == "جدید" && x.eid == userid).OrderBy(o => o.title).ToList();
                if (comboBox1.Text == "وظایف در حال انجام")
                    dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.e_status == "در حال انجام" && x.eid == userid).OrderBy(o => o.title).ToList();
                if (comboBox1.Text == "وظایف تمام شده")
                    dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.e_status == "تمام شده" && x.eid == userid).OrderBy(o => o.title).ToList();
                else
                    dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.title.Contains(txt_search_title.Text) && x.eid == userid).OrderBy(o => o.title).ToList();
            }
            catch (Exception)
            {
            }
        }

        private void btn_end_tsk_Click(object sender, EventArgs e)
        {

            try
            {
                int id = int.Parse(dgv1.SelectedCells[0].Value.ToString());
                tbl_tasks tblt = new tbl_tasks();
                tblt = dbmanager.tbl_tasks.FirstOrDefault(x => x.id == id);

                tblt.e_status = "تمام شده";
                tblt.progress = "100%";

                dbmanager.SaveChanges();

                dgv1.Refresh();
                if (comboBox1.Text == "وظایف جدید")
                    dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.e_status == "جدید" && x.eid == userid).OrderBy(o => o.title).ToList();
                if (comboBox1.Text == "وظایف در حال انجام")
                    dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.e_status == "در حال انجام" && x.eid == userid).OrderBy(o => o.title).ToList();
                if (comboBox1.Text == "وظایف تمام شده")
                    dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.e_status == "تمام شده" && x.eid == userid).OrderBy(o => o.title).ToList();
                else
                    dgv1.DataSource = dbmanager.tbl_tasks.Where(x => x.title.Contains(txt_search_title.Text) && x.eid == userid).OrderBy(o => o.title).ToList();
            }
            catch (Exception)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgv1.SelectedCells[0].Value.ToString());
                tbl_tasks tblt = dbmanager.tbl_tasks.FirstOrDefault(x => x.id == id);
                if (tblt.e_status== "در حال انجام")
                {
                    if (combo_progress.Text != "" || combo_progress.Text != " " || combo_progress.Text != null)
                    {
                        tblt.progress = combo_progress.Text;
                    }
                    else
                    {
                        MessageBox.Show("لطفا میزان پیشرفت خود را مشخص کنید");
                    }
                    dgv1.Refresh();
                }
                else if (tblt.e_status=="جدید")
                {
                    MessageBox.Show("ابتدا وظیفه را شروع کنید");
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
