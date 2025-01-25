using OnlineTest.Interfaces;

namespace OnlineTest.Models
{
    public class BasicCar : CarBase
    {
        private readonly IHonker _honker;

        private readonly int _cylinders = 4;
        private readonly int _doors = 2;
        private int _currentSpeed;

        public BasicCar(IHonker honker)
        {
            _honker = honker;
            SetSpeed();
        }

        public BasicCar()
        {
        }

        public override int GetCylinders()
        {
            return _cylinders;
        }

        public override int GetDoorCount()
        {
            return _doors;
        }

        public override int GetCurrentSpeed()
        {
            return _currentSpeed;
        }

        public string GetDescription()
        {
            return $"Basic old looking car with {_cylinders} cylinders and {_doors} doors.";
        }   

        public override void SetSpeed()
        {
            int cylinders = GetCylinders();
            _currentSpeed = SpeedCalculator.CalculateSpeed(cylinders);
        }

        public override void Beep()
        {
            _honker.Beep();
        }
    }
}
