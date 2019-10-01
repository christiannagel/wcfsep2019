using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Wrox.ProCSharp.WCF
{
    public class MessageService : IMyMessage
    {
        public void MessageToServer(string message)
        {
            Console.WriteLine($"message from the client: {message}");
            IMyMessageCallback callback =
                  OperationContext.Current.
                        GetCallbackChannel<IMyMessageCallback>();

            callback.OnCallback("message from the server");

            Task.Factory.StartNew(new Action<object>(TaskCallback), callback, TaskCreationOptions.LongRunning);
        }

        private async void TaskCallback(object callback)
        {
            if (callback is IMyMessageCallback messageCallback)
            {
                for (int i = 0; i < 10; i++)
                {
                    messageCallback.OnCallback("message " + i.ToString());
                    await Task.Delay(1000);
                }
            }
        }
    }

}
