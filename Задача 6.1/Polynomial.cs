using System;
using System.Collections.Generic;
using System.Linq;

namespace Задача_6_1
{
    public class Polynomial
    {
        public List<PolynomialPart> parts { get; set; }

        public Polynomial()
        {
            parts = new List<PolynomialPart>();
        }

        public Polynomial(string s)
        {
            parts = new List<PolynomialPart>();
            Parse(s);

            parts.Sort((x, y) => x.PolynomRank.CompareTo(y.PolynomRank));
        }

        public int this[int c]
        {
            set
            {
                PolynomialPart part = parts.FirstOrDefault(x => x.PolynomRank == c);

                if (value != 0)
                {
                    if (part != null)
                    {
                        part.RealPart = value;
                    }
                    else
                    {
                        PolynomialPart newPart = new PolynomialPart(value, c);
                        parts.Add(newPart);
                    }
                }
                else if (value == 0)
                {
                    if (part != null)
                    {
                        parts.Remove(part);
                    }
                }

                parts.Sort((x, y) => x.PolynomRank.CompareTo(y.PolynomRank));
            }
        }

        public static Polynomial operator +(Polynomial a, Polynomial b)
        {
            Polynomial newPolynomial = new Polynomial();
            foreach (PolynomialPart part in a.parts)
                newPolynomial.parts.Add(new PolynomialPart(part.RealPart, part.PolynomRank));

            foreach (PolynomialPart polynomialPart in b.parts)
            {
                PolynomialPart part = newPolynomial.parts.FirstOrDefault(x => x.PolynomRank == polynomialPart.PolynomRank);
                if (part != null)
                {
                    part.RealPart += polynomialPart.RealPart;

                    if (part.RealPart == 0)
                    {
                        newPolynomial.parts.Remove(part);
                    }
                }
                else
                {
                    newPolynomial.parts.Add(polynomialPart);
                }
            }

            newPolynomial.parts.Sort((x, y) => x.PolynomRank.CompareTo(y.PolynomRank));

            return newPolynomial;
        }

        public static Polynomial operator -(Polynomial a, Polynomial b)
        {
            Polynomial newPolynomial = new Polynomial();
            foreach (PolynomialPart part in a.parts)
                newPolynomial.parts.Add(part);

            foreach (PolynomialPart polynomialPart in b.parts)
            {
                PolynomialPart part = newPolynomial.parts.FirstOrDefault(x => x.PolynomRank == polynomialPart.PolynomRank);
                if (part != null)
                {
                    part.RealPart -= polynomialPart.RealPart;

                    if (part.RealPart == 0)
                    {
                        newPolynomial.parts.Remove(part);
                    }
                }
                else
                {
                    PolynomialPart newPart = new PolynomialPart(-polynomialPart.RealPart, polynomialPart.PolynomRank);
                    newPolynomial.parts.Add(newPart);
                }
            }

            newPolynomial.parts.Sort((x, y) => x.PolynomRank.CompareTo(y.PolynomRank));

            return newPolynomial;
        }

        public static Polynomial operator *(Polynomial a, Polynomial b)
        {
            Polynomial newPolynomial = new Polynomial();

            foreach(PolynomialPart aPart in a.parts)
            {
                foreach(PolynomialPart bPart in b.parts)
                {
                    newPolynomial.parts.Add(new PolynomialPart(aPart.RealPart * bPart.RealPart, aPart.PolynomRank + bPart.PolynomRank));
                }
            }

            newPolynomial.parts.Sort((x, y) => x.PolynomRank.CompareTo(y.PolynomRank));
            return newPolynomial;
        }

        public static implicit operator Polynomial(double t)
        {
            Polynomial newPolynomial = new Polynomial();
            newPolynomial.parts.Add(new PolynomialPart(t, 0));
            return newPolynomial;
        }

        public void Parse(string s)
        {
            string[] parts = s.Split("+");

            for(int i = 0; i < parts.Length; i++)
            {
                string[] numbers = parts[i].Split("x^");

                double realPart = double.Parse(numbers[0]);
                int polynomRank = int.Parse(numbers[1]);

                PolynomialPart part = new PolynomialPart(realPart, polynomRank);
                this.parts.Add(part);
            }
        }

        public override string ToString()
        {
            string result = "";

            for(int i = 0; i < parts.Count; i++)
            {
                if (i == 0)
                {
                    result += parts[i].ToString();
                }
                else
                {
                    if (parts[i].RealPart > 0)
                    {
                        result += "+";
                    }
                    result += parts[i].ToString();
                }
            }

            return result;
        }
    }
}