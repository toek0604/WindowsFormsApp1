using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Formlogin : Form
    {
        string Koneksi = "server=localhost;username=root;password=;database=db_apotek_petugas";
        public Formlogin()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection konfigurasi = new MySqlConnection(Koneksi);
            try
            {
                string username = textBox1.Text;
                string password = textBox2.Text;
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("username dan password tidak boleh kosong");
                    textBox2.Focus();
                    return;

                }
                konfigurasi.Open();
                string query = "SELECT usernsme,password,status_aktif from tb_apoteker WHERE username = @username limit 1";
                MySqlCommand cmd = new MySqlCommand(query, konfigurasi);
                cmd.Parameters.AddWithValue("@username", username);
                MySqlDataReader hasil = cmd.ExecuteReader();
                if (hasil.Read())
                {
                    if (password == hasil["password"].ToString())
                    {
                        FormDashboard formDashboard = new FormDashboard();
                        formDashboard.FormClosed += FormDashboard_FormClosed;
                        formDashboard.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("password salah!");
                    }
                }
                else
                {
                    MessageBox.Show("username tidak di temukan");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("terjadi kesalahan!:" + ex.Message);
            }
        }
        

        private void FormDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
