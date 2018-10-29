using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatTest
{
    public class Connection
    {
        private TcpClient client;

        public IPAddress AddressIP { get; set; }

        public int Port { get; set; }

        private NetworkStream stream;

        private BinaryWriter writing;

        public State State { get; set; }

        private Logger logger = new Logger();

        public bool SetConnection()
        {
            try
            {
                AddressIP = IPAddress.Parse("212.122.223.102");
                Port = 5529;
                State = State.Disconnected;
                IPEndPoint endPoint = new IPEndPoint(AddressIP, Port);
                client = new TcpClient();
                client.Connect(endPoint);
                stream = client.GetStream();
                stream.WriteTimeout = 5000;
                stream.ReadTimeout = 5000;
                writing = new BinaryWriter(stream, Encoding.GetEncoding(852));

                State = State.Connected;
                return true;
            }
            catch (Exception e)
            {
                logger.Debug($"Exception:\n{e}\n");
                CloseConnection();
                Thread.Sleep(1000);
                return false;
            }
        }

        public void CloseConnection()
        {
            try
            {
                stream.Close();
                State = State.Disconnected;

            }
            catch (Exception e)
            {
                logger.Debug($"Exception:\n{e}\n");
                State = State.Connected;
            }

            try
            {
                client.Close();
                State = State.Disconnected;
            }
            catch (Exception e)
            {
                logger.Debug($"Exception:\n{e}\n");
                State = State.Connected;
            }

        }

        public async Task SendingPacket(string xml)
        {
            try
            {
                Byte[] data = Encoding.ASCII.GetBytes(xml);
                await stream.WriteAsync(data, 0, data.Length);
                System.Diagnostics.Debug.WriteLine($"Sent:\n{xml}\n");
                logger.Debug($"Sent:\n{xml}\n");
            }
            catch(TimeoutException e)
            {
                System.Diagnostics.Debug.WriteLine(DateTime.Now + ": Nie udało się wysłać" + e);
                return;
            }
        }

        public async Task<string> ReceivingPacket()
        {
            byte[] data = new Byte[65536];
            string message = String.Empty;

            try
            {
                Thread.Sleep(500);
                while (stream.DataAvailable)
                {
                    Int32 bytes = await stream.ReadAsync(data, 0, data.Length);
                    message += Encoding.GetEncoding(852).GetString(data, 0, bytes);
                }

            }
            catch (Exception e)
            {
                logger.Debug($"Exception:\n{e}\n");
            }

            if (message != "")
            {
                System.Diagnostics.Debug.WriteLine($"Received:\n{message}\n");
                logger.Debug($"Received:\n{message}\n");
            }
            return message;
        }

        public async Task<List<string>> GetFramesList()
        {
            string message = await ReceivingPacket();
            var packets = new List<String>();
            int position = 0;
            int start = 0;
            try
            {
                do
                {
                    position = message.IndexOf("</XCTIP>", start);
                    if (position >= 0)
                    {
                        packets.Add(message.Substring(start, position - start + 8).Trim());
                        start = position + 8;
                    }
                } while (position > 0);
            }
            catch (Exception e)
            {
                logger.Debug($"Exception:\n{e}\n");
            }
            return packets;
        }
    }
}
