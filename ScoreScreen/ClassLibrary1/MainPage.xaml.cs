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
using Windows.Storage;
using Windows.UI.Popups;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ScoreScreen
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ScorePage : Page
    {
        public ScorePage()
        {
            this.InitializeComponent();
        }

      
        

        private void Close()
        {
            Application.Current.Exit();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string fileName = txtFileName.Text;
            string text = txtContent.Text;
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile file = await localFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, text);
            MessageDialog md = new MessageDialog("File saved" + fileName);
            await md.ShowAsync();
        }

        private async void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            string fileName = txtFileName.Text;
            StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            try
            {
                StorageFile file = await localFolder.GetFileAsync(fileName);
                String text = await FileIO.ReadTextAsync(file);
                txtContent.Text = text;
            }
            catch (Exception)
            {
                MessageDialog md = new MessageDialog("File doesn't exist:  " + fileName);
                await md.ShowAsync();
            }
        }
    }
}
