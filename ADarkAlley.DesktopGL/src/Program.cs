using System;

namespace ADarkAlley.DesktopGL
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new ADarkAlley())
                game.Run();
        }
    }
}
