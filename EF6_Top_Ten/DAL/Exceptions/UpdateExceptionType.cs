#region copyright
// // Copyright Information
// // ==============================
// // DAL - UpdateExceptionType.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
namespace DAL.Exceptions
{
	public enum UpdateExceptionType
	{
		Concurrency,
		PrimaryKey,
		UniqueIndex,
		Unknown,
	    MaxRetries
	}
}