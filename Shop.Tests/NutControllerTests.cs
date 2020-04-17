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
    class NutControllerTests
    {
        [TestCase]
        public void GetAllNuts_Gives_All_Nuts()
        {
            var data = new List<Nut>
            {
                new Nut { Name="First" },
                new Nut { Name="Second" },
                new Nut { Name="Third" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Nut>>();
            mockSet.As<IQueryable<Nut>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Nut>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Nut>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Nut>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ShopContext>();
            mockContext.Setup(c => c.Nuts).Returns(mockSet.Object);

            var controller = new NutController(mockContext.Object);
            var Nuts = controller.GetAllNuts();

            Assert.AreEqual(3, Nuts.Count);
            Assert.AreEqual("First", Nuts[0].Name);
            Assert.AreEqual("Second", Nuts[1].Name);
            Assert.AreEqual("Third", Nuts[2].Name);
        }

        [TestCase]
        public void AddNut_Add_A_Nut()
        {
            var mockSet = new Mock<DbSet<Nut>>();
            var nut = new Nut();
            var mockContext = new Mock<ShopContext>();
            mockContext.Setup(m => m.Nuts).Returns(mockSet.Object);

            var controller = new NutController(mockContext.Object);
            controller.Add(nut);

            mockSet.Verify(m => m.Add(It.IsAny<Nut>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestCase]
        public void GetNutById_Gives_Nut_By_Id()
        {
            var data = new List<Nut>()
            {
                new Nut{Id=1, Name="Nut1"},
                new Nut{Id=2, Name="Nut2" },
                new Nut{Id=3, Name="Nut3"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Nut>>();
            mockSet.As<IQueryable<Nut>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Nut>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Nut>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Nut>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ShopContext>();
            mockContext.Setup(c => c.Nuts).Returns(mockSet.Object);

            var controller = new NutController(mockContext.Object);

            var nut = controller.GetNutById(1);
            Assert.AreEqual(1, nut.Id);
        }

        [TestCase]
        public void RemoveNut_Remove_A_Nut()
        {
            var data = new List<Nut>()
            {
                new Nut{Id=1, Name="Nut1"},
                new Nut{Id=2, Name="Nut2" },
                new Nut{Id=3, Name="Nut3"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Nut>>();
            mockSet.As<IQueryable<Nut>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Nut>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Nut>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Nut>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


            var mockContext = new Mock<ShopContext>();
            mockContext.Setup(x => x.Nuts).Returns(mockSet.Object);

            var service = new NutController(mockContext.Object);
            var nuts = service.GetAllNuts();

            int deletedNutId = 1; service.Delete(nuts[0].Id);

            Assert.IsNull(service.GetAllNuts().FirstOrDefault(x => x.Id == deletedNutId));
        }
    }
}
