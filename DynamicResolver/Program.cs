using Autofac;
using DynamicResolver.Interfaces;
using System;

namespace DynamicResolver
{
    internal class Program
    {
        [LoaderOptimization(LoaderOptimization.MultiDomainHost)]
        private static void Main(string[] args)
        {
            // Autofac config
            ContainerBuilder _builder = new ContainerBuilder();
            _builder.Register<Func<Resolver<ITest>>>((c) => () => { return new Resolver<ITest>("DynamicResolver.Dll1"); });
            _builder.RegisterType<DynamicDllTester>();
            var _container = _builder.Build();

            var tester = _container.Resolve<DynamicDllTester>();
            tester.Run();
        }
    }
}