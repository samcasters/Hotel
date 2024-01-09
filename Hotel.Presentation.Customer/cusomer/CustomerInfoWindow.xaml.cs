using Hotel.Domain.Managers;
using Hotel.Persistence.Repositories;
using Hotel.Presentation.Customer.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Shapes;

namespace Hotel.Presentation.Customer
{
    /// <summary>
    /// Interaction logic for CustomerInfoWindow.xaml
    /// </summary>
    public partial class CustomerInfoWindow : Window
    {
        private CustomerRepository CustomerRepository;
        private CustomerManager customerManager;
        CustomerUI customerUI;
        public CustomerInfoWindow(CustomerUI customerUI)
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["HotelDB"].ConnectionString;
            CustomerRepository = new CustomerRepository(connectionString);
            customerManager = new CustomerManager(CustomerRepository);
            this.customerUI = customerUI;
            CustomerTextBlock.Text = customerUI.Name;
            UpdateMemberBoard();
        }

        private void UpdateMemberBoard()
        {
            memberDataGrid.ItemsSource = customerManager.GetMembers(int.Parse($"{customerUI.Id}"));
        }

        private void AddMemberButton_Click(object sender, RoutedEventArgs e)
        {
            string? memberName = null;
            if (!string.IsNullOrWhiteSpace(NameTextBox.Text)) { memberName = NameTextBox.Text; }
            else { MessageBox.Show("u have to give a name to add a member", "input error"); return; }
            
            DateTime? Memberburthday = null;
            if(BurthdayDatePicker.SelectedDate != null) { Memberburthday = BurthdayDatePicker.SelectedDate; }
            else { MessageBox.Show("u have to give a burthday to add a member", "input error"); return; }

            customerManager.AddMember(customerUI.Id, memberName, Memberburthday);
            UpdateMemberBoard();
        }
        private void AddSelectedButton_Click(object sender, RoutedEventArgs e)
        { 
            
        }
        private void RemoveSelectedButton_Click(object sender, RoutedEventArgs e)
        { 
            
        }
    }
}
