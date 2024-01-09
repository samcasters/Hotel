using Hotel.Domain.Managers;
using Hotel.Persistence.Repositories;
using Hotel.Presentation.Customer.Model;
using Hotel.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hotel.Presentation.Customer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int catagory = 2; //1=activity|2=customer|3=orgenisator|4=registration
        private ObservableCollection<ActivityUI> activityUIs = new ObservableCollection<ActivityUI>();
        private ObservableCollection<CustomerUI> customerUIs = new ObservableCollection<CustomerUI>();
        private ObservableCollection<OrganisatorUI> organisatorUIs = new ObservableCollection<OrganisatorUI>();
        private ObservableCollection<RegistrationUI> registrationUIs = new ObservableCollection<RegistrationUI>();

        //private ObservableCollection<CustomerUI> customerUIs = new ObservableCollection<CustomerUI>();
        private CustomerManager customerManager;
        private ActivityManager activityManager;
        private OrganisatorManager organisatorManager;
        private RegistrationManager registrationManager;

        public MainWindow()
        {
            InitializeComponent();
            customerManager = new CustomerManager(RepositoryFactory.CustomerRepository);
            activityManager = new ActivityManager(RepositoryFactory.ActivityRepository);
            organisatorManager = new OrganisatorManager(RepositoryFactory.organisatorRepository);
            registrationManager = new RegistrationManager(RepositoryFactory.registrationRepository);
            customerUIs =new ObservableCollection<CustomerUI>(customerManager.GetCustomers(null).Select(x => new CustomerUI(x.Id,x.Name,x.Contact.Email,x.Contact.Address.ToString(),x.Contact.Phone,x.GetMembers().Count)).ToList());
            MainDataGrid.ItemsSource = customerUIs;
        }

        private void ChangeCatagory(string Catagory,int index)
        {
            catagory = index;
            CatagoryTextBox.Text = Catagory;
        }
        private void UpdateGrid()
        {
            switch (catagory)
            {
                case 1:
                    activityUIs = new ObservableCollection<ActivityUI>(activityManager.GetActivitys(null).Select(x => new ActivityUI(x.Id, x.Name, x.Description, x.Place, x.DurationMin, x.TimeOfActivity, x.Availability, x.CostAdult, x.CostChild, x.Organisator.Id)).ToList());
                    MainDataGrid.ItemsSource = activityUIs;
                    UpdateButton.IsEnabled = true;
                    AddButton.ToolTip = "screen for updating a existing activity";
                    AddButton.IsEnabled = true;
                    AddButton.ToolTip = "screen for adding a new activity";
                    InformationButton.IsEnabled = false;
                    InformationButton.ToolTip = "Activity dose not have a information screen";
                    break;
                case 2:
                    customerUIs = new ObservableCollection<CustomerUI>(customerManager.GetCustomers(null).Select(x => new CustomerUI(x.Id, x.Name, x.Contact.Email, x.Contact.Address.ToString(), x.Contact.Phone, x.GetMembers().Count)).ToList());
                    MainDataGrid.ItemsSource = customerUIs;
                    UpdateButton.IsEnabled = true;
                    AddButton.ToolTip = "screen for updating a existing customer";
                    AddButton.IsEnabled = true;
                    AddButton.ToolTip = "screen for adding a new customer";
                    InformationButton.IsEnabled = true;
                    InformationButton.ToolTip = "screen for ading members and updating activitys";
                    break;
                case 3:
                    organisatorUIs = new ObservableCollection<OrganisatorUI>(organisatorManager.GetOrganisators(null).Select(x => new OrganisatorUI(x.Id, x.Name, x.Contact.Email, x.Contact.Address.ToString(), x.Contact.Phone)).ToList());
                    MainDataGrid.ItemsSource = organisatorUIs;
                    UpdateButton.IsEnabled = true;
                    AddButton.ToolTip = "screen for updating a existing organisator";
                    AddButton.IsEnabled = true;
                    AddButton.ToolTip = "screen for adding a new organisator";
                    InformationButton.IsEnabled = false;
                    InformationButton.ToolTip = "organisator dose not have a information screen";
                    break;
                case 4:
                    registrationUIs = new ObservableCollection<RegistrationUI>(registrationManager.GetRegistrations(null).Select(x => new RegistrationUI(x.Activatie.Id, x.Customer.Id, x.Participating)).ToList());
                    MainDataGrid.ItemsSource = registrationUIs;

                    UpdateButton.IsEnabled = false;
                    UpdateButton.ToolTip = "u can make/update regestrations in customer information";
                    AddButton.IsEnabled = false;
                    AddButton.ToolTip = "u can make/update regestrations in customer information";
                    InformationButton.IsEnabled = false;
                    InformationButton.ToolTip = "registrations dose not have a information screen";
                    
                    
                    break;
                default:
                    break;
            }

        }

        private void ActivityButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeCatagory("Activity", 1);
            UpdateGrid();
        }
        private void CustomerButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeCatagory("Customer", 2);
            UpdateGrid();
        }
        private void OrganisatorButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeCatagory("Organisator", 3);
            UpdateGrid();
        }
        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeCatagory("Registration", 4);
            UpdateGrid();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            switch (catagory)
            {
                case 1:
                    activityUIs = new ObservableCollection<ActivityUI>(activityManager.GetActivitys(SearchTextBox.Text).Select(x => new ActivityUI(x.Id, x.Name, x.Description, x.Place, x.DurationMin, x.TimeOfActivity, x.Availability, x.CostAdult, x.CostChild, x.Organisator.Id)).ToList());
                    MainDataGrid.ItemsSource = activityUIs;
                    break;
                case 2:
                    customerUIs = new ObservableCollection<CustomerUI>(customerManager.GetCustomers(SearchTextBox.Text).Select(x => new CustomerUI(x.Id, x.Name, x.Contact.Email, x.Contact.Address.ToString(), x.Contact.Phone, x.GetMembers().Count)).ToList());
                    MainDataGrid.ItemsSource = customerUIs;
                    break;
                case 3:
                    organisatorUIs = new ObservableCollection<OrganisatorUI>(organisatorManager.GetOrganisators(SearchTextBox.Text).Select(x => new OrganisatorUI(x.Id, x.Name, x.Contact.Email, x.Contact.Address.ToString(), x.Contact.Phone)).ToList());
                    MainDataGrid.ItemsSource = organisatorUIs;
                    break;
                case 4:
                    registrationUIs = new ObservableCollection<RegistrationUI>(registrationManager.GetRegistrations(SearchTextBox.Text).Select(x => new RegistrationUI(x.Activatie.Id, x.Customer.Id, x.Participating)).ToList());
                    MainDataGrid.ItemsSource = registrationUIs;
                    break;
                default:
                    break;
            }

        }
        private void UpdateSelectedButton_Click(object sender, RoutedEventArgs e)
        {
            if(MainDataGrid.SelectedItem != null)
            {
                switch (catagory)
                {
                    case 1:
                        int activityindex = MainDataGrid.SelectedIndex;
                        ActivityUI activityUI = activityUIs[activityindex];
                        ActivatieWindow aw = new ActivatieWindow(activityUI);
                        aw.ShowDialog();
                        break;
                    case 2:
                        int customerindex = MainDataGrid.SelectedIndex;
                        CustomerUI customerUI = customerUIs[customerindex];
                        CustomerWindow cw = new CustomerWindow(customerUI);
                        cw.ShowDialog();
                        break;
                    case 3:
                        int organisatorindex = MainDataGrid.SelectedIndex;
                        OrganisatorUI organisatorUI = organisatorUIs[organisatorindex];
                        OrganisatorWindow ow = new OrganisatorWindow(organisatorUI);
                        ow.ShowDialog();
                        break;
                    case 4:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("geen item geselecteerd", "input error");
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            switch (catagory)
            {
                case 1:
                    ActivatieWindow aw = new ActivatieWindow(null);
                    aw.ShowDialog();
                    break;
                case 2:
                    CustomerWindow cw = new CustomerWindow(null);
                    cw.ShowDialog();
                    break;
                case 3:
                    OrganisatorWindow ow = new OrganisatorWindow(null);
                    ow.ShowDialog();
                    break;
                case 4:
                    break;
                default:
                    break;
            }

        }
        private void InformationButton_Click(object sender, RoutedEventArgs e)
        {
            switch (catagory)
            {
                case 1:
                    break;
                case 2:
                    int customerindex = MainDataGrid.SelectedIndex;
                    CustomerUI customerUI = customerUIs[customerindex];
                    CustomerInfoWindow ciw = new CustomerInfoWindow(customerUI);
                    ciw.ShowDialog();
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    break;
            }

        }

    }
}
