using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DHM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
          
            InitializeComponent();
            this.DataContext = new ViewModel();
            this.WindowState = WindowState.Maximized;
        }

       

        private void Tile_Click_3(object sender, EventArgs e)
        {
            voice b = new voice();
            b.Show();
        }

        private void Tile_Click_1(object sender, EventArgs e)
        {

            Form1 a = new Form1();
            a.Show();

            
        }

        private void Tile_Click_4(object sender, EventArgs e)
        {
         // login c1= new login();
          //  c1.Show();

            Form3 a = new Form3();
            a.Show();


        }

        private void Tile_Click_2(object sender, EventArgs e)
        {
            Window1 s = new Window1();
            s.Show();
        }
            
        
    }
}
