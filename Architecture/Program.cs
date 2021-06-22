using System;
using System.IO;
using System.Windows.Forms;

namespace Game
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Game.CreateMap();
            Application.Run(new GameWindow(new DirectoryInfo("Images")));
        }
    }
}