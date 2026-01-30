using System;
using System.Linq;


namespace Prog2_Interfaces_BenjaminMackey
{
    public struct Position
    {
        public int x; public int y;
    }

    public class Charachter
    {
        public Position _position { get; protected set; }
        public ConsoleColor _color { get; protected set; }

        protected ConsoleKey _actionKey;
        protected ConsoleKey[] _optionKeys;
        public int _ammountOfOptions = 0;

        //-----constructors---
        public Charachter(Position position, ConsoleColor color, ConsoleKey actionKey, ConsoleKey[] optionKeys)
        {
            _position = position;
            _color = color;
            _actionKey = actionKey;
            _optionKeys = optionKeys;
        }
        public Charachter(Position position, ConsoleColor color)
        {
            _position = position;
            _color = color;
        }
        //--------------------

        public void SendKeys(ConsoleKey key)
        {

            bool actionGood = false;
            int optionGood = -1;

            if (_actionKey != null && _actionKey == key) actionGood = true;
            if (_optionKeys != null && _optionKeys.Contains(key)) optionGood = Array.IndexOf(_optionKeys, key);

            Affect(optionGood, actionGood);
        }

        protected virtual void Affect(int optGood, bool actionGood)
        {

        }

    }

    public class Player : Charachter, IHookToInput
    {
        
        public Player(Position position, ConsoleColor color, ConsoleKey actionKey, ConsoleKey[] optionKeys) : base(position, color, actionKey, optionKeys)
        {

        }
        public Player(Position position, ConsoleColor color) : base(position, color)
        {

        }

        public void SendKeys(ConsoleKey key) //the player doesnt have to move!!! 
        {
           
        }

    }

    public class Enemy : Charachter, IHookToInput
    {
        
        public Enemy(Position position, ConsoleColor color, ConsoleKey actionKey, ConsoleKey[] optionKeys) : base(position, color, actionKey, optionKeys)
        {
            _moveStrategy = Program._moveStrategies[0];
        }
        public Enemy(Position position, ConsoleColor color) : base(position, color)
        {
            _moveStrategy = Program._moveStrategies[0];
        }

        protected override void Affect(int optGood, bool aGood)
        { 
            if (optGood > -1) _moveStrategy = Program._moveStrategies[optGood];
            if (aGood)  _position=_moveStrategy.Move(_position, Program._plr._position);
            
        }
        public IMoveStrategy _moveStrategy;
    }

}