namespace Lab5_2112727_DangThiQuynhNhu
{
    partial class frmSaveChanges
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
            this.rdTXT = new System.Windows.Forms.RadioButton();
            this.rdJSON = new System.Windows.Forms.RadioButton();
            this.rdXML = new System.Windows.Forms.RadioButton();
            this.SaveChanges = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rdTXT
            // 
            this.rdTXT.AutoSize = true;
            this.rdTXT.Location = new System.Drawing.Point(150, 180);
            this.rdTXT.Name = "rdTXT";
            this.rdTXT.Size = new System.Drawing.Size(54, 20);
            this.rdTXT.TabIndex = 0;
            this.rdTXT.TabStop = true;
            this.rdTXT.Text = "TXT";
            this.rdTXT.UseVisualStyleBackColor = true;
            // 
            // rdJSON
            // 
            this.rdJSON.AutoSize = true;
            this.rdJSON.Location = new System.Drawing.Point(298, 180);
            this.rdJSON.Name = "rdJSON";
            this.rdJSON.Size = new System.Drawing.Size(64, 20);
            this.rdJSON.TabIndex = 0;
            this.rdJSON.TabStop = true;
            this.rdJSON.Text = "JSON";
            this.rdJSON.UseVisualStyleBackColor = true;
            // 
            // rdXML
            // 
            this.rdXML.AutoSize = true;
            this.rdXML.Location = new System.Drawing.Point(458, 180);
            this.rdXML.Name = "rdXML";
            this.rdXML.Size = new System.Drawing.Size(54, 20);
            this.rdXML.TabIndex = 0;
            this.rdXML.TabStop = true;
            this.rdXML.Text = "XML";
            this.rdXML.UseVisualStyleBackColor = true;
            // 
            // SaveChanges
            // 
            this.SaveChanges.AutoSize = true;
            this.SaveChanges.Location = new System.Drawing.Point(241, 119);
            this.SaveChanges.Name = "SaveChanges";
            this.SaveChanges.Size = new System.Drawing.Size(231, 16);
            this.SaveChanges.TabIndex = 1;
            this.SaveChanges.Text = "Bạn muốn lưu dưới định dạng file nào?";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(310, 268);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmSaveChanges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.SaveChanges);
            this.Controls.Add(this.rdXML);
            this.Controls.Add(this.rdJSON);
            this.Controls.Add(this.rdTXT);
            this.Name = "frmSaveChanges";
            this.Text = "frmSaveChanges";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdTXT;
        private System.Windows.Forms.RadioButton rdJSON;
        private System.Windows.Forms.RadioButton rdXML;
        private System.Windows.Forms.Label SaveChanges;
        private System.Windows.Forms.Button btnClose;
    }
}