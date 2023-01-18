using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace KlasorOlusturucu
{
    public partial class Form1 : Form
    {
        private string path;

        public Form1()
        {
            InitializeComponent();
            txtSelected.Enabled = false;
            nmfolderCount.Enabled = false;
            folderName.Enabled = false;
            label3.Text = "Created By : RESUL KARTAL";


        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        private void btnTikla_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            DialogResult dialogResult = fbd.ShowDialog();
            if (dialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {

                path = fbd.SelectedPath;
                txtSelected.Text = path;

                nmfolderCount.Enabled = true;
                folderName.Enabled = true;
            }
            else
            {
                MessageBox.Show("The selection process failed.");
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int folderCount = Convert.ToInt32(nmfolderCount.Value);
                for (int i = 1; i <= folderCount; i++)
                {
                    string newpath = @"" + path + "\\" + folderName.Text + "-" + i;
                    Directory.CreateDirectory(newpath);
                }
                MessageBox.Show("Folder creation is successful.", "SUCCESS");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured.", "ERROR!" + ex);
            }



        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        
    }
}
