using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;

namespace MyClassesTest
{
    [TestClass]
    public class AssertClassTest
    {
        #region AreEqual/AreNotEqual Tests
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
        #endregion

        #region AreSame/AreNotSame Tests
        [TestMethod]
        public void AreSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = x;

            Assert.AreSame(x, y);
        }




        #endregion



    }
}
