using System.Windows.Forms;

namespace Game
{
    public static class Game
    {
        private const string secondFloor = @"
             SSSSSSSSSSSSSSSSSSSSSSSS                                
             STTTTTTMTSTTTSTTTTTTTTTS                  SSSSSSSSSSSSSS
             STTTTTTTTSTTTSTTTTTTTTTS                  STTSTTSTTTTTMS
             STTTTTTTTSTTTSTTTTTTTTTS                  STTSTTSTTTTTTS
             STTTTTTTTSTTTGTTTTTTTTTS                  STTSTTSTTTTTTS
             STTTTTTTTSTTTSTTTTTTTTTS                  SGSSSGSTTTTTTS
             STTTTTTTTSTTTSTTTTTTTTTS                  STTTTTGTTTTTTS
             STTTTTTTTSTTTSTTTTTTTTTSSSSSSSSSSSSSSSSSSSSSSSTTSSSSSSSS
             STTTTTTTGSTTTSTTTTTTTTTSTTTTTSTTTGTTTTTTTTSTTSTTSTTTTTTS
SSESSSSSSSSSSSSSSSSSSTTTTTSTMTTTTTTTSTTTTTSTTTSTTTTTTTTSLTSTTSTTTTTTS
TPTTTSTTTTTTTSTTTTTTGTTTTTSSSSSSSGSSSSSSGSSSSSSSSGSSSSSSTTSTTSTTTTTTS
TTTTTSTTTTTTTSTTTTTTSTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTGTTTTTTS
TTTTTSSSSSSGSSSSSSSSSTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTSTTTTTTS
TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTSSSTTSSSSSSSS
TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTGTSTTGTTTTTTS
TTTTTTTTTTTTTTTTTTTTTTTTTTSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSTSTTSSSSSSSS
TTTTTTTTTTTTTTTTTTTTTTTTTTS                             STSTTSTTTTTTS
TTTTTTTTTTTTTTTTTTTTTTTTTTS                             SSSTTGTTTTTTS
TTTTTTTTTTTTTTTTSSSSSTTTTTS                             STTTTSTTTTTTS
SSSSSSSSSSSSSSSS    STTTTTS                             STTTTSTTTTTTS
                    STTTTTS                             STTTTSTTTTTTS
                    STTTTTS                             SSSSSSSSSSSSS
                    STTTTTS                                          
                    STTTTTS                                          
                    STTTTTS                                          
                    STTTTTS                                          
                    STTTTTS                                          
                    STTTTTS                                          
                    STTTTTSSSSSS                                     
                    STTTTTGTTTTS                                     
                    STTTTTSTTTMS                                     
                    STTTTTSTTTTS                                     
         SSSSSSSSSSSSTTTTTSSSSSS                                     
         STTTTTTTSTTTTTTTTTTTS                                       
         STTTTTTTSTTTTTTTTTTTS                                       
         STTTTTTTSSSSTTTTTSSSS                                       
         STTTTTTTGTTTTTTTTS                                          
         SGSSSSSSSSGSSSSSSS                                          
         STSTTTTTTTTS                                                
         STSTTTTTTTTS                                                
         SMSTTTTTTTTS                                                
         SSSSSSSSSSSS                                                
";

        private const string firstFloor = @"
             SSSSSSSSSSSSSSSSSSSSSSSS                                
             STTTTTTMTSTTTSTTTTTTTTTS                  SSSSSSSSSSSSSS
             STTTTTTTTSTTTSTTTTTTTTTS                  STTSTTSTTTTTMS
             STTTTTTTTSTTTSTTTTTTTTTS                  STTSTTSTTTTTTS
             STTTTTTTTSTTTGTTTTTTTTTS                  STTSTTSTTTTTTS
             STTTTTTTTSTTTSTTTTTTTTTS                  SGSSSGSTTTTTTS
             STTTTTTTTSTTTSTTTTTTTTTS                  STTTTTGTTTTTTS
             STTTTTTTTSTTTSTTTTTTTTTSSSSSSSSSSSSSSSSSSSSSSSTTSSSSSSSS
             STTTTTTTGSTTTSTTTTTTTTTSTTTTTSTTTGTTTTTTTTSTTSTTSTTTTTTS
SSSEESSSSSSSSSSSSSSSSTTTTTSTMTTTTTTTSTTTTTSTTTSTTTTTTTTSTTSTTSTTTTTTS
TTTTTSTTTTTTTSTTTTTTGTTTTTSSSSSSSGSSSSSSGSSSSSSSSGSSSSSSPPSTTSTTTTTTS
TTTTTSTTTTTTTSTTTTTTSTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTGTTTTTTS
TTTTTSSSSSSGSSSSSSSSSTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTSTTTTTTS
TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTSSSTTSSSSSSSS
TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTGTSTTGTTTTTTS
TTTTTTTTTTTTTTTTTTTTTTTTTTSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSTSTTSSSSSSSS
TTTTTTTTTTTTTTTTTTTTTTTTTTS                             STSTTSTTTTTTS
TTTTTTTTTTTTTTTTTTTTTTTTTTS                             SSSTTGTTTTTTS
TTTTTTTTTTTTTTTTSSSSSTTTTTS                             STTTTSTTTTTTS
SSSSSSSSSSSSSSSS    STTTTTS                             STTTTSTTTTTTS
                    STTTTTS                             STTTTSTTTTTTS
                    STTTTTS                             SSSSSSSSSSSSS
                    STTTTTS                                          
                    STTTTTS                                          
                    STTTTTS                                          
                    STTTTTS                                          
                    STTTTTS                                          
                    STTTTTS                                          
                    STTTTTSSSSSS                                     
                    STTTTTGTTTTS                                     
                    STTTTTSTTTMS                                     
                    STTTTTSTTTTS                                     
         SSSSSSSSSSSSTTTTTSSSSSS                                     
         STTTTTTTSTTTTTTTTTTTS                                       
         STTTTTTTSTTTTTTTTTTTS                                       
         STTTTTTTSSSSTTTTTSSSS                                       
         STTTTTTTGTTTTTTTTS                                          
         SGSSSSSSSSGSSSSSSS                                          
         STSTTTTTTTTS                                                
         STSTTTTTTTTS                                                
         SMSTTTTTTTTS                                                
         SSSSSSSSSSSS                                                
";
        public static ICreature[,] Map;
        public static int Scores;
        public static bool IsOver;
        public static Keys KeyPressed;
        public static int MapWidth => Map.GetLength(0);
        public static int MapHeight => Map.GetLength(1);
        public static void CreateMap()=> Map = CreatureMapCreator.CreateMap(secondFloor);
        public static void ChangeMap() => Map = CreatureMapCreator.CreateMap(firstFloor,Map);
    }
}