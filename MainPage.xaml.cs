using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Banking;

namespace BankingXamarin
{
    public partial class MainPage : ContentPage
    {
        Bank fnb;
        Customer myNewCustomer;
        BankAccount _account;

        public MainPage()
        {
            InitializeComponent();
            fnb = new Bank("First National Bank", 4324, "Kenilworth");
            myNewCustomer = new Customer("7766445424", "10 me at home", "Bob", "The Builder");
            fnb.AddCustomer(myNewCustomer);
            _account = myNewCustomer.ApplyForBankAccount();

        }

        private void DepositButton_Clicked(object sender, EventArgs e)
        {
            decimal amount = Decimal.Parse(amountDeposit.Text.ToString());
            string reason = reasonDeposit.Text.ToString();
            _account.DepositMoney(amount, DateTime.Now, reason);
        }

        private void WithdrewButton_Clicked(object sender, EventArgs e)
        {
            decimal amount = Decimal.Parse(amountWithdraw.Text.ToString());
            string reason = reasonWithdraw.Text.ToString();

            _account.WithdrawMoney(amount, DateTime.Now, reason);
        }

        private void HistoryButton_Clicked(object sender, EventArgs e)
        {
            string history = _account.GetTransactionHistory();
            DisplayAlert("Transaction History", history, "OK");
        }

    }
}


