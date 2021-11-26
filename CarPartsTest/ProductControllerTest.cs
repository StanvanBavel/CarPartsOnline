using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CarPartsTest
{
    [TestClass]
    public class ProductControllerTest
    {
        Controller _controller;
        IBookService _service;

        public BooksControllerTest()
        {
            _service = new BookService();
            _controller = new BooksController(_service);

        }

        [Fact]
        public void GetAllTest()
        {
            //Arrange
            //Act
            var result = _controller.Get();
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

            var list = result.Result as OkObjectResult;

            Assert.IsType<List<Book>>(list.Value);



            var listBooks = list.Value as List<Book>;

            Assert.Equal(5, listBooks.Count);
        }
    }
}
