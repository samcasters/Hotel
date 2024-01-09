using Hotel.Domain.Managers;
using Hotel.Domain.Model;
using Hotel.Persistence.Repositories;
using Hotel.Presentation.Customer.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {

        private CustomerRepository CustomerRepository;
        private CustomerManager customerManager;
        public CustomerUI CustomerUI { get; set; }
        public CustomerWindow(CustomerUI customerUI)
        {
            try
            {
                InitializeComponent();
                this.CustomerUI = customerUI;
                if (CustomerUI != null)
                {
                    IdTextBox.Text = CustomerUI.Id.ToString();
                    NameTextBox.Text = CustomerUI.Name;
                    EmailTextBox.Text = CustomerUI.Email;
                    PhoneTextBox.Text = CustomerUI.Phone;
                    AddButton.Content = "Update";
                }
                else
                {
                    AddButton.Content = "Add";
                }
                string connectionString = ConfigurationManager.ConnectionStrings["HotelDB"].ConnectionString;
                CustomerRepository = new CustomerRepository(connectionString);
                customerManager = new CustomerManager(CustomerRepository);
            }
            catch (Exception)
            {

                Close();
            }
            
         }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(NameTextBox.Text) | string.IsNullOrWhiteSpace(EmailTextBox.Text) | string.IsNullOrWhiteSpace(PhoneTextBox.Text) | string.IsNullOrWhiteSpace(CityTextBox.Text) | string.IsNullOrWhiteSpace(StreetTextBox.Text) | string.IsNullOrWhiteSpace(ZipTextBox.Text) | string.IsNullOrWhiteSpace(HouseNumberTextBox.Text))
                {
                    MessageBox.Show("er is ergens een value niet ingevuld", "input error");
                    return;
                }
                else
                {
                    if (CustomerUI == null)
                    {
                        Address address = new Address(CityTextBox.Text, StreetTextBox.Text, ZipTextBox.Text, HouseNumberTextBox.Text);
                        ContactInfo contactInfo = new ContactInfo(EmailTextBox.Text, PhoneTextBox.Text, address);
                        Domain.Model.Customer customer = new Domain.Model.Customer(NameTextBox.Text, contactInfo);
                        customerManager.AddCustomer(customer);
                    }
                    else
                    {
                        Address address = new Address(CityTextBox.Text, StreetTextBox.Text, ZipTextBox.Text, HouseNumberTextBox.Text);
                        ContactInfo contactInfo = new ContactInfo(EmailTextBox.Text, PhoneTextBox.Text, address);
                        Domain.Model.Customer customer = new Domain.Model.Customer(int.Parse(IdTextBox.Text), NameTextBox.Text, contactInfo);
                        customerManager.UpdateCustomer(customer);
                    }
                    DialogResult = true;
                    Close();
                }
            }
            catch (Exception)
            {

                Close();
            }
        }
    }
}
