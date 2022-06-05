using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Medium.Api.Entities
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(1000)]
        public string Content { get; set; }

        public int NoOfClaps { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<Tag> Tags { get; set; }
        public ICollection<PostTag> PostTags { get; set; }


        // public string Video { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public int AuthorId { get; set; }

       

        
        public  ICollection<Picture> pic { get; set; }

        




     
    }
}
