# Initial thoughts
There's a switch with multiple if statements inside of it, this looks like an ideal candidate for the strategy pattern.

The code where it gets the account data store is repeated and can be shortened (this can be injected via DI in a console or web api project)

# Things to do:
1. Refactor the payment types to the strategy pattern
2. Generate the strategies using a factory pattern
3. Get the account data store from a factory


# Things i would have done:
1. Make the data store type an enum
2. Could refactor the validators to return a result object which contains a reason why it failed eg if account balance is too low
3. Inject the Data store if this was used in a console or web api project.