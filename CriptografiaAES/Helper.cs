using CriptografiaAES.Model;
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

            var ByteArray = UTF8Encoding.UTF8.GetBytes(Chave);
            var VetorChave = new byte[4, 4];
            for (int i = 0; i < ByteArray.Length; i++)
            {
                int Coluna = i / 4;
                int Linha = i % 4;
                VetorChave[Linha, Coluna] = ByteArray[i];
            }

            var ChaveOriginal = new RoundKey();
            var Keys = new RoundKey[11];
            Keys[0] = ChaveOriginal;

            for (int i = 0; i < 4; i++)
            {
                var Word = new Word(new byte[] { VetorChave[0, i], VetorChave[1, i], VetorChave[2, i], VetorChave[3, i] });
                ChaveOriginal.Palavras[i] = Word;
            }

            for (int i = 0; i < 10; i++)
            {

            }



            return Chaves;
        }

    }
}
