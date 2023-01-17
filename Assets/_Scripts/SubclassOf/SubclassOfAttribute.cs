using System;
using UnityEngine;

namespace MobileFramework.Subclass
{
    [AttributeUsage(AttributeTargets.Field)]
    public class SubclassOfAttribute : PropertyAttribute
    {
        public readonly Type Type;

        public SubclassOfAttribute(Type type)
        {
            Type = type;
        }
    }
}