using System;
using System.Diagnostics;

namespace Snap.Data.Utility
{
    public static class Browser
    {
        public static void Open(string url, Action<Exception>? failAction = null)
        {
            try
            {
                Uri targetUri = new(url);
                ProcessStartInfo processInfo = new(targetUri.AbsoluteUri) { UseShellExecute = true };
                Process.Start(processInfo);
            }
            catch (Exception ex)
            {
                failAction?.Invoke(ex);
            }
        }

        public static void Open(Func<string> urlFunc, Action<Exception>? failAction = null)
        {
            try
            {
                Uri targetUri = new(urlFunc.Invoke());
                ProcessStartInfo processInfo = new(targetUri.AbsoluteUri) { UseShellExecute = true };
                Process.Start(processInfo);
            }
            catch (Exception ex)
            {
                failAction?.Invoke(ex);
            }
        }
    }

    public class FileExplorer 
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
