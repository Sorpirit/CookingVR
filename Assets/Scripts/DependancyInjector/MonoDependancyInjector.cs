using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Scripts.DependancyInjector
{
    public abstract class MonoDependancyInjector : MonoBehaviour
    {
        private Dictionary<Type, object> _singlton = new();

        public void Awake()
        {
            InstallBindings();

            var children = GetComponentsInChildren<MonoBehaviour>(true);
            foreach (var child in children)
            {
                Inject(child);
            }
        }

        public abstract void InstallBindings();

        protected void RegisterSingle<T, S>(S service) where S : T
        {
            _singlton[typeof(T)] = service;
        }

        protected T Resolve<T>()
        {
            return (T) Resolve(typeof(T));
        }

        protected object Resolve(Type type)
        {
            return _singlton[type];
        }

        protected void Inject(object obj)
        {
            var type = obj.GetType();

            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic
            | BindingFlags.DeclaredOnly | BindingFlags.Instance).Where(field => field.IsDefined(typeof(InjectAttribute), false));
            foreach (var field in fields)
            {
                field.SetValue(obj, Resolve(field.FieldType));
            }
        }
    }
}
