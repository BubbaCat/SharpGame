using System.Drawing;

namespace Game
{
    public interface ICreature
    {
        string GetImageFileName();
        int GetDrawingPriority();
        CreatureCommand Act(int x, int y);
        bool DeadInConflict(ICreature conflictedObject);
    }

    public class CreatureCommand
    {
        public int DeltaX;
        public int DeltaY;
        public ICreature TransformTo;
    }
    public class CreatureAnimation
    {
        public CreatureCommand Command;
        public ICreature Creature;
        public Point Location;
        public Point TargetLogicalLocation;
    }
}