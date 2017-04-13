using Reporter.Models.Projects;
using Reporter.Models.Users;
using Reporter.Repositories;
using Reporter.Repositories.Projects;
using Reporter.Repositories.Users;
using Reporter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Reporter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IRepository<Project> projectsRepository;
        private IRepository<User> usersRepository;

        public MainWindow()
        {
            this.projectsRepository = new ProjectsRepository();
            this.usersRepository = new UsersRepository();

            InitializeComponent();
        }

        private void Register()
        {
            string username = txt_register_username.Text;
            string password = txt_register_password.Text;

            User user = new User();
            user.Password = password;
            user.Username = username;

            this.usersRepository.AddItem(user);
            this.UpdateUsersList();

            txt_register_username.Text = "";
            txt_register_password.Text = "";
        }

        private void Login()
        {
            string username = txt_login_username.Text;
            string password = txt_login_password.Text;

            IEnumerable<User> users = this.usersRepository.GetAllItems();
            User user = users.FirstOrDefault(u => u.Username == username);

            string error = null;
            if (user == null)
            {
                error = "Such user does not exist";
            }
            else
            {
                if (new CryptoService().ValidateHash(password, user.Password))
                {
                    current_user_username.Content = username;
                }
                else
                {
                    error = "Invalid Password";
                }
            }

            if (error != null)
            {
                error_label.Visibility = Visibility.Visible;
                username_label.Visibility = Visibility.Hidden;
                current_user_username.Visibility = Visibility.Hidden;
                user_grid.Visibility = Visibility.Visible;

                error_label.Content = error;
            }
            else
            {
                error_label.Visibility = Visibility.Hidden;
                username_label.Visibility = Visibility.Visible;
                current_user_username.Visibility = Visibility.Visible;
                user_grid.Visibility = Visibility.Visible;

                txt_login_username.Text = "";
                txt_login_password.Text = "";
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            this.Register();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            this.Login();
        }

        private void UpdateUsersList()
        {
            string users = string.Join(Environment.NewLine, this.usersRepository.GetAllItems());
            users_list.Text = users;
        }

        private void Register_Username_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                this.Register();
            }
        }

        private void Register_Password_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                this.Register();
            }
        }

        private void Login_Username_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                this.Login();
            }
        }

        private void Login_Password_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                this.Login();
            }
        }
    }
}
