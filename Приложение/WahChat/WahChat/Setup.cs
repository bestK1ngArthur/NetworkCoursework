﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WahChat
{
    public partial class Setup : Form
    {
        public Setup()
        {
            InitializeComponent();
        }

<<<<<<< HEAD
=======
        //Здесь перейдём на форму авторизации
        private void connect_Click(object sender, EventArgs e)
        {
            Authorization authForm = new Authorization();
            authForm.Show();
            this.Hide();
        }

>>>>>>> authorizaation
        private void Setup_Load(object sender, EventArgs e)
        {
            // Показываем список COM-портов.
            string[] portNames = ConnectionService.GetSharedService().GetPortsNames();
            foreach (string portName in portNames)
            {
                incomePortBox.Items.Add(portName);
                outcomePortBox.Items.Add(portName);
            }
        }
    }
}
