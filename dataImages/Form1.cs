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
                btnRead.Enabled = true;
                path = ofd.FileName;
                txtFile.Text = path;
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            BinaryReader br = new BinaryReader(File.OpenRead(path));
            //txtData.Text = br.ReadChar().ToString();
            //foreach (char myChar in br.ReadChars(6)) txtData.Text += myChar;
            br.BaseStream.Position = 0x00;
            byte[] buffer = br.ReadBytes(12);
            Array.Reverse(buffer);
            txtData.Text=BitConverter.ToInt32(buffer, 0).ToString("x");
            br.Dispose();
        }
    }
}