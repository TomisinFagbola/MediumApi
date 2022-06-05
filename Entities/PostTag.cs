namespace Medium.Api.Entities
{
    public class PostTag
    {
        public DateTime PublicationDate { get; set; }


        public Post Post { get; set; }
        public int PostId { get; set; } 

        public Tag Tag { get; set; }
        public int TagId { get; set; }


      
    }
}
