namespace Medium.Api.Dtos
{
    public class Authordto
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }

        public ICollection<Postdto> Posts { get; set; } = new List<Postdto>();
    }
}
