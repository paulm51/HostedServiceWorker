using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace HostedService.Common.Services
{
    public interface IScopedProcessingService
    {
        Task DoWork(CancellationToken stoppingToken);
    }

    public class ScopedProcessingService : IScopedProcessingService
    {
        private int _executionCount;
        private readonly ILogger _logger;

        public ScopedProcessingService(ILogger<ScopedProcessingService> logger)
        {
            _logger = logger;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _executionCount++;

                _logger.LogInformation(
                    "Scoped Processing Service is working. Count: {Count}", _executionCount);

                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}
