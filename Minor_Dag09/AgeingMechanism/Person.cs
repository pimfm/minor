namespace AgeDemo
{
    public class Person
    {
        public event BirthdayEventHandler BirthDayHandlers;
        public event AgeChangedEventHandler AgeChangedHandlers;
        public string Name { get; private set; }
        public int Age { get; private set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public void ChangeAge(int difference)
        {
            int oldAge = this.Age;
            this.Age += difference;

            this.OnAgeChanged(oldAge, this.Age);
        }

        public void CelebrateBirthday()
        {
            this.ChangeAge(1);
            this.OnBirthday();
        }

        protected virtual void OnAgeChanged(int oldAge, int newAge)
        {
            AgeChangedEventArgs arguments = new AgeChangedEventArgs(this.Name, oldAge, newAge);
            AgeChangedHandlers?.Invoke(this, arguments);
        }

        protected virtual void OnBirthday()
        {
            BirthDayEventArgs arguments = new BirthDayEventArgs(this.Name, this.Age - 1, this.Age);
            BirthDayHandlers?.Invoke(this, arguments);
        }
    }
}