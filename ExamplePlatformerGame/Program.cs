using System;

namespace CustomProject
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new GameWin())
                game.Run();
        }
    }
}
