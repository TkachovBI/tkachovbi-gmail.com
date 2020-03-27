using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace WPFFinalproject.Classes
{
    class InfoReturns
    {
        public string WayNumber(int driverId)
        {
            string connectionString = "Server=localhost;Database=drivers;Uid=root;Pwd=Bogdan2507";
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

            mySqlConnection.Open();

            MySqlCommand command = new MySqlCommand($"select WayCode from `Cars`.`Cars` Where DriverId == {driverId}; ", mySqlConnection);

            MySqlDataReader reader = command.ExecuteReader();

            List<string> waycode = new List<string>();

            while (reader.Read())
            {
                waycode.Add(reader[0].ToString());
            }

            mySqlConnection.Close();
            if (waycode.Count == 1)
            {
                return waycode[0];
            }
            else
            {
                return "-\"-\"-\"-\"_";
            }
        }

        public string CarNumber(int driverId)
        {
            string connectionString = "Server=localhost;Database=drivers;Uid=root;Pwd=Bogdan2507";
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

            mySqlConnection.Open();

            MySqlCommand command = new MySqlCommand($"select WayCode from `Cars`.`Cars` Where DriverId == {driverId}; ", mySqlConnection);

            MySqlDataReader reader = command.ExecuteReader();

            List<string> waycode = new List<string>();

            while (reader.Read())
            {
                waycode.Add(reader[0].ToString());
            }

            mySqlConnection.Close();
            if (waycode.Count == 1)
            {
                return waycode[0];
            }
            else
            {
                return "-\"-\"-\"-\"_";
            }
        }

        public string[] AllCarInfo(string CarNumber)
        {
            string connectionString = "Server=localhost;Database=drivers;Uid=root;Pwd=Bogdan2507";
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

            mySqlConnection.Open();

            MySqlCommand command = new MySqlCommand($"select * from `Cars`.`Cars` Where CarNumber == {CarNumber}; ", mySqlConnection);

            MySqlDataReader reader = command.ExecuteReader();

            string[] arr = new string[7];

            while (reader.Read())
            {
                for (int i = 0; i < 8; i++)
                {
                    arr[i] = reader[i].ToString();
                }
            }

            mySqlConnection.Close();

            return arr;
        }


    }
}
