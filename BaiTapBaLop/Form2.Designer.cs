namespace BaiTapBaLop
{
    partial class Form2
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cChon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cMSSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDTB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frmChuyenNganh = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbKhoa = new System.Windows.Forms.ComboBox();
            this.cmbNganh = new System.Windows.Forms.ComboBox();
            this.btnDangKi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cChon,
            this.cMSSV,
            this.cHoTen,
            this.cKhoa,
            this.cDTB});
            this.dataGridView1.Location = new System.Drawing.Point(36, 189);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(645, 269);
            this.dataGridView1.TabIndex = 0;
            // 
            // cChon
            // 
            this.cChon.HeaderText = "Chọn";
            this.cChon.Name = "cChon";
            this.cChon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cChon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cMSSV
            // 
            this.cMSSV.HeaderText = "MSSV";
            this.cMSSV.Name = "cMSSV";
            // 
            // cHoTen
            // 
            this.cHoTen.HeaderText = "Họ Tên";
            this.cHoTen.Name = "cHoTen";
            // 
            // cKhoa
            // 
            this.cKhoa.HeaderText = "Khoa";
            this.cKhoa.Name = "cKhoa";
            // 
            // cDTB
            // 
            this.cDTB.HeaderText = "DTB";
            this.cDTB.Name = "cDTB";
            // 
            // frmChuyenNganh
            // 
            this.frmChuyenNganh.AutoSize = true;
            this.frmChuyenNganh.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmChuyenNganh.Location = new System.Drawing.Point(229, 9);
            this.frmChuyenNganh.Name = "frmChuyenNganh";
            this.frmChuyenNganh.Size = new System.Drawing.Size(248, 29);
            this.frmChuyenNganh.TabIndex = 1;
            this.frmChuyenNganh.Text = "Đăng kí chuyên ngành";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Khoa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Chuyên ngành";
            // 
            // cmbKhoa
            // 
            this.cmbKhoa.FormattingEnabled = true;
            this.cmbKhoa.Location = new System.Drawing.Point(215, 75);
            this.cmbKhoa.Name = "cmbKhoa";
            this.cmbKhoa.Size = new System.Drawing.Size(262, 21);
            this.cmbKhoa.TabIndex = 4;
            this.cmbKhoa.SelectedIndexChanged += new System.EventHandler(this.cmbKhoa_SelectedIndexChanged);
            // 
            // cmbNganh
            // 
            this.cmbNganh.FormattingEnabled = true;
            this.cmbNganh.Location = new System.Drawing.Point(215, 121);
            this.cmbNganh.Name = "cmbNganh";
            this.cmbNganh.Size = new System.Drawing.Size(262, 21);
            this.cmbNganh.TabIndex = 5;
            // 
            // btnDangKi
            // 
            this.btnDangKi.Location = new System.Drawing.Point(606, 467);
            this.btnDangKi.Name = "btnDangKi";
            this.btnDangKi.Size = new System.Drawing.Size(75, 23);
            this.btnDangKi.TabIndex = 6;
            this.btnDangKi.Text = "Đăng kí";
            this.btnDangKi.UseVisualStyleBackColor = true;
            this.btnDangKi.Click += new System.EventHandler(this.btnDangKi_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 502);
            this.Controls.Add(this.btnDangKi);
            this.Controls.Add(this.cmbNganh);
            this.Controls.Add(this.cmbKhoa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.frmChuyenNganh);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form2";
            this.Text = "Đăng kí chuyên ngành";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label frmChuyenNganh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbKhoa;
        private System.Windows.Forms.ComboBox cmbNganh;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cChon;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMSSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn cKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDTB;
        private System.Windows.Forms.Button btnDangKi;
    }
}