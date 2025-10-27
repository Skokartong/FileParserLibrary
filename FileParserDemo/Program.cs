using System;
using System.Threading.Tasks;
using FileParserLib; 

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            var parser = new FileParser();

            Console.WriteLine("Write filename here (e.g 'file.json'): ");
            var fileName = Console.ReadLine();
            
            var fullPath = Path.Combine("Data", fileName!);
            var parsedContent = await parser.ParseContentAsync(fullPath);

            Console.WriteLine($"\n--- Parsed content from {fileName} ---\n");

            foreach (var row in parsedContent)
            {
                Console.WriteLine(string.Join(", ", row));
            }

            Console.WriteLine("\n✅ Parsing done!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ An error occured: {ex.Message}");
        }
    }
}
