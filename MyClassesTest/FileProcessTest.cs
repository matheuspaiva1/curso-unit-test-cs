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
        private const string BAD_FILE_NAME = @"C:\BadFileName.bat";
        private string _GoodFileName;

        public TestContext TestContext { get; set; }

        #region Test Initialize e Cleanup

        [TestInitialize]
        public void TestInitialize() { 
            if(TestContext.TestName == "FileNameDoesExists")
            {
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    SetGoodFileName();
                    TestContext.WriteLine($"Creating File: {_GoodFileName}");
                    File.AppendAllText(_GoodFileName, "Some Text");
                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.TestName == "FileNameDoesExists")
            {
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine($"Deleting File: {_GoodFileName}");
                    File.Delete(_GoodFileName);
                }
            }
        }

        #endregion

        [TestMethod]
        [Description("Check to see if a file does exist.")]
        [Owner("Matheus Paiva")]
        [Priority(0)]
        [TestCategory("NoException")]
        public void fileNameDoesExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            TestContext.WriteLine($"Testing File: {_GoodFileName}");
            fromCall = fp.FileExists(_GoodFileName);
            

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

        private const string FILE_NAME = @"FileToDeploy.txt";

        [TestMethod]
        [Owner("Matheus Paiva")]
        [DeploymentItem(FILE_NAME)]
        public void FileNameDoesExistUsingDeploymentItem()
        {
            FileProcess fp = new FileProcess();
            string fileName;
            bool fromCall;

            fileName = $@"{TestContext.DeploymentDirectory}\{FILE_NAME}";
            TestContext.WriteLine($"Checking File: {fileName}");
            fromCall = fp.FileExists(fileName);


            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        [Timeout(4000)]
        public void SimulateTimeout()
        {
            System.Threading.Thread.Sleep(3000);
        }

        [TestMethod]
        [Description("Check to see if a file does NOT exist.")]
        [Owner("Francisco Paiva")]
        [Priority(0)]
        [TestCategory("NoException")]
        public void fileNameDoesNotExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(BAD_FILE_NAME);

            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Owner("Matheus Paiva")]
        [Priority(1)]
        [TestCategory("Exception")]
        public void fileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            //TODO  
            FileProcess fp = new FileProcess();

            fp.FileExists("");
        }

        [TestMethod]
        [Owner("João Paiva")]
        [Priority(1)]
        [TestCategory("Exception")]
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
