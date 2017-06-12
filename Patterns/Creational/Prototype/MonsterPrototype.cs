namespace Creational.Prototype
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
        public FlyingMonster(bool canFly, bool canSwim, bool hasMagic) : 
            base(canFly, canSwim, hasMagic)
        {
        }

        public override MonsterPrototype Clone()
        {
            return MemberwiseClone() as MonsterPrototype;
        }
    }
}
