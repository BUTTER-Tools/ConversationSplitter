namespace ConversationSplitter
{
    partial class SettingsForm_ConversationSplitter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm_ConversationSplitter));
            this.OKButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SpeakerTags = new System.Windows.Forms.TextBox();
            this.RegexTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SpeakersMultipleLinesCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.Location = new System.Drawing.Point(122, 541);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(118, 40);
            this.OKButton.TabIndex = 6;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Speaker Tags:";
            // 
            // WordListTextBox
            // 
            this.SpeakerTags.AcceptsReturn = true;
            this.SpeakerTags.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpeakerTags.Location = new System.Drawing.Point(12, 43);
            this.SpeakerTags.MaxLength = 2147483647;
            this.SpeakerTags.Multiline = true;
            this.SpeakerTags.Name = "WordListTextBox";
            this.SpeakerTags.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.SpeakerTags.Size = new System.Drawing.Size(339, 357);
            this.SpeakerTags.TabIndex = 19;
            this.SpeakerTags.WordWrap = false;
            // 
            // RegexTextBox
            // 
            this.RegexTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegexTextBox.Location = new System.Drawing.Point(139, 478);
            this.RegexTextBox.MaxLength = 999999999;
            this.RegexTextBox.Name = "RegexTextBox";
            this.RegexTextBox.Size = new System.Drawing.Size(211, 22);
            this.RegexTextBox.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 480);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "RegEx Removal:";
            // 
            // SpeakersMultipleLinesCheckbox
            // 
            this.SpeakersMultipleLinesCheckbox.AutoSize = true;
            this.SpeakersMultipleLinesCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpeakersMultipleLinesCheckbox.Location = new System.Drawing.Point(12, 432);
            this.SpeakersMultipleLinesCheckbox.Name = "SpeakersMultipleLinesCheckbox";
            this.SpeakersMultipleLinesCheckbox.Size = new System.Drawing.Size(271, 20);
            this.SpeakersMultipleLinesCheckbox.TabIndex = 21;
            this.SpeakersMultipleLinesCheckbox.Text = "Speakers can have Multiple Lines of Text";
            this.SpeakersMultipleLinesCheckbox.UseVisualStyleBackColor = true;
            // 
            // SettingsForm_ConversationSplitter
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 593);
            this.Controls.Add(this.RegexTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SpeakersMultipleLinesCheckbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SpeakerTags);
            this.Controls.Add(this.OKButton);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm_ConversationSplitter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plugin Name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SpeakerTags;
        private System.Windows.Forms.TextBox RegexTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox SpeakersMultipleLinesCheckbox;
    }
}