using System;

namespace DemoExceptions.ConApp;

public class MyException : ApplicationException
{
    public int ErrorCode { get; private set; }

    public MyException(int errorCode)
    {
        ErrorCode = errorCode;
    }
    public MyException(int errorCode, string message)
     : base(message)
    {
        ErrorCode = errorCode;
    }
}
