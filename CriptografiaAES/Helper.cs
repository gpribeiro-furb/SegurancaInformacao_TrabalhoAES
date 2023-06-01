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
        private static byte[,] SBox = {
            { 0x63, 0x7C, 0x77, 0x7B, 0xF2, 0x6B, 0x6F, 0xC5, 0x30, 0x01, 0x67, 0x2B, 0xFE, 0xD7, 0xAB, 0x76 },
            { 0xCA, 0x82, 0xC9, 0x7D, 0xFA, 0x59, 0x47, 0xF0, 0xAD, 0xD4, 0xA2, 0xAF, 0x9C, 0xA4, 0x72, 0xC0 },
            { 0xB7, 0xFD, 0x93, 0x26, 0x36, 0x3F, 0xF7, 0xCC, 0x34, 0xA5, 0xE5, 0xF1, 0x71, 0xD8, 0x31, 0x15 },
            { 0x04, 0xC7, 0x23, 0xC3, 0x18, 0x96, 0x05, 0x9A, 0x07, 0x12, 0x80, 0xE2, 0xEB, 0x27, 0xB2, 0x75 },
            { 0x09, 0x83, 0x2C, 0x1A, 0x1B, 0x6E, 0x5A, 0xA0, 0x52, 0x3B, 0xD6, 0xB3, 0x29, 0xE3, 0x2F, 0x84 },
            { 0x53, 0xD1, 0x00, 0xED, 0x20, 0xFC, 0xB1, 0x5B, 0x6A, 0xCB, 0xBE, 0x39, 0x4A, 0x4C, 0x58, 0xCF },
            { 0xD0, 0xEF, 0xAA, 0xFB, 0x43, 0x4D, 0x33, 0x85, 0x45, 0xF9, 0x02, 0x7F, 0x50, 0x3C, 0x9F, 0xA8 },
            { 0x51, 0xA3, 0x40, 0x8F, 0x92, 0x9D, 0x38, 0xF5, 0xBC, 0xB6, 0xDA, 0x21, 0x10, 0xFF, 0xF3, 0xD2 },
            { 0xCD, 0x0C, 0x13, 0xEC, 0x5F, 0x97, 0x44, 0x17, 0xC4, 0xA7, 0x7E, 0x3D, 0x64, 0x5D, 0x19, 0x73 },
            { 0x60, 0x81, 0x4F, 0xDC, 0x22, 0x2A, 0x90, 0x88, 0x46, 0xEE, 0xB8, 0x14, 0xDE, 0x5E, 0x0B, 0xDB },
            { 0xE0, 0x32, 0x3A, 0x0A, 0x49, 0x06, 0x24, 0x5C, 0xC2, 0xD3, 0xAC, 0x62, 0x91, 0x95, 0xE4, 0x79 },
            { 0xE7, 0xC8, 0x37, 0x6D, 0x8D, 0xD5, 0x4E, 0xA9, 0x6C, 0x56, 0xF4, 0xEA, 0x65, 0x7A, 0xAE, 0x08 },
            { 0xBA, 0x78, 0x25, 0x2E, 0x1C, 0xA6, 0xB4, 0xC6, 0xE8, 0xDD, 0x74, 0x1F, 0x4B, 0xBD, 0x8B, 0x8A },
            { 0x70, 0x3E, 0xB5, 0x66, 0x48, 0x03, 0xF6, 0x0E, 0x61, 0x35, 0x57, 0xB9, 0x86, 0xC1, 0x1D, 0x9E },
            { 0xE1, 0xF8, 0x98, 0x11, 0x69, 0xD9, 0x8E, 0x94, 0x9B, 0x1E, 0x87, 0xE9, 0xCE, 0x55, 0x28, 0xDF },
            { 0x8C, 0xA1, 0x89, 0x0D, 0xBF, 0xE6, 0x42, 0x68, 0x41, 0x99, 0x2D, 0x0F, 0xB0, 0x54, 0xBB, 0x16 },
        };

        private static List<char> AlfabetoHex = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
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

            // Transforma a chave de String para um array de bytes
            var ByteArray = UTF8Encoding.UTF8.GetBytes(Chave);

            // Transforma o array de bytes em um vetor (igual o conteúdo)
            var VetorChave = new byte[4, 4];
            for (int i = 0; i < ByteArray.Length; i++)
            {
                int Coluna = i / 4;
                int Linha = i % 4;
                VetorChave[Linha, Coluna] = ByteArray[i];
            }

            // Criando o as 11 round keys
            var Palavras = new Word[44];

            // Montando a chave original
            for (int i = 0; i < 4; i++)
            {
                var Palavra = new Word();
                Palavra.Bytes = new byte[] { VetorChave[0, i],
                                             VetorChave[1, i],
                                             VetorChave[2, i],
                                             VetorChave[3, i] };

                Palavras[i] = Palavra;
            }

            // Criando as outras 10 keys
            for (int i = 0; i < 40; i++)
            {
                // Cada word das próximas keys é o XOR da palavra diretamente anterior
                // com a palavra da mesma posição da atual, da chave anterior
                // w4 = w0 XOR w3
                // w5 = w1 XOR w4
                var wordA = Palavras[i];
                var wordB = Palavras[i + 3];

                RotWord(wordB);

                AplicarSBox(wordB);



                var newWord = XOR(wordA, wordB); // ?

                Palavras[i + 4] = newWord;
            }


            return Chaves;
        }

        private static Word XOR(Word wordA, Word wordB)
        {
            var arrayA = wordA.Bytes;
            var arrayB = wordB.Bytes;

            if (arrayA.Length == arrayB.Length)
            {
                byte[] result = new byte[arrayA.Length];
                for (int i = 0; i < arrayA.Length; i++)
                {
                    result[i] = (byte)(arrayA[i] ^ arrayB[i]);
                }
                return new Word(result);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private static Word RotWord(Word word)
        {
            var tempByte = word.Bytes[0];

            word.Bytes[0] = word.Bytes[1];
            word.Bytes[1] = word.Bytes[2];
            word.Bytes[2] = word.Bytes[3];
            word.Bytes[3] = tempByte;

            return word;
        }
        private static Word AplicarSBox(Word word)
        {
            var newWord = new Word(new byte[4]);
            var bytes = BitConverter.ToString(word.Bytes).Split("-");
            for (int i = 0; i < 4; i++)
            {
                newWord.Bytes[i] = GetFromSBox(bytes[i]);
            }

            return newWord;
        }

        private static byte GetFromSBox(string posicao)
        {
            var letraLinha = posicao[0];
            var letraColuna = posicao[1];
            var linha = AlfabetoHex.IndexOf(letraLinha);
            var coluna = AlfabetoHex.IndexOf(letraColuna);

            return SBox[linha, coluna];
        }
    }
}
