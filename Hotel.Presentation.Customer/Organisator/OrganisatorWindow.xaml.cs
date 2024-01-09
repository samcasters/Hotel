using Hotel.Domain.Managers;
using Hotel.Domain.Model;
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
    /// Interaction logic for OrganisatorWindow.xaml
    /// </summary>
    public partial class OrganisatorWindow : Window
    {
        private OrganisatorRepository organisatorRepository;
        private OrganisatorManager organisatorManager;
        public OrganisatorUI _organisatorUI { get; set; }
        public OrganisatorWindow(OrganisatorUI organisatorUI)
        {
            try
            {
                InitializeComponent();
                this._organisatorUI = organisatorUI;
                if (_organisatorUI != null)
                {
                    IdTextBox.Text = _organisatorUI.Id.ToString();
                    NameTextBox.Text = _organisatorUI.Name;
                    EmailTextBox.Text = _organisatorUI.Email;
                    PhoneTextBox.Text = _organisatorUI.Phone;
                    AddButton.Content = "Update";
                }
                else
                {
                    AddButton.Content = "Add";
                }
                string connectionString = ConfigurationManager.ConnectionStrings["HotelDB"].ConnectionString;
                organisatorRepository = new OrganisatorRepository(connectionString);
                organisatorManager = new OrganisatorManager(organisatorRepository);
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
                    if (_organisatorUI == null)
                    {
                        Address address = new Address(CityTextBox.Text, StreetTextBox.Text, ZipTextBox.Text, HouseNumberTextBox.Text);
                        ContactInfo contactInfo = new ContactInfo(EmailTextBox.Text, PhoneTextBox.Text, address);
                        Domain.Model.Organisator organisator = new Domain.Model.Organisator(NameTextBox.Text, contactInfo);
                        organisatorManager.AddOrganisator(organisator);
                    }
                    else
                    {
                        Address address = new Address(CityTextBox.Text, StreetTextBox.Text, ZipTextBox.Text, HouseNumberTextBox.Text);
                        ContactInfo contactInfo = new ContactInfo(EmailTextBox.Text, PhoneTextBox.Text, address);
                        Domain.Model.Organisator organisator = new Domain.Model.Organisator(int.Parse(IdTextBox.Text), NameTextBox.Text, contactInfo);
                        organisatorManager.UpdateOrganisator(organisator);
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
