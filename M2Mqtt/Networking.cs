using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Sales
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MQTTHandler.MainForm());
        }
    }

}
namespace GraphicsToolkit.Networking
{
    public delegate void ClientHandlePacketData(byte[] data, int bytesRead);

    public class Client
    {
        public ClientHandlePacketData OnDataReceived;

        private TcpClient tcpClient;
        private NetworkStream clientStream;
        private NetworkBuffer buffer;
        private int writeBufferSize = 1024;
        private int readBufferSize = 1024;
        private int port;
        private bool started = false;
        public static bool isTCPConnect = false;

        public class NetworkBuffer
        {
            public byte[] WriteBuffer;
            public byte[] ReadBuffer;
            public int CurrentWriteByteCount;
        }

        public Client()
        {
            buffer = new NetworkBuffer();
            buffer.WriteBuffer = new byte[writeBufferSize];
            buffer.ReadBuffer = new byte[readBufferSize];
            buffer.CurrentWriteByteCount = 0;
        }

        public void ConnectToServer(string ipAddress, int port)
        {
            try
            {
                this.port = port;
                tcpClient = new TcpClient(ipAddress, port);
                clientStream = tcpClient.GetStream();
                Console.WriteLine("Connected to server, listening for packets");
                Thread t = new Thread(new ThreadStart(ListenForPackets));
                started = true;
                isTCPConnect = true;
                t.Start();
            }
            catch
            {
                isTCPConnect = false;
            }

        }

        private void ListenForPackets()
        {
            int bytesRead;
            while (started)
            {
                bytesRead = 0;
                try
                {
                    bytesRead = clientStream.Read(buffer.ReadBuffer, 0, readBufferSize);
                }
                catch
                {
                    Console.WriteLine("A socket error has occurred with the client socket " + tcpClient.ToString());
                    break;
                }
                if (bytesRead == 0)
                {
                    break;
                }
                if (OnDataReceived != null)
                {
                    OnDataReceived(buffer.ReadBuffer, bytesRead);
                }
                Thread.Sleep(15);
            }
            started = false;
            Disconnect();
        }

        public void AddToPacket(byte[] data)
        {
            if (buffer.CurrentWriteByteCount + data.Length > buffer.WriteBuffer.Length)
            {
                FlushData();
            }
            Array.ConstrainedCopy(data, 0, buffer.WriteBuffer, buffer.CurrentWriteByteCount, data.Length);
            buffer.CurrentWriteByteCount += data.Length;
        }

        public void FlushData()
        {
            clientStream.Write(buffer.WriteBuffer, 0, buffer.CurrentWriteByteCount);
            clientStream.Flush();
            buffer.CurrentWriteByteCount = 0;
        }

        public void SendImmediate(byte[] data)
        {
            AddToPacket(data);
            FlushData();
        }

        public bool IsConnected()
        {
            return started && tcpClient.Connected;
        }

        public void Disconnect()
        {
            if (tcpClient == null)
            {
                return;
            }
            Console.WriteLine("Disconnected from server");
            tcpClient.Close();
            started = false;
            isTCPConnect = false;
        }
    }
}