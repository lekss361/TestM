namespace CalcLib.Models
{
    public class Circle : Shape
    {

        private double _radius;
        public double Radius
        {
            get
            {
                return _radius;
            }
            private set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value, nameof(Radius));
                _radius = value;
            }
        }

        public Circle(double radius) => Radius = radius;
        public override double Area()
        {
            double result = Math.PI * Math.Pow(_radius, 2);
            CheckOverlfow(result);
            return result;
        }
    }
}
