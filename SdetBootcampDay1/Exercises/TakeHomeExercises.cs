using NUnit.Framework;
using SdetBootcampDay1.TestObjects;

namespace SdetBootcampDay1.Exercises
{
    /**
     * DONE: make sure that this class is recognized by NUnit as a class that contains tests.
     */
    [TestFixture]
    public class TakeHomeExercises
    {
        /**
         * DONE: write a test that creates a new instance of the OrderHandler class,
         * places a new order for 1 copy of FIFA 24 (use the OrderItem.FIFA_24 enum value)
         * and verifies that the remaining number of copies of FIFA_24 on stock is 9.
         */
        [Test]
        public void GivenANewOrderHandle_WhenIOrder1CopyOfFIFA_thenTheStockTotalIs9()
        {
            var orderHandler = new OrderHandler();

            orderHandler.OrderAndPay(OrderItem.FIFA_24, 1);

            Assert.That(orderHandler.GetStockFor(OrderItem.FIFA_24), Is.EqualTo(9));
        }


        /**
         * DONE: write a test that creates a new instance of the OrderHandler class
         * and verifies that placing an order for 101 copies of Fortnite yields an
         * ArgumentException with the message 'Insufficient stock for item Fortnite'.
         */

        [Test]
        public void GivenANewOrderHandle_WhenIOrder101CopiesOfFortnite_thenAnExceptionOccurs()
        {
            var orderHandler = new OrderHandler();

            var arge = Assert.Throws<ArgumentException>(() =>
            {
                orderHandler.OrderAndPay(OrderItem.Fortnite, 101);;
            });

            Assert.That(arge!.Message, Is.EqualTo($"Insufficient stock for item {OrderItem.Fortnite}"));
        }


        /**
         * DONE: write a test that creates a new instance of the OrderHandler class
         * and verifies that trying to add new stock for Day Of The Tentacle yields
         * an ArgumentException with the message 'Unknown item DayOfTheTentacle'.
         */
        [Test]
        public void GivenANewOrderHandle_WhenIAddNewStockForAnUnknownGame_thenAnExceptionOccurs()
        {
            var orderHandler = new OrderHandler();

            var arge = Assert.Throws<ArgumentException>(() =>
            {
                orderHandler.OrderAndPay(OrderItem.DayOfTheTentacle, 1);;
            });

            Assert.That(arge!.Message, Is.EqualTo($"Unknown item {OrderItem.DayOfTheTentacle}"));
        }

        /**
         * TODO: after you have written all of the above tests, calculate the code coverage.
         * What does this tell you? Do we need to write more tests? Can you think of any cases that
         * we haven't covered yet? Add tests for these cases, too and see if you can further improve
         * code coverage.
         */
        
         // We have only tested a few cases for Order and Pay. We haven't tried to add stock or query the amount of stock
         // Nothing tests paypay as a payment method
         //Line | Branch | Method | 28.67% | 37.5%  | 24.44% |

        /**
         * THINK: there are some problems with the code of the OrderHandler class
         * that make it hard to write good tests. Can you spot some of the problems
         * and explain why exactly these are problems? We'll discuss these tomorrow.
         */

         // The order and pay method is doing a lot-- it's the same funciton call to check if an item exists, is in stock and to pay for it
         // Duplicates some functionality that's in getStock for
         // Code hard codes in stock values and doesn't just initialize them which means we have to look at the code for these defaults
    }
}
