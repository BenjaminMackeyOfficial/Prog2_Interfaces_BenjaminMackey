using System;
using System.Collections.Generic;
using System.Linq;


namespace Prog2_Interfaces_BenjaminMackey

{
    internal class Program
    {
        public static List<IMoveStrategy> _moveStrategies = new List<IMoveStrategy> ();
        public static List<Charachter> _chars = new List<Charachter> ();
        public static Player _plr;

        static ConsoleKey[] enemySwapKeys = {ConsoleKey.I, ConsoleKey.O, ConsoleKey.P};
        
        static void Initialize()
        {
            _moveStrategies.Add (new FleeingMoveStrategy());
            _moveStrategies.Add(new PassiveMoveStrategy());
            _moveStrategies.Add(new AggressiveMoveStrategy());

            Position startPos = new Position ();
            startPos.x = 5;
            startPos.y = 5;

            ConsoleColor color = ConsoleColor.Green;

            _plr = new Player(startPos, color);
            _chars.Add(_plr);


            startPos.x = 10;
            startPos.y = 10;

            color = ConsoleColor.Red;

            _chars.Add(new Enemy(startPos, color, ConsoleKey.M, enemySwapKeys));
        }

        static void SendInput()
        {
            ConsoleKey key = Console.ReadKey().Key;
            foreach (var inpRef in _chars.Where(a => a is IHookToInput))
            {
                inpRef.SendKeys(key);
            }
        }

        /*
        static void MoveEnemies()
        {
            foreach (Enemy moveRef in _chars.Where(a => a is Enemy))
            {
                Console.WriteLine("e");
                moveRef._moveStrategy.Move(moveRef._position, _chars.OfType<Player>().ToArray()[0]._position);
            }
        }
        */
        static void Draw()
        {
            Console.Clear();
            for (int i = 0; i < _chars.Count; i++)
            {
                Console.SetCursorPosition(_chars[i]._position.x, _chars[i]._position.y);
                Console.ForegroundColor = _chars[i]._color;
                Console.Write(0);   
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 13);
            Console.Write("M = Move enemy\nI = Fleeing\nO = Passive (wandering)\nP = Agressive");
            
        }

        static void Main(string[] args)
        {
            Initialize();
            Console.Write("Press M to begin");
            while (true) 
            {
                SendInput();
                //MoveEnemies();
                Draw();
            }
        }
    }
}
