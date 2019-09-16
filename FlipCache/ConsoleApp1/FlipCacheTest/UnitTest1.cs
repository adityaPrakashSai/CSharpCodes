using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;

namespace FlipCacheTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            LRUPolicy<string, string> policy = new LRUPolicy<string, string>();
            FlipCache<string, string> flipCache = new FlipCache<string, string>(2, policy);
           // flipCache.Put("company", "flipkart");
            string value = flipCache.Get("company");
           
            Assert.AreEqual(value, "flipkart");
        }

        [TestMethod]
        public void TestMethod2()
        {
            LRUPolicy<string, string> policy = new LRUPolicy<string, string>();
            FlipCache<string, string> flipCache = new FlipCache<string, string>(2, policy);
            flipCache.Put("company", "flipkart");
            string value = flipCache.Get("company");
            flipCache.Put("company", "amazon");
            string value2 = flipCache.Get("company");
            Assert.AreEqual(value2, "amazon");
        }

        [TestMethod]
        public void TestMethod3()
        {
            LRUPolicy<string, string> policy = new LRUPolicy<string, string>();
            FlipCache<string, string> flipCache = new FlipCache<string, string>(2, policy);
            flipCache.Put("company", "flipkart");
            string value = flipCache.Get("company1");
            flipCache.Put("company2", "amazon");
            string value2 = flipCache.Get("company2");
            flipCache.Put("company3", "swiggy");
            string value3 = flipCache.Get("company3");
            Assert.IsNull(flipCache.Get("company"));
        }
    }
}
