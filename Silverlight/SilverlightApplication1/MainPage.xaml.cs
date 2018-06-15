using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Browser;

namespace SilverlightApplication1
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void textBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.textBlock.Text = "你好！";
            //ChildWindow1
            //HtmlWindow html = HtmlPage.Window;
            //html.Navigate(new Uri("/Default.aspx", UriKind.Relative));
            //this.RootVisual = new ChildWindow1();
            SilverlightApplication1.App.Current.RootVisual= new ChildWindow1();
        }
    }
}
