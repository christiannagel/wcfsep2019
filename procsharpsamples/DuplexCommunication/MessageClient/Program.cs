using System;
using System.ServiceModel;
using System.Threading;

namespace Wrox.ProCSharp.WCF
{
    class ClientCallback : IMyMessageCallback
    {
        public void OnCallback(string message)
        {
            Console.WriteLine($"message from the server: {message}");
            Console.WriteLine($"callback in thread {Thread.CurrentThread.ManagedThreadId}");
        }
    }


    class Program
    {
        static void Main()
        {
            Console.WriteLine("Client - wait for service");
            Console.WriteLine($"client main method running in thread {Thread.CurrentThread.ManagedThreadId}");
            Console.ReadLine();

            DuplexSample();

            Console.WriteLine("Client - press return to exit");
            Console.ReadLine();
        }

        private static void DuplexSample()
        {
            var binding = new WSDualHttpBinding();
            var address =
                  new EndpointAddress("http://localhost:8733/Design_Time_Addresses/MessageService/Service1/");

            var clientCallback = new ClientCallback();
            var context = new InstanceContext(clientCallback);

            var factory = new DuplexChannelFactory<IMyMessage>(context, binding, address);

            IMyMessage messageChannel = factory.CreateChannel();

            messageChannel.MessageToServer("From the server");
        }
    }
}
