namespace API_Inscription.Model
{
    public partial class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = null;

        public string Email { get; set; } = null;

        public override string ToString()
        {
            return $"Name : {Name}, Email : {Email}";
        }
    }
}
