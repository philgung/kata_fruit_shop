using FruitShop;
using NFluent;
using NUnit.Framework;

namespace FruitShopTests
{
    public class Iteration1
    {
        [Test]
        public void lachat_dune_pomme_et_de_deux_cerises_coute_230_centimes()
        {
            var caisse = new Caisse();
            caisse.Enregistre(FruitEnum.Pommes);
            caisse.Enregistre(FruitEnum.Cerises);
            caisse.Enregistre(FruitEnum.Cerises);
            Check.That(caisse.ObtenirTotal()).IsEqualTo(230);
        }

        [Test]
        public void lachat_dune_pomme_et_de_deux_cerises_genere_un_ticket()
        {
            var caisse = new Caisse();
            caisse.Enregistre(FruitEnum.Pommes);
            caisse.Enregistre(FruitEnum.Cerises);
            caisse.Enregistre(FruitEnum.Cerises);
            Check.That(caisse.ObtenirLAffichage()).IsEqualTo("Pommes -> 100\nCerises -> 175\nCerises -> 230\nTotal : 230.");
        }

        [Test]
        public void lachat_dun_panier_de_fruits_coute_500_centimes()
        {
            var caisse = new Caisse();
            caisse.Enregistre(FruitEnum.Cerises);
            caisse.Enregistre(FruitEnum.Pommes);
            caisse.Enregistre(FruitEnum.Cerises);
            caisse.Enregistre(FruitEnum.Bananes);
            caisse.Enregistre(FruitEnum.Pommes);

            Check.That(caisse.ObtenirTotal()).IsEqualTo(480);
        }

        [Test]
        public void lachat_dun_panier_de_fruits_genere_un_ticket()
        {
            var caisse = new Caisse();
            caisse.Enregistre(FruitEnum.Cerises);
            caisse.Enregistre(FruitEnum.Pommes);
            caisse.Enregistre(FruitEnum.Cerises);
            caisse.Enregistre(FruitEnum.Bananes);
            caisse.Enregistre(FruitEnum.Pommes);

            Check.That(caisse.ObtenirLAffichage()).IsEqualTo("Cerises -> 75\nPommes -> 175\nCerises -> 230\nBananes -> 380\nPommes -> 480\nTotal : 480.");
        }
    }

    public class Iteration2
    {

        [Test]
        public void lachat_dun_second_panier_de_fruits_coute_610_centimes()
        {
            var caisse = new Caisse();
            caisse.Enregistre(FruitEnum.Cerises);
            caisse.Enregistre(FruitEnum.Pommes);
            caisse.Enregistre(FruitEnum.Cerises);
            caisse.Enregistre(FruitEnum.Bananes);
            caisse.Enregistre(FruitEnum.Cerises);
            caisse.Enregistre(FruitEnum.Cerises);
            caisse.Enregistre(FruitEnum.Pommes);

            Check.That(caisse.ObtenirTotal()).IsEqualTo(610);
        }
    }
}