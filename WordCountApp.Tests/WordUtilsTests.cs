using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace WordCountApp.Tests
{
    [TestClass]
    public class WordUtilsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WordCountTestNull()
        {
            var results = WordUtils.WordCount(null);
        }

        [TestMethod]
        public void WordCountTestEmptyString()
        {
            var s = "";
            var results = WordUtils.WordCount(s);

            Assert.AreEqual(0, results.Count());
        }

        [TestMethod]
        public void WordCountTestSpaces()
        {
            var s = "     ";
            var results = WordUtils.WordCount(s);

            Assert.AreEqual(0, results.Count());
        }

        [TestMethod]
        public void WordCountTestSymbols()
        {
            var s = ",;:.!?";
            var results = WordUtils.WordCount(s);

            Assert.AreEqual(0, results.Count());
        }

        [TestMethod]
        public void WordCountBaseTest()
        {
            var s = "One.";
            var results = WordUtils.WordCount(s).ToList();

            Assert.AreEqual(1, results.Count);

            Assert.AreEqual(1, results.GetCount("one"));

            //no rogue full stop
            Assert.AreEqual(0, results.GetCount("."));
        }

        [TestMethod]
        public void WordCountNTest()
        {
            var s = "Two two.";
            var results = WordUtils.WordCount(s).ToList();

            Assert.AreEqual(1, results.Count);

            Assert.AreEqual(2, results.GetCount("two"));
        }

        [TestMethod]
        public void WordCountMultipleTest()
        {
            var s = "one two two three three three.";
            var results = WordUtils.WordCount(s).ToList();

            Assert.AreEqual(3, results.Count);

            Assert.AreEqual(1, results.GetCount("one"));
            Assert.AreEqual(2, results.GetCount("two"));
            Assert.AreEqual(3, results.GetCount("three"));
        }

        
        [TestMethod]
        public void WordCountTestSpec()
        {
            var s = "This is a statement, and so is this.";
            var results = WordUtils.WordCount(s).ToList();

            Assert.AreEqual(6, results.Count);

            Assert.AreEqual(2, results.GetCount("this"));
            Assert.AreEqual(2, results.GetCount("is"));
            Assert.AreEqual(1, results.GetCount("a"));
            Assert.AreEqual(1, results.GetCount("and"));
            Assert.AreEqual(1, results.GetCount("statement"));
            Assert.AreEqual(1, results.GetCount("so"));
        }
    }

    //todo - this probably needs testing
    public static class WordUtilsTestHelper
    {
        public static int GetCount(this List<Tuple<string, int>> words, string word)
        {
            var w = words.Where(t => t.Item1 == word);

            if (w.Count() == 0)
            {
                return 0;
            }
            if (w.Count() > 1)
            {
                throw new ApplicationException("More than one item for same word in list.");
            }

            return w.ElementAt(0).Item2;
        }
    }
}
