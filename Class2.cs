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
    public class Wallet
    {

        private int walletValue;
        private int walletSaving;
        private int walletTotal;
        private int walletWithdraw;

        public int Carteira
        {
            get { return walletValue; }
            set { walletValue = value; }
        }

        public int Credito
        {
            get { return walletSaving; }
            set { walletSaving = value; }
        }

        public int Total
        {
            get { return walletTotal; }
            set { walletTotal = value; }
        }

        public int Withdraw
        {
            get { return walletWithdraw; }
            set { walletWithdraw = value; }
        }

    }

    
}
