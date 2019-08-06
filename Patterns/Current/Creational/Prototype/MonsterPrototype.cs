// Copyright Information
// =============================
// CreationalPatterns - MonsterPrototype.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================
namespace CreationalPatterns.Prototype
{
    public abstract class MonsterPrototype
    {
        protected MonsterPrototype(bool canFly, bool canSwim, bool hasMagic)
        {
            CanFly = canFly;
            CanSwim = canSwim;
            HasMagic = hasMagic;
            //etc
        }

        public bool CanFly { get; set; }
        public bool CanSwim { get; set; }
        public bool HasMagic { get; set; }
        //etc., etc.
        public abstract MonsterPrototype Clone();
    }

    public class FlyingMonster : MonsterPrototype
    {
        public FlyingMonster(bool canFly = true, bool canSwim = false, bool hasMagic = false) : 
            base(canFly, canSwim, hasMagic)
        {
        }

        public override MonsterPrototype Clone()
        {
            return MemberwiseClone() as MonsterPrototype;
        }
    }
}
