// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GenerateDto
{
    internal class Program
    {
        private const string EntityArgName = "entity";
        private const string NamespaceArgName = "namespace";
        public static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Arguments is empty !");
                return;
            }

            var argsAsDictionary = ResolveArguments(args);
            if (argsAsDictionary == null)
            {
                Console.WriteLine("Arguments is empty !");
                return;
            }

            var entityNamesAsString = argsAsDictionary[EntityArgName];
            if (string.IsNullOrEmpty(entityNamesAsString))
            {
                Console.WriteLine("Entity name is invalid !");
                return;
            }

            var nameSpaceName = argsAsDictionary[NamespaceArgName];
            if (string.IsNullOrEmpty(nameSpaceName))
            {
                Console.WriteLine("Namespace name is invalid !");
                return;
            }

            var entityNames = entityNamesAsString.Split(",");
            foreach (var entityName in entityNames)
            {
                var dtoFileNames = new string[]
                {
                    $"{entityName}Dto.cs",
                    $"{entityName}ListDto.cs",
                    $"{entityName}CreateDto.cs",
                    $"{entityName}UpdateDto.cs",
                };
                foreach (var dtoFileName in dtoFileNames)
                {
                    await using FileStream fs = File.Create(dtoFileName);
                    byte[] content = new UTF8Encoding(true).GetBytes(GetFileContent(Path.GetFileNameWithoutExtension(dtoFileName), nameSpaceName));    
                    await fs.WriteAsync(content);
                }
            }
            Console.WriteLine("Done !");

        }

        private static string GetFileContent(string fileName, string namespaceName)
        {
            var content = @"
namespace "+namespaceName+@"
{
    public class "+fileName+@"
    {
        
    }
}
";
            return content;
        }
        
        private static Dictionary<string, string>? ResolveArguments(IReadOnlyCollection<string> args)
        {
            if (args.Count <= 0) return null;
            var arguments = new Dictionary<string, string>();
            foreach (string argument in args)
            {
                var idx = argument.IndexOf('=');
                if (idx > 0)
                    arguments[argument.Substring(0, idx)] = argument.Substring(idx+1);
            }
            return arguments;

        }
    }
    
}