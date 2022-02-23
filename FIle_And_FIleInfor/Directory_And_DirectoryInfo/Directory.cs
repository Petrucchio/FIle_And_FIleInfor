
namespace FIle_And_FIleInfor.Directory_And_DirectoryInfo
{
    
    internal class Directory
    {
        //static void Main(string[] args)
        //{
        //    CreateDirectoryGlobo();
        //    CreateFile();
        //    var origin = Path.Combine(Environment.CurrentDirectory, "brasil.txt");
        //    var destiny = Path.Combine(Environment.CurrentDirectory,"globo","América do Sul","Argentina","argentina.txt");
        //    MoveFile(origin, destiny);
        //    CopyFile(origin, destiny);
        //    var path = Path.Combine(Environment.CurrentDirectory, "globo");
        //    ReadDirectories(path);
        //}
        static void ReadDirectories(string path)
        {
            var directories = System.IO.Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
            foreach (var directory in directories)
            {
                var directoryInfo = new DirectoryInfo(directory);
                Console.WriteLine($"[Nome]:{directoryInfo.Name}");
                Console.WriteLine($"[Raiz]:{directoryInfo.Root}");
                if (directoryInfo.Parent != null) 
                { 
                    Console.WriteLine($"[Pai]:{directoryInfo.Parent.Name}");
                }
                Console.WriteLine("---------------------");
            }
        }
        static void CopyFile(string pathOrigin, string pathDestiny)
        {
            if (!File.Exists(pathOrigin))
            {
                Console.WriteLine("Arquivo de origem não existe");
                return;
            }
            if (File.Exists(pathDestiny))
            {
                Console.WriteLine("Arquivo já existe na pasta de destino");
                return;
            }
            File.Copy(pathOrigin, pathDestiny);
        }
        static void MoveFile(string pathOrigin, string pathDestiny)
        {
            if (!File.Exists(pathOrigin))
            {
                Console.WriteLine("Arquivo de origem não existe");
                return;
            }
            if (File.Exists(pathDestiny))
            {
                Console.WriteLine("Arquivo já existe na pasta de destino");
                return;
            }
            File.Move(pathOrigin, pathDestiny);
        }
        static void CreateFile()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "brasil.txt");
            if (!File.Exists(path))
            {
                using var stringWriter = File.CreateText(path);
                stringWriter.WriteLine("População: 213MM");
                stringWriter.WriteLine("IDH: 0,901");
                stringWriter.WriteLine("Dados atualizados em: 20/04/2018");
            }
        }
        static void CreateDirectoryGlobo()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "globo");
            if (!System.IO.Directory.Exists(path))
            {
                var directoryGlobo = System.IO.Directory.CreateDirectory(path);
                var directoryNorthAmerica = directoryGlobo.CreateSubdirectory("América do Norte");
                var directoryCentralAmerica = directoryGlobo.CreateSubdirectory("América Central");
                var directorySouthAmerica = directoryGlobo.CreateSubdirectory("América do Sul");
                directoryNorthAmerica.CreateSubdirectory("USA");
                directoryNorthAmerica.CreateSubdirectory("Mexico");
                directoryNorthAmerica.CreateSubdirectory("Canada");
                directoryCentralAmerica.CreateSubdirectory("Costa Rica");
                directoryCentralAmerica.CreateSubdirectory("Panama");
                directorySouthAmerica.CreateSubdirectory("Brasil");
                directorySouthAmerica.CreateSubdirectory("Argentina");
                directorySouthAmerica.CreateSubdirectory("Paraguai");
            }
        }
    }
}
