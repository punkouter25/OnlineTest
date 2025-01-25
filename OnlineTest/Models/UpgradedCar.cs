using OnlineTest.Interfaces;

namespace OnlineTest.Models
{
    public class UpgradedCar : CarBase
    {
        private readonly IEngine _engine;
        private readonly IDoor _door;
        private readonly IHonker _honker;
        private int _currentSpeed;

        public UpgradedCar(IEngine engine, IDoor door, IHonker honker)
        {
            _engine = engine;
            _door = door;
            _honker = new UpgradedHonker(7);
            SetSpeed();
        }

        public override int GetCylinders()
        {
            return _engine.GetCylinders();
        }

        public override int GetDoorCount()
        {
            return _door.GetDoorCount();
        }

        public override int GetCurrentSpeed()
        {
            return _currentSpeed;
        }

        public string GetDescription()
        {
            return $"Upgraded Fancy car with {_engine.GetCylinders()} cylinders and {_door.GetDoorCount()} doors.";
        }

        public override void SetSpeed()
        {
            int n = _engine.GetCylinders();
            _currentSpeed = SpeedCalculator.CalculateSpeed(n);
        }

        public override void Beep()
        {
            _honker.Beep();
        }
    }
}
