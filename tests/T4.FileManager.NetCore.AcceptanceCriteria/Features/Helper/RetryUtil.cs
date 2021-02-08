namespace T4.FileManager.NetCore.AcceptanceCriteria.Features.Helper
{
    using System;
    using System.Threading.Tasks;

    public static class RetryUtil
    {
        public static int maxAttempts = 7;
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
            } 
            while (true);
        }
    }
}
