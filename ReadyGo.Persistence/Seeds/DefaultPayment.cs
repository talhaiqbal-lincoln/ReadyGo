using ReadyGo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadyGo.Persistence.Seeds
{
    public static class DefaultPayment
    {
        public static List<Payment> PaymentList()
        {
            return new List<Payment>()
            {
                new Payment
                {
                    Id = new Guid("01bc87ab-42b6-49c6-90e8-3ac066ed18a0"),
                    CustomerId = new Guid("0DAEC62B-312F-4016-9C5E-A15354259C91"),
                    SalesPersonId = "0daec62b-312f-4016-9c5e-a15354259c90",
                    CurrentBalance = 1000,
                    PaymentReceived = 500,
                    NewBalance = 500,
                    ReceivedAt = new DateTime(2021,11,10)
                },
                new Payment
                {
                    Id = new Guid("01bc87ab-42b6-49c6-90e8-3ac066ed18a1"),
                    CustomerId = new Guid("0DAEC62B-312F-4016-9C5E-A15354259C91"),
                    SalesPersonId = "0daec62b-312f-4016-9c5e-a15354259c90",
                    CurrentBalance = 500,
                    PaymentReceived = 500,
                    NewBalance = 0,
                    ReceivedAt = new DateTime(2021,11,10),
                    IsMarked = true,
                }
            };
        }
    }
}
