using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CameraApp.Droid;
[assembly:Xamarin.Forms.Dependency(typeof(SleepTask))]


namespace CameraApp.Droid
{
    public class SleepTask : ISleepTasks
    {
        public static Window MainWindow { get; set; }

        //Choose Sleep Mode
        public void ExecuteTask(string task)
        {
            switch (task)
            {
                case "cannotSleep":
                    MainWindow.AddFlags(WindowManagerFlags.KeepScreenOn);
                    break;

                case "canSleep":
                    MainWindow.ClearFlags(WindowManagerFlags.KeepScreenOn);
                    break;
            }
        }

    }
}