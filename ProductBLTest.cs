using System.Collections.Generic;
using System.Threading.Tasks;
using Capgemini.GreatOutdoors.BusinessLayer;
using Capgemini.GreatOutdoors.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Capgemini.GreatOutdoors.UnitTests
{
    [TestClass]
    public class AddProductBLTest
    {
        /// <summary>
        /// Add Product to the Collection if it is valid.
        /// </summary>
        [TestMethod]
        public async Task AddValidProduct()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product = new Product()
            {
                ProductName = "CampingTent",
                CategoryName = Category.Camping,
                ProductColour = "Black",
                ProductSize = "L",
                ProductTechSpecs = "Material: Polyester",
                CostPrice = 45.00,
                SellingPrice = 80.99,
                ProductStock = 50
            };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {

                isAdded = await productBL.AddProductBL(product);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// Product Name can't be null
        /// </summary>
        [TestMethod]
        public async Task ProductNameCanNotBeNull()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product = new Product()
            {
                ProductName = null,
                CategoryName = Category.Camping,
                ProductColour = "Black",
                ProductSize = "L",
                ProductTechSpecs = "Material: Polyester",
                CostPrice = 45.00,
                SellingPrice = 80.99,
                ProductStock = 50
            };
            bool isAdded = true;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await productBL.AddProductBL(product);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// Product colour can't be null
        /// </summary>
        [TestMethod]
        public async Task ProductColourCanNotBeNull()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product = new Product()
            {
                ProductName = "Camping Tent",
                CategoryName = Category.Camping,
                ProductColour = null,
                ProductSize = "L",
                ProductTechSpecs = "Material: Polyester",
                CostPrice = 45.00,
                SellingPrice = 80.99,
                ProductStock = 50
            };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await productBL.AddProductBL(product);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// Product Technical Specifications can't be null
        /// </summary>
        [TestMethod]
        public async Task ProductTechnicalSpecificationCanNotBeNull()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product = new Product()
            {
                ProductName = "Camping Tent",
                CategoryName = Category.Camping,
                ProductColour = "Black",
                ProductSize = "L",
                ProductTechSpecs = null,
                CostPrice = 45.00,
                SellingPrice = 80.99,
                ProductStock = 50
            };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await productBL.AddProductBL(product);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }


    }

    [TestClass]
    public class GetProductbyProductIDBLTest
    {
        /// <summary>
        /// Get Product if given ID is valid
        /// </summary>
        [TestMethod]
        public async Task ValidProductID()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product = new Product()
            {
                ProductName = "CampingTent",
                CategoryName = Category.Camping,
                ProductColour = "Black",
                ProductSize = "L",
                ProductTechSpecs = "Material: Polyester",
                CostPrice = 45.00,
                SellingPrice = 80.99,
                ProductStock = 50
            };
            await productBL.AddProductBL(product);
            bool isValid = false;
            string errorMessage = null;

            //Act
            try
            {
                if (product.Equals(await productBL.GetProductByProductIDBL(product.ProductID)))
                    isValid = true;
            }

            catch (Exception ex)
            {
                isValid = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isValid, errorMessage);
            }
        }

        /// <summary>
        /// Should raise an error if invalid Product ID is given
        /// </summary>
        [TestMethod]
        public async Task InvalidProductID()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Guid invalidID = new Guid();
            bool isValid = true;
            string errorMessage = null;

            //Act
            try
            {
                Product product = new Product();
                if ((product = (await productBL.GetProductByProductIDBL(invalidID))) == null)
                    isValid = false;
            }
            catch (Exception ex)
            {
                isValid = true;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isValid, errorMessage);
            }
        }

    }

    [TestClass]
    public class GetProductbyProductNameBLTest
    {
        /// <summary>
        /// Get Product if given Name is valid
        /// </summary>
        [TestMethod]
        public async Task ValidProductName()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product = new Product()
            {
                ProductName = "CampingTent",
                CategoryName = Category.Camping,
                ProductColour = "Black",
                ProductSize = "L",
                ProductTechSpecs = "Material: Polyester",
                CostPrice = 45.00,
                SellingPrice = 80.99,
                ProductStock = 50
            };
            await productBL.AddProductBL(product);
            bool isValid = false;
            string errorMessage = null;

            //Act
            try
            {
                List<Product> products = new List<Product>();
                products = await productBL.GetProductsByNameBL(product.ProductName);
                if (products != null)
                    isValid = true;
            }

            catch (Exception ex)
            {
                isValid = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isValid, errorMessage);
            }
        }

        /// <summary>
        /// Should raise an error if invalid Product ID is given
        /// </summary>
        [TestMethod]
        public async Task InvalidProductName()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            bool isValid = true;
            string errorMessage = null;

            //Act
            try
            {
                List<Product> products = new List<Product>();
                products = await productBL.GetProductsByNameBL("randomstring");
                if (products.Count == 0)
                    isValid = false;
            }
            catch (Exception ex)
            {
                isValid = true;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isValid, errorMessage);
            }
        }

    }


    [TestClass]
    public class DeleteProductBLTest
    {
        /// <summary>
        /// Get Product if given ID is valid
        /// </summary>
        [TestMethod]
        public async Task ValidProductID()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product = new Product()
            {
                ProductName = "CampingTent",
                CategoryName = Category.Camping,
                ProductColour = "Black",
                ProductSize = "L",
                ProductTechSpecs = "Material: Polyester",
                CostPrice = 45.00,
                SellingPrice = 80.99,
                ProductStock = 50
            };
            await productBL.AddProductBL(product);
            bool isValid = false;
            string errorMessage = null;

            //Act
            try
            {
                    isValid = await productBL.DeleteProductBL(product.ProductID);
            }

            catch (Exception ex)
            {
                isValid = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isValid, errorMessage);
            }
        }

        /// <summary>
        /// Should raise an error if invalid Product ID is given
        /// </summary>
        [TestMethod]
        public async Task InvalidProductID()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            bool isValid = true;
            Guid invalidID = new Guid();
            string errorMessage = null;

            //Act
            try
            {
                
                
                    isValid = await productBL.DeleteProductBL(invalidID);
            }
            catch (Exception ex)
            {
                isValid = true;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isValid, errorMessage);
            }
        }

    }

    [TestClass]
    public class UpdateProductBLTest
    {
        /// <summary>
        /// Update Product if given product details is valid
        /// </summary>
        [TestMethod]
        public async Task ValidProduct()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product = new Product()
            {
                ProductName = "CampingTent",
                CategoryName = Category.Camping,
                ProductColour = "Black",
                ProductSize = "L",
                ProductTechSpecs = "Material: Polyester",
                CostPrice = 45.00,
                SellingPrice = 80.99,
                ProductStock = 50
            };
            await productBL.AddProductBL(product);

            product.ProductName = "notcampintent";
            bool isValid = false;
            string errorMessage = null;

            //Act
            try
            {
                isValid = await productBL.UpdateProductBL(product);
            }

            catch (Exception ex)
            {
                isValid = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isValid, errorMessage);
            }
        }

        /// <summary>
        /// Should raise an error if invalid Product Name is given
        /// </summary>
        [TestMethod]
        public async Task InvalidProductName()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product = new Product()
            {
                ProductName = "CampingTent",
                CategoryName = Category.Camping,
                ProductColour = "Black",
                ProductSize = "L",
                ProductTechSpecs = "Material: Polyester",
                CostPrice = 45.00,
                SellingPrice = 80.99,
                ProductStock = 50
            };
            await productBL.AddProductBL(product);
            product.ProductName = "w";
            bool isValid = true;

            string errorMessage = null;

            //Act
            try
            {
                isValid = await productBL.UpdateProductBL(product);
            }
            catch (Exception ex)
            {
                isValid = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isValid, errorMessage);
            }
        }

        /// <summary>
        /// Should raise an error if technical specifications are null
        /// </summary>
        [TestMethod]
        public async Task TechnicalSpecificationsCanNotBeNull()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product = new Product()
            {
                ProductName = "CampingTent",
                CategoryName = Category.Camping,
                ProductColour = "Black",
                ProductSize = "L",
                ProductTechSpecs = "Material: Polyester",
                CostPrice = 45.00,
                SellingPrice = 80.99,
                ProductStock = 50
            };
            await productBL.AddProductBL(product);
            product.ProductTechSpecs = null;
            bool isValid = true;

            string errorMessage = null;

            //Act
            try
            {
                isValid = await productBL.UpdateProductBL(product);
            }
            catch (Exception ex)
            {
                isValid = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isValid, errorMessage);
            }
        }

        /// <summary>
        /// Should raise an error if colour is null
        /// </summary>
        [TestMethod]
        public async Task ColourCanNotBeNull()
        {
            //Arrange
            ProductBL productBL = new ProductBL();
            Product product = new Product()
            {
                ProductName = "CampingTent",
                CategoryName = Category.Camping,
                ProductColour = "Black",
                ProductSize = "L",
                ProductTechSpecs = "Material: Polyester",
                CostPrice = 45.00,
                SellingPrice = 80.99,
                ProductStock = 50
            };
            await productBL.AddProductBL(product);
            product.ProductColour = null;
            bool isValid = true;

            string errorMessage = null;

            //Act
            try
            {
                isValid = await productBL.UpdateProductBL(product);
            }
            catch (Exception ex)
            {
                isValid = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isValid, errorMessage);
            }
        }
    }




}

