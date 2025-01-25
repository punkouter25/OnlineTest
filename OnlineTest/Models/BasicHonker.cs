using OnlineTest.Interfaces;

namespace OnlineTest.Models
{
    public class BasicHonker : IHonker
    {
        //create a hard coded quiet beep
        public void Beep()
        {
            Console.WriteLine("Quiet beep");
        }
    }
}
