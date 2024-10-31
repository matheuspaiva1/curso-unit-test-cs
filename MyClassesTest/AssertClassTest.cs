using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyClassesTest
{
    [TestClass]
    public class AssertClassTest
    {
        [TestMethod]
        [Owner("Matheus")]
        public void AreEqualTest()
        {
            string str1 = "Matheus";
            string str2 = "Matheus";

            Assert.AreEqual(str1, str2);
        }

        [TestMethod]
        [Owner("Matheus")]
        [ExpectedException(typeof(AssertFailedException))]
        public void AreEqualCaseSensitiveTest()
        {
            string str1 = "Matheus";
            string str2 = "matheus";

            Assert.AreEqual(str1, str2, false);
        }

        [TestMethod]
        [Owner("Matheus")]
        public void AreNotEqualTest()
        {
            string str1 = "Matheus";
            string str2 = "Thiago";

            Assert.AreNotEqual(str1, str2);
        }


    }
}
