using NUnit.Framework;
using SdetBootcampDay1.TestObjects;

namespace SdetBootcampDay1.Exercises
{
    [TestFixture]
    public class Exercises02
    {
        /**
         * DONE: rewrite these three tests into a single, parameterized test.
         * You decide if you want to use [TestCase] or [TestCaseSource], but
         * I would like to know why you chose the option you chose afterwards.
         */
        [TestCase(100, 50, 50, TestName = "Deposit 100 and Withdraw 50 is 50")]
        [TestCase(1000, 1000, 0, TestName = "Deposit 1000 and Withdraw 1000 is 0")]
        [TestCase(250, 1, 249, TestName = "Deposit 250 and Withdraw 1 is 249")]

        public void GivenANewSavingsAccount_WhenIDepositandWithdrawSomeAmount_thenTheTotalIsAsExpected
                (int deposit, int withdraw, int expectedTotal)
            {
                var account = new Account(AccountType.Savings);

                account.Deposit(deposit);
                account.Withdraw(withdraw);

                Assert.That(account.Balance, Is.EqualTo(expectedTotal));
            }

        [Test, TestCaseSource("SavingsAccountTestData")]
        public void GivenANewSavingsAccount_WhenIDepositandWithdrawSomeAmount_thenTheTotalIsAsExpected_UsingTestCaseSource
                (int deposit, int withdraw, int expectedTotal)
            {
                var account = new Account(AccountType.Savings);

                account.Deposit(deposit);
                account.Withdraw(withdraw);

                Assert.That(account.Balance, Is.EqualTo(expectedTotal));
            }

        private static IEnumerable<TestCaseData> SavingsAccountTestData()
        {
            yield return new TestCaseData(100, 50, 50).
                SetName("Deposit 100 and Withdraw 50 is 50 (Source Version)");
            yield return new TestCaseData(1000, 1000, 0).
                SetName("Deposit 1000 and Withdraw 1000 is 0 (Source Version)");
            yield return new TestCaseData(250, 1, 249).
                SetName("Deposit 250 and Withdraw 1 is 249 (Source Version)");
        }

        // public void CreateNewSavingsAccount_Deposit100Withdraw50_BalanceShouldBe50()
        // {
        //     var account = new Account(AccountType.Savings);

        //     account.Deposit(100);
        //     account.Withdraw(50);

        //     Assert.That(account.Balance, Is.EqualTo(50));
        // }

        // [Test]
        // public void CreateNewSavingsAccount_Deposit1000Withdraw1000_BalanceShouldBe0()
        // {
        //     var account = new Account(AccountType.Savings);

        //     account.Deposit(1000);
        //     account.Withdraw(1000);

        //     Assert.That(account.Balance, Is.EqualTo(0));
        // }

        // [Test]
        // public void CreateNewSavingsAccount_Deposit250Withdraw1_BalanceShouldBe249()
        // {
        //     var account = new Account(AccountType.Savings);

        //     account.Deposit(250);
        //     account.Withdraw(1);

        //     Assert.That(account.Balance, Is.EqualTo(249));
        // }
    }
}
