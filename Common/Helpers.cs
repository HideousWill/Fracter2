using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace Fracter2.Common
{
	public class Helpers
	{
		//----------------------------------------------------------------------
		public static IEnumerable<T> GetInstancesOfTypesImplementing<T>() where T : class
		{
			var targetType = typeof(T);

			foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
				foreach (Type type in assembly.GetTypes())
				{
					if (!type.IsInterface)
					{
						if (!type.IsAbstract)
						{
							foreach (Type interfaceType in type.GetInterfaces())
							{
								if (interfaceType.Equals(targetType))
								{
									yield return Activator.CreateInstance(type) as T;
									break;
								}
							}
						}
					}
				}
		}

#if AS_LINQ
    //----------------------------------------------------------------------
        public static IEnumerable<T> GetInstancesOfTypesImplementing<T, A>( A arg ) where T : class
        {
            var targetType = typeof( T );

            return from assembly in AppDomain.CurrentDomain.GetAssemblies() 
                   from type in assembly.GetTypes() 
                   where !type.IsInterface 
                   where !type.IsAbstract 
                   where type.IsSubclassOf( targetType ) 
                   select (T) Activator.CreateInstance( type, new object[] { arg } );
        }
#else
		//----------------------------------------------------------------------
		public static IEnumerable<T> GetInstancesOfTypesImplementing<T, A>(A arg) where T : class
		{
			var targetType = typeof(T);

			foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
			{
				foreach (var type in assembly.GetTypes())
				{
					if (type.IsInterface) continue;
					if (type.IsAbstract) continue;

					if (!type.IsSubclassOf(targetType)) continue;

					yield return (T)Activator.CreateInstance(type, new object[] { arg });

				}
			}
		}

#endif
	}
}
