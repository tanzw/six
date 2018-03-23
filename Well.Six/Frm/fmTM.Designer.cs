namespace Well.Six.Frm
{
    partial class fmTM
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
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIssue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(294, 274);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(110, 37);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIssue);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(819, 60);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // txtIssue
            // 
            this.txtIssue.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtIssue.Location = new System.Drawing.Point(143, 18);
            this.txtIssue.Name = "txtIssue";
            this.txtIssue.Size = new System.Drawing.Size(175, 31);
            this.txtIssue.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(64, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 21);
            this.label3.TabIndex = 22;
            this.label3.Text = "期号：";
            // 
            // cbox
            // 
            this.cbox.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbox.FormattingEnabled = true;
            this.cbox.Location = new System.Drawing.Point(501, 18);
            this.cbox.Name = "cbox";
            this.cbox.Size = new System.Drawing.Size(216, 29);
            this.cbox.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(422, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 21;
            this.label2.Text = "客户：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.btnOK);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(819, 323);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReset.Location = new System.Drawing.Point(414, 274);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(110, 37);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // fmTM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 383);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmTM";
            this.Text = "特码订单";
            this.Load += new System.EventHandler(this.fmTM_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIssue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnReset;
    }
}