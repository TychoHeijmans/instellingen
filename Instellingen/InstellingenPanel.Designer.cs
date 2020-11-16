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
            this.AutoVerbergen = new System.Windows.Forms.RadioButton();
            this.NietVerbergen = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.batterijBesparing = new System.Windows.Forms.GroupBox();
            this.TaakBalk = new System.Windows.Forms.GroupBox();
            this.TaakBalkBox = new System.Windows.Forms.GroupBox();
            this.taakBalkBeneden = new System.Windows.Forms.RadioButton();
            this.taakBalkRechts = new System.Windows.Forms.RadioButton();
            this.taakBalkBoven = new System.Windows.Forms.RadioButton();
            this.taakBalkLinks = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.trackBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSound)).BeginInit();
            this.batterijBesparing.SuspendLayout();
            this.TaakBalk.SuspendLayout();
            this.TaakBalkBox.SuspendLayout();
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
            // AutoVerbergen
            // 
            this.AutoVerbergen.Appearance = System.Windows.Forms.Appearance.Button;
            this.AutoVerbergen.AutoSize = true;
            this.AutoVerbergen.Location = new System.Drawing.Point(7, 22);
            this.AutoVerbergen.Name = "AutoVerbergen";
            this.AutoVerbergen.Size = new System.Drawing.Size(99, 25);
            this.AutoVerbergen.TabIndex = 3;
            this.AutoVerbergen.TabStop = true;
            this.AutoVerbergen.Text = "Auto verbergen";
            this.AutoVerbergen.UseVisualStyleBackColor = true;
            this.AutoVerbergen.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // NietVerbergen
            // 
            this.NietVerbergen.Appearance = System.Windows.Forms.Appearance.Button;
            this.NietVerbergen.AutoSize = true;
            this.NietVerbergen.Location = new System.Drawing.Point(105, 22);
            this.NietVerbergen.Name = "NietVerbergen";
            this.NietVerbergen.Size = new System.Drawing.Size(95, 25);
            this.NietVerbergen.TabIndex = 4;
            this.NietVerbergen.TabStop = true;
            this.NietVerbergen.Text = "Niet verbergen";
            this.NietVerbergen.UseVisualStyleBackColor = true;
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
            // TaakBalk
            // 
            this.TaakBalk.Controls.Add(this.AutoVerbergen);
            this.TaakBalk.Controls.Add(this.NietVerbergen);
            this.TaakBalk.Location = new System.Drawing.Point(31, 200);
            this.TaakBalk.Name = "TaakBalk";
            this.TaakBalk.Size = new System.Drawing.Size(209, 62);
            this.TaakBalk.TabIndex = 8;
            this.TaakBalk.TabStop = false;
            this.TaakBalk.Text = "Taakbalk verbergen";
            // 
            // TaakBalkBox
            // 
            this.TaakBalkBox.Controls.Add(this.taakBalkBeneden);
            this.TaakBalkBox.Controls.Add(this.taakBalkRechts);
            this.TaakBalkBox.Controls.Add(this.taakBalkBoven);
            this.TaakBalkBox.Controls.Add(this.taakBalkLinks);
            this.TaakBalkBox.Location = new System.Drawing.Point(29, 267);
            this.TaakBalkBox.Name = "TaakBalkBox";
            this.TaakBalkBox.Size = new System.Drawing.Size(210, 169);
            this.TaakBalkBox.TabIndex = 9;
            this.TaakBalkBox.TabStop = false;
            this.TaakBalkBox.Tag = "up";
            this.TaakBalkBox.Text = "Taakbalk positie";
            // 
            // taakBalkBeneden
            // 
            this.taakBalkBeneden.Appearance = System.Windows.Forms.Appearance.Button;
            this.taakBalkBeneden.AutoSize = true;
            this.taakBalkBeneden.Location = new System.Drawing.Point(63, 101);
            this.taakBalkBeneden.Name = "taakBalkBeneden";
            this.taakBalkBeneden.Size = new System.Drawing.Size(63, 25);
            this.taakBalkBeneden.TabIndex = 3;
            this.taakBalkBeneden.TabStop = true;
            this.taakBalkBeneden.Tag = "down";
            this.taakBalkBeneden.Text = "Beneden";
            this.taakBalkBeneden.UseVisualStyleBackColor = true;
            // 
            // taakBalkRechts
            // 
            this.taakBalkRechts.Appearance = System.Windows.Forms.Appearance.Button;
            this.taakBalkRechts.AutoSize = true;
            this.taakBalkRechts.Location = new System.Drawing.Point(128, 75);
            this.taakBalkRechts.Name = "taakBalkRechts";
            this.taakBalkRechts.Size = new System.Drawing.Size(52, 25);
            this.taakBalkRechts.TabIndex = 2;
            this.taakBalkRechts.TabStop = true;
            this.taakBalkRechts.Tag = "right";
            this.taakBalkRechts.Text = "Rechts";
            this.taakBalkRechts.UseVisualStyleBackColor = true;
            // 
            // taakBalkBoven
            // 
            this.taakBalkBoven.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.taakBalkBoven.Appearance = System.Windows.Forms.Appearance.Button;
            this.taakBalkBoven.AutoSize = true;
            this.taakBalkBoven.Location = new System.Drawing.Point(68, 51);
            this.taakBalkBoven.Name = "taakBalkBoven";
            this.taakBalkBoven.Size = new System.Drawing.Size(50, 25);
            this.taakBalkBoven.TabIndex = 1;
            this.taakBalkBoven.TabStop = true;
            this.taakBalkBoven.Tag = "up";
            this.taakBalkBoven.Text = "Boven";
            this.taakBalkBoven.UseVisualStyleBackColor = true;
            // 
            // taakBalkLinks
            // 
            this.taakBalkLinks.Appearance = System.Windows.Forms.Appearance.Button;
            this.taakBalkLinks.AutoSize = true;
            this.taakBalkLinks.Location = new System.Drawing.Point(18, 75);
            this.taakBalkLinks.Name = "taakBalkLinks";
            this.taakBalkLinks.Size = new System.Drawing.Size(44, 25);
            this.taakBalkLinks.TabIndex = 0;
            this.taakBalkLinks.TabStop = true;
            this.taakBalkLinks.Tag = "left";
            this.taakBalkLinks.Text = "Links";
            this.taakBalkLinks.UseVisualStyleBackColor = true;
            // 
            // InstellingenPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TaakBalkBox);
            this.Controls.Add(this.batterijBesparing);
            this.Controls.Add(this.trackSound);
            this.Controls.Add(this.trackBrightness);
            this.Controls.Add(this.TaakBalk);
            this.Name = "InstellingenPanel";
            this.Text = "Instellingen";
            ((System.ComponentModel.ISupportInitialize)(this.trackBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSound)).EndInit();
            this.batterijBesparing.ResumeLayout(false);
            this.batterijBesparing.PerformLayout();
            this.TaakBalk.ResumeLayout(false);
            this.TaakBalk.PerformLayout();
            this.TaakBalkBox.ResumeLayout(false);
            this.TaakBalkBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBrightness;
        private System.Windows.Forms.TrackBar trackSound;
        private System.Windows.Forms.RadioButton AutoVerbergen;
        private System.Windows.Forms.RadioButton NietVerbergen;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.GroupBox batterijBesparing;
        private System.Windows.Forms.GroupBox TaakBalk;
        private System.Windows.Forms.GroupBox t;
        private System.Windows.Forms.GroupBox TaakBalkBox;
        private System.Windows.Forms.RadioButton taakBalkBeneden;
        private System.Windows.Forms.RadioButton taakBalkRechts;
        private System.Windows.Forms.RadioButton taakBalkBoven;
        private System.Windows.Forms.RadioButton taakBalkLinks;
    }
}

