public static class SpeedCalculator
{
    public static int CalculateSpeed(int n)
    {
        int speed = 0;

        for (int i = 0; i < (n * 2) - 1; i++)
        {
            if (i % 2 == 0)
            {
                speed += 1;
            }
            else
            {
                speed -= 1;
            }
        }

        return speed;
    }
}
