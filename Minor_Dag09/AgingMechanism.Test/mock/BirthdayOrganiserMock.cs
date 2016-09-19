namespace AgeDemo.Test
{
    public class BirthdayOrganiserMock
    {
        public bool FriendsAreInvited { get; private set; }
        public BirthDayEventArgs Arguments;

        public void InviteFriendsToComeOver(object sender, BirthDayEventArgs arguments)
        {
            this.FriendsAreInvited = true;
            this.Arguments = arguments;
        } 
    }
}
