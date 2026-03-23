using APBD_TASK2.Enum;

namespace APBD_TASK2.Models
{
    public class User
    {
        private static int _nextId = 1;
        
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType UserType { get; set; }

        public User(string firstName, string lastName, UserType userType)
        {
            Id = _nextId++;
            FirstName = firstName;
            LastName = lastName;
            UserType = userType;
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName} ({UserType})";
        }
    }
}