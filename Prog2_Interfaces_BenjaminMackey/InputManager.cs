using System;


/*
namespace Prog2_Interfaces_BenjaminMackey
{
    public class SendKeyEventArgs : EventArgs
    {
        public ConsoleKey _key { get; set; }
        public SendKeyEventArgs(ConsoleKey key)
        {
            _key = key;
        }
    }

    public class InputManager
    {
        public event EventHandler keyPress;
        public void InputRunner()
        {
            while (true) 
            {
                ConsoleKey key = Console.ReadKey().Key;
                keyPress?.Invoke(this, new SendKeyEventArgs(key));
            }
 
        }
    }
}

nah

*/

public interface IHookToInput
{
    void SendKeys(ConsoleKey key);

}

