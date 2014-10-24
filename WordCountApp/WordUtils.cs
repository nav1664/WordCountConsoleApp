using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCountApp
{
    public static class WordUtils
    {
        //could use regular expression to replace/remove symbol, but quote an issue.
        //also should full stop question mark and exclamation mark be Trimmed? 
        private static readonly char[] Separators = new char[] { ' ', ',', '?', '!', ';', ':', '.', '"', '&' };
        
        /// <summary>
        /// Counts number of words in a sentence.
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        /// <exception>ArgumentNullException if sentence is null.</exception>
        public static IEnumerable<Tuple<string, int>> WordCount(string sentence)
        {
            if (sentence == null )
            {
                throw new ArgumentNullException("sentence");
            }
            
            var results = from word in sentence
                                 .ToLower()
                                    .Split(Separators, StringSplitOptions.RemoveEmptyEntries)
                          group word by word into grpWords
                          orderby grpWords.Count() descending
                          select Tuple.Create(grpWords.Key, grpWords.Count());
                          
            return results;
        }
    }
}
