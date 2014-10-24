using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCountApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a sentence then press return.");
            string sentence = Console.ReadLine();

            var results = WordUtils.WordCount(sentence);

            Print(results);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void Print(IEnumerable<Tuple<string, int>> results)
        {
            Console.WriteLine("OUTPUT");
            var list = results.ToList();
            if (list.Count == 0)
            {
                Console.WriteLine("No words found.");
                return;
            }

            foreach (var result in results)
            {
                Console.WriteLine("{0} - {1}", result.Item1, result.Item2);
            }
        }
    }
}
