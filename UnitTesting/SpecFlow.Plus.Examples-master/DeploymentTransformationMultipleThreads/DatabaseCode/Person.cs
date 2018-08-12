using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DatabaseCode
{
    public class Person
        : IEquatable<Person>
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

        public static bool operator ==(Person value1, Person value2) => Equals(value1, value2);
        public static bool operator !=(Person value1, Person value2) => !(value1 == value2);

        public static bool Equals(Person value1, Person value2)
            => value1 is Person v1
               && value2 is Person v2
               && v1.FirstName == v2.FirstName
               && v1.LastName == v2.LastName;

        public bool Equals(Person other) => Equals(this, other);

        public override bool Equals(object obj) => obj is Person other && Equals(this, other);

        [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
        public override int GetHashCode()
            => unchecked(((FirstName?.GetHashCode() ?? 0) * 397) ^ (LastName?.GetHashCode() ?? 0));
    }
}
