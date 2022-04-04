using HW5.Business.Abstracts;
using HW5.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HW5.BackgroundWorker.API.Background
{
    public class RecorderWorker : BackgroundService
    {
        private readonly ILogger<RecorderWorker> logger;
        private readonly IBackgroundQueue<Post> queue;
        private readonly IServiceScopeFactory serviceScopeFactory;

        public RecorderWorker(ILogger<RecorderWorker> logger, IServiceScopeFactory serviceScopeFactory,  IBackgroundQueue<Post> queue)
        {
            this.logger = logger;
            this.queue = queue;
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation("{WorkerName} is now running in the background.", nameof(RecorderWorker));
            await BackgroundProcessing(stoppingToken);
            }

        private async Task BackgroundProcessing(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(300, stoppingToken);
                    // The data is recording in the database at certain intervals with the queue structure.
                    var post = queue.Dequeue();
                    if (post == null) continue;

                    logger.LogInformation("Starting the process of adding posts to the database.");
                    using var scope = serviceScopeFactory.CreateScope();
                    var postService = scope.ServiceProvider.GetRequiredService<IPostService>();
                    postService.AddPosts(post);
                }
                catch (Exception ex)
                {
                    logger.LogError("An Error occured while adding posts to the database! Exception: ", ex);
                }
            }
        }
    }
}