using RestSharp;
using System;
using System.Linq.Expressions;
using System.Net;
using System.Threading;

using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt;
using MqttClient = uPLibrary.Networking.M2Mqtt.MqttClient;

namespace BleGatewayTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MqttClient("mqtt.bconimg.com");

            // register to message received
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            var clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);

            // subscribe to the topic "/home/temperature" with QoS 2
            client.Subscribe(
                new string[] { "merge01" },
                new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        }

        public static string Line { get; set; }
        static void client_MqttMsgPublishReceived(
            object sender, MqttMsgPublishEventArgs e)
        {
            string result = System.Text.Encoding.UTF8.GetString(e.Message);
            Console.WriteLine(result);
            // handle message received
            //foreach (var item in e.Message)
            //{
            //    Line += item;
            //}
            ////
            //Console.WriteLine("message=" + Line);
            //Line = "";
        }

        public static void TrashApiCon()
        {
            var client = new RestClient("https://hook.ubeac.io/fd7jIx5i");
            var request = new RestRequest(Method.POST);
            request.AddHeader("x-pretty-print", "2");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("accept", "application/json");
            request.AddCookie("foo", "bar");
            request.AddCookie("bar", "baz");
            request.AddParameter("application/json", "{\"foo\": \"bar\"}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.ContentEncoding);
            foreach (var raw in response.RawBytes)
            {
                Console.WriteLine(raw.ToString());
            }
            Console.ReadKey();
        }
    }
}
