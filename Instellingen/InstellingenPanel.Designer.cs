namespace Instellingen
{
    partial class InstellingenPanel
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackBrightness = new System.Windows.Forms.TrackBar();
            this.trackSound = new System.Windows.Forms.TrackBar();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.batterijBesparing = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSound)).BeginInit();
            this.batterijBesparing.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBrightness
            // 
            this.trackBrightness.Location = new System.Drawing.Point(31, 29);
            this.trackBrightness.Name = "trackBrightness";
            this.trackBrightness.Size = new System.Drawing.Size(341, 45);
            this.trackBrightness.TabIndex = 0;
            // 
            // trackSound
            // 
            this.trackSound.Location = new System.Drawing.Point(31, 80);
            this.trackSound.Name = "trackSound";
            this.trackSound.Size = new System.Drawing.Size(341, 45);
            this.trackSound.TabIndex = 1;
            // 
            // radioButton1
            // 
            this.radioButton1.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(86, 25);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(92, 22);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(86, 25);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(7, 22);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(86, 25);
            this.radioButton3.TabIndex = 5;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "radioButton3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(92, 22);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(86, 25);
            this.radioButton4.TabIndex = 6;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "radioButton4";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // batterijBesparing
            // 
            this.batterijBesparing.Controls.Add(this.radioButton4);
            this.batterijBesparing.Controls.Add(this.radioButton3);
            this.batterijBesparing.Location = new System.Drawing.Point(31, 131);
            this.batterijBesparing.Name = "batterijBesparing";
            this.batterijBesparing.Size = new System.Drawing.Size(209, 63);
            this.batterijBesparing.TabIndex = 7;
            this.batterijBesparing.TabStop = false;
            this.batterijBesparing.Text = "Batterij besparing";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Location = new System.Drawing.Point(31, 200);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 62);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // InstellingenPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.batterijBesparing);
            this.Controls.Add(this.trackSound);
            this.Controls.Add(this.trackBrightness);
            this.Controls.Add(this.groupBox2);
            this.Name = "InstellingenPanel";
            this.Text = "Instellingen";
            ((System.ComponentModel.ISupportInitialize)(this.trackBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSound)).EndInit();
            this.batterijBesparing.ResumeLayout(false);
            this.batterijBesparing.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBrightness;
        private System.Windows.Forms.TrackBar trackSound;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.GroupBox batterijBesparing;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

