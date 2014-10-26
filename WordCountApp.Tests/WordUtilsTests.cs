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
            var results = WordUtils.WordCountUsingLinq(null);
        }

        [TestMethod]
        public void WordCountTestEmptyString()
        {
            var s = "";
            var results = WordUtils.WordCountUsingLinq(s);

            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void WordCountTestSpaces()
        {
            var s = "     ";
            var results = WordUtils.WordCountUsingLinq(s);

            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void WordCountTestSymbols()
        {
            var s = ",;:.!?";
            var results = WordUtils.WordCountUsingLinq(s);

            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void WordCountBaseTest()
        {
            var s = "One.";
            var results = WordUtils.WordCountUsingLinq(s);

            Assert.AreEqual(1, results.Count);

            Assert.AreEqual(1, results["one"]);

            //no rogue full stop
            Assert.IsFalse(results.ContainsKey("."));
        }

        [TestMethod]
        public void WordCountNTest()
        {
            var s = "Two two.";
            var results = WordUtils.WordCountUsingLinq(s);

            Assert.AreEqual(1, results.Count);

            Assert.AreEqual(2, results["two"]);
        }

        [TestMethod]
        public void WordCountMultipleTest()
        {
            var s = "one two two three three three.";
            var results = WordUtils.WordCountUsingLinq(s);

            Assert.AreEqual(3, results.Count);

            Assert.AreEqual(1, results["one"]);
            Assert.AreEqual(2, results["two"]);
            Assert.AreEqual(3, results["three"]);
        }

        
        [TestMethod]
        public void WordCountTestSpec()
        {
            var s = "This is a statement, and so is this.";
            var results = WordUtils.WordCountUsingLinq(s);

            Assert.AreEqual(6, results.Count);

            Assert.AreEqual(2, results["this"]);
            Assert.AreEqual(2, results["is"]);
            Assert.AreEqual(1, results["a"]);
            Assert.AreEqual(1, results["and"]);
            Assert.AreEqual(1, results["statement"]);
            Assert.AreEqual(1, results["so"]);
        }

        [TestMethod]
        public void WordCountTestSpecUsingIteration()
        {
            var s = "This is a statement, and so is this.";
            var results = WordUtils.WordCountUsingIteration(s);

            Assert.AreEqual(6, results.Count);

            Assert.AreEqual(2, results["this"]);
            Assert.AreEqual(2, results["is"]);
            Assert.AreEqual(1, results["a"]);
            Assert.AreEqual(1, results["and"]);
            Assert.AreEqual(1, results["statement"]);
            Assert.AreEqual(1, results["so"]);
        }

        [TestMethod]
        public void WordCountTestSpacesUsingInteration()
        {
            var s = "     ";
            var results = WordUtils.WordCountUsingIteration(s);

            Assert.AreEqual(0, results.Count);
        }
    }
}
