This is a simple set of Web APIs for performing CRUD operations on Loans and allied objects.

Use Postman for testing and the following requests too.


Endpoint:
1. https://localhost:44340/api/leads

{ "LoanAmountRequired":"6786.18", "LeadSource":"DirectSalesAgent", "CommunicationMode":"Email", "CurrentStatus":"InitialCommunication", "Contact":{"id":1,"typeOfContact":"Partner","contactName":"Random Bloke","dob":"02/10/1979","genderOfContact":"Male","email":"bloke@blocked.com","contactNumber":"3283432432"}}


2. https://localhost:44340/api/contacts

{ "TypeOfContact":"Partner", "ContactName":"Friendly Tom", "Dob":"10/12/1998", "GenderOfContact":"Female", "Email":"femme@gmail.com", "ContactNumber":"123212432432" }

3. https://localhost:44340/api/users

{ "UserName":"cliffhanger", "Phone":"32432384", "Email":"gimmail@gmail.com", "Role":"Admin" }

