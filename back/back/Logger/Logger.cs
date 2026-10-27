namespace back.Logger
{
    public class ExceptionLogger
    {
        private readonly string filepath;
        private readonly List<string> Logs;
        public ExceptionLogger(IConfiguration _conf)
        {
            filepath = _conf.GetValue<string>("LoggerPath:FilePath");
        }
        public async Task LogAsync(string data)
        {
            using (StreamWriter streamWriter = new StreamWriter(filepath, true))
            {
                await streamWriter.WriteLineAsync(data);
                Console.WriteLine("Error has been logged");
            }
            ; 
        }
    }
    public static class LoggerExtensions
    {
        public static void AddExceptionLogger( this IServiceCollection services)
        {
            services.AddSingleton<ExceptionLogger>();
            
        }
    }
}
