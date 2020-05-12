using System;

namespace FruitShop
{
    public enum FruitEnum
    {
        Pommes = 100,
        Cerises = 75,
        Bananes = 150
    }
    
    internal sealed class Fruit
    {
        private readonly FruitEnum _fruit;

        public Fruit(FruitEnum fruit)
        {
            this._fruit = fruit;
        }

        public readonly static Fruit Cerises = new Fruit(FruitEnum.Cerises);

        public int ObtenirPrix => (int)_fruit;

        public override string ToString()
        {
            return Enum.GetName(typeof(FruitEnum), _fruit);
        }

        public override bool Equals(object obj)
        {
            var autreFruit = obj as Fruit;
            if (autreFruit == null) return false;

            return _fruit == autreFruit._fruit;
        }

        public override int GetHashCode()
        {
            return _fruit.GetHashCode();
        }



    }

}