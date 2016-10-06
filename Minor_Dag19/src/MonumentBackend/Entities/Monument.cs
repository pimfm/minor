using System.ComponentModel.DataAnnotations;

namespace MonumentBackend.Entities
{
    public class Monument
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public Monument(string name)
        {
            Name = name;
        }
    }
}