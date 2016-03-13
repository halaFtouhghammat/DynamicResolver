namespace DynamicResolver
{
    using DynamicResolver.Interfaces;
    using System;

    /// <summary>
    /// Dynamic resolver AppDomains helper
    /// </summary>
    /// <typeparam name="T">Type to resolve</typeparam>
    public class Resolver<T> : MarshalByRefObject, IDisposable
    {
        private readonly AppDomain domain;

        /// <summary>
        /// Resloved dependency
        /// </summary>
        public T Implementation { get; private set; }

        /// <summary>
        /// Creates resolver
        /// </summary>
        /// <param name="assembly">Assembly name</param>
        public Resolver(string assembly)
        {
            domain = AppDomain.CreateDomain(string.Format("{0}:{1}", assembly, Guid.NewGuid()), null, new AppDomainSetup() { LoaderOptimization = LoaderOptimization.MultiDomain });
            IRoot root = (IRoot)domain.CreateInstanceAndUnwrap(assembly, "Root");
            Implementation = root.Resolve<T>();
        }

        /// <summary>
        /// Unloads created AppDomain
        /// </summary>
        public void Dispose()
        {
            AppDomain.Unload(domain);
        }
    }
}