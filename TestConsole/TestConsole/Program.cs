using System;
using BearLibNET;
using TKCodes = BearLibNET.TKCodes;
using TerminalT = BearLibNET.Terminal.Typed;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Terminal.Open();
            Console.WriteLine(Terminal.Set("input.filter = [keyboard, mouse]"));
            Terminal.Composition(true);
            Terminal.Clear();
            Terminal.Print(1, 1, "Hello World!");
            Terminal.Refresh();

            Boolean escape = false;

            while (!escape)
            {
                if (Terminal.HasInput())
                {
                    Terminal.Clear();
                    int input = Terminal.Read();

                    if (input == (int)TKCodes.InputEvents.TK_CLOSE)
                    {
                        escape = true;
                    }
                    else
                    {
                        _ = Terminal.Print(2, 2, $"{Enum.GetName(typeof(TKCodes.InputEvents), input)}");
                        Terminal.Print(2,3, $"{ TerminalT.State(TKCodes.InputStates.TK_MOUSE_CLICKS)}");
                        Terminal.Print(2, 4, $"{ TerminalT.State(TKCodes.InputEvents.TK_1)}");

                        Terminal.Print(2, 5, $"{ Helpers.CheckCodeType(input)?.Name}");

                        Terminal.Refresh();

                        TerminalT.Peek();
                    }
                }
            }

            Terminal.Close();
        }
    }
}
