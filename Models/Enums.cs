namespace LoanWAPIs.Models
{
    public enum Role
    {
        Admin,
        Staff
    }

    public enum RepositoryResultTypes
    {
        BadRequest,
        NotFound,
        Error,
        NoContent
    }

    public enum CommunicationModes
    {
        Email,
        Phone
    }

    public enum LeadStatus
    {
        InitialCommunication,
        FollowUp,
        NotInterested,
        ConvertedToCustomer
    }

    public enum LeadSource
    {
        Emailer,
        DirectSalesAgent,
        NewsPaper,
        Marketing
    }


    //Assumption
    public enum ContactType
    {
        Customer,
        Vendor,
        Partner,
        Other
    }

    public enum Gender
    {
        Male,
        Female
    }
}
