using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Hosting;

namespace ServiceProfiles
{
    internal static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetServiceProfileTypes<TEnvironment>(this Assembly assembly) where TEnvironment : IHostEnvironment 
            => assembly
                .GetTypes()
                .Where(t => !t.IsAbstract && typeof(IServiceProfile<TEnvironment>).IsAssignableFrom(t));
    }
}
