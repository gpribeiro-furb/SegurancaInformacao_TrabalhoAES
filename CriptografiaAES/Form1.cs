namespace CriptografiaAES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Helper.Chave = "ABCDEFGHIJKLMNOP";
            Helper.Encriptografar("C:\\Users\\panca\\OneDrive\\�rea de Trabalho\\Coisas\\Furb\\Seguran�a\\resumo.txt");
        }
    }
}