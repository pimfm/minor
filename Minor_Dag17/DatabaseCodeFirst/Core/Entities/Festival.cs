namespace DatabaseCodeFirst.Core.Entities
{
    public class Festival
    {
        public string Title { get; }
        public int Id { get; internal set; }

        public Festival(string title)
        {
            Title = title;
        }
    }
}