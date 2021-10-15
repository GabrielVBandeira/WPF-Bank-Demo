using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace WPF_BANK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public Person personName;
        public Person PersonName
        {
            get => personName;
            set
            {
                personName = value;
                RaisePropertyChanged("AxisYFormatter");
            }
        }

        public Wallet currentWallet;
        public Wallet CurrentWallet
        {
            get => currentWallet;
            set
            {
                currentWallet = value;
                RaisePropertyChanged(nameof(CurrentWallet));
            }
        }



        public Wallet currentCredit;
        public Wallet CurrentCredit
        {
            get => currentCredit;
            set
            {
                currentCredit = value;
                RaisePropertyChanged(nameof(CurrentCredit));
            }
        }

        public Wallet currentTotal;
        public Wallet CurrentTotal
        {
            get => currentTotal;
            set
            {
                currentTotal = value;
                RaisePropertyChanged(nameof(CurrentTotal));
            }
        }

        public Wallet currentWithdraw;
        public Wallet CurrentWithdraw
        {
            get => currentWithdraw;
            set
            {
                currentWithdraw = value;
                RaisePropertyChanged("AxisYFormatter");
            }
        }

        private ObservableCollection<Wallet> listWallet = new ObservableCollection<Wallet>();

        public ObservableCollection<Wallet> ListWallet
        {
            get => listWallet;
            set
            {
                listWallet = value;
                RaisePropertyChanged(nameof(ListWallet));
            }
        }

        private ObservableCollection<Wallet> listCredit = new ObservableCollection<Wallet>();

        public ObservableCollection<Wallet> ListCredit
        {
            get => listCredit;
            set
            {
                listCredit = value;
                RaisePropertyChanged(nameof(listCredit));
            }
        }


        public MainWindow()
        {
            personName = new Person()
            {
                Name = "Gabriel"
            };

            CurrentWallet = new Wallet()
            {
                Carteira = 300
            };

            CurrentCredit = new Wallet()
            {
                Credito = 200
            };

            CurrentTotal = new Wallet()
            {
                Total = currentCredit.Credito + currentWallet.Carteira
            };

            currentWithdraw = new Wallet();


            this.DataContext = this;

            InitializeComponent();


        }

        private void RecordTransactions_Click(object sender, RoutedEventArgs e)
        {

            if (CurrentWallet.Carteira >= CurrentWithdraw.Withdraw)
            {
                CurrentWallet = new Wallet()
                {
                    Carteira = CurrentWallet.Carteira - CurrentWithdraw.Withdraw
                };
                ListWallet.Add(CurrentWallet);
                
                CurrentTotal = new Wallet()
                {
                    Total = CurrentCredit.Credito + CurrentWallet.Carteira
                };
            }
            else if (CurrentWallet.Carteira < CurrentWithdraw.Withdraw && CurrentCredit.Credito >= CurrentWithdraw.Withdraw)
            {
                CurrentCredit = new Wallet()
                {
                    Credito = CurrentCredit.Credito - CurrentWithdraw.Withdraw
                };
                ListCredit.Add(CurrentCredit);
                
                CurrentTotal = new Wallet()
                {
                    Total = CurrentCredit.Credito + CurrentWallet.Carteira
                };
            } else if (CurrentWallet.Carteira + CurrentCredit.Credito >= CurrentWithdraw.Withdraw)
            {
                CurrentCredit = new Wallet()
                {
                    Credito = (CurrentCredit.Credito + CurrentWallet.Carteira) - CurrentWithdraw.Withdraw
                };
                ListCredit.Add(CurrentCredit);

                CurrentWallet = new Wallet()
                {
                    Carteira = 0
                };
                ListWallet.Add(CurrentWallet);


                CurrentTotal = new Wallet()
                {
                    Total = CurrentCredit.Credito + CurrentWallet.Carteira
                };
            }


            


            

            
            

        }


        #region Interface INotifyPropertyChanged 
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion




    }

    
}
