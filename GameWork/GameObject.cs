using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using GameWork.Modules;
using static GameWork.Log;

namespace GameWork
{
    public class GameObject
    {
        private readonly Dictionary<string, IModule> _modules;

        public Transform Transform { get; }

        public GameObject(params IModule[] modules)
        {
            _modules = new Dictionary<string, IModule>();
            foreach (IModule module in modules)
            {
                AddModule(module);
            }

            Transform = GetOrAddModule(new Transform());
        }

        public T GetModule<T>() where T : IModule
        {
            return _modules.TryGetValue(typeof(T).FullName, out IModule module) ? (T) module : default;
        }

        public bool HasModule<T>() where T : IModule
        {
            return _modules.ContainsKey(typeof(T).FullName);
        }

        public bool AddModule<T>(T module) where T : IModule
        {
            string typeName = module.GetType().FullName;
            if (_modules.TryAdd(typeName, module))
            {
                Logger.TraceEvent(TraceEventType.Information, 1, $"{typeName} added to {{{GetHashCode()}}}");
                return true;
            }

            return false;
        }

        public bool AddModule(IModule module)
        {
            return AddModule<IModule>(module);
        }

        public T GetOrAddModule<T>(T newModule) where T : IModule
        {
            string typeName = typeof(T).FullName;

            if (_modules.TryAdd(typeName, newModule))
            {
                Logger.TraceEvent(TraceEventType.Information, 1, $"{typeName} added to {{{GetHashCode()}}}");
                return newModule;
            }

            return (T) _modules[typeName];
        }

        public IModule GetOrAddModule(IModule newModule)
        {
            return GetOrAddModule<IModule>(newModule);
        }
    }
}
