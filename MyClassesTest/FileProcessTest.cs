using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;
using System.Configuration;
using System.IO;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE_NAME = @"C:\BadFileName.txt";
        private string _GoodFileName;

        public TestContext TestContext { get; set; }
        [TestMethod]
        public void fileNameDoesExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            SetGoodFileName();
            TestContext.WriteLine($"Creating File: {_GoodFileName}" );
            File.AppendAllText(_GoodFileName, "Some Text");
            TestContext.WriteLine($"Testing File: {_GoodFileName}");
            fromCall = fp.FileExists(_GoodFileName);
            TestContext.WriteLine($"Deleting File: {_GoodFileName}");
            File.Delete(_GoodFileName);

            Assert.IsTrue(fromCall);
        }

        public void SetGoodFileName()
        {
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];
            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
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
