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

        private Connection currentConnection;

        /// <summary>
        /// Создание соединения соединения
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
        /// Обработка пришедшего кадра
        /// </summary>
        public void HandleFrame()
        {
            // ..
        }
    }
}
