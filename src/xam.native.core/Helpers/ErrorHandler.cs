using System;
using System.Threading.Tasks;

namespace xam.native.core.Helpers
{
    public static class ErrorHandler
    {
        public static async Task OutPutErrorToConsoleAsync(System.Exception error)
        {
            await Task.Run(() =>
            {
                Console.WriteLine(error.Message);
                Console.WriteLine(error.StackTrace);
            });
        }

        public static void OutPutErrorToConsole(System.Exception error)
        {
            
                Console.WriteLine(error.Message);
                Console.WriteLine(error.StackTrace);
           
        }
    }
}
