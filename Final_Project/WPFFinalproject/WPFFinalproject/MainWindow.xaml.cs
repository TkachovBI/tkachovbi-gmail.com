using MySql.Data.MySqlClient;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFFinalproject.Classes;

namespace WPFFinalproject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        Logging log = new Logging();
        public readonly int MoneyForKilometr = 25;
        public int driverid;
        public string CarNum;
        ObjectSizes Sizes = new ObjectSizes();        

        public bool isAgree = false;
        bool hasCar = false;

        public MainWindow()
        {
            InitializeComponent();

            Sizes.SizeZero(LableCarNumber);
            Sizes.SizeZero(LableCarNumber_Copy);
            Sizes.SizeZero(LableCarNumber_Copy1);
            Sizes.SizeZero(LableCarNumber_Copy2);
            Sizes.SizeZero(LableCarNumber_Copy3);
            Sizes.SizeZero(LableCarNumber_Copy4);
            Sizes.SizeZero(LableCarNumber_Copy5);
            Sizes.SizeZero(LableCarNumber_Copy6);
            Sizes.SizeZero(LableCarNumber_Copy7);
            Sizes.SizeZero(LableWay);

            Sizes.SizeZero(SetAgeBtn);
            Sizes.SizeZero(SetAgeTB);

            Sizes.SizeZero(TBDistance);
            Sizes.SizeZero(BtnWayEnd);
            Sizes.SizeZero(CarCond);

            Sizes.SizeZero(Btnstation);

            Sizes.SizeZero(DriverIdTB);
            Sizes.SizeZero(WayNumber);
            Sizes.SizeZero(CarNumberTB);
            Sizes.SizeZero(SetCar);
            Sizes.SizeZero(SetWay);

            log.Debug("Unuseble objects were deleted");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            log.Debug("Button sing Up Was pressed");
            //RadioBtn.IsEnabled == true
            //radioBtn is clecked
            if (isAgree == true)
            {
                log.Debug("The user agree with rules");
                if (SingUpChecks.CheckLength(TextBoxName, TextBoxPassword))
                {
                    log.Debug("Lenghts is normal");
                    if (SingUpChecks.IsPasswordstheSames(TextBoxPassword, TextBoxPassword_Copy, out string psw))
                    {
                        log.Debug("Passwords are the same");
                        if (SingUpChecks.DoNotSameNames(TextBoxName.Text))
                        {
                            log.Debug("The names aren't repiet");
                            log.Debug("All checks are done");

                            DeleteFirstView();                           

                            string connectionString = "Server=localhost;Database=drivers;Uid=root;Pwd=Bogdan2507";
                            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

                            mySqlConnection.Open();

                            string temp = TextBoxName.Text.ToString();

                            MySqlCommand command = new MySqlCommand($"INSERT INTO `drivers`.`driverstable` (`Name`, `password`) VALUES(\"{temp}\", \"{psw}\"); select `id` from `drivers`.`driverstable` where `Name`= \"{temp}\" ;", mySqlConnection);

                            MySqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                driverid = int.Parse(reader[0].ToString());
                            }

                            mySqlConnection.Close();

                            ActiveNew();

                            Sizes.SizeSet(SetAgeBtn, 58, 32);
                            Sizes.SizeSet(SetAgeTB, 154, 48);




                            // Logic

                        }
                        else
                        {
                            log.Error("Name has repited");
                            isAgree = false;
                        }
                        // Application.Current.Shutdown();
                    }
                    else
                    {
                        log.Error("Passwords aren't the same");
                        isAgree = false;
                    }
                }
                else
                {                    
                    log.Error("Lenghts isn\'t normal");
                    isAgree = false;
                }
            }
            else
            {
                log.Error("The user don\'t agree with rules");
                isAgree = false;
                MessageBox.Show("We are sorry, but you don\'t agree with our rules");
            }



        }

        // delete all view on first view
        private void DeleteFirstView()
        {
            Sizes.SizeZero(LableName);
            Sizes.SizeZero(TextBoxName);
            Sizes.SizeZero(TextBoxPassword);
            Sizes.SizeZero(LableName_Copy);
            Sizes.SizeZero(TextBoxPassword);
            Sizes.SizeZero(TextBoxPassword_Copy);
            Sizes.SizeZero(BtnIAWAR);
            Sizes.SizeZero(Sing_Up);
            Sizes.SizeZero(LableNameSingIn);
            Sizes.SizeZero(TextBoxNameSingIn);
            Sizes.SizeZero(TextBoxPassword_Copy1);
            Sizes.SizeZero(LableName_Copy1);
            Sizes.SizeZero(Sing_In);
            Sizes.SizeZero(BtnIAWAR_Copy);

            log.Debug("First view was deleted"); 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (isAgree == true)
            {
                log.Debug("The user agree with rules");
                if (TextBoxNameSingIn.Text != "root")
                {
                    bool isNumber = int.TryParse(TextBoxNameSingIn.Text, out int idd);

                    if (isNumber)
                    {
                        string connectionString = "Server=localhost;Database=drivers;Uid=root;Pwd=Bogdan2507";
                        MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

                        mySqlConnection.Open();

                        MySqlCommand command = new MySqlCommand($"select `password`, `old` from `drivers`.`driverstable` Where `id` = {idd}; ", mySqlConnection);

                        MySqlDataReader reader = command.ExecuteReader();

                        string temp = "lol";
                        string old = null;

                        while (reader.Read())
                        {
                            temp = reader[0].ToString();

                            old = reader[1].ToString();
                        }

                        mySqlConnection.Close();
                        if (temp != "lol")
                        {
                            if (temp == TextBoxPassword_Copy1.Text)
                            {
                                log.Debug("The driver sing in");
                                driverid = int.Parse(TextBoxNameSingIn.Text);
                                DeleteFirstView();
                                ActiveNew();
                                if (old == "")
                                {
                                    Sizes.SizeSet(SetAgeBtn, 58, 32);
                                    Sizes.SizeSet(SetAgeTB, 154, 48);
                                }


                            }
                            else
                            {
                                isAgree = false;
                                MessageBox.Show("The password isn\'t correct");
                            }
                        }
                        else
                        {
                            isAgree = false;
                            MessageBox.Show("We can\'t found your name in our data base");
                        }
                    }
                    else
                    {
                        MessageBox.Show("You hasn\'t wrote an a number. \n Please, rewrite it");
                    }
                }
                else
                {
                    // id = root
                    // password = despetchers
                    log.Debug("Despetcher has sing in");
                    if (TextBoxPassword_Copy1.Text.ToLower() == "despetchers")
                    {
                        DeleteFirstView();
                       
                        MessageBox.Show("You are sing in to dispetcher account");

                        // logic

                        Sizes.SizeSet(DriverIdTB, 178, 27);      
                        Sizes.SizeSet(WayNumber, 65, 35); 
                        Sizes.SizeSet(CarNumberTB, 65, 35);
                        Sizes.SizeSet(SetCar, 73, 38); 
                        Sizes.SizeSet(SetWay, 73, 38); 

                    }
                    else
                    {
                        MessageBox.Show("Uncorrect password");
                    }
                }
            }
            else
            {
                log.Error("The user don\'t agree with rules");
                isAgree = false;
                MessageBox.Show("You don\'t agree with our rules");
            }
        }

        private void BtnIAWAR_Click(object sender, RoutedEventArgs e)
        {
            log.Debug("The user agree with rules");
            isAgree = true;
        }

        public string[] CarInfo(int driverId)
        {
            string connectionString = "Server=localhost;Database=drivers;Uid=root;Pwd=Bogdan2507";
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

            mySqlConnection.Open();

            MySqlCommand command = new MySqlCommand($"select * from `Cars`.`Carstable` WHERE `driverid`= {driverId}; ", mySqlConnection);

            MySqlDataReader reader = command.ExecuteReader();

            string[] arr = new string[7];

            while (reader.Read())
            {
                hasCar = true;
                for (int i = 0; i < (arr.Length); i++)
                {
                    arr[i] = reader[i].ToString();
                }
            }

            mySqlConnection.Close();

            int y = 0;
            foreach (var item in arr)
            {
                if (item != null)
                {
                    y++;
                }
            }

            if (y == 7)
            {
                return arr;
                
            }
            else
            {
                return new string[] { "-", "-", "-", "-", "-", "-", "-" };
                
            }

        }

        public string[] personalInfo(int id)
        {
            string connectionString = "Server=localhost;Database=drivers;Uid=root;Pwd=Bogdan2507";
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

            mySqlConnection.Open();

            MySqlCommand command = new MySqlCommand($"select * from `drivers`.`driverstable` WHERE `id`= {id}; ", mySqlConnection);

            MySqlDataReader reader = command.ExecuteReader();

            string[] arr = new string[5];

            while (reader.Read())
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = reader[i].ToString();
                }
            }

            mySqlConnection.Close();

            return arr;

        }

        public void ActiveNew()
        {

            #region Info about car

            string[] arr = CarInfo(driverid);
            // LableCarNumber -- car number
            Sizes.SizeSet(LableCarNumber, 174, 41);
            LableCarNumber.Content = $"Number: {arr[0]}  ";
            CarNum = arr[0];
            // LableCarNumber_Copy -- Brandname
            Sizes.SizeSet(LableCarNumber_Copy, 174, 41);
            LableCarNumber_Copy.Content = $"Brand: {arr[1]}  ";
            // LableCarNumber_Copy1 -- Vin code
            Sizes.SizeSet(LableCarNumber_Copy1, 174, 41);
            LableCarNumber_Copy1.Content = $"VIN: {arr[2]}  ";
            // LableCarNumber_Copy2 -- date of creating
            Sizes.SizeSet(LableCarNumber_Copy2, 174, 41);
            LableCarNumber_Copy2.Content = $"Date of creating: {arr[3]}  ";
            // LableCarNumber_Copy5 -- price
            Sizes.SizeSet(LableCarNumber_Copy5, 174, 41);
            LableCarNumber_Copy5.Content = $"Price: {arr[5]}$  ";
            #endregion
            log.Debug("Info about car was getted");

            #region same datas

            // LableCarNumber_Copy4 -- DriverId
            Sizes.SizeSet(LableCarNumber_Copy4, 174, 41);
            LableCarNumber_Copy4.Content = $"Driver Id: {driverid}  ";
            #endregion

            log.Debug("Info about same datas was getted");

            #region personal datas
            string[] personaleinformation = personalInfo(driverid);

            // LableCarNumber_Copy6 -- NAME
            Sizes.SizeSet(LableCarNumber_Copy6, 174, 41);
            LableCarNumber_Copy6.Content = $"Name: {personaleinformation[1]}  ";
            // LableCarNumber_Copy7 -- OLD
            Sizes.SizeSet(LableCarNumber_Copy7, 174, 41);
            LableCarNumber_Copy7.Content = $"Your old: {personaleinformation[4]}  ";
            #endregion

            log.Debug("Info about driver was getted");

            // LableCarNumber_Copy3 -- WayCode
            Sizes.SizeSet(LableCarNumber_Copy3, 174, 41);
            LableCarNumber_Copy3.Content = $"Way code: {personaleinformation[3]}    ";

            if (arr[0] != "-")
            {
                log.Debug("A driver has a car");

                hasCar = true;

                string connectionString = "Server=localhost;Database=drivers;Uid=root;Pwd=Bogdan2507";
                MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

                mySqlConnection.Open();

                MySqlCommand command = new MySqlCommand($"UPDATE `drivers`.`driverstable` SET `CarNumber` = '{arr[0]}' WHERE `id` = '{driverid}'; UPDATE `Cars`.`Carstable` SET `WayCode` = '{personaleinformation[3]}' WHERE `DriverId` = '{driverid}'; UPDATE `Cars`.`Carstable` SET `DriverId` = '{driverid}' WHERE `CarNumber` = '{arr[0]}';", mySqlConnection);

                MySqlDataReader reader = command.ExecuteReader();

                mySqlConnection.Close();


            }

            if (personaleinformation[3] != "")
            {
                log.Debug("the driver has a way");
                // LableWay -- way
                Sizes.SizeSet(LableWay, 174, 41);
                LableWay.Content = $"Your way: {personaleinformation[3]}        ";

                Sizes.SizeSet(CarCond, 218, 51);
                Sizes.SizeSet(TBDistance, 218, 51);
                Sizes.SizeSet(BtnWayEnd,218,51);
            }

            if (hasCar)
            {
                Sizes.SizeSet(Btnstation, 127, 50);
            }

            log.Debug("New wiew was active");


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            log.Debug("Application exit event");
            Application.Current.Shutdown();
        }

        private void SetAgeBtn_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Server=localhost;Database=drivers;Uid=root;Pwd=Bogdan2507";
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

            mySqlConnection.Open();

            int.TryParse(SetAgeTB.Text, out int z);

            MySqlCommand command = new MySqlCommand($"UPDATE `drivers`.`driverstable` SET `old` = '{z}' WHERE `id` = '{driverid}';", mySqlConnection);

            MySqlDataReader reader = command.ExecuteReader();

            mySqlConnection.Close();

            Sizes.SizeZero(SetAgeTB);
            Sizes.SizeZero(SetAgeBtn);

            // LableCarNumber_Copy7 -- OLD
            Sizes.SizeSet(LableCarNumber_Copy6, 174, 41);
            LableCarNumber_Copy6.Content = $"Your old: {z}  ";
        }

        private void BtnWayEnd_Click(object sender, RoutedEventArgs e)
        {

            bool isNum = int.TryParse(TBDistance.Text.ToString(), out int distance);

            if (isNum)
            {
                MessageBox.Show($"{distance * MoneyForKilometr}$ is added to your balance");

                if (CarCond.Text.Length <= 3 & double.TryParse(CarCond.Text, out double Cond))
                {
                    MessageBox.Show("Thank you, you are finished your task on your way");

                    string connectionString = "Server=localhost;Database=drivers;Uid=root;Pwd=Bogdan2507";
                    MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

                    mySqlConnection.Open();

                    MySqlCommand command = new MySqlCommand($"UPDATE `drivers`.`driverstable` SET `wayCode` = '' WHERE `id` = '{driverid}'; UPDATE `Cars`.`Carstable` SET `WayCode` = '' WHERE `DriverId` = '{driverid}'", mySqlConnection);

                    MySqlDataReader reader = command.ExecuteReader();

                    // Delete view which conected with wayEnd
                    Sizes.SizeZero(LableWay);
                    Sizes.SizeZero(TBDistance);
                    Sizes.SizeZero(CarCond);
                    Sizes.SizeZero(BtnWayEnd);

                    log.Debug("The way has finished");
                }
                else
                {
                    if (CarCond.Text.Length <= 3)
                    {
                        MessageBox.Show("It isn\'t a decimal number");
                    }
                    else
                    {
                        MessageBox.Show("The number isn\'t in range");
                    }
                }
            }
            else
            {
                MessageBox.Show("the diistance isn\'t a number");
            }


            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // UPDATE `Cars`.`Carstable` SET `DriverId` = '' WHERE (`CarNumber` = 'AE4433BX');

            string connectionString = "Server=localhost;Database=drivers;Uid=root;Pwd=Bogdan2507";
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

            mySqlConnection.Open();

            string temp = TextBoxName.Text.ToString();

            MySqlCommand command = new MySqlCommand($"UPDATE `Cars`.`Carstable` SET `DriverId` = '0' WHERE `CarNumber` = '{CarNum}';", mySqlConnection);

            MySqlDataReader reader = command.ExecuteReader();           

            mySqlConnection.Close();

            MessageBox.Show("The car was sanded to the station");

            log.Debug($"The car({CarNum}) was sended to the station");
        }

        private void SetCar_Click(object sender, RoutedEventArgs e)
        {
            bool isNumId = int.TryParse(DriverIdTB.Text, out int drivId);
            bool isNumCarNumber = int.TryParse(CarNumberTB.Text, out int CarNum);

            if (isNumId & isNumCarNumber)
            {
                string connectionString = "Server=localhost;Database=drivers;Uid=root;Pwd=Bogdan2507";
                MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

                mySqlConnection.Open();

                string temp = TextBoxName.Text.ToString();

                MySqlCommand command = new MySqlCommand($"UPDATE `drivers`.`driverstable` SET `CarNumber` = '{CarNum}' WHERE `id` = '{drivId}'; UPDATE `Cars`.`Carstable` SET `DriverId` = '{drivId}' WHERE `CarNumber` = '{CarNum}';", mySqlConnection);

                MySqlDataReader reader = command.ExecuteReader();

                mySqlConnection.Close();

                log.Debug($"The car {CarNum} gived to driver({drivId})");
            }
        }

        private void SetWay_Click(object sender, RoutedEventArgs e)
        {
            bool isNumId = int.TryParse(DriverIdTB.Text, out int drivId);
            bool isNumWay = int.TryParse(WayNumber.Text, out int WayCode);

            if (isNumId & isNumWay)
            {
                string connectionString = "Server=localhost;Database=drivers;Uid=root;Pwd=Bogdan2507";
                MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

                mySqlConnection.Open();

                string temp = TextBoxName.Text.ToString();

                MySqlCommand command = new MySqlCommand($"UPDATE `drivers`.`driverstable` SET `wayCode` = '{WayCode}' WHERE `id` = '{drivId}';", mySqlConnection);

                MySqlDataReader reader = command.ExecuteReader();

                mySqlConnection.Close();

                log.Debug($"The way {WayCode} gived to driver({drivId})");
            }
        }
    }
}

