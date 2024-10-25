using Castle.Core.Resource;
using NUnit.Framework;
using SdetBootcampDay2.TestObjects.Exercises;

namespace SdetBootcampDay2.Exercises
{
    [TestFixture]
    public class Exercises01
    {
        /**
         * DONE: After updating the OrderHandler to fix the Single Responsibility violation,
         * make the tests work again.
         */

        /**
         * DONE: After updating the OrderHandler to fix the Dependency Inversion violations,
         * make the tests work again.
         */

        [Test]
        public void Order1CopyOfFIFA24_ShouldLeave9CopiesRemaining()
        {
            var orderHandler = new OrderHandler(new Dictionary<OrderItem, int>{{ OrderItem.FIFA_24, 10 }}, new PaymentProcessor(PaymentProcessorType.Stripe));

            orderHandler.Order(OrderItem.FIFA_24, 1);

            Assert.That(orderHandler.GetStockFor(OrderItem.FIFA_24), Is.EqualTo(9));
        }

        [Test]
        public void Order101CopiesOfFortnite_ShouldYieldArgumentException()
        {
            var orderHandler = new OrderHandler(new Dictionary<OrderItem, int>{{ OrderItem.Fortnite, 10 }}, new PaymentProcessor(PaymentProcessorType.Stripe));

            var ae = Assert.Throws<ArgumentException>(() =>
            {
                orderHandler.Order(OrderItem.Fortnite, 101);
            });

            Assert.That(ae!.Message, Is.EqualTo("Insufficient stock for item Fortnite"));
        }

        [Test]
        public void AddStockForDayOfTheTentacle_ShouldYieldArgumentException()
        {
            var orderHandler = new OrderHandler(new Dictionary<OrderItem, int>{{ OrderItem.Fortnite, 10 }}, new PaymentProcessor(PaymentProcessorType.Stripe));

            var ae = Assert.Throws<ArgumentException>(() =>
            {
                orderHandler.AddStock(OrderItem.DayOfTheTentacle, 10);
            });

            Assert.That(ae!.Message, Is.EqualTo("Unknown item DayOfTheTentacle"));
        }

        /**
         * DONE: Add a test that tests that injects a stock count of 0 for Day Of The Tentacle,
         * tries to order a copy and verifies that the expected exception with the expected message
         * is thrown.
         */

        [Test]
        public void Add0StockForDayOfTheTentacle_OrderCopy_ShouldYieldArgumentException()
        {
            var orderHandler = new OrderHandler(new Dictionary<OrderItem, int>{{ OrderItem.DayOfTheTentacle, 0 }}, new PaymentProcessor(PaymentProcessorType.Stripe));

            var ae = Assert.Throws<ArgumentException>(() =>
            {
                orderHandler.Order(OrderItem.DayOfTheTentacle, 1);
            });

            Assert.That(ae!.Message, Is.EqualTo("Insufficient stock for item DayOfTheTentacle"));
        }

        /**
         * DONE: Add a test that that creates a new OrderHandler using PayPal as a payment
         * processor, and test that ordering more than five items results in a payment failure,
         * even when there is enough stock.
         */
        [Test]
        public void Add10StockforFortnite_TryToPayForMoreThanFiveItemsUsingPayPal_PaymentShouldFail()
        {
            var orderHandler = new OrderHandler(new Dictionary<OrderItem, int>{{ OrderItem.Fortnite, 10 }}, new PaymentProcessor(PaymentProcessorType.Paypal));

            Assert.That(orderHandler.Pay(OrderItem.Fortnite, 6), Is.False);
            
        }


    }
}
