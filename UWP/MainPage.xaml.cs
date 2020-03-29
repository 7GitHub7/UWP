using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static UWP.DataStore;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.Storage;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.ViewModel = new DataStoreViewModel();

        }

        public DataStoreViewModel ViewModel { get; set; }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }

    public class DataStore : INotifyPropertyChanged
    {
       /* Windows.Storage.ApplicationDataCompositeValue composite = new Windows.Storage.ApplicationDataCompositeValue();
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;*/

        private string lifeHistory;

        public string LifeHistory
        {
            get { return "LifeHistory: " + this.lifeHistory; }
            set
            {
                if (value.CompareTo("lunched") == 0)
                {
                    this.lifeHistory += "1";
                }
                if (value.CompareTo("restored") == 0)
                {
                    this.lifeHistory += "2";
                }
                if (value.CompareTo("suspended") == 0)
                {
                    this.lifeHistory += "3";
                }
                if (value.CompareTo("resumed") == 0)
                {
                    this.lifeHistory += "4";
                }
                StoreLocalSettings();
                this.OnPropertyChanged();


            }
        }


        public DataStore()
        {

            fname = "UWP";
            lname = "User";
            lifeHistory = "";

            localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            composite = (Windows.Storage.ApplicationDataCompositeValue)localSettings.Values["DataBindingViewModel"];

            if (composite == null)
            {
                composite = new Windows.Storage.ApplicationDataCompositeValue();
                StoreLocalSettings();
            }
            else
            {
                fname = (String)composite["fname"];
                lname = (String)composite["lname"];
                lifeHistory = (String)composite["lifeHistory"];
            }

        }

        public void StoreLocalSettings() {

            composite["fname"] = fname;
            composite["lname"] = lname;
            composite["lifeHistory"] = lifeHistory;
            localSettings.Values["DataBindingViewModel"] = composite;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string fname;
        public string Summary
        {
            get { return $"Witaj, {this.FName}  {this.LName}"; }
            set { this.OnPropertyChanged(); }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // Raise the PropertyChanged event, passing the name of the property whose value has changed.
            //
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public string FName
        {
            get { return this.fname; }
            set
            {
                this.fname = value;
                Summary = "";
                StoreLocalSettings();
            }
        }
        private string lname;
        private ApplicationDataContainer localSettings;
        private ApplicationDataCompositeValue composite;

        public string LName
        {
            get { return this.lname; }

            set
            {
                this.lname = value;
                Summary = "";
                StoreLocalSettings();

            }

        }
        public class DataStoreViewModel
        {        

            private DataStore defaultDataStore = new DataStore();
            public DataStore DefaultDataStore { get { return this.defaultDataStore; } }
        }
    }
}

