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
}

namespace UWP
{
    public class DataStore : INotifyPropertyChanged
    {
      

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string fname ;
        public string Summary {
            get{ return $"Witaj, {this.FName}  {this.LName}"; }
            set{ this.OnPropertyChanged(); }
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
            }
        }
        private string lname;

        

        public string LName
        {
            get { return this.lname; }

            set
            {
                this.lname = value;
                Summary = "";

            }

        }
        public class DataStoreViewModel
        {
            private DataStore defaultDataStore = new DataStore();
            public DataStore DefaultDataStore { get { return this.defaultDataStore; } }
        }
    }
}

