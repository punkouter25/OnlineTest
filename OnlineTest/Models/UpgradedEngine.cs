using OnlineTest.Interfaces;

namespace OnlineTest.Models
{
    public class UpgradedEngine : IEngine
    {
        private readonly int _cylinders;

        public UpgradedEngine(int cylinders)
        {
            _cylinders = cylinders;
        }

        public int GetCylinders()
        {
            return _cylinders;
        }
    }
}
