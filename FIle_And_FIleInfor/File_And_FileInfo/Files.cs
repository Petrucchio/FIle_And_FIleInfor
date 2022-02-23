using static System.Console;

namespace FIle_And_FIleInfor.File_And_FileInfo
{

    internal class Files
    {
        //static void Main(string[] args)
        //{
        //    WriteLine("Digite o nome do arquivo:");

        //    var name = ReadLine();

        //    name = ClearName(name);

        //    var path = Path.Combine(Environment.CurrentDirectory, $"{name}.txt");

        //    CreateFile(path);

        //    WriteLine("Digite enter para finalizar...");
        //    ReadLine();
        //}

        static string ClearName(string name)
        {
            foreach (var @char in Path.GetInvalidFileNameChars())
            {
                name = name.Replace(@char, '-');
            }
            return name;
        }

        static void CreateFile(string path)
        {
            try
            {
                using var stringWriter = File.CreateText(path);
                stringWriter.WriteLine("Esta a linha 1 do arquivo");
                stringWriter.WriteLine("Esta a linha 2 do arquivo");
                stringWriter.WriteLine("Esta a linha 3 do arquivo");
            }
            catch
            {

                WriteLine("O nome do arquivo está inválido!");
            }

        }
    }
}
