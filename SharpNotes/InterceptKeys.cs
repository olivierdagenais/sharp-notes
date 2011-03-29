using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;

public class InterceptKeys
{
    private const int WH_KEYBOARD_LL = 13;
    private const int WM_KEYDOWN = 0x0100;
    private Action<Keys> handler;
    private IntPtr hookId;

    public InterceptKeys(Action<Keys> keyHandler)
    {
        handler = keyHandler;
        hookId = SetHook(Handler);
    }

    ~InterceptKeys()
    {
        UnhookWindowsHookEx(hookId);
    }

    private IntPtr Handler(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0 && wParam == (IntPtr)InterceptKeys.WM_KEYDOWN)
            handler((Keys)Marshal.ReadInt32(lParam));

        return CallNextHookEx(hookId, nCode, wParam, lParam);
    }

    #region http://blogs.msdn.com/b/toub/archive/2006/05/03/589423.aspx

    private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

    private IntPtr SetHook(LowLevelKeyboardProc proc)
    {
        using (Process curProcess = Process.GetCurrentProcess())
        using (ProcessModule curModule = curProcess.MainModule)
        {
            hookId = SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            return hookId;
        }
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);

    #endregion
}
