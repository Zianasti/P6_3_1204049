using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace P6_3_1204049
{
    public partial class Form1 : Form
    {
        string prodi;
        public Form1()
        {
            InitializeComponent();
            rbLakiLaki.Checked = false;
            rbPerempuan.Checked = false;

            SqlConnection myConnection = new SqlConnection(@"Data Source=ZIANASTI\ZIANASTI; Initial Catalog = P6_1204049; Integrated Security = True");

            myConnection.Open();

            SqlCommand myCommand = new SqlCommand("SELECT * FROM msprodi", myConnection);
            SqlDataReader reader;

            reader = myCommand.ExecuteReader();
            DataTable myDataTable = new DataTable();
            myDataTable.Columns.Add("id_prodi", typeof(string));
            myDataTable.Columns.Add("singkatan", typeof(string));
            myDataTable.Load(reader);

            cbProdi.ValueMember = "id_prodi";
            cbProdi.DisplayMember = "singkatan";
            cbProdi.DataSource = myDataTable;

            myConnection.Close();

            
        }

        private void tbNpm_Leave(object sender, EventArgs e)
        {
            
            if (tbNpm.TextLength == 7)
            {
                epCorrect.SetError(tbNpm, "Betul");
            }
            else if (tbNpm.Text == "")
            {
                epWarning.SetError(tbNpm, "Textbox NPM tidak boleh kosong !");
            }
            else
            {
                epWrong.SetError(tbNpm, "NPM berisi 7 digit angka !");
            }
        }

        private void tbNama_Leave(object sender, EventArgs e)
        {
            if (tbNama.Text == "")
            {
                epWarning.SetError(tbNama, "TextBox Nama tidak boleh kosong !");
            }
            else
            {
                epCorrect.SetError(tbNama, "Betul");
            }
        }

        private void tbAlamat_Leave(object sender, EventArgs e)
        {
            if (tbAlamat.Text == "")
            {
                epWarning.SetError(tbAlamat, "TextBox Alamat tidak boleh kosong !");
            }
            else
            {
                epCorrect.SetError(tbAlamat, "Betul");
            }
        }

        private void tbTelepon_Leave(object sender, EventArgs e)
        {
            if (tbTelepon.Text == "")
            {
                epWarning.SetError(tbTelepon, "TextBox No.Telepon tidak boleh kosong !");
            }
            else
            {
                epCorrect.SetError(tbTelepon, "Betul");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbNpm.Text !="" && tbNpm.TextLength == 7)
            {
                if (tbNama.Text != "")
                {
                    if(mcTglLahir.Text != "")
                    {
                        if(!rbLakiLaki.Checked || rbPerempuan.Checked)
                        {
                            if (tbAlamat.Text != "")
                            {
                                if (tbTelepon.Text != "")
                                {
                                    if (cbProdi.Text != "--Pilih Program Studi--")
                                    {
                                        string npm = tbNpm.Text;
                                        string nama = tbNama.Text;
                                        string tgllahir = mcTglLahir.Text;
                                        string jkelamin = "";
                                        if (rbLakiLaki.Checked)
                                        {
                                            jkelamin = rbLakiLaki.Text;
                                        }
                                        if (rbPerempuan.Checked)
                                        {
                                            jkelamin = rbPerempuan.Text;
                                        }
                                        string alamat = tbAlamat.Text;
                                        string telepon = tbTelepon.Text;
                                        string prodi = this.prodi;

                                        SqlConnection myConnection = new SqlConnection(@"Data Source=ZIANASTI\ZIANASTI; Initial Catalog = P6_1204049; Integrated Security = True");
                                        string sql = "INSERT INTO msmhs ([nim],[nama],[tgl_lahir],[jenis_kelamin],[alamat],"+"[telepon],[id_prodi]) VALUES (@npm,@nama,@tgllahir,@jkelamin,@alamat,@telepon,@idprodi)";

                                        using (SqlConnection Connection = new SqlConnection(@"Data Source = ZIANASTI\ZIANASTI; Initial Catalog = P6_1204049; Integrated Security=True"))
                                        {
                                            try
                                            {
                                                Connection.Open();

                                                using (SqlCommand command = new SqlCommand(sql, Connection))
                                                {
                                                    command.Parameters.Add("@npm", SqlDbType.VarChar).Value = npm;
                                                    command.Parameters.Add("@nama", SqlDbType.VarChar).Value = nama;
                                                    command.Parameters.Add("@tgllahir", SqlDbType.Date).Value = tgllahir;
                                                    command.Parameters.Add("@jkelamin", SqlDbType.VarChar).Value = jkelamin;
                                                    command.Parameters.Add("@alamat", SqlDbType.VarChar).Value = alamat;
                                                    command.Parameters.Add("@telepon", SqlDbType.VarChar).Value = telepon;
                                                    command.Parameters.Add("@idprodi", SqlDbType.VarChar).Value = prodi;

                                                    int rowsAdded = command.ExecuteNonQuery();
                                                    if (rowsAdded > 0)
                                                        MessageBox.Show("Data berhasil di simpan");
                                                    else
                                                        MessageBox.Show("Data tidak tersimpan");

                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show("ERROR:" + ex.Message);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Pilih Program Studi !", "Infromasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No. Telepon harus diisi !", "Infromasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Alamat harus diisi !", "Infromasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Pilih salah satu dari jenis kelamin !", "Infromasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tanggal Lahir harus diisi !", "Infromasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Nama harus diisi !", "Infromasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Nama harus diisi !", "Infromasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            tbNpm.Text = null;
            tbNama.Text = null;
            tbAlamat.Text = null;
            mcTglLahir.Text = null;
            tbTelepon.Text = null;
            rbLakiLaki.Checked = false;
            rbPerempuan.Checked = false;
            cbProdi.SelectedIndex = 0;
        }

        private void cbProdi_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.prodi = cbProdi.SelectedValue.ToString();
        }
    }
}
