using System.Globalization;
using CsvHelper.Configuration;
using CsvHelper;
using CsvHelper.TypeConversion;
using Files_And_Streams.Csv.Helper.Model;
using Files_And_Streams.Csv.Helper.Mapping;

namespace Files_And_Streams.Csv.Helper
{
    public class csvHelper
    {
        static void Main(string[] args)
        {
            //ReadCsvDynamic();
            //ReadCsvClass();
            //ReadCsvOtherDelimiter();
            WriteCsv();

            Console.WriteLine("Digite [enter] para finalizar");
            Console.ReadLine();
        }
        static void WriteCsv()
        {
            var path = Path.Combine(
                Environment.CurrentDirectory,
                "Saida");

            var directoryInfo = new DirectoryInfo(path);

            if (!directoryInfo.Exists)
                directoryInfo.Create();

            path = Path.Combine(path, "usuarios.csv");

            var pessoas = new List<Pessoa>()
            {
            new Pessoa()
            {
                Nome = "José da Silva",
                Email = "js@gmail.com",
                Telefone = 123456,
            },
            new Pessoa()
            {
                Nome = "Pedro Paiva",
                Email = "pp@gmail.com",
                Telefone = 456789,
            },
            new Pessoa()
            {
                Nome = "Maria Antonia",
                Email = "ma@gmail.com",
                Telefone = 123456,
            },
            new Pessoa()
            {
                Nome = "Carla Moraes",
                Email = "cms@gmail.com",
                Telefone = 9987411,

            },
        };

            using var streamWriter = new StreamWriter(path);
            var csvConfig = new CsvConfiguration(CultureInfo.InstalledUICulture)
            {
                Delimiter = "|"
            };
            using var csvWriter = new CsvWriter(streamWriter, csvConfig);
            csvWriter.WriteRecords(pessoas);

        }
        static void ReadCsvOtherDelimiter()
        {
            var path = Path.Combine(
                Environment.CurrentDirectory,
                "Entrada",
                "Livros-preco-com-virgula.csv");
            var fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
                throw new FileNotFoundException($"O aruivo {path} não existe!");

            using var streamReader = new StreamReader(fileInfo.FullName);
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";"
            };

            using var csvReader = new CsvReader(streamReader, csvConfig);
            csvReader.Context.RegisterClassMap<LivroMap>();
            var registers = csvReader.GetRecords<Livro>().ToList();

            foreach (var register in registers)
            {
                Console.WriteLine($"Título:{register.Titulo}");
                Console.WriteLine($"Preço:{register.Preco}");
                Console.WriteLine($"Autor:{register.Autor}");
                Console.WriteLine($"Lançamento:{register.Lancamento}");
                Console.WriteLine("--------");
            }
        }
        static void ReadCsvClass()
        {
            var path = Path.Combine(
                Environment.CurrentDirectory,
                "Entrada",
                "novos-usuarios.csv");
            var fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
                throw new FileNotFoundException($"O aruivo {path} não existe!");

            using var streamReader = new StreamReader(fileInfo.FullName);
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
            using var csvReader = new CsvReader(streamReader, csvConfig);

            var registers = csvReader.GetRecords<Usuario>().ToList();

            foreach (var register in registers)
            {
                Console.WriteLine($"nome:{register.Nome}");
                Console.WriteLine($"email:{register.Email}");
                Console.WriteLine($"telefone:{register.Telefone}");
                Console.WriteLine("--------");
            }
        }
        static void ReadCsvDynamic()
        {
            var path = Path.Combine(
                Environment.CurrentDirectory,
                "Entrada",
                "Produtos.csv");

            var fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
                throw new FileNotFoundException($"O aruivo {path} não existe!");

            using var streamReader = new StreamReader(fileInfo.FullName);
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
            using var csvReader = new CsvReader(streamReader, csvConfig);

            var registers = csvReader.GetRecords<dynamic>();

            foreach (var register in registers)
            {
                Console.WriteLine($"nome:{register.Produto}");
                Console.WriteLine($"marca:{register.Marca}");
                Console.WriteLine($"preço:{register.Preco}");
                Console.WriteLine("--------");
            }
        }
    }
}
