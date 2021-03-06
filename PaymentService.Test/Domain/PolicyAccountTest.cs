﻿using PaymentService.Domain;
using System;
using Xunit;
using static Xunit.Assert;

namespace PaymentService.Tests.Domain
{
    public class PolicyAccountTest
    {
        [Fact]
        public void CanRegisterInPayment()
        {
            var incomeDate = new DateTimeOffset(new DateTime(2018, 1, 1));
            PolicyAccount account = new PolicyAccount("A", "A");
            account.InPayment(10M, incomeDate);

            Equal(1, account.Entries.Count);
            Equal(10M, account.BalanceAt(incomeDate));
        }

        [Fact]
        public void CanRegisterOutpayment()
        {
            var paymentReleaseDate = new DateTimeOffset(new DateTime(2018, 1, 1));
            PolicyAccount account = new PolicyAccount("B", "B");
            account.OutPayment(10M, paymentReleaseDate);

            Equal(1, account.Entries.Count);
            Equal(-10M, account.BalanceAt(paymentReleaseDate));
        }

        [Fact]
        public void CanRegisterExpectdPayment()
        {
            var dueDate = new DateTimeOffset(new DateTime(2018, 1, 1));
            PolicyAccount account = new PolicyAccount("C", "C");
            account.ExpectedPayment(10M, dueDate);

            Equal(1, account.Entries.Count);
            Equal(-10M, account.BalanceAt(dueDate));
        }

        [Fact]
        public void CanProperlyCalculateBalance()
        {
            var dueDate1 = new DateTimeOffset(new DateTime(2018, 1, 1));
            var dueDate2 = new DateTimeOffset(new DateTime(2018, 10, 1));
            var incomeDate = new DateTimeOffset(new DateTime(2018, 5, 1));

            PolicyAccount account = new PolicyAccount("D", "D");
            account.ExpectedPayment(10M, dueDate1);
            account.ExpectedPayment(15M, dueDate2);
            account.InPayment(25M, incomeDate);

            Equal(-10M, account.BalanceAt(dueDate1));
            Equal(15M, account.BalanceAt(incomeDate));
            Equal(0M, account.BalanceAt(dueDate2));
        }
    }
}
