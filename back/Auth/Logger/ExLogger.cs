namespace Auth.Logger
{
    public class ExLogger
    {
        private readonly string filepath;
        private readonly List<string> logs;
        public ExLogger(IConfiguration conf)
        {
            filepath = conf.GetValue<string>("LoggerPath:FilePath");
            if (filepath == null)
            {
                throw new InvalidOperationException("Filepath is null");
            }
        }

        public async Task Log(string message)
        {
            using(StreamWriter writer = new StreamWriter(filepath, true))
            {
                await writer.WriteLineAsync(message);
            }
        }
    }

    public static class LoggerExtensions
    {
        public static void AddExceptionLogger(this IServiceCollection services)
        {
            services.AddSingleton<ExLogger>();

        }
    }
}
