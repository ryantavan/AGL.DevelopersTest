using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AGL.DevelopersTest.Interfaces;
using AGL.DevelopersTest.Models;
using System.Collections.Generic;
using AGL.DevelopersTest.Web.Controllers;
using System.Web.Mvc;

namespace AGL.DevelopersTest.Tests
{
    [TestClass]
    public class UnitTestJSON
    {
        private class MockPersonRepo : IPersonRepository
        {
            public List<Person> GetPeople()
            {
                List<Person> Persons = new List<Person>();
                Person ryan = new Person()
                {
                    name = "Ryan",
                    age = 40,
                    gender = Enums.Gender.Male

                };
                var ryansPets = new List<Pet>() { new Pet() { name = "Snowy", type = Enums.PetType.Cat, Owner = ryan }, new Pet() { name = "Kitty", type = Enums.PetType.Cat, Owner = ryan } };
                ryan.pets = ryansPets;

                Person rob = new Person()
                {
                    name = "Rob",
                    age = 35,
                    gender = Enums.Gender.Male
                   
                };
                var robPets = new List<Pet>() { new Pet() { name = "Jimmy", type = Enums.PetType.Cat }, new Pet() { name = "Nano", type = Enums.PetType.Dog } };
                rob.pets = robPets;
                Persons.Add(ryan);
                Persons.Add(rob);

                return Persons;

            }
        }


        [TestMethod]
        public void IfControllerWorkd()
        {
            var homeController = new HomeController(new MockPersonRepo()); // you should mock your DbContext and pass that in

            // Act
            var result = homeController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model); // add additional checks on the Model
            Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Index");
            var listmodel = result.ViewData.Model;
            Assert.AreEqual((listmodel as List<AGL.DevelopersTest.Models.Pet>).Count, 3); 
        }
    }
}
