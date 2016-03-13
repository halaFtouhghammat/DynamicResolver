using DynamicResolver.Interfaces;
using System;

namespace DynamicResolver
{
    internal class DynamicDllTester
    {
        private Func<Resolver<ITest>> _dynamicDll1Factory;

        public DynamicDllTester(Func<Resolver<ITest>> dynamicDll1Factory)
        {
            _dynamicDll1Factory = dynamicDll1Factory;
        }

        public void Run()
        {
            using (var dynamicDll = _dynamicDll1Factory())
            {
                dynamicDll.Implementation.Test();
            }
        }
    }
}