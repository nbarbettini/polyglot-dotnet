// <copyright file="CustomAssemblyLoader.cs" company="Nate Barbettini">
// Copyright (c) Nate Barbettini. Licensed under MIT.
// </copyright>

using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.Extensions.PlatformAbstractions;

namespace Polyglot.Tests
{
    public static class CustomAssemblyLoader
    {
        public static Assembly Load(string fileName, string assemblyName)
        {
            var context = new SingleTestLoadContext(fileName);
            var assembly = context.LoadFromAssemblyName(new AssemblyName(assemblyName));

            return assembly;
        }

        private class SingleTestLoadContext : AssemblyLoadContext
        {
            private readonly string fileName;

            public SingleTestLoadContext(string fileName)
            {
                this.fileName = fileName;
            }

            protected override Assembly Load(AssemblyName assemblyName)
            {
                string assemblyPath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "..\\SampleTestAssemblies", fileName);
                return LoadFromAssemblyPath(assemblyPath);
            }
        }
    }
}
