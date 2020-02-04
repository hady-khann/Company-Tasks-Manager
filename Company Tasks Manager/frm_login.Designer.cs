namespace Company_Tasks_Manager
{
    partial class frm_login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_login));
            this.txtb_username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtb_pw = new System.Windows.Forms.TextBox();
            this.btn_showpw = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radio_m = new System.Windows.Forms.RadioButton();
            this.radio_a = new System.Windows.Forms.RadioButton();
            this.radio_e = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtb_username
            // 
            this.txtb_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_username.Location = new System.Drawing.Point(198, 97);
            this.txtb_username.Name = "txtb_username";
            this.txtb_username.Size = new System.Drawing.Size(396, 53);
            this.txtb_username.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "نام کاربری";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(198, 281);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 57);
            this.button1.TabIndex = 2;
            this.button1.Text = "ورود";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 46);
            this.label2.TabIndex = 4;
            this.label2.Text = "گذر واژه";
            // 
            // txtb_pw
            // 
            this.txtb_pw.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_pw.Location = new System.Drawing.Point(198, 195);
            this.txtb_pw.Name = "txtb_pw";
            this.txtb_pw.PasswordChar = '*';
            this.txtb_pw.Size = new System.Drawing.Size(344, 53);
            this.txtb_pw.TabIndex = 3;
            this.txtb_pw.TextChanged += new System.EventHandler(this.txtb_pw_TextChanged);
            // 
            // btn_showpw
            // 
            this.btn_showpw.BackColor = System.Drawing.Color.Gray;
            this.btn_showpw.BackgroundImage = global::Company_Tasks_Manager.Properties.Resources.download1;
            this.btn_showpw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_showpw.Location = new System.Drawing.Point(540, 195);
            this.btn_showpw.Name = "btn_showpw";
            this.btn_showpw.Size = new System.Drawing.Size(54, 53);
            this.btn_showpw.TabIndex = 5;
            this.btn_showpw.UseVisualStyleBackColor = false;
            this.btn_showpw.Click += new System.EventHandler(this.btn_showpw_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(707, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 40);
            this.button3.TabIndex = 7;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(658, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 6;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radio_m);
            this.groupBox1.Controls.Add(this.radio_a);
            this.groupBox1.Controls.Add(this.radio_e);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(612, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(128, 151);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "نوع کاربری";
            // 
            // radio_m
            // 
            this.radio_m.AutoSize = true;
            this.radio_m.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_m.Location = new System.Drawing.Point(59, 79);
            this.radio_m.Name = "radio_m";
            this.radio_m.Size = new System.Drawing.Size(63, 29);
            this.radio_m.TabIndex = 8;
            this.radio_m.TabStop = true;
            this.radio_m.Text = "مدیر";
            this.radio_m.UseVisualStyleBackColor = true;
            // 
            // radio_a
            // 
            this.radio_a.AutoSize = true;
            this.radio_a.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_a.Location = new System.Drawing.Point(54, 113);
            this.radio_a.Name = "radio_a";
            this.radio_a.Size = new System.Drawing.Size(68, 29);
            this.radio_a.TabIndex = 10;
            this.radio_a.TabStop = true;
            this.radio_a.Text = "ادمین";
            this.radio_a.UseVisualStyleBackColor = true;
            // 
            // radio_e
            // 
            this.radio_e.AutoSize = true;
            this.radio_e.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_e.Location = new System.Drawing.Point(46, 44);
            this.radio_e.Name = "radio_e";
            this.radio_e.Size = new System.Drawing.Size(76, 29);
            this.radio_e.TabIndex = 9;
            this.radio_e.TabStop = true;
            this.radio_e.Text = "کارمند";
            this.radio_e.UseVisualStyleBackColor = true;
            // 
            // frm_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(759, 380);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_showpw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtb_pw);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtb_username);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frm_main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtb_username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtb_pw;
        private System.Windows.Forms.Button btn_showpw;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radio_m;
        private System.Windows.Forms.RadioButton radio_a;
        private System.Windows.Forms.RadioButton radio_e;
    }
}