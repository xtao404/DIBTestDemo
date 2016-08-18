using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace WpfApplication1
{
    public class PageChangedEventArgs : RoutedEventArgs
    {
        public int CurrentPageIndex { get; set; }
    }
}
