namespace DictIt.Model
{
    public class Term
    {
        public Term()
        {
        }

        public Term(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
