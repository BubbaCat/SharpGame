using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public class Player : ICreature
    {
        public string GetImageFileName()
        {
            return "Student.png";
        }

        public int GetDrawingPriority()
        {
            return 2;
        }

        public CreatureCommand Act(int x, int y)
        {
            int dx = 0;
            int dy = 0;
            if (Game.KeyPressed == Keys.Up || Game.KeyPressed == Keys.W)
            {
                dy = -1;
            }
            if (Game.KeyPressed == Keys.Down || Game.KeyPressed == Keys.S)
            {
                dy = 1;
            }
            if (Game.KeyPressed == Keys.Left || Game.KeyPressed == Keys.A)
            {
                dx = -1;
            }
            if (Game.KeyPressed == Keys.Right || Game.KeyPressed == Keys.D)
            {
                dx = 1;
            }
            bool isOnEdge = x + dx < 0 || y + dy < 0 || x + dx >= Gasme.MapWidth || y + dy >= Game.MapHeight;
            if (isOnEdge || Game.Map[x + dx, y + dy] != null
            && Game.Map[x + dx, y + dy].GetType() == new Wall().GetType())
            {
                dx = 0;
                dy = 0;
            }

            return new CreatureCommand { DeltaY = dy, DeltaX = dx };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Door)
            {
                Game.Scores += 10;
            }
            return conflictedObject.GetType() == new Wall().GetType()
            || conflictedObject.GetType() == new Professor().GetType();
        }
    }

    public class Terrain : ICreature
    {

    }


    public class Wall : ICreature
    {
        
       
    }


    public class Door : ICreature
    {
 
    }

    public class Professor : ICreature
    {

        }
    
    }
}