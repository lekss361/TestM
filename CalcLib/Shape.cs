using System.Numerics;

namespace CalcLib
{
    public abstract class Shape
    {
        public abstract double Area();
        protected static void CheckOverlfow<T>(T value) where T : INumber<T>
        {
            if (T.IsInfinity(value) || T.IsNaN(value))
                throw new OverflowException("The operation resulted in an overflow.");
        }
    }
}
