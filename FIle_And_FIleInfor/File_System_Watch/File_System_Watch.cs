using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files_And_Streams.File_System_Watch
{
    internal class File_System_Watch
    {
        static void Main(string[] args)
        {
            var path = @"c:\temp\globo";
            using var fileSystemWatcher = new FileSystemWatcher(path);
            fileSystemWatcher.Created += OnCreate;
            fileSystemWatcher.Renamed += OnRenamed;
            fileSystemWatcher.Deleted += OnDeleted;
            fileSystemWatcher.EnableRaisingEvents = true;
            fileSystemWatcher.IncludeSubdirectories = true;

            Console.WriteLine($"Monitorando eventos na pasta {path}");
            Console.WriteLine("Pressione [enter] para finalizar....");
            Console.ReadLine();
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Foi excluído o arquivo {e.Name}");
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"O arquivo {e.OldName} foi renomeado para {e.Name}");
        }

        private static void OnCreate(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Foi criado o arquivo {e.Name}");
        }
    }
}
