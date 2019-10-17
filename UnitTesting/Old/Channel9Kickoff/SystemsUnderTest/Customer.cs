#region Copyright
// Copyright Information
// ==================================
// UnitTesting - XUnitTestProject - Customer.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 08/09/2018
// See License.txt for more information
// ==================================
#endregion

namespace Channel9Kickoff.SystemsUnderTest
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual Address AddressNavigation { get; set; }
    }
}