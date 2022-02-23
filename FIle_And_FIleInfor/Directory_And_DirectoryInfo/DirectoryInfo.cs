
namespace Files_And_Streams.Directory_And_DirectoryInfo
{
    internal class DirectoryInform
    {
        //static void Main(string[] args)
        //{
        //    var path = @"c:\temp\globo";
        //    ReadDirectory(path);
        //    ReadFiles(path);
        //    Console.WriteLine("Digite [enter] para finalizar...");
        //    Console.ReadLine();
        //}

        static void ReadFiles(string path)
        {
            var files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                Console.WriteLine($"[Nome]:{fileInfo.Name}");
                Console.WriteLine($"[Tamanho]:{fileInfo.Length}");
                Console.WriteLine($"[Ultimo acesso]:{fileInfo.LastAccessTime}");
                Console.WriteLine($"[Extensão]:{fileInfo.Extension}");
                Console.WriteLine($"[Pasta]:{fileInfo.DirectoryName}");
                Console.WriteLine("----------------");
            }
        }
        static void ReadDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                var directories = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
                foreach (var directory in directories)
                {
                    var directoryInfo = new DirectoryInfo(directory);
                    Console.WriteLine($"[Nome]:{directoryInfo.Name}");
                    Console.WriteLine($"[Raiz]:{directoryInfo.Root}");
                    if (directoryInfo.Parent != null)
                        Console.WriteLine($"[Pai]:{directoryInfo.Parent.Name}");
                    Console.WriteLine("-------------------");
                }

            }
            else
            {
                Console.WriteLine($"{path} não existe");
            }

        }
    }
}
