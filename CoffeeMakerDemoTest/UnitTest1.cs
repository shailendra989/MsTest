using CoffeeMakerDemo;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CoffeeMakerDemoTest
{
    [TestClass]
   
        public class UnitTest1
        {
            [TestMethod]
            public void OrderACoffee_Should_return_Received_Message()
            {
                StarbuckStore store = new StarbuckStore(new FakeStarbucksStore());
                string result = store.OrderCoffee(2, 4);
                Assert.AreEqual("Your Order is received.", result);
            }

            [TestMethod]
            public void OrderACoffee_Should_Return_Received_MessageUsingStub()
            {
                StarbuckStore store = new StarbuckStore(new StubStarbucks());
                string result = store.OrderCoffee(2, 4);
                Assert.AreEqual("Your order is received.", result);
            }

            //Moq MOCK

            [TestMethod]
            public void OrderACoffee_Should_Return_Received_MessageUsingMock()
            {
                var service = new Mock<IMakeACoffee>();
                service.Setup(x => x.CheckIngredientAvailability()).Returns(true);
                service.Setup(x => x.CoffeeMaking(It.IsAny<int>(), It.IsAny<int>())).Returns("Your Order is received");
                //var result = store.OrderCoffee(2, 4);
                //Assert.AreEqual("Your Order is received", result);

            }



        }





    }




