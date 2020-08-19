using System;
using FluentRanges;

namespace NugetPackageDemo.FluentRanges
{
    class Program
    {
        static void Main(string[] args)
        {
            var startsAt = DateTime.Now;
            var dr = new DateTimeRange(startsAt, startsAt.AddSeconds(10));
            Console.WriteLine($"Duration of range in milliseconds: { dr.Duration.TotalMilliseconds}");

            //actualSum >= expectedTotalSum - margin && actualSum <= expectedTotalSum - margin
            //new DRange(invoiceTotalSum, margin).IsBetween(actualSum);
            //actualSum.IsBetWeen(new DRange(invoiceTotalSum, margin))




            //actualSum > invoiceTotalSum - margin && actualSum < invoiceTotalSum - margin
            //new DRange(invoiceTotalSum, margin).IsBetween(actualSum);
            //actualSum.IsBetWeen(new DRange(invoiceTotalSum, margin))

            //if(invoiceSum >= expectedSum && dateInvoice > deadlineDate) {}
            //if(invoiceSum.IsGreaterThen(expectedSum) && dateInvoice.HappenedAfter(deadlineDate)) {}

            //IsGreaterThen operator
            //if(invoiceSum >= expectedSum && dateInvoice > deadlineDate) {}
            //if(invoiceSum.IsGreaterThen(expectedSum) && dateInvoice.HappenedAfter(deadlineDate)) {}

            //IsBetween operator
            //if(invoiceSum >= expectedSum && dateInvoice > deadlineDate) {}
            //if(invoiceSum.IsGreaterThen(expectedSum) && dateInvoice.HappenedAfter(deadlineDate)) {}

            //HappenedXXX operator
            
            //HappenedAtXXX operator
            
            //SetUpper && SetLower
            
        }
    }
}
