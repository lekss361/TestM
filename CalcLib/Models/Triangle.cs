namespace CalcLib.Models
{
    public class Triangle : Shape
    {
        private double _sideA;
        private double _sideB;
        private double _sideC;
        private bool? _isTriangleRectangle = null;
        private double? _area = null;

        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
            IsTriangle();
        }

        public double SideA
        {
            get { return _sideA; }
            private set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value, nameof(SideA));
                _sideA = value;
            }
        }
        public double SideB
        {
            get { return _sideB; }
            private set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value, nameof(SideB));
                _sideB = value;
            }
        }
        public double SideC
        {
            get { return _sideC; }
            private set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value, nameof(SideC));
                _sideC = value;
            }
        }
        public override double Area()
        {
            double result;
            if (_area == null)
            {
                double semiperimeter = (_sideA + _sideB + _sideC) / 2;
                result = Math.Sqrt(semiperimeter * (semiperimeter - _sideA) * (semiperimeter - _sideB) * (semiperimeter - _sideC));
                CheckOverlfow(result);
                _area = result;
            }

            return (double)_area;
        }

        public bool IsTriangleRectangle()
        {
            if (_isTriangleRectangle == null)
            {
                return (bool)(_isTriangleRectangle = (
                IsPifagore(_sideA, _sideB, _sideC))
                || IsPifagore(_sideA, _sideC, _sideB)
                || IsPifagore(_sideC, _sideB, _sideA)
                );
            }
            else
                return (bool)_isTriangleRectangle;
        }
        private void IsTriangle()
        {
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(_sideA + _sideB, _sideC);
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(_sideB + _sideC, _sideA);
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(_sideC + _sideA, _sideB);
        }
        private static bool IsPifagore(double sideA, double sideB, double sideC)
        {
            double leftpart = sideA * sideA + sideB * sideB;
            double rightpart = sideC * sideC;
            CheckOverlfow(leftpart);
            CheckOverlfow(rightpart);
            return leftpart == rightpart;
        }
    }
}
