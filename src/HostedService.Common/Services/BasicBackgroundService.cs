using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HostedService.Common.Services
{
    public class BasicBackgroundService : BackgroundService
    {
        private readonly ILogger<BasicBackgroundService> _logger;

        public BasicBackgroundService(ILogger<BasicBackgroundService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int i = 0;

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(500, stoppingToken);
                _logger.LogInformation($"VideosWatcher running {i++}");

                if (i == 8)
                {
                    throw new AggregateException("An error occurred in VideosWatcher");
                }
            }
        }
    }
}
