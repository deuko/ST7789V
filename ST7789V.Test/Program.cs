namespace ST7789V.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var disp = new Display();
            disp.Initialize();
            disp.TurnOn();
            disp.SetRedScreen();
        }
    }
}