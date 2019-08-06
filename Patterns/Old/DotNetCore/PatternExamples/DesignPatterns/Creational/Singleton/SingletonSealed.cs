// Copyright Information
// =============================
// CreationalPatterns - SingletonSealed.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================
namespace DesignPatterns.Creational.Singleton
{
    public sealed class SingletonSealed
    {
        private static readonly SingletonSealed instance = new SingletonSealed();

        private SingletonSealed() { }

        public static SingletonSealed Instance => instance;
    }
    /*
     Static initialization is suitable for most situations. 
     When your application must delay the instantiation, use a non-default constructor 
     or perform other tasks before the instantiation, and work in a multithreaded environment, 
     you need a different solution.
     Cases do exist, however, in which you cannot rely on the common language 
     runtime to ensure thread safety, as in the Static Initialization example.
     https://msdn.microsoft.com/en-us/library/ff650316.aspx?f=255&MSPPError=-2147217396
*/
}