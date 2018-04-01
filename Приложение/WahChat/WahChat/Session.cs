using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WahChat
{
    class Session
    {
        //Здесь будут хранится данные о сессии после соединения
        void sessionData()
        {
            Authorization form = new Authorization();

            //Получили логин одного юзера
            String login = form.data_login;
        }
    }
}
