# Code

The backend is encompassed by 3 microservices:

* [Customers](Customers): Stores customer data, currently only the customer name and a related id.
* [Prizes](Prizes): Prizes information. This will hold the list of prizes per customer. The id of the customer should be validated by the code itself not the database.
* [AppManager](App-Manager): Manages app state. Initially it will add records for prizes and customers.

# Database

Files can be found in the [SQL](sql) folder. They have some data on it, for mocking purposes.