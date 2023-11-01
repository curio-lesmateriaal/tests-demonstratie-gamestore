using GameStore.Data;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace GameStore
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public Receipt CurrentReceipt { get; set; } = new ();
        
        public MainWindow()
        {
            this.InitializeComponent();

            using var db = new AppDbContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            gamesListView.ItemsSource = db.Games;
        }

        private void RefreshReceiptInfo()
        {
            // By setting it to null first we force the data to change
            receiptListView.ItemsSource = null;
            receiptListView.ItemsSource = CurrentReceipt.GameReceipts;

            var totalPriceWithoutTax = CurrentReceipt.TotalPrice;
            priceWithoutTaxRun.Text = FormatHelper.FormatMoney(totalPriceWithoutTax);
            priceWithTaxRun.Text = FormatHelper.FormatMoney(totalPriceWithoutTax * 1.21m); // 1.21 = +21% tax
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            using var db = new AppDbContext();
            gamesListView.ItemsSource = db.Games.Where(g => g.Name.Contains(searchTextBox.Text));
        }

        private void PrintReceiptButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextOrderButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentReceipt = new();
            RefreshReceiptInfo();
        }

        private void GamesListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedGame = e.ClickedItem as Game;

            CurrentReceipt.AddGame(selectedGame);
            RefreshReceiptInfo();
        }

        private void receiptListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedGameReceipt = e.ClickedItem as GameReceipt;

            CurrentReceipt.RemoveGame(selectedGameReceipt.Game);
            RefreshReceiptInfo();
        }
    }
}
