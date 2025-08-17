namespace SmartPoultry.Shared
{
    public class ApplicationContants
    {
        public static class ResponseMessages
        {
            // Success Messages
            public const string RecordsFetchedSuccessfully = "Records fetched successfully.";
            public const string RecordUpdatedSuccessfully = "Record updated successfully.";
            public const string RecordAddedSuccessfully = "Record added successfully.";

            // Failure Messages
            public const string InvalidData = "Invalid data provided.";
            public const string OperationFailed = "Operation failed. Please try again later.";
            public const string RecordNotFound = "The requested record was not found.";
            public const string UnauthorizedAccess = "You do not have permission to perform this operation.";

            // General Messages
            public const string InvalidRequest = "The request is invalid.";
            public const string InternalServerError = "An internal server error occurred.";
            public const string ValidationError = "There was a validation error.";
            public const string InValidQuantity = "The item does not have provided quantity.";

            // Error handling messages
            public const string DatabaseError = "An error occurred while interacting with the database.";
        }
    }
}
