using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Controls;

namespace KanjiKingInterface.Pages.MainMenu
{
    public partial class MainMenuView : Page
    {
        public MainMenuView()
        {
            InitializeComponent();
            this.Loaded += MainMenuView_Loaded; 
        }

        private void MainMenuView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            // Initialize the DataContext with an active NavigationService
            if (this.NavigationService != null)
            {
                DataContext = new MainMenuViewModel(this.NavigationService);
            }
            else
            {
                // Handle the case where NavigationService might still be null (rare)
                throw new InvalidOperationException("Navigation service is not initialized properly.");
            }
        }
    }
}


