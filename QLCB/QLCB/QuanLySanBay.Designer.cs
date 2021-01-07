namespace QLCB
{
    partial class QuanLySanBay
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDSSanBay = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonThoat = new System.Windows.Forms.Button();
            this.buttonSua = new System.Windows.Forms.Button();
            this.buttonXoa = new System.Windows.Forms.Button();
            this.buttonThem = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenSanBay = new System.Windows.Forms.TextBox();
            this.txtMaSanBay = new System.Windows.Forms.TextBox();
            this.txtTim = new System.Windows.Forms.RichTextBox();
            this.buttonTim = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSanBay)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(114, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 54);
            this.label1.TabIndex = 1;
            this.label1.Text = "QUẢN LÝ SÂN BAY";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTim);
            this.groupBox1.Controls.Add(this.buttonTim);
            this.groupBox1.Controls.Add(this.buttonLoad);
            this.groupBox1.Controls.Add(this.dgvDSSanBay);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(12, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 301);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DANH SÁCH SÂN BAY";
            // 
            // dgvDSSanBay
            // 
            this.dgvDSSanBay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvDSSanBay.BackgroundColor = System.Drawing.Color.White;
            this.dgvDSSanBay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDSSanBay.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSSanBay.Location = new System.Drawing.Point(6, 44);
            this.dgvDSSanBay.Name = "dgvDSSanBay";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.dgvDSSanBay.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDSSanBay.Size = new System.Drawing.Size(466, 251);
            this.dgvDSSanBay.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(-13, -10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(539, 98);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBox5);
            this.groupBox3.Controls.Add(this.buttonThoat);
            this.groupBox3.Controls.Add(this.buttonSua);
            this.groupBox3.Controls.Add(this.buttonXoa);
            this.groupBox3.Controls.Add(this.buttonThem);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtTenSanBay);
            this.groupBox3.Controls.Add(this.txtMaSanBay);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox3.Location = new System.Drawing.Point(12, 401);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(478, 192);
            this.groupBox3.TabIndex = 54;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "THÊM MỚI & SỬA SÂN BAY";
            // 
            // buttonThoat
            // 
            this.buttonThoat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonThoat.Location = new System.Drawing.Point(314, 132);
            this.buttonThoat.Name = "buttonThoat";
            this.buttonThoat.Size = new System.Drawing.Size(69, 32);
            this.buttonThoat.TabIndex = 41;
            this.buttonThoat.Text = "THOÁT";
            this.buttonThoat.UseVisualStyleBackColor = true;
            // 
            // buttonSua
            // 
            this.buttonSua.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonSua.Location = new System.Drawing.Point(223, 132);
            this.buttonSua.Name = "buttonSua";
            this.buttonSua.Size = new System.Drawing.Size(72, 32);
            this.buttonSua.TabIndex = 14;
            this.buttonSua.Text = "SỬA";
            this.buttonSua.UseVisualStyleBackColor = true;
            // 
            // buttonXoa
            // 
            this.buttonXoa.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonXoa.Location = new System.Drawing.Point(126, 132);
            this.buttonXoa.Name = "buttonXoa";
            this.buttonXoa.Size = new System.Drawing.Size(74, 32);
            this.buttonXoa.TabIndex = 13;
            this.buttonXoa.Text = "XÓA";
            this.buttonXoa.UseVisualStyleBackColor = true;
            // 
            // buttonThem
            // 
            this.buttonThem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonThem.Location = new System.Drawing.Point(32, 132);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(75, 32);
            this.buttonThem.TabIndex = 15;
            this.buttonThem.Text = "THÊM";
            this.buttonThem.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(23, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Mã Sân Bay";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(23, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Tên Sân Bay";
            // 
            // txtTenSanBay
            // 
            this.txtTenSanBay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSanBay.Location = new System.Drawing.Point(174, 82);
            this.txtTenSanBay.Name = "txtTenSanBay";
            this.txtTenSanBay.Size = new System.Drawing.Size(277, 23);
            this.txtTenSanBay.TabIndex = 22;
            // 
            // txtMaSanBay
            // 
            this.txtMaSanBay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSanBay.Location = new System.Drawing.Point(174, 31);
            this.txtMaSanBay.Name = "txtMaSanBay";
            this.txtMaSanBay.ReadOnly = true;
            this.txtMaSanBay.Size = new System.Drawing.Size(277, 23);
            this.txtMaSanBay.TabIndex = 23;
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(245, 17);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(142, 21);
            this.txtTim.TabIndex = 13;
            this.txtTim.Text = "";
            // 
            // buttonTim
            // 
            this.buttonTim.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonTim.Location = new System.Drawing.Point(393, 17);
            this.buttonTim.Name = "buttonTim";
            this.buttonTim.Size = new System.Drawing.Size(75, 23);
            this.buttonTim.TabIndex = 12;
            this.buttonTim.Text = "Tìm";
            this.buttonTim.UseVisualStyleBackColor = true;
            // 
            // buttonLoad
            // 
            this.buttonLoad.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonLoad.Location = new System.Drawing.Point(9, 19);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 11;
            this.buttonLoad.Text = "LOAD";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::QLCB.Properties.Resources.map_icon;
            this.pictureBox2.Location = new System.Drawing.Point(34, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(74, 64);
            this.pictureBox2.TabIndex = 32;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::QLCB.Properties.Resources.cat_food_hearts_icon;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox5.Location = new System.Drawing.Point(393, 122);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(58, 61);
            this.pictureBox5.TabIndex = 47;
            this.pictureBox5.TabStop = false;
            // 
            // QuanLySanBay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(498, 595);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "QuanLySanBay";
            this.Text = "QuanLySanBay";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSanBay)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDSSanBay;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button buttonThoat;
        private System.Windows.Forms.Button buttonSua;
        private System.Windows.Forms.Button buttonXoa;
        private System.Windows.Forms.Button buttonThem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenSanBay;
        private System.Windows.Forms.TextBox txtMaSanBay;
        private System.Windows.Forms.RichTextBox txtTim;
        private System.Windows.Forms.Button buttonTim;
        private System.Windows.Forms.Button buttonLoad;
    }
}