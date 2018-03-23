namespace Well.Six.Frm
{
    partial class fmPTYX
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIssue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnReset_ws = new System.Windows.Forms.Button();
            this.btnOK_ws = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
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
            this.groupBox1.Size = new System.Drawing.Size(800, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtIssue
            // 
            this.txtIssue.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtIssue.Location = new System.Drawing.Point(123, 14);
            this.txtIssue.Name = "txtIssue";
            this.txtIssue.Size = new System.Drawing.Size(175, 31);
            this.txtIssue.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(44, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 21);
            this.label3.TabIndex = 26;
            this.label3.Text = "期号：";
            // 
            // cbox
            // 
            this.cbox.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbox.FormattingEnabled = true;
            this.cbox.Location = new System.Drawing.Point(481, 14);
            this.cbox.Name = "cbox";
            this.cbox.Size = new System.Drawing.Size(216, 29);
            this.cbox.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(402, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 25;
            this.label2.Text = "客户：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 408);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(3, 17);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(794, 388);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnReset);
            this.tabPage1.Controls.Add(this.btnOK);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(786, 354);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "一肖";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(399, 313);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(112, 38);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(281, 313);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(112, 38);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnReset_ws);
            this.tabPage2.Controls.Add(this.btnOK_ws);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(786, 354);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "尾数";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnReset_ws
            // 
            this.btnReset_ws.Location = new System.Drawing.Point(399, 310);
            this.btnReset_ws.Name = "btnReset_ws";
            this.btnReset_ws.Size = new System.Drawing.Size(112, 38);
            this.btnReset_ws.TabIndex = 3;
            this.btnReset_ws.Text = "重置";
            this.btnReset_ws.UseVisualStyleBackColor = true;
            this.btnReset_ws.Click += new System.EventHandler(this.btnReset_ws_Click);
            // 
            // btnOK_ws
            // 
            this.btnOK_ws.Location = new System.Drawing.Point(281, 310);
            this.btnOK_ws.Name = "btnOK_ws";
            this.btnOK_ws.Size = new System.Drawing.Size(112, 38);
            this.btnOK_ws.TabIndex = 2;
            this.btnOK_ws.Text = "确定";
            this.btnOK_ws.UseVisualStyleBackColor = true;
            this.btnOK_ws.Click += new System.EventHandler(this.btnOK_ws_Click);
            // 
            // fmPTYX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 463);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "fmPTYX";
            this.Text = "平特一肖/尾数";
            this.Load += new System.EventHandler(this.fmPTYX_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtIssue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnReset_ws;
        private System.Windows.Forms.Button btnOK_ws;
    }
}