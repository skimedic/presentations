// Copyright Information
// =============================
// CreationalPatterns - MySingletonClass.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================

namespace DesignPatterns.Creational.Singleton
{
    /*
    This approach ensures that only one instance is created and only when the instance is needed.
    Also, the variable is declared to be volatile to ensure that assignment to the instance variable 
    completes before the instance variable can be accessed.Lastly, this approach uses a syncRoot 
    instance to lock on, rather than locking on the type itself, to avoid deadlocks.

    This double-check locking approach solves the thread concurrency problems while avoiding an 
    exclusive lock in every call to the Instance property method.
    It also allows you to delay instantiation until the object is first accessed. In practice, 
    an application rarely requires this type of implementation.In most cases, the static initialization 
    approach is sufficient.
    */
    public sealed class MySingletonClass 
	{
        //the volatile keyword ensures that the instantiation is complete 
        //before it can be accessed further helping with thread safety.
		private static volatile MySingletonClass _instance;
		private static readonly object _syncLock = new object();
		private MySingletonClass()
		{
		}

        //uses a pattern known as double check locking
		public static MySingletonClass Instance
		{
			get
			{
				if (_instance != null) return _instance;
				lock (_syncLock)
				{
					if (_instance == null)
					{
						_instance = new MySingletonClass();
					}
				}
				return _instance;
			}
		}

		public int SomeValue { get; set; }
	}
}

