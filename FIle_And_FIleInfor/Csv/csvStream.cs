using static System.Console;

namespace Files_And_Streams.Csv
{
    internal class csvStream
    {
        //static void Main(string[] args)
        //{
        //    ReadCsv();
        //    CreateCsv();
        //    WriteLine("\n\nPressione [enter] para finalizar");
        //    ReadLine();
        //}

        static void CreateCsv()
        {
            var path = Path.Combine(
                Environment.CurrentDirectory,
                "Saida"
                );

            var peoples = new List<People>(){
            new People()
            {
                Name = "José da Silva",
                Email = "js@gmail.com",
                Phone = 123456,
                BirthDate = new DateOnly(year: 1970, month: 2, day: 14)
            },
            new People(){
                Name = "Pedro Paiva",
                Email = "pp@gmail.com",
                Phone = 456789,
                BirthDate = new DateOnly(year: 2002, month: 4, day: 20)
            },
            new People()
            {
                Name = "Maria Antonia",
                Email = "ma@gmail.com",
                Phone = 123456,
                BirthDate = new DateOnly(year: 1982, month: 12, day: 4)
            },
            new People()
            {
                Name = "Carla Moraes",
                Email = "cms@gmail.com",
                Phone = 9987411,
                BirthDate = new DateOnly(year: 2000, month: 7, day: 20)
            }
        };

            var directoryInfo = new DirectoryInfo(path);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
                path = Path.Combine(path, "usuarios.csv");
            }
            using var streamWriter = new StreamWriter(path);
            streamWriter.WriteLine("nome,email,telefone,nascimento");
            foreach (var people in peoples)
            {
                var line = $"{people.Name},{people.Email},{people.Phone},{people.BirthDate}";
                streamWriter.WriteLine(line);
            }

        }



        static void ReadCsv()
        {
            var path = Path.Combine(
                Environment.CurrentDirectory,
                "Entrada",
                "usuarios-exportacao.csv");
            if (File.Exists(path))
            {
                using var stringReader = new StreamReader(path);
                var header = stringReader.ReadLine()?.Split(',');
                while (true)
                {
                    var register = stringReader.ReadLine()?.Split(',');
                    if (register == null) break;
                    if (header.Length != register.Length)
                    {
                        WriteLine("Arquivo fora do padrão");
                        break;
                    }
                    for (int i = 0; i < register.Length; i++)
                    {
                        WriteLine($"{header?[i]}:{register[i]}");
                    }
                    WriteLine("--------------");
                }
            }
            else
            {
                WriteLine($"O arquivo {path} não existe");
            }
        }

        class People
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public int Phone { get; set; }
            public DateOnly BirthDate { get; set; }
        }
    }
}
