using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Shop.Controllers;
using Shop.Data;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Tests
{
    class FruitAndVegetableControllerTests
    {
        [TestCase]
        public void GetAllFruitsAndVegetables_Gives_All_FruitsAndVegetables()
        {
            var data = new List<FruitAndVegetable>
            {
                new FruitAndVegetable { Name="First" },
                new FruitAndVegetable { Name="Second" },
                new FruitAndVegetable { Name="Third" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<FruitAndVegetable>>();
            mockSet.As<IQueryable<FruitAndVegetable>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<FruitAndVegetable>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<FruitAndVegetable>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<FruitAndVegetable>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ShopContext>();
            mockContext.Setup(c => c.FruitsAndVegetables).Returns(mockSet.Object);

            var controller = new FruitAndVegetableController(mockContext.Object);
            var fruitsAndVegetables = controller.GetAllFruitsAndVegetables();

            Assert.AreEqual(3, fruitsAndVegetables.Count);
            Assert.AreEqual("First", fruitsAndVegetables[0].Name);
            Assert.AreEqual("Second", fruitsAndVegetables[1].Name);
            Assert.AreEqual("Third", fruitsAndVegetables[2].Name);
        }

        [TestCase]
        public void AddFruitAndVegetable_Add_A_FruitAndVegetable()
        {
            var mockSet = new Mock<DbSet<FruitAndVegetable>>();
            var fruitOrVegetable = new FruitAndVegetable();
            var mockContext = new Mock<ShopContext>();
            mockContext.Setup(m => m.FruitsAndVegetables).Returns(mockSet.Object);

            var controller = new FruitAndVegetableController(mockContext.Object);
            controller.Add(fruitOrVegetable);

            mockSet.Verify(m => m.Add(It.IsAny<FruitAndVegetable>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestCase]
        public void GetFruitOrVegetableById_Gives_FruitOrVegetable_By_Id()
        {
            var data = new List<FruitAndVegetable>()
            {
                new FruitAndVegetable{Id=1, Name="FruitAndVegetable1"},
                new FruitAndVegetable{Id=2, Name="FruitAndVegetable2" },
                new FruitAndVegetable{Id=3, Name="FruitAndVegetable3"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<FruitAndVegetable>>();
            mockSet.As<IQueryable<FruitAndVegetable>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<FruitAndVegetable>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<FruitAndVegetable>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<FruitAndVegetable>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ShopContext>();
            mockContext.Setup(c => c.FruitsAndVegetables).Returns(mockSet.Object);

            var controller = new FruitAndVegetableController(mockContext.Object);

            var fruitOrVegetable = controller.GetFruitOrVegetableById(1);
            Assert.AreEqual(1, fruitOrVegetable.Id);
        }

        [TestCase]
        public void RemoveFruitOrVegetable_Remove_A_FruitOrVegetable()
        {
            var data = new List<FruitAndVegetable>()
            {
                new FruitAndVegetable{Id=1, Name="FruitAndVegetable1"},
                new FruitAndVegetable{Id=2, Name="FruitAndVegetable2" },
                new FruitAndVegetable{Id=3, Name="FruitAndVegetable3"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<FruitAndVegetable>>();
            mockSet.As<IQueryable<FruitAndVegetable>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<FruitAndVegetable>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<FruitAndVegetable>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<FruitAndVegetable>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


            var mockContext = new Mock<ShopContext>();
            mockContext.Setup(x => x.FruitsAndVegetables).Returns(mockSet.Object);

            var service = new FruitAndVegetableController(mockContext.Object);
            var fruitsAndVegetables = service.GetAllFruitsAndVegetables();

            int deletedNutId = 1; service.Delete(fruitsAndVegetables[0].Id);

            Assert.IsNull(service.GetAllFruitsAndVegetables().FirstOrDefault(x => x.Id == deletedNutId));
        }
    }
}
