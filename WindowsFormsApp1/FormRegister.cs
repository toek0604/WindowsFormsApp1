using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp1
{
    public partial class FormRegister : Form
    {
        string Koneksi = "server=localhost;username=root;password=;database=db_apotek_petugas";
        public FormRegister()
        {
            InitializeComponent();
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection konfigurasi = new MySqlConnection(Koneksi);
            MySqlCommand komando = new MySqlCommand();
            try
            {
                konfigurasi.Open();
                string query = "INSERT INTO `tb_apoteker` (`id_petugas`, `username`, `password`, `nama_petugas`, `shift`, `role`, `status_aktif`) VALUES (@id_petugas, @nama_petugas, @username, @password, @shift, @role)";
                MySqlCommand cmd = new MySqlCommand(Koneksi, konfigurasi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new MySqlParameter("@Username", textBox1.Text));
                cmd.Parameters.Add(new MySqlParameter("@Password", textBox2.Text));
                cmd.Parameters.Add(new MySqlParameter("@Confirm Password", textBox3.Text));
                if(textBox1 == textBox3)
                {
                    MessageBox.Show("password dan konfirmasi benar");
                }
                else
                {
                    MessageBox.Show("password dan konfirmasi salah");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }

                cmd.ExecuteNonQuery();
                MessageBox.Show("data berhasil di simpan", "sukses", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception)
            {
                konfigurasi.Close();
            }
            MessageBox.Show("gagal menyimpan data. pesan kesalahan:" + "kesalahan");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(Koneksi);
            string query = "SELECT @role FOrM tb_petugas";
            MySqlCommand cmd = new MySqlCommand(query, con);

        }
    }
}
