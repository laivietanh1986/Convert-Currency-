The problem we are solving is to create a naive currency exchange predictor. Given one exchange rate sample
each month over a year for two currencies we want to predict the currency exchange for a future rate using a
simple linear regression model.
To solve this problem the requirement is to create a command-line application which takes two input parameters
for the “from” currency and the “to” currency and outputs a predicted currency exchange rate.
Example usage:
exchangePredict from=USD to=TRY
Example output:
The predicted currency exchange from USD to TRY for 15/1/2017 is 3.263.
