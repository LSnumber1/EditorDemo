using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace EditorFramework
{
    public static class TypeEx
    {
        public static IEnumerable<Type> GetSubTypesInAssemblies(this Type self)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => assembly.FullName.StartsWith("Assembly")) 
                .Select(assembly =>
                {
                    Debug.Log(assembly.FullName);
                    return assembly;
                })
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsSubclassOf(self));
        }

        public static IEnumerable<Type> GetSubTypesWithClassInAssemblies<TClassAttribute>(this Type self)
            where TClassAttribute : Attribute
        {
            return GetSubTypesInAssemblies(self)
                .Where(type => type.GetCustomAttribute<TClassAttribute>() != null);
        }
    }
}