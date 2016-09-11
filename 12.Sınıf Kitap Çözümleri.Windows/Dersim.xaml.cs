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
    public sealed partial class Dersim : Page
    {
        public static string Dersinadı;
        public Dersim()
        {
            this.Loaded+=Dersim_Loaded;
            this.InitializeComponent();
        }
        string[] arrayyeni = new string[] { };
        string dosyabasi;
        int index;

        async void Dersim_Loaded(object sender,RoutedEventArgs e)
        {
            txtDers.Text = Dersinadı;
            var _Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            _Folder = await _Folder.GetFolderAsync("Assets");
            var _File = await _Folder.GetFileAsync(MainPage.Derslerim);
            txtIcerik.Text = await Windows.Storage.FileIO.ReadTextAsync(_File, Windows.Storage.Streams.UnicodeEncoding.Utf8);


            index = MainPage.Comboboxindex;
           
            if (Dersinadı == "Dil ve Anlatım")
            {
                dosyabasi = "dil ";
                arrayyeni = MainPage.DilAnlatım;

            }
            else if (Dersinadı == "Edebiyat")
            {

                dosyabasi = "edb ";
                arrayyeni = MainPage.Edebiyat;
            }

            comboboxindexcheck();
        }

        private void comboboxindexcheck()
        {

            if (index == 0)
            {
                Btngeri.IsEnabled = false;
                Btngeri.Visibility = Visibility.Collapsed;
            }
            else if (index == (MainPage.Comboboxlenght - 1))
            {
                btnileri.IsEnabled = false;
                btnileri.Visibility = Visibility.Collapsed;
            }
            else
            {
                Btngeri.IsEnabled = true;
                Btngeri.Visibility = Visibility.Visible;
                btnileri.IsEnabled = true;
                btnileri.Visibility = Visibility.Visible;
            }
        }

        private void btnAnaSayf_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }



        private async void Btngeri_Click(object sender, RoutedEventArgs e)
        {
            index = index - 1;
            var _Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            _Folder = await _Folder.GetFolderAsync("Assets");
            var _File = await _Folder.GetFileAsync(dosyabasi + arrayyeni[index] + ".txt");
            txtIcerik.Text = await Windows.Storage.FileIO.ReadTextAsync(_File, Windows.Storage.Streams.UnicodeEncoding.Utf8);


            comboboxindexcheck();
        }

        private async void btnileri_Click(object sender, RoutedEventArgs e)
        {
            index = index + 1;
            var _Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            _Folder = await _Folder.GetFolderAsync("Assets");
            var _File = await _Folder.GetFileAsync(dosyabasi + arrayyeni[index] + ".txt");
            txtIcerik.Text = await Windows.Storage.FileIO.ReadTextAsync(_File, Windows.Storage.Streams.UnicodeEncoding.Utf8);


            comboboxindexcheck();
        }

        
    }
}
