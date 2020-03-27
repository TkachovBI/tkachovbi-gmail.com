using System;
using System.Collections.Generic;
using System.Text;

namespace WPFFinalproject.Classes
{
    class SingUp
    {
        private string name;
        private string password;


        public void SetDatas(string Name, string Password)
        {
            name = Name;
            password = Password;
        }

      

        public string passwordGet()
        {
            return password;
        }

        public string nameGet()
        {
            return name;
        }
    }
}
