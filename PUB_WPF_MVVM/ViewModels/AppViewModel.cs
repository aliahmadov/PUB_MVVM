using DevExpress.Utils.CommonDialogs.Internal;
using GalaSoft.MvvmLight.Views;
using PUB_WPF_MVVM.Commands;
using PUB_WPF_MVVM.Helpers;
using PUB_WPF_MVVM.Models;
using PUB_WPF_MVVM.Repositories;
using PUB_WPF_MVVM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PUB_WPF_MVVM.ViewModels
{
    public class AppViewModel : BaseViewModel
    {
        public ComboBox ComboBox { get; set; }

        private double price;

        public List<BeerPurchase> BeerPurchases { get; set; } = new List<BeerPurchase>();
        public double TotalPrice
        {
            get { return price; }
            set { price = value; OnPropertyChanged(); }
        }


        private int orderCount;

        public int OrderCount
        {
            get { return orderCount; }
            set { orderCount = value; OnPropertyChanged(); }
        }

        public FakeBeerRepo BeersRepo { get; set; }

        public Label Label { get; set; }
        public ObservableCollection<Beer> Beers { get; set; }

        public RelayCommand SelectedCommand { get; set; }

        public RelayCommand MinusCommand { get; set; }
        public RelayCommand PlusCommand { get; set; }
        public RelayCommand BuyCommand { get; set; }

        public RelayCommand ShowCommand { get; set; }

        public RelayCommand ResetCommand { get; set; }

        private Beer beer;

        public Beer Beer
        {
            get { return beer; }
            set { beer = value; OnPropertyChanged(); }
        }


        public AppViewModel()
        {
            BeersRepo = new FakeBeerRepo();
            Beers = BeersRepo.GetAll();
            SelectedCommand = new RelayCommand(c =>
            {
                var beer = c as Beer;
                Beer = beer;
                Label.Visibility = System.Windows.Visibility.Hidden;
                TotalPrice = OrderCount * Beer.Price;

            });


            PlusCommand = new RelayCommand(c =>
           {
               OrderCount++;
               TotalPrice = OrderCount * Beer.Price;
           }, (d) =>
           {
               if (Beer == null) return false;
               return true;
           });

            MinusCommand = new RelayCommand(c =>
            {

                if (OrderCount > 0)
                {
                    OrderCount--;
                    TotalPrice = OrderCount * Beer.Price;
                }

            }, (d) =>
            {
                if (Beer == null) return false;
                return true;
            });

            BuyCommand = new RelayCommand(c =>
            {
                if (OrderCount != 0)
                {

                    if (MessageBox.Show("Are you sure you want to buy?", "Question", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                    {
                        if (MessageBox.Show($@"Success : {OrderCount} {Beer.Name} bought
Total Price: {TotalPrice} $
Date:{DateTime.Now}", "Purchase Details", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                        {
                            PDFWriter.GenerateBeerPDF(Beer, TotalPrice, OrderCount);
                            BeerPurchases.Add(new BeerPurchase()
                            {
                                BeerName = Beer.Name,
                                BeerPath = Beer.ImagePath,
                                BeerVolume=Beer.Volume,
                                Date = DateTime.Now,
                                OrderCount = $"Count : {OrderCount}",
                                total_price = TotalPrice.ToString()+"$"
                            });
                            TotalPrice = 0;
                            Beer = null;
                            OrderCount = 0;
                        }
                    }
                }
                else MessageBox.Show("Enter Order Count !!!", "Caution", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }, (d) =>
            {
                if (Beer == null) return false;
                return true;
            });

            ShowCommand = new RelayCommand(c =>
            {
                DisplayViewModel dVM = new DisplayViewModel();
                dVM.PurchaseDetails = BeerPurchases;
                DisplayWindow dP = new DisplayWindow();
                dP.DataContext = dVM;

                dP.Show();

            });


            ResetCommand = new RelayCommand(c =>
            {
                ComboBox.SelectedItem = null;
                Label.Visibility = Visibility.Visible;
                TotalPrice = 0;
                OrderCount = 0;

            });

        }


    }
}
