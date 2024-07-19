
using System;
using System.Collections.Generic;

public abstract class ServiceLocator<T>
{
    protected Dictionary<Type, T> ServicesDictionary;

    protected ServiceLocator()
    {
        ServicesDictionary = new Dictionary<Type, T>();
    }

    public void RegisterService(T service)
    {
        Type serviceType = service.GetType();

        if (!ServicesDictionary.ContainsKey(serviceType))
        {
            ServicesDictionary.Add(serviceType, service);
        }
    }
    public T Get(Type serviceType)
    {
        return ServicesDictionary.ContainsKey(serviceType) ?
            ServicesDictionary[serviceType] :
            default;
    }
}

