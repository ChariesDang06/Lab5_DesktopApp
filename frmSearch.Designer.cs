namespace Lab5_2112727_DangThiQuynhNhu
{
    partial class frmSearch
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
            this.rdLop = new System.Windows.Forms.RadioButton();
            this.rdMSSV = new System.Windows.Forms.RadioButton();
            this.rdTen = new System.Windows.Forms.RadioButton();
            this.txtThongTin = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rdLop
            // 
            this.rdLop.AutoSize = true;
            this.rdLop.Location = new System.Drawing.Point(497, 90);
            this.rdLop.Name = "rdLop";
            this.rdLop.Size = new System.Drawing.Size(86, 20);
            this.rdLop.TabIndex = 0;
            this.rdLop.TabStop = true;
            this.rdLop.Text = "Theo Lớp";
            this.rdLop.UseVisualStyleBackColor = true;
            // 
            // rdMSSV
            // 
            this.rdMSSV.AutoSize = true;
            this.rdMSSV.Location = new System.Drawing.Point(129, 90);
            this.rdMSSV.Name = "rdMSSV";
            this.rdMSSV.Size = new System.Drawing.Size(101, 20);
            this.rdMSSV.TabIndex = 1;
            this.rdMSSV.TabStop = true;
            this.rdMSSV.Text = "Theo MSSV";
            this.rdMSSV.UseVisualStyleBackColor = true;
            // 
            // rdTen
            // 
            this.rdTen.AutoSize = true;
            this.rdTen.Location = new System.Drawing.Point(301, 90);
            this.rdTen.Name = "rdTen";
            this.rdTen.Size = new System.Drawing.Size(87, 20);
            this.rdTen.TabIndex = 1;
            this.rdTen.TabStop = true;
            this.rdTen.Text = "Theo Tên";
            this.rdTen.UseVisualStyleBackColor = true;
            // 
            // txtThongTin
            // 
            this.txtThongTin.Location = new System.Drawing.Point(163, 162);
            this.txtThongTin.Multiline = true;
            this.txtThongTin.Name = "txtThongTin";
            this.txtThongTin.Size = new System.Drawing.Size(382, 57);
            this.txtThongTin.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(163, 296);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(109, 38);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(436, 296);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(109, 38);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtThongTin);
            this.Controls.Add(this.rdTen);
            this.Controls.Add(this.rdMSSV);
            this.Controls.Add(this.rdLop);
            this.Name = "frmSearch";
            this.Text = "frmSearch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdLop;
        private System.Windows.Forms.RadioButton rdMSSV;
        private System.Windows.Forms.RadioButton rdTen;
        private System.Windows.Forms.TextBox txtThongTin;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExit;
    }
}