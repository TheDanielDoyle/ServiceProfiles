using System.Reflection;

namespace ServiceProfiles
{
    public abstract class DefaultServiceProfile
    {
        protected Assembly ThisAssembly => GetType().Assembly;
    }
}