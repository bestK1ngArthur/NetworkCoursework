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
    class ConnectionService
    {
        // TODO: Вынести соединение в отдельный класс.
        // TODO: Вынести кадр в отдельный класс.

        /// <summary>
        /// Тип кадра
        /// </summary>
        enum FrameType
        {
            /// Установка логического соединения.
            Link,
            /// Получение списка пользователей.
            Ask,
            /// Отправка сообщения пользователя.
            Data,
            /// Отправка запроса на переотправку сообщения.
            Error,
            /// Разъединение соединения.
            Downlink
        }

        private byte startByte = 0xFF;
        private byte endByte = 0xFE;

        private SerialPort incomePort;
        private SerialPort outcomePort;

        /// <summary>
        /// Создание соединения соединения
        /// </summary>
        public void CreateConnection(string incomePortName, string outcomePortName)
        {
            bool portsIsOpened = OpenPorts(incomePortName, outcomePortName);

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
        /// Обработка пришедшего кадра
        /// </summary>
        public void HandleFrame()
        {
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
    }
}
