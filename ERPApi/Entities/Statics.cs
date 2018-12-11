namespace Entities
{
    public class Statics
    {
        public static CurrentUser LoggedInUser = null;
    }

    public class CurrentUser
    {
        public int userId { get; set; }
        public string userName { get; set; }
    }
}
