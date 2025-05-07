using System.Net;
using System.Net.Sockets;
using System.Text;


Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

IPAddress iPAddress = IPAddress.Any;

IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 23000);

listenerSocket.Bind(iPEndPoint);

Console.WriteLine("About to accept incoming connection.");

listenerSocket.Listen(5);
Socket client = listenerSocket.Accept();

Console.WriteLine($"Client connected. {client.ToString()} - IP End Point: {client.RemoteEndPoint.ToString()}");

byte[] buffer = new byte[128];

int numberOfReceivedBytes = 0;
numberOfReceivedBytes = client.Receive(buffer);

Console.WriteLine($"Number of received bytes: {numberOfReceivedBytes}");

Console.WriteLine($"Data sent by client is: {buffer}");

string receivedText = Encoding.ASCII.GetString(buffer, 0, numberOfReceivedBytes);

Console.WriteLine($"Data sent by client is: {receivedText}");