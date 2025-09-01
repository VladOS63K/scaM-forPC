namespace Updater
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            ProgressBar = new ProgressBar();
            LabelStatus = new TextBox();
            SuspendLayout();
            // 
            // ProgressBar
            // 
            ProgressBar.Location = new Point(12, 56);
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new Size(317, 21);
            ProgressBar.TabIndex = 0;
            // 
            // LabelStatus
            // 
            LabelStatus.BackColor = SystemColors.Control;
            LabelStatus.BorderStyle = BorderStyle.None;
            LabelStatus.Location = new Point(12, 17);
            LabelStatus.Multiline = true;
            LabelStatus.Name = "LabelStatus";
            LabelStatus.ReadOnly = true;
            LabelStatus.Size = new Size(317, 33);
            LabelStatus.TabIndex = 1;
            LabelStatus.Text = "Состояние";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(341, 89);
            Controls.Add(LabelStatus);
            Controls.Add(ProgressBar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "скаМ Updater";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ProgressBar ProgressBar;
        private TextBox LabelStatus;
    }
}
