using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medium.Api.Entities
{
    public class Author
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  AuthorId { get; set; }   
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();

    }
}
