using OnlineTest.Interfaces;

namespace OnlineTest.Models
{
    public class UpgradedHonker : IHonker
    {
        private readonly IHonker _honker;
        private readonly int _volume;

        public UpgradedHonker(int volume = 5)
        {
            _volume = volume;
        }

        public void Beep()
        {
            Console.WriteLine($"Quiet beep at volume: {_volume}");
        }
    }
}
