using System.Windows.Forms;

namespace Game
{
    public static class Game
    {
        private const string map = @"
PTTGTTTTTTTTTTTTTTTTTTTT
SSSSSSSTTTTTSSSSSSSTTTTT
TTTMTTSTTTTTSTTMTTSTTTTT
TTTTTTSTTTTTSTTTTTSTTTTT
TTTTTTSTTTTTSTTTTTSTTTTT
TTTMTTGTTTTTGTTMTTGTTTTT
SSSGSSSTTTTTSSSGSSSTTTTT
TTTTTTSTTTTTSTTTTTSTTTTT
TTTTTTGTTTTTGTTTTTGTTTTT
GTTTTMSTTTTTSTTTTMSTTTTT";

        public static ICreature[,] Map;
        public static int Scores;
        public static bool IsOver;
        public static Keys KeyPressed;
        public static int MapWidth => Map.GetLength(0);
        public static int MapHeight => Map.GetLength(1);
        public static void CreateMap()=> Map = CreatureMapCreator.CreateMap(map);
    }
}