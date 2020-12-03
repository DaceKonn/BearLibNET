using System;
using BearLibNET;
using TKCodes = BearLibNET.TKCodes;
using TerminalT = BearLibNET.Terminal.Typed;

namespace TestConsole
{
    class Program
    {
        static void Main()
        {
            Terminal.Open();
            Console.WriteLine(Terminal.Set("input.filter = [keyboard+, mouse+]"));
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
                    TKCodes.InputEvents input = TerminalT.Read();

                    if (input == TKCodes.InputEvents.TK_CLOSE)
                    {
                        escape = true;
                    }
                    else
                    {
                        _ = Terminal.Print(2, 2, $"{Enum.GetName(typeof(TKCodes.InputEvents), input)}");
                        Terminal.Print(2,3, $"{ TerminalT.State(TKCodes.InputStates.TK_MOUSE_CLICKS)}");
                        Terminal.Print(2, 4, $"{ TerminalT.State(TKCodes.InputEvents.TK_1)}");

                        Terminal.Print(2, 5, $"{ input }");
                        //Terminal.Print(2, 6, $"{ Helpers.CheckCodeType(input) }");

                        TKCodes.InputEvents flag = TKCodes.InputEvents.TK_A | TKCodes.InputEvents.TK_KEY_RELEASED;
                        Terminal.Print(2, 7, $"Expect : { flag }");
                        Terminal.Print(2, 8, $"Flagged : { input == flag }");
                        Terminal.Print(2, 9, $"Release check : { (input & TKCodes.InputEvents.TK_KEY_RELEASED) != TKCodes.InputEvents.TK_INPUT_NONE}");

                        Terminal.Refresh();
                    }
                }
            }

            Terminal.Close();
        }
    }
}
