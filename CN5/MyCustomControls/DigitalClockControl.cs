using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Threading;

namespace MyCustomControls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:MyCustomControls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:MyCustomControls;assembly=MyCustomControls"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    public class DigitalClockControl : Control
    {

        public static readonly DependencyProperty TimeProperty = DependencyProperty.Register("Time",typeof(String),typeof(DigitalClockControl));

        public String Time
        {
            get { return (String)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value);}
        }

        private Timer timer;
        static DigitalClockControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DigitalClockControl), new FrameworkPropertyMetadata(typeof(DigitalClockControl)));
           
        }

        public DigitalClockControl()
        {
            timer = new Timer();
            timer.Elapsed += Timer_Elapsed; 
            timer.Start();
            this.timer.Interval = 1000;
            this.DataContext = this;
            
        }

        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(DispatcherPriority.Normal, () =>
            {
                Time = DateTime.Now.ToLongTimeString();
            });
        }
    }
}
