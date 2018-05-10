using System;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            NetworkService.GetSharedService().notificationLabel = this.notificationLabel;
            NetworkService.GetSharedService().connectButton = this.loginButton;

            this.loginButton.Text = "Подключиться";

            if (NetworkService.GetSharedService().currentConnection.isPortsOpened)
            {
                this.notificationLabel.Text = "Порты открыты";
            }
            else
            {
                this.notificationLabel.Text = "Ошибка открытия портов";
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            int username = int.Parse(textBox.Text);
            NetworkService.GetSharedService().CreateSession(username);

            /*
            string str = "ffuuucckk";
            byte[] byteStr = System.Text.Encoding.UTF8.GetBytes(str);

            List<byte> data = new List<byte>();

            data.Add(boundByte);

            data.Add((byte)Frame.Type.Data);
            data.Add((byte)username);

            foreach (byte b in byteStr)
            {
                data.Add(b);
            }

            data.Add(boundByte);
            */

            Frame frame = new Frame(Frame.Type.Link);
            NetworkService.GetSharedService().SendFrame(frame);

            this.notificationLabel.Text = "Отправил парашу";

            //this.Close();
        }
    }
}
