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
    /// Interaction logic for ActivatieWindow.xaml
    /// </summary>
    public partial class ActivatieWindow : Window
    {
        private OrganisatorRepository OrganisatorRepository;
        private OrganisatorManager OrganisatorManager;

        private ActivityRepository ActivityRepository;
        private ActivityManager ActivityManager;
        public ActivityUI ActivityUI { get; set; }

        public ActivatieWindow(ActivityUI activityUI)
        {
            try
            {
                InitializeComponent();
                this.ActivityUI = activityUI;
                if (ActivityUI != null)
                {

                    IdTextBox.Text = $"{activityUI.Id}";
                    NameTextBox.Text = activityUI.Name;
                    DiscriptionTextBox.Text = activityUI.Discription;
                    PlaceTextBox.Text = activityUI.Place;
                    DurationTextBox.Text = $"{activityUI.DurationMin}";
                    AvalibilityTextBox.Text = $"{activityUI.Availability}";
                    CostChildTextBox.Text = $"{activityUI.CostChild}";
                    CostAdultTextBox.Text = $"{activityUI.CostAdult}";
                    TimeOfActivityDatePicker.SelectedDate = activityUI.TimeOfActivity;
                    OrganisatorIdTextBox.Text = $"{activityUI.OrganisatorId}";

                    OrganisatorIdTextBox.IsEnabled = false;
                    AddButton.Content = "Update";
                }
                else
                {
                    OrganisatorIdTextBox.IsEnabled = true;
                    AddButton.Content = "Add";
                }
                string connectionString = ConfigurationManager.ConnectionStrings["HotelDB"].ConnectionString;
                ActivityRepository = new ActivityRepository(connectionString);
                ActivityManager = new ActivityManager(ActivityRepository);

                OrganisatorRepository = new OrganisatorRepository(connectionString);
                OrganisatorManager = new OrganisatorManager(OrganisatorRepository);
                Close();
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
                if(string.IsNullOrWhiteSpace(NameTextBox.Text)| string.IsNullOrWhiteSpace(DiscriptionTextBox.Text)| string.IsNullOrWhiteSpace(PlaceTextBox.Text) | string.IsNullOrWhiteSpace(DurationTextBox.Text) | string.IsNullOrWhiteSpace(AvalibilityTextBox.Text) | string.IsNullOrWhiteSpace(CostAdultTextBox.Text) | string.IsNullOrWhiteSpace(CostChildTextBox.Text))
                {
                    MessageBox.Show("er is ergens een value niet ingevuld", "input error");
                    return;
                }
                else
                {
                    if (ActivityUI == null)
                    {
                        // register
                        DateTime dateTime = DateTime.Parse(TimeOfActivityDatePicker.SelectedDate.ToString());
                        Organisator organisator = OrganisatorManager.GetOrganisatorById(ActivityUI.OrganisatorId);
                        Activity activity = new Activity(NameTextBox.Text, DiscriptionTextBox.Text,
                                                         PlaceTextBox.Text, int.Parse(DurationTextBox.Text), dateTime,
                                                         int.Parse(AvalibilityTextBox.Text), float.Parse(CostAdultTextBox.Text), float.Parse(CostChildTextBox.Text),
                                                         organisator);
                        ActivityManager.AddActivity(activity);
                    }
                    else
                    {
                        //update
                        DateTime dateTime = DateTime.Parse(TimeOfActivityDatePicker.SelectedDate.ToString());
                        Organisator organisator = OrganisatorManager.GetOrganisatorById(ActivityUI.OrganisatorId);
                        Activity activity = new Activity(int.Parse(IdTextBox.Text), NameTextBox.Text, DiscriptionTextBox.Text,
                                                         PlaceTextBox.Text, int.Parse(DurationTextBox.Text), dateTime,
                                                         int.Parse(AvalibilityTextBox.Text), float.Parse(CostAdultTextBox.Text), float.Parse(CostChildTextBox.Text),
                                                         organisator);
                        ActivityManager.UpdateActivity(activity);

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
