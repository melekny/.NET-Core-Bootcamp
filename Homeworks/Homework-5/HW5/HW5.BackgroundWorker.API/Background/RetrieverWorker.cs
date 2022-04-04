using HW5.Domain.Entities;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HW5.BackgroundWorker.API.Background
{
    public class RetrieverWorker : BackgroundService
    {
        private readonly ILogger<RetrieverWorker> logger;
        private readonly IBackgroundQueue<Post> queue;
        private HttpClient httpClient;
  
        public RetrieverWorker(ILogger<RetrieverWorker> logger, IBackgroundQueue<Post> queue)
        {
            this.logger = logger;
            this.queue = queue;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            httpClient = new HttpClient();
            return base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var request = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");
                if (request.IsSuccessStatusCode)
                {
                    var response = await request.Content.ReadAsStringAsync();

                    var posts = JsonConvert.DeserializeObject<List<Post>>(response);
                    // Newtonsoft.Json: JsonConvert -> It provides methods for converting between .NET types and JSON types.

                    foreach (var post in posts)
                    {
                        queue.Enqueue(post);
                        logger.LogInformation("Post, id:{}, enqueued successfully.", post.Id);
                    }           
                }
                else
                {
                    logger.LogError("Error while proccessing getting data!");
                }
                await Task.Delay(60000, stoppingToken);
                // Capturing data with HTTP request once in a minute.
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            httpClient.Dispose();
            return base.StopAsync(cancellationToken);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}