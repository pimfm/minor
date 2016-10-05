namespace MonumentBackend.Entities
{
    public class Monument
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Monument(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}