using System;

namespace Collections
{
    public class User : IUser
    {
        public User(string fullName, string username, uint? age)
        {
            if (username == null) {
                throw new System.ArgumentException("username must be non-null");
            }
            Age = age;
            FullName = fullName;
            Username = username;
        }
        
        public uint? Age { get; }
        
        public string FullName { get; }
        
        public string Username { get; }

        public bool IsAgeDefined => Age != null;
        
        public string toString() 
        {
            return "[username: " + Username + ", fullname: " + FullName + (IsAgeDefined ? ", age: " + Age : "") + "]"; 
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
