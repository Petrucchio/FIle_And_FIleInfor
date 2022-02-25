using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files_And_Streams.StringReader_and_StringWriter
{
    internal class stringWriter
    {
        static void Main(string[] args)
        {
            string textReaderText = "TextReader é a classe base abstrata " +
              "de StreamReader e StringReader, que lê caracteres " +
              "de streams e strings, respectivamente.\n\n" +

              "Crie uma instância de TextReader para abrir um arquivo de texto " +
              "para ler um intervalo especificado de caracteres " +
              "ou para criar um leitor baseado em um fluxo existente.\n\n" +

              "Você também pode usar uma instância de TextReader para ler " +
              "texto de um armazenamento de suporte personalizado usando as mesmas " +
              "APIs que você usaria para uma string ou um fluxo.\n\n";

            Console.WriteLine($"Texto original: {textReaderText}");

            string line, paragraph = null;
            var stringReader = new StringReader(textReaderText);
            while (true)
            {
                line = stringReader.ReadLine();
                if (line != null)
                {
                    paragraph += line + " ";
                }
                else
                {
                    paragraph += '\n';
                    break;
                }
            }

            Console.WriteLine($"Texto modificado: {paragraph}");
            int characterRead;
            char characterConverted;

            var stringWriter = new StringWriter();
            stringReader = new StringReader(paragraph);

            while (true)
            {
                characterRead = stringReader.Read();
                if (characterRead == -1) break;

                characterConverted = Convert.ToChar(characterRead);

                if (characterConverted == '.')
                {
                    stringWriter.Write("\n\n");

                    stringReader.Read();
                    stringReader.Read();
                }
                else
                {
                    stringWriter.Write(characterConverted);
                }


            }

            Console.WriteLine($"Texto armazenado no StringWriter: {stringWriter.ToString()}");
            Console.WriteLine("\n\nDigite [enter] para finalizar...");
            Console.ReadLine();
        }
    }
}
