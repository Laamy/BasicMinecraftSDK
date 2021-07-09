using System;

namespace Bhop
{
    class DBG
    {
        public static void error(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Mc_ModLauncher> " + str);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
