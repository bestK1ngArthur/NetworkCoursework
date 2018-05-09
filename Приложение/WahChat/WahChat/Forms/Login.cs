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
            string str = "ffuuucckk";
            List<byte> data = new List<byte>();

            byte[] arr = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, arr, 0, arr.Length);
            data.AddRange(arr);

            NetworkService.GetSharedService().currentConnection.SendBytes(data);

            this.notificationLabel.Text = "Отправил парашу";

            //this.Close();
        }
    }
}
