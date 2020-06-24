using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4.FileManager.VisualStudio.AcceptanceCriteria.Helper
{
    public static class RetryUtil
    {
        public static int maxAttempts = 250;
        public static TimeSpan delay = TimeSpan.FromSeconds(2);

        public static void RetryOnException(Action operation)
        {
            var attempts = 0;
            do
            {
                try
                {
                    attempts++;
                    operation();
                    break;
                }
                catch (Exception exception)
                {
                    if (attempts == maxAttempts)
                        throw;

                    Console.WriteLine(exception);
                    
                    Task.Delay(delay).Wait();
                }
            } while (true);
        }
    }
}
