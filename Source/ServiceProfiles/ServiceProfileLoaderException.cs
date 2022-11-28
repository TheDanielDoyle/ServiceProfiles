using System;

namespace ServiceProfiles;

public class ServiceProfileLoaderException : Exception
{
    public ServiceProfileLoaderException(string message) : base (message)
    {
    }

    public ServiceProfileLoaderException(string message, Exception exception) : base(message, exception)
    {
    }
}