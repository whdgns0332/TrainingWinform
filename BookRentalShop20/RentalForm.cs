using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace BookRentalShop20
{
    public partial class RentalForm : MetroForm
    {
        string mode = "";
        public RentalForm()
        {
            InitializeComponent();
        }

        private void Updatedata()
        {
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open(); // DB 열기
                string strQuery = "SELECT Idx, memberIdx, bookIdx, rentalDate, returnDate FROM rentaltbl";
                // SqlCommand cmd = new SqlCommand(strQuery, conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "rentaltbl");

                GrdDivTbl.DataSource = ds;
                GrdDivTbl.DataMember = "rentaltbl";
            }
        }

        private void GrdDivTbl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow data = GrdDivTbl.Rows[e.RowIndex];
                TxtIdx.Text = data.Cells[0].Value.ToString();
                CboMemberIdx.SelectedIndex = CboMemberIdx.FindString(data.Cells[1].Value.ToString()); // 항목편집
                CboBookIdx.SelectedIndex = CboBookIdx.FindString(data.Cells[2].Value.ToString());
                DtpRental.CustomFormat = "yyyy-MM-dd";
                DtpRental.Format = DateTimePickerFormat.Custom;
                DtpRental.Value = DateTime.Parse(data.Cells[3].Value.ToString());
                if (string.IsNullOrEmpty(data.Cells[4].Value.ToString()))
                {
                    DtpReturn.CustomFormat = " ";
                    DtpReturn.Format = DateTimePickerFormat.Custom;
                }
                else
                {
                    DtpReturn.CustomFormat = "yyyy-MM-dd";
                    DtpReturn.Format = DateTimePickerFormat.Custom;
                    DtpReturn.Value = DateTime.Parse(data.Cells[4].Value.ToString());
                }
                TxtIdx.ReadOnly = true;
                TxtIdx.BackColor = Color.Beige;

                mode = "UPDATE";
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearTextControls();

            mode = "INSERT";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (CboMemberIdx.SelectedIndex == -1
                || CboBookIdx.SelectedIndex == -1 || DtpReturn.CustomFormat == " "
                || DtpRental.CustomFormat == " ")
            {
                MetroMessageBox.Show(this, "빈값은 저장할 수 없습니다.", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SaveProcess();
            Updatedata();
            
            ClearTextControls(); // 구분코드 변경 잠금 해제
        }

        private void ClearTextControls()
        {
            TxtIdx.Text = "";
            TxtIdx.ReadOnly = true;
            TxtIdx.BackColor = Color.Beige;
            CboMemberIdx.SelectedIndex = CboBookIdx.SelectedIndex = -1;
            DtpRental.CustomFormat = DtpReturn.CustomFormat = " ";
            DtpRental.Format = DtpReturn.Format = DateTimePickerFormat.Custom;

            TxtIdx.Focus();
        }

        private void SaveProcess() // DB 저장 프로세스
        {
            if (String.IsNullOrEmpty(mode))
            {
                MetroMessageBox.Show(this, "신규버튼을 누르고 데이터를 저장하십시오", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string strQuery = "";

                if (mode == "UPDATE")
                {
                    strQuery = "UPDATE dbo.rentaltbl " +
                               "   SET memberIdx = @memberIdx, " +
                               "       bookIdx = @bookIdx, " +
                               "       rentalDate = @rentalDate, returnDate = @returnDate " +
                               " WHERE Idx = @Idx";
                }
                else if (mode == "INSERT")
                {
                    strQuery = "INSERT INTO dbo.rentaltbl (memberIdx, bookIdx, rentalDate, returnDate) " +
                               "VALUES(@memberIdx, @bookIdx, @rentalDate, @returnDate)";
                }
                cmd.CommandText = strQuery;

                SqlParameter parmMemberIdx = new SqlParameter("@memberIdx", SqlDbType.Int);
                parmMemberIdx.Value = CboMemberIdx.SelectedValue;
                cmd.Parameters.Add(parmMemberIdx);
                SqlParameter parmBookIdx = new SqlParameter("@bookIdx", SqlDbType.Int);
                parmBookIdx.Value = CboBookIdx.SelectedValue;
                cmd.Parameters.Add(parmBookIdx);
                SqlParameter parmDtpRental = new SqlParameter("@rentalDate", SqlDbType.Date);
                parmDtpRental.Value = DtpRental.Value;
                cmd.Parameters.Add(parmDtpRental);
                SqlParameter parmDtpReturn = new SqlParameter("@returnDate", SqlDbType.Date);
                parmDtpReturn.Value = DtpReturn.Value;
                cmd.Parameters.Add(parmDtpReturn);

                if (mode == "UPDATE")
                {
                    SqlParameter parmIdx = new SqlParameter("@Idx", SqlDbType.Int);
                    parmIdx.Value = TxtIdx.Text;
                    cmd.Parameters.Add(parmIdx);
                }

                cmd.ExecuteNonQuery();
            }
        }

        private void RentalForm_Load(object sender, EventArgs e)
        {
            DtpRental.CustomFormat = DtpReturn.CustomFormat = "yyyy-MM-dd";
            DtpRental.Format = DtpReturn.Format = DateTimePickerFormat.Custom;

            Updatedata(); // 데이터그리드 DB 데이터 로딩하기
            UpdateCboMemberIdx();
            UpdateCboBookIdx();
        }

        private void UpdateCboBookIdx()
        {
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT Idx FROM bookstbl";
                SqlDataReader reader = cmd.ExecuteReader();
                Dictionary<string, string> temps = new Dictionary<string, string>();
                while (reader.Read())
                {
                    temps.Add(reader[0].ToString(), reader[0].ToString());
                }
                CboBookIdx.DataSource = new BindingSource(temps, null);
                CboBookIdx.DisplayMember = "Value";
                CboBookIdx.ValueMember = "Key";
                CboBookIdx.SelectedIndex = -1;
            }
        }

        private void UpdateCboMemberIdx()
        {
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT Idx FROM membertbl";
                SqlDataReader reader = cmd.ExecuteReader();
                Dictionary<string, string> temps = new Dictionary<string, string>();
                while (reader.Read())
                {
                    temps.Add(reader[0].ToString(), reader[0].ToString());
                }
                CboMemberIdx.DataSource = new BindingSource(temps, null);
                CboMemberIdx.DisplayMember = "Value";
                CboMemberIdx.ValueMember = "Key";
                CboMemberIdx.SelectedIndex = -1;
            }
        }

        private void DtpRental_ValueChanged(object sender, EventArgs e)
        {
            DtpRental.CustomFormat = "yyyy-MM-dd";
            DtpRental.Format = DateTimePickerFormat.Custom;
        }

        private void DtpReturn_ValueChanged(object sender, EventArgs e)
        {
            DtpReturn.CustomFormat = "yyyy-MM-dd";
            DtpReturn.Format = DateTimePickerFormat.Custom;
        }

        /*
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(TxtIdx.Text) || string.IsNullOrEmpty(TxtNames.Text))
            {
                MetroMessageBox.Show(this, "빈값은 삭제할 수 없습니다.", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DeleteProcess();
            Updatedata();
            ClearTextControls();
        }
        

        private void DeleteProcess()
        {
            using (SqlConnection conn = new SqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM dbo.divtbl WHERE Division = @Division";
                SqlParameter parmDivision = new SqlParameter("@Division", SqlDbType.Char, 4);
                parmDivision.Value = TxtIdx.Text;
                cmd.Parameters.Add(parmDivision);

                cmd.ExecuteNonQuery();
            }
        }
        */
    }
}
