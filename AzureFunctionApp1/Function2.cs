using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFunctionApp1
{
    public static class Function2
    {
        [FunctionName("Function2")]
        public static void Run([QueueTrigger("myqueue-items", Connection = "queueconstring")]string myQueueItem,
            [Blob("sample-workitems/{queueTrigger}", Connection = "blobconstr")] string myInputBlob,
            [Blob("sample-workitems/Rename_{queueTrigger}", Connection = "blobconstr")] out string myOutputBlob,
            ILogger log)
        {
            myOutputBlob = myInputBlob;
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
