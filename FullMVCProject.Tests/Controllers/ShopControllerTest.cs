using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using FullMVCProject.Controllers;
using FullMVCProject.Models;

namespace FullMVCProject.Controllers
{
    [TestClass]
    public class ShopControllerTest
    {

        [TestMethod]
        public void IndexWelcomeMessage()
        {

            //Arrange
            ProductModel model = new ProductModel();
            ShopController controller = new ShopController(model);


            //Act
            ViewResult result = controller.Index();


            //Assert
            Assert.AreEqual("Welcome to the shop!. Kindly spend all your money with us!",
              controller.ViewBag.WelcomeMessage);

        }

        [TestMethod]
        public void ProductName()
        {
            //Arrange
            ProductModel model = new ProductModel();
            ShopController controller = new ShopController(model);

            //Act
            ViewResult viewResult = controller.Product();
            ProductModel result = viewResult.Model as ProductModel;


            //Assert 
            Assert.AreEqual("Iphone 6", result.Name);
        }

        [TestMethod]
        public void ProductIsBling()
        {
            //Arrange
            ProductModel model = new ProductModel();
            ShopController controller = new ShopController(model);
            //Act
            ViewResult result = controller.Product();
            Assert.AreEqual("Bling!", result.ViewBag.SubTitle);
        }
        [TestMethod]
        public void ProductIsCheapAndNasty()
        {
            //Arrange
            ProductModel model = new ProductModel();
            model.Name = "Test Product 1";
            model.Description = "Description of Test Product 1";
            model.Price = 2.99M;

            //Inject the controller's dependency on the model so we can test it
            ShopController controller = new ShopController(model);

            //Act
            ViewResult result = controller.Product();
            Assert.AreEqual("Cheap and nasty product!", result.ViewBag.SubTitle);
        }
    }
}
