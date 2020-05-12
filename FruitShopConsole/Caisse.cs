using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FruitShop
{
    public class Caisse
    {
        private IList<Fruit> _fruits = new List<Fruit>();
        public Caisse()
        {
        }

        public void Enregistre(FruitEnum fruit)
        {
            _fruits.Add(new Fruit(fruit));
        }

        public string ObtenirLAffichage()
        {
            var sb = new StringBuilder();
            int sousTotal = 0;
            var montantDeLaReduction = ObtenirMontantDeLaReduction();

            int index = 0;

            foreach (var fruit in _fruits)
            {
                sousTotal += fruit.ObtenirPrix;
                sousTotal -= montantDeLaReduction[index];
                sb.Append($"{fruit} -> {sousTotal}\n");
                index++;
            }

            sb.Append($"Total : {sousTotal}.");
            return sb.ToString();
        }

        private List<int> ObtenirMontantDeLaReduction()
        {
            var compteurDeFruits = new Dictionary<Fruit, int>();
            var montantDeLaReduction = new List<int>();

            foreach (var fruit in _fruits)
            {
                AjouteAuCompteurDeFruits(compteurDeFruits, fruit);

                montantDeLaReduction.Add(compteurDeFruits[fruit] % 2 == 0 &&
                    fruit.Equals(Fruit.Cerises)
                    ? 20 : 0);
            }

            return montantDeLaReduction;
        }

        private static void AjouteAuCompteurDeFruits(Dictionary<Fruit, int> compteurDeFruits, Fruit fruit)
        {
            if (compteurDeFruits.ContainsKey(fruit))
            {
                compteurDeFruits[fruit]++;
            }
            else
            {
                compteurDeFruits.Add(fruit, 1);
            }
        }

        public int ObtenirTotal()
        {
            return _fruits.Sum(fruit => fruit.ObtenirPrix)
                - ObtenirMontantDeLaReduction().Sum(reduction => reduction);
        }
    }

    //public sealed class Reduction
}