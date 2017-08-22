// Copyright Information
// =============================
// CreationalPatterns - MySingletonClass.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================
using System;

namespace CreationalPatterns.Singleton
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
    public sealed class MySingletonClass : IDisposable
	{
		private bool _disposed;
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
				//removed double lock because this is fixed in C# 6
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
		//
		// Implement IDisposable.
		// Do not make this method virtual.
		// A derived class should not be able to override this method.
		public void Dispose()
		{
			Dispose(true);
			// This object will be cleaned up by the Dispose method.
			// Therefore, you should call GC.SupressFinalize to
			// take this object off the finalization queue
			// and prevent finalization code for this object
			// from executing a second time.
			GC.SuppressFinalize(this);
		}

		// Dispose(bool disposing) executes in two distinct scenarios.
		// If disposing equals true, the method has been called directly
		// or indirectly by a user's code. Managed and unmanaged resources
		// can be disposed.
		// If disposing equals false, the method has been called by the
		// runtime from inside the finalizer and you should not reference
		// other objects. Only unmanaged resources can be disposed.
		private void Dispose(bool disposing)
		{
			// Check to see if Dispose has already been called.
			if (_disposed) return;
			// If disposing equals true, dispose all managed
			// and unmanaged resources.
			if (disposing)
			{
				_instance = null;
				// Dispose managed resources.
			}

			// Call the appropriate methods to clean up
			// unmanaged resources here.
			// If disposing is false,
			// only the following code is executed.
			// Note disposing has been done.
			_disposed = true;
		}

		// Use C# destructor syntax for finalization code.
		// This destructor will run only if the Dispose method
		// does not get called.
		// It gives your base class the opportunity to finalize.
		// Do not provide destructors in types derived from this class.
		~MySingletonClass()
		{
			// Do not re-create Dispose clean-up code here.
			// Calling Dispose(false) is optimal in terms of
			// readability and maintainability.
			Dispose(false);
		}
	}
}

