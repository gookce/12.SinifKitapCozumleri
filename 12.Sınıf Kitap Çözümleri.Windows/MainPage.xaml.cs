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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace _12.Sınıf_Kitap_Çözümleri
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            btngit.Visibility = Visibility.Collapsed;
            Combobox.IsEnabled = false;
        }
        public static string Derslerim;
        public static int Comboboxindex;
        public static int Comboboxlenght;
        public static string[] Edebiyat = { "10-11", "17-18", "21-23", "25-29", "31-34", "37-39", "41-48", "57-62", "76-79", "80-86", "109-113", "116-119", "122-128", "130-138", "139-150", "155-159", "163-171", "175-185", "192-221" };
        public static string[] DilAnlatım = { "10-18", "21-29", "40-54","68-73", "78-93", "103-113", "115-133", "141-156", "165-172", "178-223" };
        public static string dersinuzantısı;
        private void btnEdb_Click(object sender, RoutedEventArgs e)
        {
            Dersim.Dersinadı = "Edebiyat";
            dersinuzantısı="edb";
            Combobox.Items.Clear();

            for(int i=0;i<19;i++)
            {
                Combobox.Items.Add(Edebiyat[i]);
            }
            Combobox.IsEnabled = true;
            
            this.btnEdb.Background = new SolidColorBrush(Windows.UI.Colors.Black);
            this.btnEdb.Background.Opacity = 0.2;
            this.btnDil.Background.Opacity = 0;
        }
        private void btnDil_Click(object sender, RoutedEventArgs e)
        {
            Dersim.Dersinadı = "Dil ve Anlatım";
            dersinuzantısı= "dil";
            Combobox.Items.Clear();
            

            for(int i=0;i<10;i++)
            {
                Combobox.Items.Add(DilAnlatım[i]);
            }
            Combobox.IsEnabled = true;
            
            this.btnDil.Background = new SolidColorBrush(Windows.UI.Colors.Black);
            this.btnDil.Background.Opacity = 0.2;
            this.btnEdb.Background.Opacity = 0;
        }
        private void Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Combobox.SelectedIndex>=0)
            {
                btngit.Visibility = Visibility.Visible;
                btngit.IsEnabled = true;
            }
            else
            {
                btngit.Visibility = Visibility.Collapsed;
                btngit.IsEnabled = false;
            }
        }
        private void btngit_Click(object sender, RoutedEventArgs e)
        {
          Derslerim=dersinuzantısı+" "+Combobox.SelectedItem.ToString()+".txt";
          Comboboxindex = Combobox.SelectedIndex;
          Comboboxlenght = Combobox.Items.Count;
           
          Frame.Navigate(typeof(Dersim));
          btngit.IsEnabled=false;
          Combobox.IsEnabled=false;
          btngit.Visibility=Visibility.Collapsed;
          btnDil.Background.Opacity=0;
          btnEdb.Background.Opacity=0;
        }
        public Brush Brushes { get; set; }
    }
}
