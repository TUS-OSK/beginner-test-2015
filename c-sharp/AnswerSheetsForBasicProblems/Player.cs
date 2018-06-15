namespace Basic_5
{
    class Player
    {
        private int hp;
        private int attack;
        private int diffence;
        private double criticalHitProbability;

        string a;

        private int GetHp()
        {
            return hp;
        }

        private int SetHp(int newHp)
        {
            hp = newHp;
        }

        static void Main(string[] args)
        {
            Player hero = new Player();
            hero.SetHp(100);
            hero.GetHp();
        }
    }
  //(1)(2)(3)は以下に、クラスPlayerを定義することによって答えること。
}
