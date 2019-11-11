namespace watch
{
    partial class Msg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Msg));
            this.btnQD = new System.Windows.Forms.Button();
            this.labelX1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnQD
            // 
            this.btnQD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQD.Location = new System.Drawing.Point(232, 68);
            this.btnQD.Name = "btnQD";
            this.btnQD.Size = new System.Drawing.Size(89, 34);
            this.btnQD.TabIndex = 0;
            this.btnQD.Text = "确定";
            this.btnQD.Click += new System.EventHandler(this.btnQD_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.Location = new System.Drawing.Point(-1, 24);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(347, 31);
            this.labelX1.TabIndex = 1;
            // 
            // Msg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 114);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btnQD);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Msg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "系统提示";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnQD;
        private System.Windows.Forms.Label labelX1;
    }
}