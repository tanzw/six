namespace Well.Six.UControls
{
    partial class ULX
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cbox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIssue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbox
            // 
            this.cbox.FormattingEnabled = true;
            this.cbox.Location = new System.Drawing.Point(260, 15);
            this.cbox.Name = "cbox";
            this.cbox.Size = new System.Drawing.Size(109, 20);
            this.cbox.TabIndex = 1;
            this.cbox.SelectedIndexChanged += new System.EventHandler(this.cbox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "客户：";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(283, 180);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(61, 23);
            this.btnReset.TabIndex = 22;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(224, 180);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(53, 23);
            this.btnOK.TabIndex = 21;
            this.btnOK.Text = "确认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "单注金额:";
            // 
            // txtMoney
            // 
            this.txtMoney.Location = new System.Drawing.Point(155, 182);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(63, 21);
            this.txtMoney.TabIndex = 20;
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
            this.groupBox1.Size = new System.Drawing.Size(455, 42);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // txtIssue
            // 
            this.txtIssue.Location = new System.Drawing.Point(67, 14);
            this.txtIssue.Name = "txtIssue";
            this.txtIssue.Size = new System.Drawing.Size(109, 21);
            this.txtIssue.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "期号：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.txtMoney);
            this.groupBox2.Controls.Add(this.btnOK);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(455, 212);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // ULX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ULX";
            this.Size = new System.Drawing.Size(455, 254);
            this.Load += new System.EventHandler(this.ULX_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.ComboBox cbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIssue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
