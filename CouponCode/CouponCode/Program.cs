using System;

namespace CouponCode
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = new CouponCodeBuilder();

            var code = builder.GenerateCode("####-####-####", "ABC-");

            Console.WriteLine(code);
            Console.ReadLine();
        }
    }
}