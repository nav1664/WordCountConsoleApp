using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordCountApp
{
    public static class WordUtils
    {
        //Could use regular expression to replace/remove symbol, but quote an issue.  Also should full stop question mark and exclamation mark be Trimmed? 
        private static readonly char[] Separators = new char[] { ' ', ',', '?', '!', ';', ':', '.', '"', '&' };
        
        /// <summary>
        /// Counts number of words in a sentence using Linq.
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        /// <exception>ArgumentNullException if sentence is null.</exception>
        public static Dictionary<string, int> WordCountUsingLinq(string sentence)
        {
            if (sentence == null )
            {
                throw new ArgumentNullException("sentence");
            }

            var results = sentence.ToLower()
                                     .Split(Separators, StringSplitOptions.RemoveEmptyEntries)
                                        .GroupBy(s => s).ToDictionary(g => g.Key, g => g.Count());
        
            return results;
        }

        /// <summary>
        /// Counts number of words in a sentence.
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        /// <exception>ArgumentNullException if sentence is null.</exception>
        public static Dictionary<string, int> WordCountUsingIteration(string sentence)
        {
            if (sentence == null)
            {
                throw new ArgumentNullException("sentence");
            }

            var results = new Dictionary<string,int>();
            for(int i = 0, j = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
  
                if (!char.IsLetterOrDigit(c) && c != '\'')
                {
                    var s = sentence.Substring(j, i - j);
                    if (!string.IsNullOrEmpty(s))
                    {
                        s = s.ToLower();
                        if (!results.ContainsKey(s))
                        {
                            results[s] = 1;
                        }
                        else
                        {
                            results[s]++;
                        }
                    }

                    j = i + 1;
                }
            }
        
            return results;
        }
    }
}
