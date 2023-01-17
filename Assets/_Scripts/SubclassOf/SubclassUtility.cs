using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MobileFramework.Subclass
{
    /// <summary>
    /// Rudimentary class made to mimic the TSubClassOf from Unreal Engine 4, provides some utility methods to fetch the base classes
    /// </summary>
    public static class SubclassUtility
    {
        /// <summary>
        /// Get the parent class of TBaseType.
        /// </summary>
        /// <typeparam name="TBaseType">The class you need to find the parent of.</typeparam>
        /// <returns>Returns an IEnumerable<Type> of classes that inherit from TBaseType.</returns>
        public static IEnumerable<Type> GetSubclassesOf<TBaseType>()
        {
            var baseType = typeof(TBaseType);
            var assembly = baseType.Assembly;

            return assembly.GetTypes().Where(t => t.IsSubclassOf(baseType));
        }
    
        /// <summary>
        /// Returns the class at 'index' position from a parent.
        /// </summary> 
        /// <param name="index">the index of the class you're looking for.</param>
        /// <typeparam name="T">Parent class of the one you're looking for.</typeparam>
        /// <returns>Returns the class at the given index.</returns>
        public static T GetSubclassFromIndex<T>(int index) where T : class
        {
            var type = GetSubclassesOf<T>().ToList();
            var desiredType = type[index];
            return Assembly.GetAssembly(desiredType).CreateInstance(desiredType.Name) as T;
        }
        
        /// <summary>
        /// Returns the class at 'index' position from a parent.
        /// </summary> 
        /// <param name="index">the index of the class you're looking for.</param>
        /// <typeparam name="T">Parent class of the one you're looking for.</typeparam>
        /// <returns>Returns the class at the given index.</returns>
        public static Type GetSubclassFromIndex(Type desiredType, int index)
        {
            var assembly = desiredType.Assembly;
            var types = new List<Type>();

            foreach (var type in assembly.GetTypes().Where(t => t.IsSubclassOf(desiredType)))
            {
                types.Add(type);
            }

            return types.Find(type => type == desiredType);
        }

        /// <summary>
        /// Returns all the names of the classes that inherit from the given Type.
        /// </summary>
        /// <param name="desiredType">The Type you wish to know the names of the children classes of.</param>
        /// <returns>Returns a list of the classes names.</returns>
        public static List<string> GetSubclassesNames(Type desiredType)
        {
            List<string> names = new List<string>();

            var assembly = desiredType.Assembly;

            foreach (var type in assembly.GetTypes().Where(t => t.IsSubclassOf(desiredType)))
            {
                names.Add(type.Name);
            }

            return names;
        }
    }
}

