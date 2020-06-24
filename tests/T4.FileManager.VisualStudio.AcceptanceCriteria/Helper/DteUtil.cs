using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using EnvDTE;

namespace T4.FileManager.VisualStudio.AcceptanceCriteria.Helper
{
    public static class DteUtil
    {
        public static IEnumerable<DTE> GetDtes()
        {
            IRunningObjectTable rot;
            IEnumMoniker enumMoniker;

            var retVal = GetRunningObjectTable(0, out rot);

            if (retVal == 0)
            {
                rot.EnumRunning(out enumMoniker);
                var fetched = IntPtr.Zero;
                var moniker = new IMoniker[1];

                while (enumMoniker.Next(1, moniker, fetched) == 0)
                {
                    IBindCtx bindCtx;
                    string displayName;

                    CreateBindCtx(0, out bindCtx);

                    moniker[0].GetDisplayName(bindCtx, null, out displayName);

                    Console.WriteLine("Display Name: {0}", displayName);

                    var isVisualStudio = displayName.StartsWith("!VisualStudio");
                    if (isVisualStudio)
                    {
                        object obj;

                        rot.GetObject(moniker[0], out obj);

                        var dte = obj as DTE;

                        yield return dte;
                    }
                }
            }
        }

        [DllImport("ole32.dll")]
        private static extern void CreateBindCtx(int reserved, out IBindCtx ppbc);

        [DllImport("ole32.dll")]
        private static extern int GetRunningObjectTable(int reserved, out IRunningObjectTable prot);

        public static DTE GetCurrentDte()
        {
            DTE dte = null;

            RetryUtil.RetryOnException(() =>
            {
                dte = GetDtes().First(x => x.Solution?.FileName.Contains("T4.FileManager.VisualStudio") == true);
                dte.MainWindow.Activate();
                dte.MainWindow.SetFocus();
            });

            return dte;
        }
    }
}