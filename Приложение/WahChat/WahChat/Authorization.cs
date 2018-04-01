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
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Authorization_Load(object sender, EventArgs e)
        {

        }

        //Переход назад, к форме выбора портов
        private void close_Click(object sender, EventArgs e)
        {
            this.Hide();
            Setup setupForm = new Setup();
            setupForm.Show();
        }

        private void auth_btn_Click(object sender, EventArgs e)
        {
            if (login.Text == "")
            {
                MessageBox.Show("Вы должны ввести свой логин.");
            }
            else
            {
                //ЭТО НАДО БУДЕТ УБРАТЬ
                MessageBox.Show("ЗАЕБИСЬ!!!!!!!");

                //Это будем куда-то запихивать
                String your_login = login.Text;

                //Будет происходить переход в форму чата
            }
        }

        public String data_login
        {
            get { return login.Text; }
            set { }
        }
    }
}
