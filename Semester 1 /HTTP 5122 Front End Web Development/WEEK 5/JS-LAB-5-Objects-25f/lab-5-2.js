//#### LAB 5 - FUNCTIONS & OBJECTS ####
//PART 2:  MAKE THE BANK
//1. Create the object structure first.
//2. Add the required properties to your object.
//3. Add your first method and test it. Remember, the methods will change the properties of the object.
//4. Add your second method and test it.
//5. Create the required output to complete steps 6-10 of the lab.
//6. Once everything is working, tackle the Stretch Goal!
var bankAccount = {
    lastName: 'Rinzin',
    branchNumber: 'TD1023',
    accountBalance: 500.25,
    multipleAccounts:true,
    interestRate: 1.03,
    // Methods
    // Deposit methods
    makeDeposit: function (amount) {
         bankAccount.accountBalance = Number((bankAccount.accountBalance + amount).toFixed(2));
        return `Thank you, your current balance is now ${bankAccount.accountBalance}`;
    },
    // Withdrawal Method
    makeWithdrawal: function (amount) {
         bankAccount.accountBalance = Number((bankAccount.accountBalance - amount).toFixed(2));
        return `Thank you, your current balance is now ${bankAccount.accountBalance}`;
    },
    // InterestRate
    addInterest: function () {
        // Interest Rate
        var tmpInterestRate = bankAccount.interestRate;
        if(bankAccount.multipleAccounts){
            tmpInterestRate += .005;
            bankAccount.accountBalance = Number((bankAccount.accountBalance * tmpInterestRate).toFixed(2));
        }else{
            bankAccount.accountBalance = Number((bankAccount.accountBalance * bankAccount.interestRate).toFixed(2));
        }
        return `Thank you, your current balance is now ${bankAccount.accountBalance}`;
    }
}
// Console Starting Account balance
console.log(bankAccount)
// Deposit 200 in Account
console.log("Account Balance after Deposit")
console.log(bankAccount.makeDeposit(200));

console.log(bankAccount)

// Deposit 200 in Account
console.log("Account Balance after withdrawal")
console.log(bankAccount.makeWithdrawal(75));

console.log(bankAccount)
// Interest Rate

console.log("Account Balance after interest Rate")
bankAccount.addInterest();
console.log(bankAccount)
