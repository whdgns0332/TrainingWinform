﻿namespace WinFormApp
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnMessage = new System.Windows.Forms.Button();
            this.TxtCurrentDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnMessage
            // 
            this.BtnMessage.BackColor = System.Drawing.Color.Teal;
            this.BtnMessage.Font = new System.Drawing.Font("나눔고딕코딩", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnMessage.Location = new System.Drawing.Point(601, 378);
            this.BtnMessage.Name = "BtnMessage";
            this.BtnMessage.Size = new System.Drawing.Size(187, 60);
            this.BtnMessage.TabIndex = 0;
            this.BtnMessage.Text = "현재시간";
            this.BtnMessage.UseVisualStyleBackColor = false;
            this.BtnMessage.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxtCurrentDate
            // 
            this.TxtCurrentDate.Location = new System.Drawing.Point(108, 98);
            this.TxtCurrentDate.Name = "TxtCurrentDate";
            this.TxtCurrentDate.Size = new System.Drawing.Size(274, 25);
            this.TxtCurrentDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "현재시간";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtCurrentDate);
            this.Controls.Add(this.BtnMessage);
            this.Name = "MainForm";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnMessage;
        private System.Windows.Forms.TextBox TxtCurrentDate;
        private System.Windows.Forms.Label label1;
    }
}
