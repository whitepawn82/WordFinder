using Microsoft.VisualStudio.TestTools.UnitTesting;
using QU_test_01;
using System.Collections.Generic;

namespace QU_Utest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IEnumerable<string> matrix = new string[] { "abcdc", "fgwio", "chill", "pqnsd", "uvdxy"};
            IEnumerable<string> wordstream = new string[] { "cold", "wwww" };

            WordFinder wordFinder = new WordFinder(matrix);

            IEnumerable<string> wordresult = wordFinder.Find(wordstream);

            List<string> wordresults = new List<string>();

            foreach (string item in wordresult)
            {
                wordresults.Add(item);
            }

            List<string> results = new List<string>() { "cold" };

            Assert.AreEqual(results[0], wordresults[0]);
        }
    }
}
