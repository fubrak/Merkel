using System;

namespace Merkel
{
    class NamesEntry
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }

        private void fillWithTrash()
        {

        }

        public NamesEntry()
        {
            fillWithTrash();
        }
        public NamesEntry(string firstName, string lastName, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }
    }
}
