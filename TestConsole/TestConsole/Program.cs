using System;
using BearLibNET;
using TKCodes = BearLibNET.TKCodes;

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
                        Terminal.Print(2,3, $"{ Terminal.State((int)TKCodes.InputStates.TK_MOUSE_CLICKS)}");

                        try
                        {
                            Terminal.Print(2, 4, $"{ Terminal.State((int)TKCodes.InputEvents.TK_1)}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }

                        Terminal.Refresh();
                    }
                }
            }

            Terminal.Close();
        }
    }
}
