using Medium.Api.Entities;

namespace Medium.Api.Dtos
{
    public class Tagdto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Postdto> Posts { get; set; }
    }
}
