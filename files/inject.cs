// Decompiled with JetBrains decompiler
// Type: ShadowFN.files.inject
// Assembly: ShadowLauncher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 64770B21-5DB7-47F0-BD93-09D9B0982599
// Assembly location: C:\Users\User\Desktop\Debug\ShadowLauncher.exe

using StormLauncher.Utilities;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace StormLauncher.files
{
  internal class inject
  {
    public static int InjectDll(int processId, string dllPath)
    {
      IntPtr hProcess = win32.OpenProcess(1082, false, processId);
      IntPtr procAddress = win32.GetProcAddress(win32.GetModuleHandle("Kernel32.dll"), "LoadLibraryA");
      IntPtr num = win32.VirtualAllocEx(hProcess, IntPtr.Zero, (uint) ((dllPath.Length + 1) * Marshal.SizeOf(typeof (char))), 12288U, 4U);
      win32.WriteProcessMemory(hProcess, num, Encoding.Default.GetBytes(dllPath), (uint) ((dllPath.Length + 1) * Marshal.SizeOf(typeof (char))), out UIntPtr _);
      win32.CreateRemoteThread(hProcess, IntPtr.Zero, 0U, procAddress, num, 0U, IntPtr.Zero);
      return 0;
    }
  }
}
