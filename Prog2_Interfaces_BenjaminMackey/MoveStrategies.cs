
namespace Prog2_Interfaces_BenjaminMackey
{
    public interface IMoveStrategy
    {
        Position Move(Position curPos, Position TargPos);
    }

    //==============================================MOVE STRATEGY CLASSES============================
    public class AggressiveMoveStrategy : IMoveStrategy
    {
        public Position Move(Position curPos, Position TargPos)
        {
            curPos.x -= (curPos.x - TargPos.x).Clamp(-1, 1);
            curPos.y -= (curPos.y - TargPos.y).Clamp(-1, 1);

            curPos.x = curPos.x.Clamp(1, 10);
            curPos.y = curPos.y.Clamp(1, 10);
            return (curPos);
        }
    }
    public class PassiveMoveStrategy : IMoveStrategy
    {
        public Position Move(Position curPos, Position TargPos)
        {
            curPos.x = curPos.x.AddRandom(-1, 1);
            curPos.y = curPos.y.AddRandom(-1, 1);

            curPos.x = curPos.x.Clamp(1, 10);
            curPos.y = curPos.y.Clamp(1, 10);
            return (curPos);
        }
    }
    public class FleeingMoveStrategy : IMoveStrategy
    {
        public Position Move(Position curPos, Position TargPos)
        {
            if (curPos.x == TargPos.x && curPos.y == TargPos.y) curPos.x += 1;

            curPos.x += (curPos.x - TargPos.x).Clamp(-1, 1);
            curPos.y += (curPos.y - TargPos.y).Clamp(-1, 1);

            curPos.x = curPos.x.Clamp(1, 10);
            curPos.y = curPos.y.Clamp(1, 10);
            return (curPos);
        }
    }
}
