using System.Text;

namespace CouponCode
{
    public class CouponCodeBuilder
    {
        private const string Symbols = "234679CDFGHJKLMNPQRTVWXYZ";
        private readonly SecureRandom _rng = new SecureRandom();

        public string GenerateCode(string prefix, string format)
        {
            var code = new StringBuilder(prefix);

            foreach (var glyph in format)
            {
                if (glyph != 'X')
                {
                    code.Append(glyph);
                    continue;
                }

                var randomSymbol = this.GetRandomSymbol();
                code.Append(randomSymbol);
            }

            return code.ToString();
        }

        private char GetRandomSymbol()
        {
            var pos = _rng.Next(Symbols.Length);

            return Symbols[pos];
        }
    }
}