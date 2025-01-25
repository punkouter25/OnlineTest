using OnlineTest.Interfaces;

namespace OnlineTest.Models
{
    public class UpgradedDoor : IDoor
    {
        private readonly int _doors;

        public UpgradedDoor(int doors)
        {
            _doors = doors;
        }

        public int GetDoorCount() => _doors;
    }
}
