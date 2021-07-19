using System;

namespace Ulaw.ApplicationProcessor.Models
{
    public class UserModel
    {

        public UserModel( string title, string firstName, string lastName, DateTime dateOfBirth, bool requiresVisa )
        {
            Title = title;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            RequiresVisa = requiresVisa;
        }

        public string Title { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public bool RequiresVisa { get; private set; }
    }
}

