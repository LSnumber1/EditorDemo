using System;
using System.Collections.Generic;
using UnityEngine;

namespace EditorFramework
{
  
    public abstract class StringConverter
    {
        public static Dictionary<Type, StringConverter> mConverterMap = new Dictionary<Type, StringConverter>()
        {
            {typeof(Rect), new RectStringConverter()},
            {typeof(string), new StringStringConverter()},
            {typeof(bool), new BooleanStringConverter()},
        };

        public static StringConverter<T> Get<T>()
        {
            StringConverter t = default;
            if (mConverterMap.TryGetValue(typeof(T), out t))
            {
                return t as StringConverter<T>;
            }

            return default;
        }
    }

    public abstract class StringConverter<T> :StringConverter
    {
        
        public virtual string ConvertToString(T value)
        {
            return value.ToString();
        }

        public abstract bool tryConvert(string self, out T result);
    }
}