using RoutesInfoLibrary.Models;
using RoutesInfoLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VariativePart.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            CBTransport.ItemsSource = DBService.Instance.GetModelData<Transport>();
            Refresh();
        }

        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void CBTrasport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            {
                var filtred = DBService.Instance.GetModelData<Route>();
                var searchText = TBSearch.Text;
                var selectedTransport = CBTransport.SelectedItem as Transport;
                if (string.IsNullOrWhiteSpace(searchText) == false)
                {
                    filtred = filtred.Where(x => x.Stops.Any(s => s.Name.Contains(searchText))).ToList();
                }
                if (selectedTransport != null)
                {
                    filtred = filtred.Where(x => x.TransportId == selectedTransport.Id).ToList(); 
                    
                }
                LVRoutes.ItemsSource = filtred;
            }

        }
        private void LVRoutes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRoute = LVRoutes.SelectedItem as Route;
            if (selectedRoute != null)
            {
                NavigationService.Navigate(new RoutePage(selectedRoute));
            }
        }
    }
}
