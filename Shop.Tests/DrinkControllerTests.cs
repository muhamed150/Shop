using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Shop.Controllers;
using Shop.Data;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Tests
{
    class DrinkControllerTests
    {
        [TestCase]
        public void GetAllDrinks_Gives_All_Drinks()
        {
            var data = new List<Drink>
            {
                new Drink { Name="First" },
                new Drink { Name="Second" },
                new Drink { Name="Third" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Drink>>();
            mockSet.As<IQueryable<Drink>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Drink>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Drink>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Drink>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ShopContext>();
            mockContext.Setup(c => c.Drinks).Returns(mockSet.Object);

            var controller = new DrinkController(mockContext.Object);
            var Drinks = controller.GetAllDrinks();

            Assert.AreEqual(3, Drinks.Count);
            Assert.AreEqual("First", Drinks[0].Name);
            Assert.AreEqual("Second", Drinks[1].Name);
            Assert.AreEqual("Third", Drinks[2].Name);
        }

        [TestCase]
        public void AddDrink_Add_A_Drink()
        {
            var mockSet = new Mock<DbSet<Drink>>();
            var drink = new Drink();
            var mockContext = new Mock<ShopContext>();
            mockContext.Setup(m => m.Drinks).Returns(mockSet.Object);

            var controller = new DrinkController(mockContext.Object);
            controller.Add(drink);

            mockSet.Verify(m => m.Add(It.IsAny<Drink>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestCase]
        public void GetDrinkById_Gives_Drink_By_Id()
        {
            var data = new List<Drink>()
            {
                new Drink{Id=1, Name="Drink1"},
                new Drink{Id=2, Name="Drink2" },
                new Drink{Id=3, Name="Drink3"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Drink>>();
            mockSet.As<IQueryable<Drink>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Drink>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Drink>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Drink>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ShopContext>();
            mockContext.Setup(c => c.Drinks).Returns(mockSet.Object);

            var controller = new DrinkController(mockContext.Object);

            var drink = controller.GetDrinkById(1);
            Assert.AreEqual(1, drink.Id);
        }

        [TestCase]
        public void RemoveDrink_Remove_A_Drink()
        {
            var data = new List<Drink>()
            {
                new Drink{Id=1, Name="Drink1"},
                new Drink{Id=2, Name="Drink2" },
                new Drink{Id=3, Name="Drink3"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Drink>>();
            mockSet.As<IQueryable<Drink>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Drink>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Drink>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Drink>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ShopContext>();
            mockContext.Setup(x => x.Drinks).Returns(mockSet.Object);

            var service = new DrinkController(mockContext.Object);
            var drinks = service.GetAllDrinks();

            int deletedDrinkId = 1; service.Delete(drinks[0].Id);

            Assert.IsNull(service.GetAllDrinks().FirstOrDefault(x => x.Id == deletedDrinkId));
        }
    }
}