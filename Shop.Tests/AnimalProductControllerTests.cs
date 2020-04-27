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
    class AnimalProductControllerTests
    {
        [TestCase]
        public void GetAllAnimalProducts_Gives_All_AnimalProducts()
        {
            var data = new List<AnimalProduct>
            {
                new AnimalProduct { Name="First" },
                new AnimalProduct { Name="Second" },
                new AnimalProduct { Name="Third" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<AnimalProduct>>();
            mockSet.As<IQueryable<AnimalProduct>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<AnimalProduct>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<AnimalProduct>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<AnimalProduct>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ShopContext>();
            mockContext.Setup(c => c.AnimalProducts).Returns(mockSet.Object);

            var controller = new AnimalProductController(mockContext.Object);
            var AnimalProducts = controller.GetAllAnimalProducts();

            Assert.AreEqual(3, AnimalProducts.Count);
            Assert.AreEqual("First", AnimalProducts[0].Name);
            Assert.AreEqual("Second", AnimalProducts[1].Name);
            Assert.AreEqual("Third", AnimalProducts[2].Name);
        }

        [TestCase]
        public void AddAnimalProduct_Add_A_AnimalProduct()
        {
            var mockSet = new Mock<DbSet<AnimalProduct>>();
            var animalProduct = new AnimalProduct();
            var mockContext = new Mock<ShopContext>();
            mockContext.Setup(m => m.AnimalProducts).Returns(mockSet.Object);

            var controller = new AnimalProductController(mockContext.Object);
            controller.Add(animalProduct);

            mockSet.Verify(m => m.Add(It.IsAny<AnimalProduct>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestCase]
        public void GetAnimalProductById_Gives_AnimalProduct_By_Id()
        {
            var data = new List<AnimalProduct>()
            {
                new AnimalProduct{Id=1, Name="AnimalProduct1"},
                new AnimalProduct{Id=2, Name="AnimalProduct2" },
                new AnimalProduct{Id=3, Name="AnimalProduct3"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<AnimalProduct>>();
            mockSet.As<IQueryable<AnimalProduct>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<AnimalProduct>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<AnimalProduct>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<AnimalProduct>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ShopContext>();
            mockContext.Setup(c => c.AnimalProducts).Returns(mockSet.Object);

            var controller = new AnimalProductController(mockContext.Object);

            var animalProduct = controller.GetAnimalProductById(1);
            Assert.AreEqual(1, animalProduct.Id);
        }

        [TestCase]
        public void RemoveAnimalProduct_Remove_A_AnimalProduct()
        {
            var data = new List<AnimalProduct>()
            {
                new AnimalProduct{Id=1, Name="AnimalProduct1"},
                new AnimalProduct{Id=2, Name="AnimalProduct2" },
                new AnimalProduct{Id=3, Name="AnimalProduct3"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<AnimalProduct>>();
            mockSet.As<IQueryable<AnimalProduct>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<AnimalProduct>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<AnimalProduct>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<AnimalProduct>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ShopContext>();
            mockContext.Setup(x => x.AnimalProducts).Returns(mockSet.Object);

            var service = new AnimalProductController(mockContext.Object);
            var animalProducts = service.GetAllAnimalProducts();

            int deletedAnimalProductId = 1; service.Delete(animalProducts[0].Id);

            Assert.IsNull(service.GetAllAnimalProducts().FirstOrDefault(x => x.Id == deletedAnimalProductId));
        }
    }
}