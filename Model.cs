﻿using System;
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
            bool isOnEdge = x + dx < 0 || y + dy < 0 || x + dx >= Game.MapWidth || y + dy >= Game.MapHeight;
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
        public string GetImageFileName()
        {
            return "Floor.png";
        }

        public int GetDrawingPriority()
        {
            return 1;
        }

        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand { };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return true;
        }
    }

    public class Wall : ICreature
    {

        public string GetImageFileName()
        {
            return "Wall.png";
        }

        public int GetDrawingPriority()
        {
            return 2;
        }

        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand { };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return conflictedObject.GetType() == new Wall().GetType();
        }
    }


    public class Door : ICreature
    {
        public string GetImageFileName()
        {
            return "Door.png";
        }

        public int GetDrawingPriority()
        {
            return 2;
        }

        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand { };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return true;
        }
    }

    public class Professor : ICreature
    {
        public string GetImageFileName()
        {
            return "Professor.png";
        }

        public int GetDrawingPriority()
        {
            return 2;
        }

        public CreatureCommand Act(int x, int y)
        {
            var (userX, userY) = FindUser();
            var (dx, dy) = Move(userX, userY, x, y);
            if (CantProfessorMove(x, y, dx, dy))
            {
                dx = 0;
                dy = 0;
            }
            return new CreatureCommand { DeltaY = dy, DeltaX = dx };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return conflictedObject.GetType() == new Wall().GetType()
            || conflictedObject.GetType() == new Professor().GetType();
        }

        public (int, int) Move(int userX, int userY, int x, int y)
        {
            int dy = 0;
            int dx = 0;
            if (userX >= 0 && userY >= 0)
            {
                if (userX == x)
                {
                    if (userY < y) dy = -1;
                    else if (userY > y) dy = 1;
                }
                if (userY == y)
                {
                    if (userX < x) dx = -1;
                    else if (userX > x) dx = 1;
                }
                else
                {
                    if (userX < x) dx = -1;
                    else if (userX > x) dx = 1;
                }
            }
            return (dx, dy);
        }

        public bool CantProfessorMove(int x, int y, int dx, int dy)
        {
            return Game.Map[x + dx, y + dy] != null &&
            (Game.Map[x + dx, y + dy].GetType() == new Wall().GetType()
            || Game.Map[x + dx, y + dy].GetType() == new Terrain().GetType()
            || Game.Map[x + dx, y + dy].GetType() == new Professor().GetType());
        }

        public (int, int) FindUser()
        {
            int width = Game.MapWidth;
            int height = Game.MapHeight;
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    if (Game.Map[i, j] != null && Game.Map[i, j].GetType() == new Player().GetType())
                        return (i, j);
                }
            return (-1, -1);
        }
    }
}