namespace QuanlidiemTHPT
{
    partial class fLop
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
            this.buttonXoa = new System.Windows.Forms.Button();
            this.buttonSua = new System.Windows.Forms.Button();
            this.dataGridViewLop = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textLop_Ten = new System.Windows.Forms.TextBox();
            this.textLop_Ma = new System.Windows.Forms.TextBox();
            this.comboboxKhoi = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxNamhoc = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonThem = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Lop_Ma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lop_Ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Khoi_Ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NH_Ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLop)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonXoa
            // 
            this.buttonXoa.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonXoa.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonXoa.Location = new System.Drawing.Point(205, 26);
            this.buttonXoa.Name = "buttonXoa";
            this.buttonXoa.Size = new System.Drawing.Size(87, 41);
            this.buttonXoa.TabIndex = 18;
            this.buttonXoa.Text = "Xóa";
            this.buttonXoa.UseVisualStyleBackColor = false;
            this.buttonXoa.Click += new System.EventHandler(this.buttonXoa_Click);
            // 
            // buttonSua
            // 
            this.buttonSua.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonSua.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSua.Location = new System.Drawing.Point(111, 26);
            this.buttonSua.Name = "buttonSua";
            this.buttonSua.Size = new System.Drawing.Size(87, 41);
            this.buttonSua.TabIndex = 19;
            this.buttonSua.Text = "Sửa";
            this.buttonSua.UseVisualStyleBackColor = false;
            this.buttonSua.Click += new System.EventHandler(this.buttonSua_Click);
            // 
            // dataGridViewLop
            // 
            this.dataGridViewLop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLop.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewLop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLop.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Lop_Ma,
            this.Lop_Ten,
            this.Khoi_Ten,
            this.NH_Ten});
            this.dataGridViewLop.Location = new System.Drawing.Point(6, 26);
            this.dataGridViewLop.Name = "dataGridViewLop";
            this.dataGridViewLop.Size = new System.Drawing.Size(583, 283);
            this.dataGridViewLop.TabIndex = 14;
            this.dataGridViewLop.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLop_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tên Lớp:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "Mã Lớp:";
            // 
            // textLop_Ten
            // 
            this.textLop_Ten.Location = new System.Drawing.Point(94, 137);
            this.textLop_Ten.Name = "textLop_Ten";
            this.textLop_Ten.Size = new System.Drawing.Size(186, 23);
            this.textLop_Ten.TabIndex = 11;
            // 
            // textLop_Ma
            // 
            this.textLop_Ma.Location = new System.Drawing.Point(94, 104);
            this.textLop_Ma.Name = "textLop_Ma";
            this.textLop_Ma.Size = new System.Drawing.Size(186, 23);
            this.textLop_Ma.TabIndex = 10;
            // 
            // comboboxKhoi
            // 
            this.comboboxKhoi.BackColor = System.Drawing.SystemColors.Window;
            this.comboboxKhoi.FormattingEnabled = true;
            this.comboboxKhoi.Location = new System.Drawing.Point(94, 59);
            this.comboboxKhoi.Name = "comboboxKhoi";
            this.comboboxKhoi.Size = new System.Drawing.Size(186, 25);
            this.comboboxKhoi.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 19);
            this.label3.TabIndex = 22;
            this.label3.Text = "Khối: ";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox1.Controls.Add(this.comboBoxNamhoc);
            this.groupBox1.Controls.Add(this.comboboxKhoi);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textLop_Ma);
            this.groupBox1.Controls.Add(this.textLop_Ten);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 190);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // comboBoxNamhoc
            // 
            this.comboBoxNamhoc.FormattingEnabled = true;
            this.comboBoxNamhoc.Location = new System.Drawing.Point(94, 26);
            this.comboBoxNamhoc.Name = "comboBoxNamhoc";
            this.comboBoxNamhoc.Size = new System.Drawing.Size(186, 25);
            this.comboBoxNamhoc.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 19);
            this.label5.TabIndex = 22;
            this.label5.Text = "Năm học:";
            // 
            // buttonThem
            // 
            this.buttonThem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonThem.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonThem.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonThem.ImageKey = "(none)";
            this.buttonThem.Location = new System.Drawing.Point(28, 26);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonThem.Size = new System.Drawing.Size(76, 41);
            this.buttonThem.TabIndex = 20;
            this.buttonThem.Text = "Thêm ";
            this.buttonThem.UseVisualStyleBackColor = false;
            this.buttonThem.Click += new System.EventHandler(this.buttonThem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox3.Controls.Add(this.dataGridViewLop);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(326, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(595, 315);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox4.Controls.Add(this.buttonXoa);
            this.groupBox4.Controls.Add(this.buttonThem);
            this.groupBox4.Controls.Add(this.buttonSua);
            this.groupBox4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 208);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(308, 87);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thao tác";
            // 
            // Lop_Ma
            // 
            this.Lop_Ma.DataPropertyName = "Lop_Ma";
            this.Lop_Ma.HeaderText = "Mã Lớp";
            this.Lop_Ma.Name = "Lop_Ma";
            // 
            // Lop_Ten
            // 
            this.Lop_Ten.DataPropertyName = "Lop_Ten";
            this.Lop_Ten.HeaderText = "Tên Lớp";
            this.Lop_Ten.Name = "Lop_Ten";
            // 
            // Khoi_Ten
            // 
            this.Khoi_Ten.DataPropertyName = "Khoi_Ten";
            this.Khoi_Ten.HeaderText = "Khối";
            this.Khoi_Ten.Name = "Khoi_Ten";
            // 
            // NH_Ten
            // 
            this.NH_Ten.DataPropertyName = "NH_Ten";
            this.NH_Ten.HeaderText = "Năm Học";
            this.NH_Ten.Name = "NH_Ten";
            // 
            // fLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(933, 340);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "fLop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lí lớp";
            this.Load += new System.EventHandler(this.fLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLop)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonXoa;
        private System.Windows.Forms.Button buttonSua;
        private System.Windows.Forms.Button buttonThem;
        private System.Windows.Forms.DataGridView dataGridViewLop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textLop_Ten;
        private System.Windows.Forms.TextBox textLop_Ma;
        private System.Windows.Forms.ComboBox comboboxKhoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxNamhoc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lop_Ma;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lop_Ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn Khoi_Ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn NH_Ten;
    }
}