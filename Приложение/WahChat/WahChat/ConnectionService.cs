﻿using System;
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

        private Connection currentConnection;

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
        /// Обработка пришедшего кадра
        /// </summary>
        public void HandleFrame()
        {
            // ..
        }

        /// <summary>
        /// Список доступных портов
        /// </summary>
        public string[] GetPortsNames()
        {
            return SerialPort.GetPortNames();
        }

        /// <summary>
        /// Создание сессии
        /// </summary>
        public void CreateSession(string username)
        {
            this.currentConnection = new Connection(incomePortName, outcomePortName);

            // формирование LINK кадра..
            // отправка LINK кадра..
        }
    }
}
