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
    public partial class Setup : Form
    {
        public Setup()
        {
            InitializeComponent();
        }

        //Здесь перейдём на форму авторизации
        private void connect_Click(object sender, EventArgs e)
        {
            Authorization authForm = new Authorization();
            authForm.Show();
            this.Hide();
        }

        private void Setup_Load(object sender, EventArgs e)
        {

        }
    }
}
