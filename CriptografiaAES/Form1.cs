namespace CriptografiaAES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Helper.Chave = "ABCDEFGHIJKLMNOP";
            Helper.Encriptografar("C:\\Users\\panca\\OneDrive\\Área de Trabalho\\Coisas\\Furb\\Segurança\\resumo.txt");
        }
    }
}