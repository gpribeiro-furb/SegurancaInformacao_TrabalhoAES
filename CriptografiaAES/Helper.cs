using CriptografiaAES.Model;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
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

        private static byte[,] tabelaL = {
            { 0x00, 0x00, 0x19, 0x01, 0x32, 0x02, 0x1A, 0xC6, 0x4B, 0xC7, 0x1B, 0x68, 0x33, 0xEE, 0xDF, 0x03 },
            { 0x64, 0x04, 0xE0, 0x0E, 0x34, 0x8D, 0x81, 0xEF, 0x4C, 0x71, 0x08, 0xC8, 0xF8, 0x69, 0x1C, 0xC1 },
            { 0x7D, 0xC2, 0x1D, 0xB5, 0xF9, 0xB9, 0x27, 0x6A, 0x4D, 0xE4, 0xA6, 0x72, 0x9A, 0xC9, 0x09, 0x78 },
            { 0x65, 0x2F, 0x8A, 0x05, 0x21, 0x0F, 0xE1, 0x24, 0x12, 0xF0, 0x82, 0x45, 0x35, 0x93, 0xDA, 0x8E },
            { 0x96, 0x8F, 0xDB, 0xBD, 0x36, 0xD0, 0xCE, 0x94, 0x13, 0x5C, 0xD2, 0xF1, 0x40, 0x46, 0x83, 0x38 },
            { 0x66, 0xDD, 0xFD, 0x30, 0xBF, 0x06, 0x8B, 0x62, 0xB3, 0x25, 0xE2, 0x98, 0x22, 0x88, 0x91, 0x10 },
            { 0x7E, 0x6E, 0x48, 0xC3, 0xA3, 0xB6, 0x1E, 0x42, 0x3A, 0x6B, 0x28, 0x54, 0xFA, 0x85, 0x3D, 0xBA },
            { 0x2B, 0x79, 0x0A, 0x15, 0x9B, 0x9F, 0x5E, 0xCA, 0x4E, 0xD4, 0xAC, 0xE5, 0xF3, 0x73, 0xA7, 0x57 },
            { 0xAF, 0x58, 0xA8, 0x50, 0xF4, 0xEA, 0xD6, 0x74, 0x4F, 0xAE, 0xE9, 0xD5, 0xE7, 0xE6, 0xAD, 0xE8 },
            { 0x2C, 0xD7, 0x75, 0x7A, 0xEB, 0x16, 0x0B, 0xF5, 0x59, 0xCB, 0x5F, 0xB0, 0x9C, 0xA9, 0x51, 0xA0 },
            { 0x7F, 0x0C, 0xF6, 0x6F, 0x17, 0xC4, 0x49, 0xEC, 0xD8, 0x43, 0x1F, 0x2D, 0xA4, 0x76, 0x7B, 0xB7 },
            { 0xCC, 0xBB, 0x3E, 0x5A, 0xFB, 0x60, 0xB1, 0x86, 0x3B, 0x52, 0xA1, 0x6C, 0xAA, 0x55, 0x29, 0x9D },
            { 0x97, 0xB2, 0x87, 0x90, 0x61, 0xBE, 0xDC, 0xFC, 0xBC, 0x95, 0xCF, 0xCD, 0x37, 0x3F, 0x5B, 0xD1 },
            { 0x53, 0x39, 0x84, 0x3C, 0x41, 0xA2, 0x6D, 0x47, 0x14, 0x2A, 0x9E, 0x5D, 0x56, 0xF2, 0xD3, 0xAB },
            { 0x44, 0x11, 0x92, 0xD9, 0x23, 0x20, 0x2E, 0x89, 0xB4, 0x7C, 0xB8, 0x26, 0x77, 0x99, 0xE3, 0xA5 },
            { 0x67, 0x4A, 0xED, 0xDE, 0xC5, 0x31, 0xFE, 0x18, 0x0D, 0x63, 0x8C, 0x80, 0xC0, 0xF7, 0x70, 0x07 },
        };

        private static byte[,] tabelaE = {
            { 0x01, 0x03, 0x05, 0x0F, 0x11, 0x33, 0x55, 0xFF, 0x1A, 0x2E, 0x72, 0x96, 0xA1, 0xF8, 0x13, 0x35 },
            { 0x5F, 0xE1, 0x38, 0x48, 0xD8, 0x73, 0x95, 0xA4, 0xF7, 0x02, 0x06, 0x0A, 0x1E, 0x22, 0x66, 0xAA },
            { 0xE5, 0x34, 0x5C, 0xE4, 0x37, 0x59, 0xEB, 0x26, 0x6A, 0xBE, 0xD9, 0x70, 0x90, 0xAB, 0xE6, 0x31 },
            { 0x53, 0xF5, 0x04, 0x0C, 0x14, 0x3C, 0x44, 0xCC, 0x4F, 0xD1, 0x68, 0xB8, 0xD3, 0x6E, 0xB2, 0xCD },
            { 0x4C, 0xD4, 0x67, 0xA9, 0xE0, 0x3B, 0x4D, 0xD7, 0x62, 0xA6, 0xF1, 0x08, 0x18, 0x28, 0x78, 0x88 },
            { 0x83, 0x9E, 0xB9, 0xD0, 0x6B, 0xBD, 0xDC, 0x7F, 0x81, 0x98, 0xB3, 0xCE, 0x49, 0xDB, 0x76, 0x9A },
            { 0xB5, 0xC4, 0x57, 0xF9, 0x10, 0x30, 0x50, 0xF0, 0x0B, 0x1D, 0x27, 0x69, 0xBB, 0xD6, 0x61, 0xA3 },
            { 0xFE, 0x19, 0x2B, 0x7D, 0x87, 0x92, 0xAD, 0xEC, 0x2F, 0x71, 0x93, 0xAE, 0xE9, 0x20, 0x60, 0xA0 },
            { 0xFB, 0x16, 0x3A, 0x4E, 0xD2, 0x6D, 0xB7, 0xC2, 0x5D, 0xE7, 0x32, 0x56, 0xFA, 0x15, 0x3F, 0x41 },
            { 0xC3, 0x5E, 0xE2, 0x3D, 0x47, 0xC9, 0x40, 0xC0, 0x5B, 0xED, 0x2C, 0x74, 0x9C, 0xBF, 0xDA, 0x75 },
            { 0x9F, 0xBA, 0xD5, 0x64, 0xAC, 0xEF, 0x2A, 0x7E, 0x82, 0x9D, 0xBC, 0xDF, 0x7A, 0x8E, 0x89, 0x80 },
            { 0x9B, 0xB6, 0xC1, 0x58, 0xE8, 0x23, 0x65, 0xAF, 0xEA, 0x25, 0x6F, 0xB1, 0xC8, 0x43, 0xC5, 0x54 },
            { 0xFC, 0x1F, 0x21, 0x63, 0xA5, 0xF4, 0x07, 0x09, 0x1B, 0x2D, 0x77, 0x99, 0xB0, 0xCB, 0x46, 0xCA },
            { 0x45, 0xCF, 0x4A, 0xDE, 0x79, 0x8B, 0x86, 0x91, 0xA8, 0xE3, 0x3E, 0x42, 0xC6, 0x51, 0xF3, 0x0E },
            { 0x12, 0x36, 0x5A, 0xEE, 0x29, 0x7B, 0x8D, 0x8C, 0x8F, 0x8A, 0x85, 0x94, 0xA7, 0xF2, 0x0D, 0x17 },
            { 0x39, 0x4B, 0xDD, 0x7C, 0x84, 0x97, 0xA2, 0xFD, 0x1C, 0x24, 0x6C, 0xB4, 0xC7, 0x52, 0xF6, 0x01 },
        };

        private static int[,] matrizMultiplicacao = {
            { 2, 3, 1, 1 },
            { 1, 2, 3, 1 },
            { 1, 1, 2, 3 },
            { 3, 1, 1, 2 }
        };

        private static List<char> alfabetoHex = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        public static byte[] chave { get; set; }
        private static List<Word> chavesExpandidas { get; set; }

        public static string Encriptografar(string caminhoArquivo)
        {
            if (chave == null)
                throw new NullReferenceException("Informe uma chave de encriptação");

            var arquivoEncriptografado = "";

            chavesExpandidas = ExpensaoDeChave();

            var textoSimplesTeste = UTF8Encoding.UTF8.GetBytes("DESENVOLVIMENTO!");
            var textoSimples = File.ReadAllBytes(caminhoArquivo);
            var resultadoEncriptado = Cifragem(textoSimples);
            var resultadoHex = BitConverter.ToString(resultadoEncriptado).Replace("-", "");

            return resultadoHex;
        }

        private static List<Word> ExpensaoDeChave()
        {
            // Transforma a chave de String para um array de bytes
            var byteArray = UTF8Encoding.UTF8.GetBytes("ABCDEFGHIJKLMNOP");

            // Transforma o array de bytes em um vetor (igual o conteúdo)
            var vetorChave = new byte[4, 4];
            for (int i = 0; i < chave.Length; i++)
            {
                int coluna = i / 4;
                int linha = i % 4;
                vetorChave[linha, coluna] = chave[i];
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
                var wordB = palavras[i];

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
                    newWord = XOR(newWord, wordB);
                }
                else
                {
                    newWord = XOR(wordB, wordA);
                }

                palavras[i + 4] = newWord;
            }


            return palavras.ToList();
        }

        public static byte[] Cifragem(byte[] textoSimples)
        {
            var blocos = SepararPorBlocos(textoSimples);

            var blocosCriptografados = new List<byte[,]>();
            foreach (var item in blocos)
            {
                //Passo 1
                var chave0 = GetChaveByIndex(0);
                var blocoA = XOR(item, chave0);
                byte[,] blocoB;
                byte[,] blocoC;

                for (int i = 1; i < 10; i++)
                {
                    //Passo 2
                    blocoB = AplicarSBox(blocoA);
                    var blocoBTexto = BlocoToString(blocoB);
                    //Passo 3
                    blocoC = ShiftRows(blocoB);
                    var blocoCTexto = BlocoToString(blocoC);
                    //Passo 4
                    var blocoD = MixColumns(blocoC);
                    var blocoDTexto = BlocoToString(blocoD);
                    //Passo 5
                    var chaveUsada = GetChaveByIndex(i);
                    var chaveUsadaTexto = BlocoToString(chaveUsada);
                    blocoA = XOR(blocoD, chaveUsada);
                    var blocoATexto = BlocoToString(blocoA);
                    var a = 2;
                }

                blocoB = AplicarSBox(blocoA);
                blocoC = ShiftRows(blocoB);
                var resultadoFinal = XOR(blocoC, GetChaveByIndex(10));

                blocosCriptografados.Add(resultadoFinal);
            }

            var bytesCriptografados = new byte[16 * blocosCriptografados.Count];
            for (int i = 0; i < blocosCriptografados.Count; i++)
            {
                var bloco = BlocoToByteArray(blocosCriptografados[i]);
                for (int j = 0; j < 16; j++)
                {
                    bytesCriptografados[i * 16 + j] = bloco[j];
                }
            }

            return bytesCriptografados;
        }

        public static List<byte[,]> SepararPorBlocos(byte[] byteArray)
        {
            var blocos = new List<byte[,]>();
            var bloco = new byte[4, 4];

            var byteList = byteArray.ToList();
            var qntdPadding = 16 - (byteArray.Length % 16);
            if (qntdPadding == 16)
            {
                byteList.AddRange(new List<byte> {
                    0x10, 0x10, 0x10, 0x10,
                    0x10, 0x10, 0x10, 0x10,
                    0x10, 0x10, 0x10, 0x10,
                    0x10, 0x10, 0x10, 0x10
                });
            }
            else
            {
                for (int indexPadding = 0; indexPadding < qntdPadding; indexPadding++)
                {
                    byteList.Add((byte)qntdPadding);
                }
            }

            for (int i = 0; i < byteList.Count; i++)
            {
                var index = i >= 16 ? i % 16 : i;
                var linha = index % 4;
                var coluna = (int)Math.Floor((double)index / 4d);

                bloco[linha, coluna] = byteList[i];
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

        private static byte[,] AplicarSBox(byte[,] bloco)
        {
            var novoBloco = new byte[4, 4];
            for (int coluna = 0; coluna < 4; coluna++)
            {
                for (int linha = 0; linha < 4; linha++)
                {
                    var valor = bloco[linha, coluna];
                    var byteEmTexto = BitConverter.ToString(new byte[] { valor }).Split("-");
                    novoBloco[linha, coluna] = GetFromSBox(byteEmTexto[0]);
                }
            }


            return novoBloco;
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

            var valor = Math.Pow(2, index);
            valor = valor == 256 ? 27 : valor == 512 ? 54 : valor;
            roundConstant.Bytes = new byte[] { (byte)valor, 0, 0, 0 };

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
                    bloco[j, i] = word.Bytes[j];
                }
            }

            return bloco;
        }

        private static byte[,] ShiftRows(byte[,] bloco)
        {
            var novoBloco = new byte[4, 4];

            novoBloco[0, 0] = bloco[0, 0];
            novoBloco[0, 1] = bloco[0, 1];
            novoBloco[0, 2] = bloco[0, 2];
            novoBloco[0, 3] = bloco[0, 3];

            novoBloco[1, 0] = bloco[1, 1];
            novoBloco[1, 1] = bloco[1, 2];
            novoBloco[1, 2] = bloco[1, 3];
            novoBloco[1, 3] = bloco[1, 0];

            novoBloco[2, 0] = bloco[2, 2];
            novoBloco[2, 1] = bloco[2, 3];
            novoBloco[2, 2] = bloco[2, 0];
            novoBloco[2, 3] = bloco[2, 1];

            novoBloco[3, 0] = bloco[3, 3];
            novoBloco[3, 1] = bloco[3, 0];
            novoBloco[3, 2] = bloco[3, 1];
            novoBloco[3, 3] = bloco[3, 2];

            return novoBloco;
        }

        private static byte[,] MixColumns(byte[,] bloco)
        {
            var blocoR = new byte[4, 4];

            for (int coluna = 0; coluna < 4; coluna++)
            {
                for (int linha = 0; linha < 4; linha++)
                {
                    var valor = bloco[linha, coluna];
                    var byteEmTexto = BitConverter.ToString(new byte[] { valor }).Split("-");
                    blocoR[linha, coluna] = byteEmTexto[0] == "01" ? (byte)0x01 : GetFromTabelaL(byteEmTexto[0]);
                }
            }

            var blocoResultado = new byte[4, 4];

            for (int coluna = 0; coluna < 4; coluna++)
            {
                for (int linha = 0; linha < 4; linha++)
                {
                    var multiplicador1 = matrizMultiplicacao[linha, 0];
                    var multiplicador2 = matrizMultiplicacao[linha, 1];
                    var multiplicador3 = matrizMultiplicacao[linha, 2];
                    var multiplicador4 = matrizMultiplicacao[linha, 3];
                    var resultado1 = multiplicador1 > 1 ? MultiplicarBytes(bloco[0, coluna], blocoR[0, coluna], multiplicador1) : bloco[0, coluna];
                    var resultado2 = multiplicador2 > 1 ? MultiplicarBytes(bloco[1, coluna], blocoR[1, coluna], multiplicador2) : bloco[1, coluna];
                    var resultado3 = multiplicador3 > 1 ? MultiplicarBytes(bloco[2, coluna], blocoR[2, coluna], multiplicador3) : bloco[2, coluna];
                    var resultado4 = multiplicador4 > 1 ? MultiplicarBytes(bloco[3, coluna], blocoR[3, coluna], multiplicador4) : bloco[3, coluna];

                    var resultado1E = bloco[0, coluna] == 0 ? 0 : multiplicador1 > 1 && bloco[0, coluna] != 0x01 ? GetFromTabelaE(resultado1) : resultado1;
                    var resultado2E = bloco[1, coluna] == 0 ? 0 : multiplicador2 > 1 && bloco[1, coluna] != 0x01 ? GetFromTabelaE(resultado2) : resultado2;
                    var resultado3E = bloco[2, coluna] == 0 ? 0 : multiplicador3 > 1 && bloco[2, coluna] != 0x01 ? GetFromTabelaE(resultado3) : resultado3;
                    var resultado4E = bloco[3, coluna] == 0 ? 0 : multiplicador4 > 1 && bloco[3, coluna] != 0x01 ? GetFromTabelaE(resultado4) : resultado4;

                    var xor1 = (byte)(resultado1E ^ resultado2E);
                    var xor2 = (byte)(resultado3E ^ resultado4E);
                    var byteResultado = (byte)(xor1 ^ xor2);

                    blocoResultado[linha, coluna] = byteResultado;
                }
            }

            return blocoResultado;
        }

        private static byte MultiplicarBytes(byte byteOriginal, byte byteR, int valor)
        {
            if (valor == 0 || byteOriginal == 0)
            {
                return 0x00;
            }
            else if (valor == 1)
            {
                return byteOriginal;
            }
            else if (byteOriginal == 0x01)
            {
                return (byte)valor;
            }

            var segundoByte = tabelaL[0, valor];
            var resultado = (byte)(byteR + segundoByte);

            //Dúvida:
            if (byteR >= 0xE7 && resultado < 0xE7)
            {
                resultado += 0x01;
            }

            return resultado;
        }

        private static byte GetFromTabelaL(string posicao)
        {
            var letraLinha = posicao[0];
            var letraColuna = posicao[1];
            var linha = alfabetoHex.IndexOf(letraLinha);
            var coluna = alfabetoHex.IndexOf(letraColuna);

            return tabelaL[linha, coluna];
        }
        private static byte GetFromTabelaE(byte valorEmByte)
        {
            var posicao = BitConverter.ToString(new byte[] { valorEmByte }).Split("-")[0];
            var letraLinha = posicao[0];
            var letraColuna = posicao[1];
            var linha = alfabetoHex.IndexOf(letraLinha);
            var coluna = alfabetoHex.IndexOf(letraColuna);

            return tabelaE[linha, coluna];
        }

        private static byte[] BlocoToByteArray(byte[,] bloco)
        {
            var byteArray = new byte[16];

            var index = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    byteArray[index] = bloco[j, i];
                    index++;
                }
            }

            return byteArray;
        }

        private static string BlocoToString(byte[,] bloco)
        {
            string hexString = "";

            for (int row = 0; row < bloco.GetLength(0); row++)
            {
                for (int col = 0; col < bloco.GetLength(1); col++)
                {
                    hexString += bloco[col, row].ToString("X2");
                }
                hexString += " ";
            }

            return hexString.ToLower();
        }
    }
}
