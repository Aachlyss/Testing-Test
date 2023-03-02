using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem
{
    public class BankAccount
    {
        public BankAccount(int id, decimal balance =0)
        {
            this.Id = id;
            this.Balance = balance;
        }

        public int Id { get; set; }
        public decimal Balance { get; set; }

        public void Deposit(decimal amount)
        {
            if (amount <=0)
            {
                throw new InvalidOperationException("Negative Amount");
            }
            this.Balance += amount;
        }
        public void Credit(decimal cash)
        {
            if (cash <= 0)
            {
                throw new InvalidOperationException("Credit Cannot Be Negative Amount");
            }
            this.Balance -= cash;
        }
        public void IncreasePercent(decimal percent)
        {         
                this.Balance += (this.Balance / percent) * 100; 
        }

        public void Bonus()
        {
            if (this.Balance>=1000&&this.Balance<=2000)
            {
                this.Balance += 100;
            }
            if (this.Balance >= 2000 && this.Balance <= 3000)
            {
                this.Balance += 200;
            }
            if (this.Balance >= 3000)
            {
                this.Balance += 300;
            }
            /*
            else
            {
                throw new Exception("Number Cannot Be Negative");
            }
            */
        }

        public void PaymentForCredit(decimal payment)
        {
            if (payment <=0)
            {
                throw new InvalidOperationException("Payment Cannot Be Zero Or Negative");
            }
            if (this.Balance<payment)
            {
                throw new InvalidOperationException("Not Enough Money");
            }
            this.Balance -= payment;
        }
    }
}
