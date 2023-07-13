using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FactoryManager<T>
{
    private static Dictionary<string, Factory<T>> _factories = new Dictionary<string, Factory<T>>();
    public static event Action AddedFactory;
    public static Factory<T> GetFactory(string name)
    {
        if (_factories.ContainsKey(name))
        {
            return _factories[name];
        }
        else
        {
            return null;
        }
    }
    public static void AddFactory(string name, Factory<T> factory)
    {
        if (!_factories.ContainsKey(name))
        {
            _factories.Add(name, factory);
        }
    }

}
