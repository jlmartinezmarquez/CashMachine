using CashMachine.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashMachine.Business;

namespace CashMachine.Tests.UnitTests
{
    [TestFixture]
    public class CashMachineOperationsTests
    {
        private List<Item> _repository;

        [SetUp]
        public void Setup()
        {
            _repository = Repository.Repository.GetInitRepository();    //In a real world solution (ie, the repository represents a database) I would mock the repository
        }
        
        #region Algorithm 1

        [Test]
        public void Should_be_able_to_withdraw_least_number_of_items()
        {
            //Arrange
            var expected = new Withdrawal
            {
                WithdrawnItems = new List<Item>
                {
                    new Item
                    {
                        NumberOfAvailableItems = 2,
                        Size = Size.Fifty,
                        Type = ItemType.Pound
                    },
                    new Item
                    {
                        NumberOfAvailableItems = 1,
                        Size = Size.Twenty,
                        Type = ItemType.Pound
                    },
                },
                BalanceAfter = 4518
            };

            //Act
            var amount = 120.00;
            var cashMachine = new CashMachineOperations();
            var actual = cashMachine.ReturnLeastNumberOfItems(amount, _repository);

            //Assert
            Assert.That(expected.BalanceAfter, Is.EqualTo(actual.BalanceAfter));
            Assert.That(expected.WithdrawnItems.Count, Is.EqualTo(actual.WithdrawnItems.Count));
            for (var i = 0; i < expected.WithdrawnItems.Count; i++)
            {
                Assert.IsTrue(expected.WithdrawnItems[i].Equals(actual.WithdrawnItems[i]));
            }
        }

        [Test]
        public void Should_be_able_to_withdraw_least_number_of_items_for_zero_amount()
        {
            //Arrange
            var expected = new Withdrawal
            {
                WithdrawnItems = new List<Item>(),
                BalanceAfter = 4638.00
            };

            //Act
            var amount = 0.00;
            var cashMachine = new CashMachineOperations();
            var actual = cashMachine.ReturnLeastNumberOfItems(amount, _repository);

            //Assert
            Assert.That(expected.BalanceAfter, Is.EqualTo(actual.BalanceAfter));
            Assert.That(expected.WithdrawnItems.Count, Is.EqualTo(actual.WithdrawnItems.Count));
            for (var i = 0; i < expected.WithdrawnItems.Count; i++)
            {
                Assert.IsTrue(expected.WithdrawnItems[i].Equals(actual.WithdrawnItems[i]));
            }
        }

        [Test]
        public void Should_error_least_number_for_bigger_amount_than_balance()
        {
            var amount = 10000.00;
            var cashMachine = new CashMachineOperations();
            var actual = cashMachine.ReturnLeastNumberOfItems(amount, _repository);

            Assert.IsNull(actual);
        }

        [Test]
        public void Should_error_least_number_for_negative_amount()
        {
            var amount = -3.52;
            var cashMachine = new CashMachineOperations();
            var actual = cashMachine.ReturnLeastNumberOfItems(amount, _repository);

            Assert.IsNull(actual);
        }

        #endregion

        //#region Algorithm 2

        //[Test]
        //public void Should_be_able_to_withdraw_highest_number_of_20s()
        //{
        //    //Arrange
        //    var expected = new Withdrawal
        //    {
        //        WithdrawnItems = new List<Item>
        //        {
        //            new Item
        //            {
        //                NumberOfAvailableItems = 6,
        //                Size = Size.Twenty,
        //                Type = ItemType.Pound
        //            },
        //            new Item
        //            {
        //                NumberOfAvailableItems = 1,
        //                Size = Size.Twenty,
        //                Type = ItemType.Pound
        //            },
        //        },
        //        BalanceAfter = 4518
        //    };

        //    //Act
        //    var amount = 120.00;
        //    var cashMachine = new CashMachineOperations();
        //    var actual = cashMachine.ReturnHighestNumberOf20Notes(amount, _repository);

        //    //Assert
        //    Assert.That(expected.BalanceAfter, Is.EqualTo(actual.BalanceAfter));
        //    Assert.That(expected.WithdrawnItems.Count, Is.EqualTo(actual.WithdrawnItems.Count));
        //    for (var i = 0; i < expected.WithdrawnItems.Count; i++)
        //    {
        //        Assert.IsTrue(expected.WithdrawnItems[i].Equals(actual.WithdrawnItems[i]));
        //    }
        //}

        //[Test]
        //public void Should_be_able_to_withdraw_highest_number_of_20s_for_zero_amount()
        //{
        //    //Arrange
        //    var expected = new Withdrawal
        //    {
        //        WithdrawnItems = new List<Item>(),
        //        BalanceAfter = 4638.00
        //    };

        //    //Act
        //    var amount = 0.00;
        //    var cashMachine = new CashMachineOperations();
        //    var actual = cashMachine.ReturnHighestNumberOf20Notes(amount, _repository);

        //    //Assert
        //    Assert.That(expected.BalanceAfter, Is.EqualTo(actual.BalanceAfter));
        //    Assert.That(expected.WithdrawnItems.Count, Is.EqualTo(actual.WithdrawnItems.Count));
        //    for (var i = 0; i < expected.WithdrawnItems.Count; i++)
        //    {
        //        Assert.IsTrue(expected.WithdrawnItems[i].Equals(actual.WithdrawnItems[i]));
        //    }
        //}

        //[Test]
        //public void Should_error_highest_20s_for_bigger_amount_than_balance()
        //{
        //    var amount = 10000.00;
        //    var cashMachine = new CashMachineOperations();
        //    var actual = cashMachine.ReturnHighestNumberOf20Notes(amount, _repository);

        //    Assert.IsNull(actual);
        //}

        //[Test]
        //public void Should_error_highest_20s_for_negative_amount()
        //{
        //    var amount = -3.52;
        //    var cashMachine = new CashMachineOperations();
        //    var actual = cashMachine.ReturnHighestNumberOf20Notes(amount, _repository);

        //    Assert.IsNull(actual);
        //}

        //#endregion
        }
    }
