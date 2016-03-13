using DynamicResolver.Interfaces;
using System;
using System.Collections.Generic;

/// <summary>
/// Composition root of library
/// </summary>
[Serializable]
public class Root : MarshalByRefObject, IRoot
{
    // Poor man's container can be replaced with any DI Container eg AutoFac or Ninject
    private Dictionary<Type, Type> _bindings = new Dictionary<Type, Type>()
        {
            { typeof(DynamicResolver.Interfaces.ITest), typeof(DynamicResolver.Dll1.Class1) }
        };

    /// <summary>
    /// Resolve dependencies using built-in "Poor man's container"
    /// </summary>
    /// <typeparam name="T">Type to resolve</typeparam>
    /// <returns>Instance of resolved implementation</returns>
    public T Resolve<T>()
    {
        if (_bindings.ContainsKey(typeof(T)))
            return (T)Activator.CreateInstance(_bindings[typeof(T)]);

        throw new InvalidOperationException();
    }
}