using AutoFixture;
using BawlAPI.Controllers;
using BawlAPI.Dtos.Product;
using BawlAPI.Models;
using BawlAPI.Services.ProductService;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BawlApiMsTest
{
    [TestClass]
   public class ProductControllerTest
    {
        //creating an instance of the repository so that we can get access to the methods in our API
        private Mock<IProductService> _productServiceMock;
        //crearting an instance of the fixture library to create the object that we will need
        private Fixture _fixture;
        //creating an instance of our controller so that we feed the repo into so that when created it uses the mock repo
        private ProductController _controller;

        //constructor to initialise our variables
        public ProductControllerTest()
        {
            _fixture = new Fixture();
            _productServiceMock = new Mock<IProductService>();

        }

        //test method to assert if we are getting our products from the get method
        [TestMethod] 
        public async Task GetProductTest()
        {

            //this is the autofixture creating fake object data using formating from the data transfer object
            var productList = _fixture.CreateMany<Product>(3).ToList();

            //setting up our repository method (Get()) so that whenever we run our test we expect to get an object of 3 products
            _productServiceMock.Setup(repo => repo.Get()).Returns(productList.ToList());

            //product controller to pass our fake product repository with mock data
            _controller = new ProductController(_productServiceMock.Object);

            //executing the asserts for the unit test
            var result = await _controller.Get();
            var obj = result as ObjectResult;

            Assert.AreEqual(200,obj.StatusCode);
            Assert.IsNotNull(obj);
        }


        //test method to assert if an exception will be thrown if there is an error
        [TestMethod]

        public async Task GetProductExceptionTest()
        {
            _productServiceMock.Setup(repo => repo.Get()).Throws(new Exception());

            _controller = new ProductController(_productServiceMock.Object);
            var result = await _controller.Get();
            var obj = result as ObjectResult;

            Assert.AreEqual(400, obj.StatusCode);
        }





    }
}
