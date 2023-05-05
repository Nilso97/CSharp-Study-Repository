namespace HostedServices
{
    public class HostedJob : IHostedService, IDisposable
    {
        private Timer? _timer;
        private readonly ILogger<HostedJob> _logger;
        public int shotsCount;

        public HostedJob(ILogger<HostedJob> logger)
        {
            _logger = logger;
        }
        
        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer
            (
                callback => ExecuteAsync(),
                null,
                TimeSpan.FromSeconds(3),
                TimeSpan.FromSeconds(5)
            );

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private void ExecuteAsync()
        {
            shotsCount++;

            Console.WriteLine("---------------------------------");
            
            _logger.LogInformation($"-> Triggering a Hosted Service {shotsCount} time(s)");
        }
    }
}