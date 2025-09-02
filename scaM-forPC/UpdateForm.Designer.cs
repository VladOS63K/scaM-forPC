namespace scaM_forPC
{
    partial class UpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
            TitleLabel = new Label();
            DescriptionWebView = new Microsoft.Web.WebView2.WinForms.WebView2();
            CancelBtn = new Button();
            UpdateBtn = new Button();
            linkLabel1 = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)DescriptionWebView).BeginInit();
            SuspendLayout();
            // 
            // TitleLabel
            // 
            TitleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TitleLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            TitleLabel.Location = new Point(12, 20);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(484, 21);
            TitleLabel.TabIndex = 2;
            TitleLabel.Text = "Загрузка...";
            // 
            // DescriptionWebView
            // 
            DescriptionWebView.AllowExternalDrop = true;
            DescriptionWebView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DescriptionWebView.CreationProperties = null;
            DescriptionWebView.DefaultBackgroundColor = SystemColors.Control;
            DescriptionWebView.Location = new Point(12, 44);
            DescriptionWebView.Name = "DescriptionWebView";
            DescriptionWebView.Size = new Size(484, 412);
            DescriptionWebView.TabIndex = 3;
            DescriptionWebView.ZoomFactor = 1D;
            // 
            // CancelBtn
            // 
            CancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CancelBtn.Location = new Point(421, 462);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(75, 23);
            CancelBtn.TabIndex = 1;
            CancelBtn.Text = "Отмена";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelBtn_Click_1;
            // 
            // UpdateBtn
            // 
            UpdateBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            UpdateBtn.Enabled = false;
            UpdateBtn.Location = new Point(340, 462);
            UpdateBtn.Name = "UpdateBtn";
            UpdateBtn.Size = new Size(75, 23);
            UpdateBtn.TabIndex = 0;
            UpdateBtn.Text = "Обновить!";
            UpdateBtn.UseVisualStyleBackColor = true;
            UpdateBtn.Click += UpdateBtn_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            linkLabel1.LinkArea = new LinkArea(39, 11);
            linkLabel1.Location = new Point(41, 465);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(293, 20);
            linkLabel1.TabIndex = 4;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Это обновление можно скачать только по этой ссылке.";
            linkLabel1.UseCompatibleTextRendering = true;
            linkLabel1.Visible = false;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // UpdateForm
            // 
            AcceptButton = UpdateBtn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CancelBtn;
            ClientSize = new Size(508, 497);
            Controls.Add(linkLabel1);
            Controls.Add(UpdateBtn);
            Controls.Add(CancelBtn);
            Controls.Add(DescriptionWebView);
            Controls.Add(TitleLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UpdateForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Обновление";
            TopMost = true;
            FormClosing += UpdateForm_FormClosing;
            Load += UpdateForm_Load;
            Shown += UpdateForm_Shown;
            ((System.ComponentModel.ISupportInitialize)DescriptionWebView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TitleLabel;
        private Microsoft.Web.WebView2.WinForms.WebView2 DescriptionWebView;
        private Button CancelBtn;
        private Button UpdateBtn;
        private LinkLabel linkLabel1;
    }
}