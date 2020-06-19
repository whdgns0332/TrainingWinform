﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace BookRentalShop20
{
    public partial class LoginForm : MetroForm
    {
        string strConnString = "Data Source=192.168.0.27;Initial Catalog=BookRantalShopDB;Persist Security Info=True;User ID=sa;Password=p@ssw0rd!";
        public LoginForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 캔슬 처리버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Application.Exit();
            Environment.Exit(0); // 위와 같이 창닫기
        }
        /// <summary>
        /// 로그인 처리버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOK_Click(object sender, EventArgs e)
        {
            LoginProcess();
        }

        private void textID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // 엔터
            {
                TxtPassword.Focus();
            }
        }

        private void textPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                LoginProcess();
            }
        }

        private void LoginProcess()
        {
            // throw new NotImplementedException();
            if (String.IsNullOrEmpty(TxtUserID.Text) ||
                String.IsNullOrEmpty(TxtPassword.Text))
            {
                MetroMessageBox.Show(this, "아이디/패스워드를 입력하세요!", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string strUserId = string.Empty;

            try
            {
                using (SqlConnection conn = new SqlConnection(strConnString))
                {
                    conn.Open(); // using을 써서 나중에 Close를 호출할 필요 없음
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select userID from userTbl" +
                                      " where userID = @userID " +
                                      "   and password = @password";
                    SqlParameter parmUserID = new SqlParameter("@userID", SqlDbType.VarChar, 12);
                    parmUserID.Value = TxtUserID.Text;
                    cmd.Parameters.Add(parmUserID);
                    SqlParameter parmPassword = new SqlParameter("@Password", SqlDbType.VarChar, 20);
                    parmPassword.Value = TxtPassword.Text;
                    cmd.Parameters.Add(parmPassword);

                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    strUserId = reader["userID"] != null ? reader["userID"].ToString() : "";
                    
                    if (strUserId != "")
                    {
                        MetroMessageBox.Show(this, "접속성공", "로그인 성공");
                        this.Close();
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "접속실패", "로그인 실패",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                    // MetroMessageBox.Show(this, "접속성공", "로그인");
                    // Debug.WriteLine("On the Debug");
                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, $"Error : {ex.StackTrace}", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}