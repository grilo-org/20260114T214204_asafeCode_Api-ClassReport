using System.Net;

namespace MyRecipeBook.Exceptions.ExceptionsBase;

public class ExternalServiceException : ClassReportException
{
    public ExternalServiceException(string messages) : base(messages) {}

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.Unauthorized;


    public override IList<string> GetErrorMessage() => [Message];

}