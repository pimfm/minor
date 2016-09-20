using System;

namespace AgeDemo
{
    public delegate void BirthdayEventHandler(object sender, BirthDayEventArgs arguments);

    public class BirthDayEventArgs : EventArgs {
        public string Name { get; private set; }
        public int OldAge { get; private set; }
        public int NewAge { get; private set; }

        public BirthDayEventArgs(string name, int oldAge, int newAge)
        {
            this.Name = name;
            this.OldAge = oldAge;
            this.NewAge = newAge;
        }
    }
}
