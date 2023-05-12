using System;
using System.Security.Cryptography;

namespace dataImages
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string path;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = ofd.FileName;
                path = ofd.FileName;
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            //foreach (char c in br.ReadChars(5)) txtData.Text += c;

            //txtData.Text += "\r\n";

            br.BaseStream.Position = 0x00;
            byte[] bytes = br.ReadBytes(10);
            //MessageBox.Show(bytes.Length+"");
            //foreach (char c in bytes) txtData.Text += c;
            //txtData.Text += "\r\n";
            //txtData.Text += BitConverter.ToString(bytes);
            //txtData.Text += "\r\n";
            Array.Reverse(bytes);
            //foreach (char c in bytes) txtData.Text += c;
            //txtData.Text += "\r\n";
            txtData.Text += BitConverter.ToString(bytes);
            //txtData.Text += "\r\n";
            // foreach (byte c in bytes) txtData.Text += BitConverter.ToInt16(c).ToString();
            //txtData.Text += BitConverter.ToInt64(bytes, 0).ToString("x");
            br.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtFile.Text = @"C:\Users\ckarlos\OneDrive\Escritorio\fileTest.bin";
            txtFile.Focus();
            path = txtFile.Text;
        }
    }
}