using ATM_Machine;
using System;
using Xunit;

namespace ATM_Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(5000, Program.ViewBalance(Program.Balance = 5000));
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(50009, Program.ViewBalance(Program.Balance = 50009));
        }

        [Theory]
        [InlineData(200, 4800)]
        [InlineData(5000, 0)]
        [InlineData(2500, 2500)]
        [InlineData(4999, 1)]
        public void Test3(decimal num, decimal expected)
        {
            Program.Balance = 5000;
            decimal actual = Program.Withdraw(num);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(200, 5200)]
        [InlineData(5000, 10000)]
        [InlineData(2500, 7500)]
        [InlineData(4999, 9999)]
        public void Test4(decimal num, decimal expected)
        {
            Program.Balance = 5000;
            decimal actual = Program.Deposit(num);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThrowExceptionIfWithdrawingMoreThanBalance()
        {
            Program.Balance = 20;
            Assert.Throws<Exception>(() => Program.Withdraw(9999999));
        }
    }
}
