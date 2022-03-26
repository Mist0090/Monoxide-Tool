using System;
using System.Threading;
using System.IO;
using static Monoxide.extract;

using static Monoxide.MonoxideTool;

namespace Monoxide
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(Path.GetTempPath());

            Extract("Monoxide", Path.GetTempPath(), "DLL", "gdi.dll");
            Extract("Monoxide", Path.GetTempPath(), "DLL", "audio.dll");

            LoadMonoxideTool();
        }
    }
}
