using CriptografiaAES.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace CriptografiaAES
{
    internal class Helper
    {
        private static byte[,] sBox = {
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

        private static List<char> alfabetoHex = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        public static string chave { get; set; }
        private static List<Word> chavesExpandidas { get; set; }

        public static string Encriptografar(string caminhoArquivo)
        {
            if (chave == null)
                throw new NullReferenceException("Informe uma chave de encriptação");

            var arquivoEncriptografado = "";

            chavesExpandidas = ExpensaoDeChave();

            var textoSimples = UTF8Encoding.UTF8.GetBytes("DESENVOLVIMENTO!");
            var resultadoEncriptado = Cifragem(textoSimples);

            return arquivoEncriptografado;
        }

        private static List<Word> ExpensaoDeChave()
        {
            // Transforma a chave de String para um array de bytes
            var byteArray = UTF8Encoding.UTF8.GetBytes(chave);

            // Transforma o array de bytes em um vetor (igual o conteúdo)
            var vetorChave = new byte[4, 4];
            for (int i = 0; i < byteArray.Length; i++)
            {
                int coluna = i / 4;
                int linha = i % 4;
                vetorChave[linha, coluna] = byteArray[i];
            }

            // Criando o as 11 round keys
            var palavras = new Word[44];

            // Montando a chave original
            for (int i = 0; i < 4; i++)
            {
                var palavra = new Word();
                palavra.Bytes = new byte[] { vetorChave[0, i],
                                             vetorChave[1, i],
                                             vetorChave[2, i],
                                             vetorChave[3, i] };

                palavras[i] = palavra;
            }

            // Criando as outras 10 keys
            for (int i = 0; i < 40; i++)
            {
                // Cada word (que não é a primeira) das próximas keys é o XOR da palavra diretamente anterior
                // com a palavra da mesma posição da atual, da chave anterior
                // w4 = w0 XOR w3
                // w5 = w1 XOR w4

                // A primeira palavra de cada KEY é feita com todos esses passos:
                Word newWord;
                var wordA = palavras[i + 3];

                if (i % 4 == 0)
                {
                    // Passo 2
                    newWord = RotWord(wordA);

                    // Passo 3
                    newWord = AplicarSBox(newWord);

                    // Passo 4
                    var keyIndex = Math.Floor((double)i / 4d);
                    var roundConstant = GerarRoundConstant(keyIndex);

                    // Passo 5
                    newWord = XOR(newWord, roundConstant);
                } else
                {
                    var wordB = palavras[i];

                    newWord = XOR(wordB, wordA);
                }

                palavras[i + 4] = newWord;
            }


            return palavras.ToList();
        }

        public static byte[] Cifragem(byte[] textoSimples)
        {
            var blocos = SepararPorBlocos(textoSimples);

            var blocosEncriptografados = new List<byte[,]>();
            foreach (var item in blocos)
            {
                //Passo 1
                var chave0 = GetChaveByIndex(0);
                var blocoA = XOR(item, chave0);
                var a = 2;


            }

            return textoSimples;
        }

        public static List<byte[,]> SepararPorBlocos(byte[] byteArray)
        {
            var blocos = new List<byte[,]>();
            var bloco = new byte[4, 4];
            for (int i = 0; i < byteArray.Length; i++)
            {
                var linha = i % 4;
                var coluna = (int)Math.Floor((double)i / 4d);

                bloco[coluna, linha] = byteArray[i];
                if (i > 0 && (i + 1) % 16 == 0)
                {
                    blocos.Add(bloco);
                    bloco = new byte[4, 4];
                }
            }

            return blocos;
        }

        private static Word XOR(Word wordA, Word wordB)
        {
            var arrayA = wordA.Bytes;
            var arrayB = wordB.Bytes;

            if (arrayA.Length == arrayB.Length)
            {
                byte[] resultado = new byte[arrayA.Length];
                for (int i = 0; i < arrayA.Length; i++)
                {
                    resultado[i] = (byte)(arrayA[i] ^ arrayB[i]);
                }
                return new Word(resultado);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private static byte[,] XOR(byte[,] bytesA, byte[,] bytesB)
        {
            int linhas = bytesA.GetLength(0);
            int colunas = bytesA.GetLength(1);

            if (linhas != bytesB.GetLength(0) || colunas != bytesB.GetLength(1))
            {
                throw new ArgumentException();
            }

            byte[,] resultado = new byte[linhas, colunas];

            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    resultado[i, j] = (byte)(bytesA[i, j] ^ bytesB[i, j]);
                }
            }

            return resultado;
        }

        private static Word RotWord(Word word)
        {
            return new Word(new byte[] { word.Bytes[1], word.Bytes[2], word.Bytes[3], word.Bytes[0] });
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
            var linha = alfabetoHex.IndexOf(letraLinha);
            var coluna = alfabetoHex.IndexOf(letraColuna);

            return sBox[linha, coluna];
        }

        private static Word GerarRoundConstant(double index)
        {
            var roundConstant = new Word();

            roundConstant.Bytes = new byte[] { 0, 0, 0, (byte)Math.Pow(2, index) };

                return roundConstant;
        }

        private static byte[,] GetChaveByIndex(int index)
        {
            index *= 4;
            var bloco = new byte[4, 4];

            for (int i = 0; i < 4; i++)
            {
                var word = chavesExpandidas[index + i];
                for (int j = 0; j < 4; j++)
                {
                    bloco[i, j] = word.Bytes[j];
                }
            }

            return bloco;
        }
    }
}
