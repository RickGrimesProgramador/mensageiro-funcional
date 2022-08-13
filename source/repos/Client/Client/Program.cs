using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);

                socket.Connect(endPoint);

                Console.WriteLine("Conectado!");
                while (0 != 1)
                {
                    Console.WriteLine("Escreva algo: ");
                    String info = Console.ReadLine();
                    Console.WriteLine();
                    byte[] infoEnviar = Encoding.Default.GetBytes(info);

                    socket.Send(infoEnviar, infoEnviar.Length, SocketFlags.None);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel conectar ao servidor !");
            }
        }
    }

}
