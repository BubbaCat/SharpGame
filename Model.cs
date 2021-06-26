using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

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
            if (conflictedObject is Exit)
            {
                Game.IsOver=true;
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

    public class Tree : ICreature
    {

        public string GetImageFileName()
        {
            return new Random(1).Next(0,2)>1 ? "Tree.png" : "tree1.png";
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

    public class Exit : ICreature
    {
        public string GetImageFileName()
        {
            return "Exit.png";
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
    public class Stairs : ICreature
    {
        public string GetImageFileName()
        {
            return "Stairs.png";
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

    public class Grass : ICreature
    {
        public string GetImageFileName()
        {
            return "Grass.png";
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

            //(int userX, int userY) = FindUser();

            //var path = FindPathToPlayer(x, y, userX, userY).OrderBy(p => p.Length).FirstOrDefault();

            //if (path == null)
            //    return new CreatureCommand { };

            //var currentPoint = new Point(x, y);
            //var pointToMove = path;
            //while (pointToMove.Previous.Value != currentPoint)
            //    pointToMove = pointToMove.Previous;

            //(int dx, int dy) = Move(x, y, pointToMove.Value);
            //return new CreatureCommand { DeltaX = dx, DeltaY = dy };
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

        public IEnumerable<SinglyLinkedList<Point>> FindPathToPlayer(int x, int y, int userX, int userY)
        {
            var player = new Point(userX, userY);
            Queue<SinglyLinkedList<Point>> queue = new Queue<SinglyLinkedList<Point>>();
            HashSet<Point> VisitedPoints = new HashSet<Point>() { new Point(x, y) };
            var walls = FindWalls();
            queue.Enqueue(new SinglyLinkedList<Point>(new Point(x, y), null));

            while (queue.Count != 0)
            {
                var currentPoint = queue.Dequeue();

                if (CantMove(currentPoint.Value.X, currentPoint.Value.Y))
                    continue;

                if (walls.Contains(currentPoint.Value))
                    continue;

                if (player == currentPoint.Value)
                    yield return currentPoint;

                for (var dy = -1; dy <= 1; dy++)
                    for (var dx = -1; dx <= 1; dx++)
                    {
                        if (dx == 0 || dy == 0)
                        {
                            var nextPoint = new Point(currentPoint.Value.X + dx, currentPoint.Value.Y + dy);
                            if (!VisitedPoints.Contains(nextPoint))
                            {
                                queue.Enqueue(new SinglyLinkedList<Point>(nextPoint, currentPoint));
                                VisitedPoints.Add(nextPoint);
                            }
                        }
                    }
            }
            yield break;
        }

        public HashSet<Point> FindWalls()
        {
            var walls = new HashSet<Point>();

            for (var dx = 0; dx < Game.MapWidth; dx++)
                for (var dy = 0; dy < Game.MapHeight; dy++)
                    if (Game.Map[dx, dy] != null && Game.Map[dx, dy].GetType() == new Wall().GetType())
                        walls.Add(new Point(dx, dy));

            return walls;
        }

        public bool CantMove(int x, int y)
        {
            return x < 0 || x >= Game.MapWidth || y < 0 || y >= Game.MapHeight;
        }

        public (int, int) GetMoveDirection(int x, int y, Point point)
        {
            return (point.X - x, point.Y - y);
        }

        public bool CantProfessorMove(int x, int y, int dx, int dy)
        {
            return Game.Map[x + dx, y + dy] != null &&
            (Game.Map[x + dx, y + dy].GetType() == new Wall().GetType()
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