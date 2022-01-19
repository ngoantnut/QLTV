using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace doanv1
{
    public partial class Form1 : Form
    {
       
        SqlConnection cn = new SqlConnection(@"Data Source=H47INQJNOACLDCO\SQLEXPRESS;Initial Catalog=QLTVNT;Integrated Security=True");
        DataTable test;
        SqlCommand cmd;
        DataView vtest;
        SqlDataAdapter adapter;
        Bitmap bmp;
        public Form1()
        {
            
            InitializeComponent();
        }

        void loaddata()
        {



            test.Clear();
            adapter.Fill(test);
            dataGridView1.DataSource = test;
        }


        private void bntxuat_Click(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("select* from DauSach", cn);
            test = new DataTable("DauSach");

            adapter.Fill(test);
            vtest = new DataView(test);
            dataGridView1.DataSource = vtest;
            MessageBox.Show("Đã xuất danh sách", "Thông báo!",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cmd = cn.CreateCommand();
            cmd.CommandText = "insert into DauSach values('" + textMaDauSach.Text + "', N'" + textTenSach.Text + "', N'" + textTacGia.Text + "', N'" + textNXB.Text + "', N'" + textNamXB.Text + "', '" + textMaPL.Text + "',N'" + txtNgonNgu.Text + "', '" + txtSoLuong.Text + "')";

            cmd.ExecuteNonQuery();
            loaddata();
            MessageBox.Show("Đã thêm", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            textMaDauSach.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textTenSach.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textTacGia.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textNXB.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            textNamXB.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            textMaPL.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txtNgonNgu.Text= dataGridView1.Rows[i].Cells[6].Value.ToString();
            txtSoLuong.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
            cn.Open();
          
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            cmd = cn.CreateCommand();
            cmd.CommandText = "update DauSach set   TenSach=N'" + textTenSach.Text + "', TacGia =N'" + textTacGia.Text + "', NXB =N'" + textNXB.Text + "', NamXB ='" + textNamXB.Text + "',MaPL =N'" + textMaPL.Text + "', MaDauSach='" + textMaDauSach.Text + "', NgonNgu='" + txtNgonNgu.Text + "' where SoLuong='" + txtSoLuong + '"';
            cmd.ExecuteNonQuery();

            loaddata();
            MessageBox.Show("Đã sửa", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnxuat1_Click(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("select* from DocGia", cn);
            test = new DataTable("DocGia");

            adapter.Fill(test);
            vtest = new DataView(test);
            dataGridView2.DataSource = vtest;
            MessageBox.Show("Đã xuất danh sách", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = cn.CreateCommand();
            cmd.CommandText = "delete from DauSach  where MaDauSach ='" + textMaDauSach.Text + "'";

            cmd.ExecuteNonQuery();
            loaddata();
            MessageBox.Show("Đã xóa", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSachXuat_Click(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("select MaMT, NgayTra, HienTrang from MuonSach", cn);
            test = new DataTable("TraSach");

            adapter.Fill(test);
            vtest = new DataView(test);
            dataGridView3.DataSource = vtest;
            MessageBox.Show("Đã xuất danh sách", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Sex_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThemDG_Click(object sender, EventArgs e)
        {
            cmd = cn.CreateCommand();
            cmd.CommandText = "insert into DocGia values('" + MaDG.Text + "', N'" + HoTen.Text + "', '" + SDT.Text + "','" + txtLop.Text + "',  '" + Sex.Text + "', N'" + Diachi.Text + "')";

            cmd.ExecuteNonQuery();
            loaddata();
            MessageBox.Show("Đã thêm", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int j;
            j = dataGridView2.CurrentRow.Index;
            MaDG.Text = dataGridView2.Rows[j].Cells[0].Value.ToString();
            HoTen.Text = dataGridView2.Rows[j].Cells[1].Value.ToString();
            txtLop.Text = dataGridView2.Rows[j].Cells[2].Value.ToString();
            SDT.Text = dataGridView2.Rows[j].Cells[3].Value.ToString();
            Sex.Text = dataGridView2.Rows[j].Cells[4].Value.ToString();
            Diachi.Text = dataGridView2.Rows[j].Cells[5].Value.ToString();
        }

    

        private void btnXoaDG_Click(object sender, EventArgs e)
        {
            cmd = cn.CreateCommand();
            cmd.CommandText = "delete from DocGia  where MaDG ='" + MaDG.Text + "'";

            cmd.ExecuteNonQuery();
            loaddata();
            MessageBox.Show("Đã xóa", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "DataSach.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Không thể ghi dữ liệu " + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dataGridView1.Columns.Count;
                            string columnNames = "";
                            string[] outputCsv = new string[dataGridView1.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dataGridView1.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; i < dataGridView1.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCsv[i] += dataGridView1 .Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }

                            File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                            MessageBox.Show("Xuất dữ liệu thành công !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất !!!", "Info");
            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {

            adapter = new SqlDataAdapter("Select * from DauSach where MaDauSach+TenSach+TacGia+NXB+MaPL like '%" + textSearch.Text + "%'", cn);

            test = new DataTable("DauSach");

            adapter.Fill(test);
            vtest = new DataView(test);
            dataGridView1.DataSource = vtest;
        }

        private void XuatMT_Click(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("select MaMT,MaDG, MaDauSach, NgayMuon, HanTra, TinhTrangMuon from MuonSach", cn);
            test = new DataTable("MuonSach");

            adapter.Fill(test);
            vtest = new DataView(test);
            dataGridView4.DataSource = vtest;
            MessageBox.Show("Đã xuất danh sách", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textMaMTs_TextChanged(object sender, EventArgs e)
        {

        }

        private void textMaDG_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSuaMT_Click(object sender, EventArgs e)
        {
            cmd = cn.CreateCommand();
            cmd.CommandText = "update MuonSach set   MaDG ='" + textMaDG.Text + "', MaDauSach ='" + textMaSach.Text + "', NgayMuon =@Ngaymuon, HanTra =@HanTra, TinhTrangMuon =N'" + TinhTrang.Text + "' where MaMT='" + textMaMT.Text + "'";
            cmd.Parameters.AddWithValue("@Ngaymuon", DateTime.Parse(textNgayMuon.Text));
            
            cmd.Parameters.AddWithValue("@HanTra", DateTime.Parse(textHanTra.Text));
            cmd.ExecuteNonQuery();

            loaddata();
            MessageBox.Show("Đã sửa", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView4.CurrentRow.Index;
            textMaMT.Text = dataGridView4.Rows[i].Cells[0].Value.ToString();
            textMaDG.Text = dataGridView4.Rows[i].Cells[1].Value.ToString();
            textMaSach.Text = dataGridView4.Rows[i].Cells[2].Value.ToString();
            textNgayMuon.Text = dataGridView4.Rows[i].Cells[3].Value.ToString();
            
            textHanTra.Text = dataGridView4.Rows[i].Cells[5].Value.ToString();
            TinhTrang.Text = dataGridView4.Rows[i].Cells[6].Value.ToString();
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = cn.CreateCommand();
            cmd.CommandText = "insert into MuonSach(MaMT, MaDG, MaDauSach, NgayMuon, HanTra, TinhTrangMuon) values('" + textMaMT.Text + "', '" + textMaDG.Text + "', '" + textMaSach.Text + "', @NgayMuon, @HanTra, N'" + TinhTrang.Text + "' )";
            cmd.Parameters.AddWithValue("@Ngaymuon", DateTime.Parse(textNgayMuon.Text));
            
            cmd.Parameters.AddWithValue("@HanTra", DateTime.Parse(textHanTra.Text));
            cmd.ExecuteNonQuery();
            loaddata();
            MessageBox.Show("Đã thêm", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cmd = cn.CreateCommand();
            cmd.CommandText = "delete from MuonSach  where MaMT ='" + textMaMT.Text + "'";

            cmd.ExecuteNonQuery();
            loaddata();
            MessageBox.Show("Đã xóa", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void henhan_Click(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("select* from MuonSach  where NgayTra>HanTra", cn);
            test = new DataTable("MuonSach");

            adapter.Fill(test);
            vtest = new DataView(test);
            dataGridView4.DataSource = vtest;
            MessageBox.Show("Đã xuất danh sách", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("exec NguoiTraMuon", cn);
            test = new DataTable("MuonSach");
            adapter.Fill(test);
            vtest = new DataView(test);
            dataGridView4.DataSource = vtest;
            MessageBox.Show("Đã xuất danh sách", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

     

        private void label18_Click(object sender, EventArgs e)
        {
           
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

      

        private void btnSuaS_Click(object sender, EventArgs e)
        {
            cmd = cn.CreateCommand();
            cmd.CommandText = "update MuonSach set   NgayTra =@NgayTra, HienTrang =N'" + HienTrang.Text + "' where MaMT='" + MaMT.Text + "'";
            cmd.Parameters.AddWithValue("@NgayTra", DateTime.Parse(textNgayTra.Text));

            cmd.ExecuteNonQuery();

            loaddata();
            MessageBox.Show("Đã sửa", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            cmd = cn.CreateCommand();
            cmd.CommandText = "delete from MuonSach  where MaMT ='" + textMaMT.Text + "'";

            cmd.ExecuteNonQuery();
            loaddata();
            MessageBox.Show("Đã xóa", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {

        }

        

        private void textNgayTra_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView3.CurrentRow.Index;
            textMaMT.Text = dataGridView3.Rows[i].Cells[0].Value.ToString();
            textNgayTra.Text = dataGridView3.Rows[i].Cells[1].Value.ToString();
          
            
            HienTrang.Text = dataGridView3.Rows[i].Cells[4].Value.ToString();
            
        }

        private void textMaDauSach_TextChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void txtLop_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNgonNgu_TextChanged(object sender, EventArgs e)
        {

        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void HienTrang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ptrIn_Click(object sender, EventArgs e)
        {
            // ptnInthe.Document = printDocument2;

            //ptnInthe.ShowDialog();
            /*if (ptnInthe.ShowDialog() == DialogResult.OK)
            {
                printDocument2.Print();
            }*/
            if (dataGridView2.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "DataDocGia.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Không thể ghi dữ liệu " + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dataGridView2.Columns.Count;
                            string columnNames = "";
                            string[] outputCsv = new string[dataGridView2.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dataGridView2.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; i  < dataGridView2.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCsv[i] += dataGridView2.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }

                            File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                            MessageBox.Show("Xuất dữ liệu thành công !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất !!!", "Info");
            }
        }

        private void btnChuaTra_Click(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("exec ChuaTra", cn);
            test = new DataTable("MuonSach");

            adapter.Fill(test);
            vtest = new DataView(test);
            dataGridView4.DataSource = vtest;
            MessageBox.Show("Đã xuất danh sách", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSachHong_Click(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("exec SachHong", cn);
            test = new DataTable("MuonSach");

            adapter.Fill(test);
            vtest = new DataView(test);
            dataGridView4.DataSource = vtest;
            MessageBox.Show("Đã xuất danh sách", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ptnInthe_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void btnInMuon_Click(object sender, EventArgs e)
        {
            if (dataGridView4.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "in.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Không thể ghi dữ liệu " + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dataGridView4.Columns.Count;
                            string columnNames = "";
                            string[] outputCsv = new string[dataGridView4.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dataGridView4.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; i < dataGridView4.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCsv[i] += dataGridView4.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }

                            File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                            MessageBox.Show("Xuất dữ liệu thành công !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất !!!", "Info");
            }
        }

        private void btnInTra_Click(object sender, EventArgs e)
        {
            if (dataGridView3.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "DataTra.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Không thể ghi dữ liệu " + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dataGridView3.Columns.Count;
                            string columnNames = "";
                            string[] outputCsv = new string[dataGridView3.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dataGridView3.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; i < dataGridView3.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCsv[i] += dataGridView3.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }

                            File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                            MessageBox.Show("Xuất dữ liệu thành công !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất !!!", "Info");
            }
        }
    }
}
