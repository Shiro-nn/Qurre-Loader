using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loader.Features
{
    internal static class Log
    {
        internal static void Debug(string message, ConsoleColor color = ConsoleColor.Magenta)
        {
#if DEBUG
            ServerConsole.AddLog($"[Qurre.Loader] {message}", color);
#endif
        }

        internal static void Info(string message, ConsoleColor color = ConsoleColor.Cyan)
        {
            ServerConsole.AddLog($"[Qurre.Loader] {message}", color);
        }

        internal static void Warn(string message, ConsoleColor color = ConsoleColor.Yellow)
        {
            ServerConsole.AddLog($"[Qurre.Loader] {message}", color);
        }

        internal static void ErrorNormal(string message, ConsoleColor color = ConsoleColor.Red)
        {
            ServerConsole.AddLog($"[Qurre.Loader] {message}", color);
        }

        internal static void ErrorFatal(string message, ConsoleColor color = ConsoleColor.DarkRed)
        {
            ServerConsole.AddLog($"[Qurre.Loader] {message}", color);
        }
    }
}
