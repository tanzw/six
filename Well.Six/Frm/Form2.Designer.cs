namespace Well.Six.Frm
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
            this.lX21 = new Well.Six.UControls.ULX();
            this.lX22 = new Well.Six.UControls.ULX();
            this.SuspendLayout();
            // 
            // lX21
            // 
            this.lX21.Location = new System.Drawing.Point(27, 27);
            this.lX21.Name = "lX21";
            this.lX21.Size = new System.Drawing.Size(743, 390);
            this.lX21.TabIndex = 0;
            // 
            // lX22
            // 
            this.lX22.Location = new System.Drawing.Point(197, 68);
            this.lX22.Name = "lX22";
            this.lX22.OrderType = 0;
            this.lX22.Size = new System.Drawing.Size(455, 207);
            this.lX22.TabIndex = 1;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lX22);
            this.Controls.Add(this.lX21);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private UControls.ULX lX21;
        private UControls.ULX lX22;
    }
}