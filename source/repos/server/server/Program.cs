using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace server
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);

            socket.Bind(endpoint);

            socket.Listen(5);

            Console.WriteLine("Server aberto ");
            Console.WriteLine("Qual o nome do seu amigo?");
            string nome = Console.ReadLine();
            Console.WriteLine("espere....");
            Socket escutar = socket.Accept();
            while (1 != 0)
            {
         
                byte[] bytes = new byte[255];

                int tamanho = escutar.Receive(bytes, 0, bytes.Length, SocketFlags.None);

                Array.Resize(ref bytes, tamanho);
                Console.Write(" mensagem recebida:  ", nome, " falou : ");
                Console.Write(Encoding.Default.GetString(bytes));
                Console.ReadLine();

            }



        }
    }
}