using System;
using System.Security.Cryptography;

namespace CouponCode
{
    public class SecureRandom : RandomNumberGenerator
    {
        private readonly RandomNumberGenerator _rng = new RNGCryptoServiceProvider();

        public int Next(int maxValue)
        {
            return Next(0, maxValue);
        }

        public int Next(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("minValue", minValue, "minValue cannot be greater than maxValue");
            }

            return (int)Math.Floor((minValue + ((double)maxValue) - minValue) * this.NextDouble());
        }

        public double NextDouble()
        {
            var data = new byte[sizeof(uint)];
            _rng.GetBytes(data);

            var randUint = BitConverter.ToUInt32(data, 0);

            return randUint / (uint.MaxValue + 1.0);
        }

        public override void GetBytes(byte[] data)
        {
            _rng.GetBytes(data);
        }

        public override void GetNonZeroBytes(byte[] data)
        {
            _rng.GetNonZeroBytes(data);
        }
    }
}