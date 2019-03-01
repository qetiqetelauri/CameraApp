
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace CameraApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
    
        }
        //Scan Barcode
        private async void ScanButton_Clicked(object sender, EventArgs e)
        {
            var scan = new ZXingScannerPage();
            await Navigation.PushAsync(scan);

            //Sleep Off
            DependencyService.Get<ISleepTasks>().ExecuteTask("cannotSleep");

            scan.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    //Show Result
                    mycode.Text = result.Text;

                    //Sleep On
                    DependencyService.Get<ISleepTasks>().ExecuteTask("canSleep");
                });
            };
        }
    }
}
