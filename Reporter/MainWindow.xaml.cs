using System.Windows;

using Reporter.Repositories.Projects;
using Reporter.Models.Projects;
using Reporter.Repositories;
using Reporter.Models.Users;
using Reporter.Repositories.Users;
using System;

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

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string username = txt_username.Text;
            string password = txt_password.Text;

            User user = new User();
            user.Password = password;
            user.Username = username;

            this.usersRepository.AddItem(user);
        }

        private void UpdateUsersList()
        {
            string users = string.Join(Environment.NewLine, this.usersRepository.GetAllItems());
            users_list.Text = users;
        }
    }
}
