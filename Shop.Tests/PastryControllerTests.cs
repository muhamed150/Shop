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
    class PastryControllerTests
    {
        [TestCase]
        public void GetAllPastries_Gives_All_Pastries()
        {
            var data = new List<Pastry>
            {
                new Pastry { Name="First" },
                new Pastry { Name="Second" },
                new Pastry { Name="Third" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Pastry>>();
            mockSet.As<IQueryable<Pastry>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Pastry>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Pastry>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Pastry>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ShopContext>();
            mockContext.Setup(c => c.Pastries).Returns(mockSet.Object);

            var controller = new PastryController(mockContext.Object);
            var pastries = controller.GetAllPastries();

            Assert.AreEqual(3, pastries.Count);
            Assert.AreEqual("First", pastries[0].Name);
            Assert.AreEqual("Second", pastries[1].Name);
            Assert.AreEqual("Third", pastries[2].Name);
        }

        [TestCase]
        public void AddPastry_Add_A_Pastry()
        {
            var mockSet = new Mock<DbSet<Pastry>>();
            var pastry = new Pastry();
            var mockContext = new Mock<ShopContext>();
            mockContext.Setup(m => m.Pastries).Returns(mockSet.Object);

            var controller = new PastryController(mockContext.Object);
            controller.Add(pastry);

            mockSet.Verify(m => m.Add(It.IsAny<Pastry>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestCase]
        public void GetPastryById_Gives_Pastry_By_Id()
        {
            var data = new List<Pastry>()
            {
                new Pastry{Id=1, Name="Pastry1"},
                new Pastry{Id=2, Name="Pastry2" },
                new Pastry{Id=3, Name="Pastry3"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Pastry>>();
            mockSet.As<IQueryable<Pastry>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Pastry>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Pastry>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Pastry>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ShopContext>();
            mockContext.Setup(c => c.Pastries).Returns(mockSet.Object);

            var controller = new PastryController(mockContext.Object);

            var pastry = controller.GetPastryById(1);
            Assert.AreEqual(1, pastry.Id);
        }

        [TestCase]
        public void RemovePastry_Remove_A_Pastry()
        {
            var data = new List<Pastry>()
            {
                new Pastry{Id=1, Name="Pastry1"},
                new Pastry{Id=2, Name="Pastry2" },
                new Pastry{Id=3, Name="Pastry3"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Pastry>>();
            mockSet.As<IQueryable<Pastry>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Pastry>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Pastry>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Pastry>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


            var mockContext = new Mock<ShopContext>();
            mockContext.Setup(x => x.Pastries).Returns(mockSet.Object);

            var service = new PastryController(mockContext.Object);
            var pastries = service.GetAllPastries();

            int deletedNutId = 1; service.Delete(pastries[0].Id);

            Assert.IsNull(service.GetAllPastries().FirstOrDefault(x => x.Id == deletedNutId));
        }
    }
}
