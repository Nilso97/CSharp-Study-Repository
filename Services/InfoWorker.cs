using WebApiBackgroudServices.Repository;

namespace WebApiBackgroudServices.Services
{
    public class InfoWorker : IHostedService
    {
        private Timer? _timer;
        private readonly ILogger<InfoWorker> _logger;
        private int executionCount = 0;

        private ICommandRepository _commandRepository;

        public InfoWorker(ILogger<InfoWorker> logger, ICommandRepository commandRepository)
        {
            _logger = logger;
            _commandRepository = commandRepository;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"Process started -> {nameof(InfoWorker)}");

            _timer = new Timer
            (
                DoWork,
                null,
                TimeSpan.FromSeconds(5),
                TimeSpan.FromSeconds(5)
            );

            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            var count = Interlocked.Increment(ref executionCount);

            _logger.LogInformation(
                "Timed Hosted Service is working. Count: {Count}", count
            );

            Console.WriteLine($"{DateTime.UtcNow:o} -> " + _commandRepository.GetMessage());
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"Process finished -> {nameof(InfoWorker)}");

            return Task.CompletedTask;
        }
    }
}