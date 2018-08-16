using System.Text;

namespace CouponCode
{
    /// <summary>
    /// The <see cref="CouponCodeBuilder" /> class for building new random coupon codes.
    /// </summary>
    public class CouponCodeBuilder
    {
        private const string Symbols = "234679CDFGHJKLMNPQRTVWXYZ";
        private readonly SecureRandom _rng = new SecureRandom();

        /// <summary>
        /// Generates a new random code with the supplied format and option prefix.
        /// </summary>
        /// <param name="format">The format of the code using hashes for code symbols, e.g. "####-####-####".</param>
        /// <param name="prefix">The optional prefix for the code, e.g. "ABC-".</param>
        /// <returns></returns>
        public string GenerateCode(string format, string prefix = null)
        {
            var code = new StringBuilder(prefix ?? string.Empty);

            foreach (var glyph in format)
            {
                if (glyph != '#')
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