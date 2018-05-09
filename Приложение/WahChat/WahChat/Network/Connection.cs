using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WahChat
{
    class Connection
    {
        public bool isPortsOpened = false;

        private byte boundByte = 0xFF;

        private SerialPort incomePort;
        private SerialPort outcomePort;

        public Connection(string incomePortName, string outcomePortName)
        {
            this.isPortsOpened = OpenPorts(incomePortName, outcomePortName);

            // ..
        }

        /// <summary>
        /// Открытие портов
        /// </summary>
        private bool OpenPorts(string incomePortName, string outcomePortName)
        {
            // Создаем объекты портов.
            this.incomePort = new SerialPort(incomePortName);
            this.outcomePort = new SerialPort(outcomePortName);

            // Настраиваем порты.
            this.incomePort.Parity = Parity.Even;
            this.incomePort.Handshake = Handshake.RequestToSend;
            this.incomePort.BaudRate = 9600;
            this.incomePort.ReadBufferSize = 4 * 1024; // TODO: Надо пересчитать размер буфера.
            this.outcomePort.Parity = Parity.Even;
            this.outcomePort.Handshake = Handshake.RequestToSend;
            this.outcomePort.BaudRate = 9600;
            this.outcomePort.ReadBufferSize = 4 * 1024; // TODO: Надо пересчитать размер буфера.

            // Открываем порты.
            this.incomePort.Open();
            this.outcomePort.Open();

            return (this.incomePort.IsOpen && this.outcomePort.IsOpen);
        }

        /// <summary>
        /// Закрытие портов
        /// </summary>
        private bool ClosePorts()
        {
            // Закрываем порты.
            this.incomePort.Close();
            this.outcomePort.Close();

            return (this.incomePort.IsOpen && this.outcomePort.IsOpen);
        }

        /// <summary>
        /// Пересылка байтов
        /// </summary>
        private void SendBytes(List<byte> list)
        {
            // Кодирование
            List<byte> hamm = list; //Hamming.To(list);

            // Делаем так, чтобы внутри кадра не встречалось boundByte.
            List<byte> safeList = new List<byte>(hamm.Count);
            foreach (var b in hamm)
            {
                if ((b & 0x7F) == 0x7F)
                {
                    safeList.Add(0x7F);
                    safeList.Add((byte)(b & 0x80));
                }
                else
                {
                    safeList.Add(b);
                }
            }

            safeList.Insert(0, boundByte); // start byte
            safeList.Add(boundByte); // end byte

            if (this.outcomePort.WriteBufferSize - this.outcomePort.BytesToWrite < safeList.Count)
            {
                // Если сообщение не влезло в порт, то надо что-то с этим делать.
                // То ли очередь придумать, то ли ещё что.
                return;
            }

            byte[] arr = safeList.ToArray();
            this.outcomePort.Write(arr, 0, arr.Length);
        }
    }
}
