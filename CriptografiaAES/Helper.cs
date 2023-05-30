using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriptografiaAES
{
    internal class Helper
    {
        public static string Chave { get; set; }

        public static string Encriptografar(string CaminhoArquivo)
        {
            if (Chave == null)
                throw new NullReferenceException("Informe uma chave de encriptação");

            var ArquivoEncriptografado = "";

            var Chaves = ExpensaoDeChave();

            return ArquivoEncriptografado;
        }

        private static List<string> ExpensaoDeChave()
        {
            var Chaves = new List<string>();

            return Chaves;
        }
    }
}
