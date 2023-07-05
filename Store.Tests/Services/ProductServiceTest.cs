using Store.API.Repository;
using Store.API.Services;
using Moq;
using Store.API.Entities;
using Xunit;

namespace Store.Tests.Services
{
    public class ProductServiceTest
    {
        IEnumerable<Product> products = new Product[]
        {
            new Product {
                Id = 1,
                Description = "Terrain in Medellín",
                Type = ProductType.Terrains,
                Value = 60000000,
                PurchaseDate = DateTime.Now,
                Status = false
            },
            new Product
            {
                Id = 2,
                Description = "Libero 125cc",
                Type = ProductType.Vehicles,
                Value = 4000000,
                PurchaseDate = DateTime.Now,
                Status = false
            },
            new Product
            {
                Id = 3,
                Description = "Aparment in Itagüí",
                Type = ProductType.Apartments,
                Value = 59000000,
                PurchaseDate = DateTime.Now,
                Status = false
            }
        };

        Product newProduct = new Product
        {
            Id = 4,
            Description = "Terrain in Medellín",
            Type = ProductType.Terrains,
            Value = 60000000,
            PurchaseDate = DateTime.Now,
            Status = false
        };

        Product editedProduct = new Product
        {
            Id = 2,
            Description = "Libero 125cc",
            Type = ProductType.Vehicles,
            Value = 4000000,
            PurchaseDate = DateTime.Now,
            Status = false
        };

        string query = "in";

        IEnumerable<Product> filtered = new Product[]
        {
            new Product {
                Id = 1,
                Description = "Terrain in Medellín",
                Type = ProductType.Terrains,
                Value = 60000000,
                PurchaseDate = DateTime.Now,
                Status = false
            },
            new Product
            {
                Id = 3,
                Description = "Aparment in Itagüí",
                Type = ProductType.Apartments,
                Value = 59000000,
                PurchaseDate = DateTime.Now,
                Status = false
            }
        };

        IProductService _productService;

        public void setupMock()
        {
            var repository = new Mock<IProductRepository>();
            repository.Setup(r => r.GetProducts()).Returns(products);

            var productById = products.FirstOrDefault(p => p.Id == 3);
            repository.Setup(r => r.GetProductById(3)).Returns(productById);

            var productById2 = products.FirstOrDefault(p => p.Id == 7);
            repository.Setup(r => r.GetProductById(7)).Returns(productById2);

            repository.Setup(r => r.AddProduct(newProduct)).Returns(newProduct);
            repository.Setup(r => r.UpdateProduct(2, editedProduct)).Returns(true);
            repository.Setup(r => r.DeleteProduct(4)).Returns(true);

            editedProduct.Id = 5;
            repository.Setup(r => r.UpdateProduct(5, editedProduct)).Returns(false);
            repository.Setup(r => r.DeleteProduct(6)).Returns(false);
            repository.Setup(r => r.GetByDescription(query)).Returns(filtered);

            _productService = new ProductService(repository.Object);
        }

        [Fact]
        public void GetProductsShouldReturnList()
        {
            // Arrange
            setupMock();

            // Act
            var actuals = _productService.GetProducts();

            // Assert
            Assert.Equal(products, actuals);
        }

        [Fact]
        public void GetProductByIdShouldReturnEntity()
        {
            // Arrange
            setupMock();
            var expected = products.FirstOrDefault(p => p.Id == 3);

            // Act
            var actual = _productService.GetProductById(3);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetProductByIdShouldReturnNull()
        {
            // Arrange
            setupMock();
            var expected = products.FirstOrDefault(p => p.Id == 7);

            // Act
            var actual = _productService.GetProductById(7);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddProductShouldReturnSameEntity()
        {
            // Arrange
            setupMock();

            // Act
            var actual = _productService.AddProduct(newProduct);

            // Assert
            Assert.Equal(newProduct, actual);
        }

        [Fact]
        public void UpdateShouldReturnTrue()
        {
            // Arrange
            setupMock();

            // Act
            var actual = _productService.UpdateProduct(2, editedProduct);

            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void DeleteShouldReturnTrue()
        {
            // Arrange
            setupMock();

            // Act
            var actual = _productService.DeleteProduct(4);

            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void UpdateShouldReturnFalse()
        {
            // Arrange
            setupMock();

            // Act
            var actual = _productService.UpdateProduct(5, editedProduct);

            // Assert
            Assert.False(actual);
        }

        [Fact]
        public void DeleteShouldReturnFalse()
        {
            // Arrange
            setupMock();

            // Act
            var actual = _productService.DeleteProduct(6);

            // Assert
            Assert.False(actual);
        }

        [Fact]
        public void GetByDescriptionShouldFindTwo()
        {
            // Arrange
            setupMock();

            // Act
            var actual = _productService.GetByDescription("in");

            // Assert
            Assert.Equal(2, actual.Count());
            Assert.Equal(filtered, actual);
        }
    }
}
