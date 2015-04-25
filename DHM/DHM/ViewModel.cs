using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace DHM
{
    class ViewModel
    {
    private ObservableCollection<FrameworkElement> _List;
        public ObservableCollection<FrameworkElement> List
        {
            get
            {
                _List = new ObservableCollection<FrameworkElement>();
                for (int i = 1; i < 3; i++)
                {
                    _List.Add(new Image() { Source = new BitmapImage(new Uri("pack://application:,,,/Images/image" + i + ".png")) });
                }
                return _List;
            }
        }

       
        public ObservableCollection<FrameworkElement> List1
        {
            get
            {
                _List = new ObservableCollection<FrameworkElement>();
                for (int j = 3; j < 5; j++)
                {
                    _List.Add(new Image() { Source = new BitmapImage(new Uri("pack://application:,,,/Images/image" + j + ".png")) });
                }
                return _List;
            }
        
        }
        public ObservableCollection<FrameworkElement> List2
        {
            get
            {
                _List = new ObservableCollection<FrameworkElement>();
                for (int j = 5; j < 7; j++)
                {
                    _List.Add(new Image() { Source = new BitmapImage(new Uri("pack://application:,,,/Images/image" + j + ".png")) });
                }
                return _List;
            }

        }

        public ObservableCollection<FrameworkElement> List3
        {
            get
            {
                _List = new ObservableCollection<FrameworkElement>();
                for (int j = 8; j < 10; j++)
                {
                    _List.Add(new Image() { Source = new BitmapImage(new Uri("pack://application:,,,/Images/" + j + ".png")) });
                }
                return _List;
            }

        }

    }
}
