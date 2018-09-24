using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SearchFolder.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Question2 : Page
    {
        public Question2()
        {
            this.InitializeComponent();
        }

        private async void Search(object sender, RoutedEventArgs e)
        {

            var fold = Windows.Storage.ApplicationData.Current.LocalFolder;
            try
            {
                StorageFile file = await fold.GetFileAsync(fileName.Text);
                string result = await FileIO.ReadTextAsync(file);
                if (file == null)
                {
                    txtBox.Text = "File not found";
                    await this.dialog.ShowAsync();
                }
                else if (file != null && result != content.Text)
                {
                    txtBox.Text = "File found but text not found";
                    await this.dialog.ShowAsync();
                }
                else
                {
                    txtBox.Text = "File found and text found";
                    await this.dialog.ShowAsync();
                }
            }
            catch (Exception)
            {
                txtBox.Text = "File not found";
                await this.dialog.ShowAsync();
            }

        }

        private void Button_OK(object sender, RoutedEventArgs e)
        {
            dialog.Hide();
        }


    }
}
