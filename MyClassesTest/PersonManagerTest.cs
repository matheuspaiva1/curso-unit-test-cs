using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;
using System;
using System.Collections.Generic;

namespace MyClassesTest
{
    [TestClass]
    public class PersonManagerTest
    {
        [TestMethod]
        public void CreatePerson_OfTypeEmployeeTest()
        {
            PersonManager PerMgr = new PersonManager();
            Person per;

            per = PerMgr.CreatePerson("Matheus", "Paiva", false);

            Assert.IsInstanceOfType(per, typeof(Employee));
        }

        [TestMethod]
        public void DoEmployeeExistTest()
        {
            Supervisor super = new Supervisor();
           
            super.Employees = new List<Employee>();
            super.Employees.Add(new Employee()
            {
                FirstName = "Matheus",
                LastName = "Paiva"
            });

            Assert.IsTrue(super.Employees.Count > 0);
        }



    }
}
