using System;
using System.Diagnostics;

namespace Snap.Data.Utility
{
    public static class FileExplorer
    {
        public static void Open(string folder, Action<Exception>? failAction = null)
        {
            try
            {
                ProcessStartInfo processInfo = new("explorer.exe")
                {
                    Arguments = folder,
                    UseShellExecute = true
                };
                Process.Start(processInfo);
            }
            catch (Exception ex)
            {
                failAction?.Invoke(ex);
            }
        }
    }
}
