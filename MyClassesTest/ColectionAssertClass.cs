using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;
using System;
using System.Collections.Generic;

namespace MyClassesTest
{
    [TestClass]
    public class ColectionAssertClass
    {
        [TestMethod]
        [Owner("Matheus")]
        public void AreCollectionEqualFailsBecauseNoComparerTest()
        {
            PersonManager PerMgr = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person() { FirstName= "Matheus", LastName= "Paiva" });
            peopleExpected.Add(new Person() { FirstName = "Francisco", LastName = "Girão" });
            peopleExpected.Add(new Person() { FirstName = "José", LastName = "Luis" });

            // Não passa assim
            peopleActual = PerMgr.GetPeople();

            CollectionAssert.AreEqual(peopleExpected, peopleActual);
        }

        [TestMethod]
        public void AreCollectionEqualWithComparerTest()
        {
            PersonManager PerMgr = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person() { FirstName = "Matheus", LastName = "Paiva" });
            peopleExpected.Add(new Person() { FirstName = "Francisco", LastName = "Girão" });
            peopleExpected.Add(new Person() { FirstName = "José", LastName = "Luis" });

            // Não passa assim
            peopleActual = PerMgr.GetPeople();

            CollectionAssert.AreEqual(peopleExpected, peopleActual, Comparer<Person>.Create((x,y) => 
                x.FirstName == y.FirstName && x.LastName == y.LastName ? 0 : 1)
            );
        }

        [TestMethod]
        public void AreCollectionEquivalentTest()
        {
            PersonManager PerMgr = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            // Não passa assim
            peopleActual = PerMgr.GetPeople();

            peopleExpected.Add(peopleActual[1]);
            peopleExpected.Add(peopleActual[2]);
            peopleExpected.Add(peopleActual[0]);

            CollectionAssert.AreEquivalent(peopleExpected, peopleActual);
        }

        [TestMethod]
        public void IsCollectionOfTypeTest()
        {
            PersonManager PerMgr = new PersonManager();
            List<Person> peopleActual = new List<Person>();

            // Não passa assim
            peopleActual = PerMgr.GetSupervisors();

            CollectionAssert.AllItemsAreInstancesOfType(peopleActual, typeof(Supervisor));
        }

    }
}

