using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE_NAME = @"C:\BadFileName.txt";
        [TestMethod]
        public void fileNameDoesExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(@"");

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void fileNameDoesNotExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(BAD_FILE_NAME);

            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void fileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            //TODO  
            FileProcess fp = new FileProcess();

            fp.FileExists("");
        }

        [TestMethod]
        public void fileNameNullOrEmpty_ThrowsArgumentNullException_UsingTryCatch()
        {
            //TODO  
            FileProcess fp = new FileProcess();

            try
            {
                fp.FileExists("");
            }
            catch (ArgumentException)
            {
                // test sucess!
                return;
            }

            Assert.Fail("Fail Excepted");
        }
    }
}
