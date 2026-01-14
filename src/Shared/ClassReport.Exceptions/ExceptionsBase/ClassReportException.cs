using System.Net;

namespace MyRecipeBook.Exceptions.ExceptionsBase;

public abstract class ClassReportException : SystemException
{
    protected ClassReportException(string messages) : base(messages) {}

    public abstract HttpStatusCode GetStatusCode();
    public abstract IList<string> GetErrorMessage();

}
