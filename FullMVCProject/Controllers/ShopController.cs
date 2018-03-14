using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FullMVCProject.Models;

namespace FullMVCProject.Controllers
{
    public class ShopController : Controller
    {
        private ProductModel _model;
        public ShopController() { }
        public ShopController(ProductModel model)
        {
            _model = model;
        }
        // GET: Shop
        public ViewResult Index()
        {
            ViewBag.Title = "The shop";
            ViewBag.WelcomeMessage = "Welcome to the shop!. Kindly spend all your money with us!";
            ViewData["CurrentTime"] = DateTime.Now;
            return View();

        }
        public ViewResult Product()
        {
            if(_model == null)
            {
                _model = new ProductModel();
                _model.Name = "Iphone 6";
                _model.Description = "Better than the IPhone 5 etc";
                _model.Price = 399.99M;
            }
            ProductModel productModel = new ProductModel();
            productModel.Name = "IPhone 6";
            productModel.Description = "Latest IPhone with things that make it better.";
            productModel.Price = 350.00M;


            if(_model.Price > 200)
            {
                ViewBag.SubTitle = "Bling!";
            }
            else
            {
                ViewBag.SubTitle = "Cheap and nasty product!";
            }
            return View(_model);

        }
        public RedirectResult DVD()
        {
            return Redirect("~/Shop/Product");
        }

    }
}