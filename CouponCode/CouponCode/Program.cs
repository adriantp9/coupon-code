using System;

namespace CouponCode
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = new CouponCodeBuilder();

            var code = builder.GenerateCode("JLR-", "XXXX-XXXX-XXXX");

            Console.WriteLine(code);
            Console.ReadLine();
        }
    }
}