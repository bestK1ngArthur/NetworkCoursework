using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WahChat
{
    class NetworkService
    {
        private NetworkService()
        {
            // ..
        }

        private static readonly NetworkService _sharedService = new NetworkService();

        public static NetworkService GetSharedService()
        {
            return _sharedService;
        }

        /// Текущее соединение
        public Connection currentConnection;

        /// <summary>
        /// Создание соединения
        /// </summary>
        public void CreateConnection(string incomePortName, string outcomePortName)
        {
            this.currentConnection = new Connection(incomePortName, outcomePortName);

            // формирование LINK кадра..
            // отправка LINK кадра..
        }

        /// <summary>
        /// Закрытие соединения
        /// </summary>
        public void CloseConnection()
        {
            // формирование DOWNLINK кадра..
            // отправка DOWNLINK кадра..
        }

        /// <summary>
        /// Обработка пришедшего сообщения
        /// </summary>
        public void HandleMessage(List<byte> message)
        {
            //byte[] messageData = message.ToArray();
            //string s = System.Text.Encoding.UTF8.GetString(messageData, 0, messageData.Length);

            Frame frame = new Frame(message);
            this.HandleFrame(frame);

            return;
        }

        /// <summary>
        /// Обработка пришедшего кадра
        /// </summary>
        public void HandleFrame(Frame frame)
        {
            switch (frame.type)
            {
                case Frame.Type.Link:
                    break;

                case Frame.Type.Ask:
                    break;

                case Frame.Type.Data:
                    break;

                case Frame.Type.Error:
                    break;

                case Frame.Type.Downlink:
                    break;
            }
        }

        public void SendFrame(Frame frame)
        {
            this.currentConnection.SendBytes(frame.data);
        }

        /// <summary>
        /// Список доступных портов
        /// </summary>
        public string[] GetPortsNames()
        {
            return SerialPort.GetPortNames();
        }

        /// Текущая сессия
        private Session currentSession;

        /// <summary>
        /// Создание сессии
        /// </summary>
        public void CreateSession(int username)
        {
            this.currentSession = new Session(username);

            // формирование кадра c username..
            // отправка кадра c username..
        }

        /// <summary>
        /// Закрытие сессии
        /// </summary>
        public void CloseSession()
        {
            // ..
        }
    }
}
