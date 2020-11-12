namespace Merkel
{
    class NamesEntry
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        
        public NamesEntry(string firstName, string lastName, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + " " + Id.ToString();
        }
    }
}
