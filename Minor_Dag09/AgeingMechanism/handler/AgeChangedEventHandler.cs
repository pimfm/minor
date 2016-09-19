namespace AgeDemo
{
    public delegate void AgeChangedEventHandler(object sender, AgeChangedEventArgs arguments);

    public class AgeChangedEventArgs
    {
        public string Name { get; private set; }
        public int OldAge { get; private set; }
        public int NewAge { get; private set; }

        public AgeChangedEventArgs(string name, int oldAge, int newAge)
        {
            this.Name = name;
            this.OldAge = oldAge;
            this.NewAge = newAge;
        }
    }
}
