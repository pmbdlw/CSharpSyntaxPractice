using System.Net;
using CSharpExcise.Syntax.Common;

namespace CSharpExcise.Syntax.Advanced;

public class AsyncNAwait
{
    private const string url = "http://www.i-gpt5.com/";

    public static void Test()
    {
        // EventBasedAsyncPattern();
        // Thread.Sleep(5000);
        var task = CallerWithAsync();
        Console.ReadKey();
        // Greeting("What?");
        // SynchronizedAPI();
        // TestSync();
        // TaskBasedAsyncPatternAsync().Wait();
        // AsynchronousPattern();
        // EventBasedAsyncPattern();
    }

    private async static Task CallerWithAsync()
    {
        TraceThreadAndTask($"started {nameof(CallerWithAsync)}");
        var result = await GreetingAsync("Okok");
        Console.WriteLine("result " + result);
        TraceThreadAndTask($"ended {nameof(CallerWithAsync)}");
    }
    
    static Task<string> GreetingAsync(string name) => Task.Run<string>(() =>
    {
        TraceThreadAndTask($"running {nameof(GreetingAsync)}");
        return Greeting(name);
    });
    
    public static string Greeting(string name)
    {
        TraceThreadAndTask($"running {nameof(Greeting)}");
        Task.Delay(3000).Wait();
        return $"Hello , {name}.";
    }
    
    public static void TraceThreadAndTask(string info)
    {
        var taskInfo = Task.CurrentId == null ? "no task" : $"task {Task.CurrentId}";
        Console.WriteLine(($"{info} in thread {Thread.CurrentThread.ManagedThreadId} and {taskInfo}"));
    }

    public static async Task TestAsync()
    {
    }

    private static void EventBasedAsyncPattern()
    {
        Console.WriteLine(nameof(EventBasedAsyncPattern));
        using (var client = new WebClient())
        {
            ServicePointManager.ServerCertificateValidationCallback
                = (sender, certificate, chain, sslPolicyErrors) => true;
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(WebclientCallback);// // += new DownloadStringCompletedEventHandler(WebclientCallback)
            
            client.DownloadStringAsync(new Uri(url));
            Thread.Sleep(5000);
            Console.WriteLine("Event executed complete!");
        }
    }

    private static async Task TaskBasedAsyncPatternAsync()
    {
        Console.WriteLine(nameof(TaskBasedAsyncPatternAsync));
        using (var client = new WebClient())
        {
            ServicePointManager.ServerCertificateValidationCallback
                = (sender, certificate, chain, sslPolicyErrors) => true;
            string content = await client.DownloadStringTaskAsync(url);
            FileOperate.CreateFileAndAppendText("AsynNAwait.txt", content);
            
        }
    }

    private static void WebclientCallback(object sender, DownloadStringCompletedEventArgs e)
    {
        var text = e.Result.Substring(0, 100);
        Console.WriteLine(text);
        FileOperate.CreateFileAndAppendText("AsynNAwait.txt", text);
    }

    // Current thread will not be notified by the new threed.
    private static void AsynchronousPattern()
    {
        Console.WriteLine(nameof(AsynchronousPattern));
        WebRequest request = WebRequest.Create(url);
        IAsyncResult result = request.BeginGetResponse(ReadResponse, null);

        void ReadResponse(IAsyncResult ar)
        {
            using (WebResponse response = request.EndGetResponse(ar))
            {
                Stream stream = response.GetResponseStream();
                var reader = new StreamReader(stream);
                var content = reader.ReadToEnd();
                Console.WriteLine(content.Substring(0, 100));
                FileOperate.CreateFileAndAppendText("AsynNAwait.txt", content);
                Console.WriteLine();
            }
        }

        // Thread.Sleep(1500);
    }

    public static void TestSync()
    {
        SynchronizedAPI();
    }

    private static void SynchronizedAPI()
    {
        Console.WriteLine(nameof(SynchronizedAPI));
        using (var client = new WebClient())
        {
            ServicePointManager.ServerCertificateValidationCallback
                = (sender, certificate, chain, sslPolicyErrors) => true;

            string content = client.DownloadString(url);
            Console.WriteLine(content.Substring(0, 100));
        }

        Console.WriteLine();
    }
}