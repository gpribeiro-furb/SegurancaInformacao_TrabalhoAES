namespace CriptografiaAES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = !checkBox1.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = sfd.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var chave = textBox2.Text.Split(',').Select(x => byte.Parse(x)).ToArray();
            Helper.chave = chave;
            textBox4.Text = Helper.Encriptografar(textBox1.Text);
        }
    }
}