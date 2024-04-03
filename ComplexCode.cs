using System;

 

namespace ConsoleApp3 {
    class Program {
        static void Main(string[] args) {
            Console.ReadLine();
            Account acc = new Account(1000);
            acc.Withdraw(1100);
            Console.WriteLine("Account Balance is: "+acc.GetBalance()+
                              " AND Account Status is : " + acc.GetStatus() +
                              " AND Account OD balance now is : "+ acc.currentOverdueAmount);
            Console.ReadLine();
        }
    }

 

    //Account class which represents all the details about the bank account.
    public class Account {
        private AccountStatus currentAccountStatus;

 

        private int currentBalance;
        private readonly int minBalance;
        internal int currentOverdueAmount;

 

        //Create an account with opening balance
        public Account(int openingBalance) {
            currentBalance = openingBalance;
            currentOverdueAmount = 500;
            minBalance = 500;
            currentAccountStatus = AccountStatus.Active;
        }

 

        internal void Withdraw(int amount) {
            if (currentAccountStatus == AccountStatus.Closed) {
                throw new Exception("Cannot Withdraw the amount requested...Account is CLOSED state");
            }
            if (amount > currentBalance + currentOverdueAmount) {
                throw new Exception("Cannot Withdraw the amount requested...");
            }
            if (currentBalance > amount) {
                currentBalance = currentBalance - amount;
            } else { //Take the remaining amount from OD.
                currentOverdueAmount = currentOverdueAmount + (currentBalance - amount);
                currentBalance = 0;
            }
            SetAccountStatus();
        }

 

        internal void Deposit(int amount) {
            if (currentAccountStatus == AccountStatus.Closed) {
                throw new Exception("Cannot Withdraw the amount requested...Account is CLOSED state");
            }
            if (currentOverdueAmount < 500) {
                currentOverdueAmount = currentOverdueAmount + amount;
                currentBalance = currentOverdueAmount - 500;
                currentOverdueAmount = 500;
            } else {
                currentBalance = currentBalance + amount;
            }
            SetAccountStatus();
        }

 

        internal int GetBalance() {
            return currentBalance;
        }

 

        internal AccountStatus GetStatus() {
            return currentAccountStatus;
        }

 

        private void SetAccountStatus() {
            if (currentAccountStatus == AccountStatus.Active) {
                //All the supported states from ACTIVE to ---> CLOSED,SUSPENDED,OVERDUE.
                if (currentBalance < minBalance + currentOverdueAmount) {
                    currentAccountStatus = AccountStatus.Closed;
                } else if (IsOverdue()) {
                    currentAccountStatus = AccountStatus.Overdue;
                } else if (IsSuspended()) {
                    currentAccountStatus = AccountStatus.Suspended;
                }
            } else if (currentAccountStatus== AccountStatus.Suspended) {
                //All the supported states from SUSPENDED to ---> ACTIVE,OVERDUE.
                if (IsActive()) {
                    currentAccountStatus = AccountStatus.Active;
                } else if (IsOverdue()) {
                    currentAccountStatus = AccountStatus.Overdue;
                }
            } else if (currentAccountStatus == AccountStatus.Overdue) {
                //All the supported states from OVERDUE to ---> SUSPENDED,ACTIVE.
                if (IsActive()) {
                    currentAccountStatus = AccountStatus.Active;
                } else if (IsSuspended()) {
                    currentAccountStatus = AccountStatus.Suspended;
                }
            }
        }

 

        private bool IsActive() {
            bool isActive = currentBalance > minBalance;
            return isActive;
        }

 

        private bool IsSuspended() {
            bool isSuspended = currentOverdueAmount == 0;
            return isSuspended;
        }

 

        private bool IsOverdue() {
            bool isSuspended = currentOverdueAmount < 500;
            return isSuspended;
        }

 

        //States the status of the account.
        internal enum AccountStatus {
            Active,
            Closed,
            Suspended,
            Overdue
        }
    }
