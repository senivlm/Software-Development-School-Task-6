namespace Задача_6_1
{
    public class PolynomialPart
    {
        public double RealPart { get; set; }
        public int PolynomRank { get; set; }

        public PolynomialPart(double realPart, int polynomRank)
        {
            RealPart = realPart;
            PolynomRank = polynomRank;
        }

        public override string ToString()
        {
            string result = "";
            if (RealPart != 1)
            {
                result += RealPart;
            }

            if(PolynomRank == 1)
            {
                result += "x";
            }
            else if(PolynomRank != 0)
            {
                result += "x^" + PolynomRank;
            }
            return result;
        }
    }
}