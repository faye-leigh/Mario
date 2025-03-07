using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Mario.ECS
{
    public class Entity
    {
        private readonly Dictionary<Type, object> components = new();

        public void AddComponent<T>(T component)
        {
            components[typeof(T)] = component;
        }

        public T GetComponent<T>()
        {
            return (T)components[typeof(T)];
        }

        public bool HasComponent<T>()
        {
            return components.ContainsKey(typeof(T));
        }
    }
}