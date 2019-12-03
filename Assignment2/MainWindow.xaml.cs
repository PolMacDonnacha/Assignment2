using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ObservableCollection<Activity> ActivityList;
        ObservableCollection<Activity> SelectedList = new ObservableCollection<Activity>();
        ObservableCollection<Activity> FilteredList = new ObservableCollection<Activity>();

        decimal totalCost = 0;

        public MainWindow()
        {
            InitializeComponent();


            Activity Kayaking = new Activity("Kayaking", Activity.ActivityType.Water, new DateTime(1922, 2, 2), 45, "Half day lakeland kayak with island picnic.");
            Activity Parachuting = new Activity("Parachuting", Activity.ActivityType.Air, new DateTime(1978, 2, 28), 279, "Experience the thrill of free fall while you tandem jump from an airplane.");
            Activity MountainBiking = new Activity("Mountain Biking", Activity.ActivityType.Land, new DateTime(2011, 10, 24), 627,"Instructor led half day mountain biking.  All equipment provided.");
            Activity HangGliding = new Activity("Hang Gliding", Activity.ActivityType.Air, new DateTime(1937, 9, 21), 310, "Soar on hot air currents and enjoy spectacular views of the coastal region.");
            Activity Abseiling = new Activity("Abseiling", Activity.ActivityType.Land, new DateTime(1916, 12, 29), 299, "Experience the rush of adrenaline as you descend cliff faces from 10-500m.");
            Activity Sailing = new Activity("Sailing", Activity.ActivityType.Water, new DateTime(1916, 12, 29), 299, "Full day lakeland sailing with island picnic.");
            ActivityList = new ObservableCollection<Activity>();
            ActivityList.Add(Kayaking);
            ActivityList.Add(Parachuting);
            ActivityList.Add(MountainBiking);
            ActivityList.Add(HangGliding);
            ActivityList.Add(Abseiling);
            ActivityList.Add(Sailing);
            
            lstbxActivities.ItemsSource = ActivityList;
            lstbxSelected.ItemsSource = SelectedList;
            txtblk_cost.Text = "0";

            lstbxActivities.ItemsSource = ActivityList.OrderBy(act => act.ActivityDate);
        }

        private void RadioAll_Click(object sender, RoutedEventArgs e)
        {
            FilteredList.Clear();
            Activity.ActivityType Al = 0;
            foreach (var item in ActivityList)
            {
                Al = item._ActivityType;
                if (Al == Activity.ActivityType.All)
                {
                    FilteredList.Add(item);
                }
                lstbxActivities.ItemsSource = ActivityList;
            }
        }

        private void RadioLand_Click(object sender, RoutedEventArgs e)
        {
            FilteredList.Clear();
            Activity.ActivityType L = 0;
            foreach (var item in ActivityList)
            {
                L = item._ActivityType;
                if (L == Activity.ActivityType.Land)
                {
                    FilteredList.Add(item);
                }
                lstbxActivities.ItemsSource = FilteredList;
            }
        }

        private void RadioWater_Click(object sender, RoutedEventArgs e)
        {
            FilteredList.Clear();
            Activity.ActivityType W = 0;
            foreach (var item in ActivityList)
            {
                W = item._ActivityType;
                if (W == Activity.ActivityType.Water)
                {
                    FilteredList.Add(item);
                }
                lstbxActivities.ItemsSource = FilteredList;
            }
        }

       private void RadioAir_Click(object sender, RoutedEventArgs e)
        {
            FilteredList.Clear();
            Activity.ActivityType A = 0;
           foreach (var item in ActivityList)
            {
                A = item._ActivityType;
                if(A  == Activity.ActivityType.Air )
                {
                    FilteredList.Add(item);
                }
                lstbxActivities.ItemsSource = FilteredList;
            }
       }

        private void BtnUnselectActivity_Click(object sender, RoutedEventArgs e)
        {
            Activity selected = lstbxSelected.SelectedItem as Activity;
            if (selected != null)
            {
                ActivityList.Add(selected);
                SelectedList.Remove(selected);

                lstbxActivities.ItemsSource = null;
                lstbxActivities.ItemsSource = ActivityList; 
                
                if(RadioAll.IsChecked == true)
                {
                    lstbxActivities.ItemsSource = ActivityList;
                }
                else if(RadioLand.IsChecked == true)
                {
                    FilteredList.Clear();
                    Activity.ActivityType L = 0;
                    foreach (var item in ActivityList)
                    {
                        L = item._ActivityType;
                        if (L == Activity.ActivityType.Land)
                        {
                            FilteredList.Add(item);
                        }
                        lstbxActivities.ItemsSource = FilteredList;
                    }
                }
                else if (RadioWater.IsChecked == true)
                {
                    FilteredList.Clear();
                    Activity.ActivityType W = 0;
                    foreach (var item in ActivityList)
                    {
                        W = item._ActivityType;
                        if (W == Activity.ActivityType.Water)
                        {
                            FilteredList.Add(item);
                        }
                        lstbxActivities.ItemsSource = FilteredList;
                    }
                }

                else if (RadioAir.IsChecked == true)
                {
                    FilteredList.Clear();
                    Activity.ActivityType A = 0;
                    foreach (var item in ActivityList)
                    {
                        A = item._ActivityType;
                        if (A == Activity.ActivityType.Air)
                        {
                            FilteredList.Add(item);
                        }
                        lstbxActivities.ItemsSource = FilteredList;
                    }
                }
                lstbxSelected.ItemsSource = SelectedList.OrderBy(act => act.ActivityDate);
                if (lstbxActivities.ItemsSource == FilteredList)
                {
                    lstbxActivities.ItemsSource = FilteredList.OrderBy(act => act.ActivityDate);
                }
                else if (lstbxActivities.ItemsSource == ActivityList)
                {
                    lstbxActivities.ItemsSource = ActivityList.OrderBy(act => act.ActivityDate);
                }
                totalCost = 0;
                foreach (var item in SelectedList)
                {
                    decimal C = item.Cost;
                    totalCost += C;
                }

                txtblk_cost.Text = totalCost.ToString("C");
            }
        }
        public void ButtonSelectActivity_Click(object sender, RoutedEventArgs e)
        {
            //determine what is selected
            Activity selected = lstbxActivities.SelectedItem as Activity;

            //null check - make sure something selected
            if (selected != null)
            {

                bool conflict = false;

                //loop

                foreach (Activity activity in SelectedList)
                {
                    if (activity.ActivityDate == selected.ActivityDate)
                    {
                        conflict = true;
                        MessageBox.Show("You have already selected an activity for that day.");
                    }
                }


                if(conflict == false)
                {
                     ActivityList.Remove(selected);
                     SelectedList.Add(selected);

                     lstbxActivities.ItemsSource = null;
                     lstbxActivities.ItemsSource = ActivityList;
                }

                if (RadioAll.IsChecked == true)
                {
                    lstbxActivities.ItemsSource = ActivityList;
                }
                else if (RadioLand.IsChecked == true)
                {
                    FilteredList.Clear();
                    Activity.ActivityType L = 0;
                    foreach (var item in ActivityList)
                    {
                        L = item._ActivityType;
                        if (L == Activity.ActivityType.Land)
                        {
                            FilteredList.Add(item);
                        }
                        lstbxActivities.ItemsSource = FilteredList;
                    }
                }
                else if (RadioWater.IsChecked == true)
                {
                    FilteredList.Clear();
                    Activity.ActivityType W = 0;
                    foreach (var item in ActivityList)
                    {
                        W = item._ActivityType;
                        if (W == Activity.ActivityType.Water)
                        {
                            FilteredList.Add(item);
                        }
                        lstbxActivities.ItemsSource = FilteredList;
                    }
                }

                else if (RadioAir.IsChecked == true)
                {
                    FilteredList.Clear();
                    Activity.ActivityType A = 0;
                    foreach (var item in ActivityList)
                    {
                        A = item._ActivityType;
                        if (A == Activity.ActivityType.Air)
                        {
                            FilteredList.Add(item);
                        }
                        lstbxActivities.ItemsSource = FilteredList;
                    }
                }
                lstbxSelected.ItemsSource = SelectedList.OrderBy(act => act.ActivityDate);

                foreach (var item in SelectedList)
                {
                    decimal C = item.Cost;
                    totalCost += C;
                }

                txtblk_cost.Text = totalCost.ToString("C");

                if (lstbxActivities.ItemsSource == FilteredList)
                {
                    lstbxActivities.ItemsSource = FilteredList.OrderBy(act => act.ActivityDate);
                }
                else if (lstbxActivities.ItemsSource == ActivityList)
                {
                    lstbxActivities.ItemsSource = ActivityList.OrderBy(act => act.ActivityDate);
                }

            }
            else
            {
                MessageBox.Show("Please select an activity.");
            }

        }
        private void lstbxActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Activity selected = lstbxActivities.SelectedItem as Activity;

            //null check - make sure something selected
            if (selected != null)
            {
                tbxdescription.Text = selected.Description;
            }
        }
    }
}
