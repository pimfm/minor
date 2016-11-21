namespace InfoSupport.BKE.GameAdministration.Domain.Entities
{
    public class Player
    {
        public string Name { get; private set; }

        public Player(string name)
        {
            Name = name;
        }

        public static Player Register(string name)
        {
            return new Player(name);
        }
    }
}