using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WPFFinalproject.Classes
{
    static class SingUpChecks
    {
        public static bool IsPasswordstheSames(TextBox textBox1, TextBox textBox2, out string password)
        {
            if(textBox1.Text == textBox2.Text)
            {
                password = textBox2.Text;
                return true;
            }
            else
            {
                MessageBox.Show("The passwords aren't the same");
                password = null;
                return false;
                 
            }
        }

        public static bool DoNotSameNames(string name)
        {
            string connectionString = "Server=localhost;Database=drivers;Uid=root;Pwd=Bogdan2507";
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

            mySqlConnection.Open();

            MySqlCommand command = new MySqlCommand("select * from `drivers`.`driverstable`", mySqlConnection);

            MySqlDataReader reader = command.ExecuteReader();


            List<string> names = new List<string>();

            while (reader.Read())
            {
               names.Add(reader[1].ToString());
            }

            mySqlConnection.Close();
            int counter = 0;

            for (int i = 0; i < names.Count; i++)
            {
                if (name !=  names[i])
                {
                    counter++;
                }   
            }

            if (counter == names.Count)
            {
                return true;
            }
            else
            {
                MessageBox.Show("This name was alredy used");
                return false;
            }
        }

        public static bool CheckLength(TextBox NameTBX, TextBox pswTBX)
        {
            if (NameTBX.Text.Length >= 6 & pswTBX.Text.Length >= 6)
            {
                return true;
            }
            else
            {
                if (NameTBX.Text.Length < 6)
                {
                    MessageBox.Show($"The name: {NameTBX.Text} - is too short( \n Please rewrite it");
                }
                else
                {
                    MessageBox.Show($"The password: {pswTBX.Text} - is too short( \n Please rewrite it");
                }

                return false;
            }
        }
    }
}
