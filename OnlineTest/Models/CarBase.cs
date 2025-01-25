using OnlineTest.Interfaces;

namespace OnlineTest.Models
{
    public abstract class CarBase : IEngine, IDoor, IHonker
    {
        public abstract int GetCylinders();
        public abstract int GetDoorCount();
        public abstract int GetCurrentSpeed();
        public abstract void SetSpeed();
        public abstract void Beep();
    }
}
