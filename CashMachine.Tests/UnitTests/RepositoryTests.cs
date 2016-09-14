using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CashMachine.Tests.UnitTests
{
    [TestFixture]
    public class RepositoryTests
    {
        [Test]
        public void Should_be_able_to_calculate_balance()
        {
            //Arrange
            var repository = Repository.Repository.GetInitRepository();
            var expected = 4638.00;

            //Act
            var actual = Repository.Repository.CalculateBalance(repository);

            //Assert
            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}
