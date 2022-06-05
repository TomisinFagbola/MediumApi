using System.Drawing;


namespace Medium.Api.Dtos
{
    public class Postdto
    {

        public int Id { get; set; }
        public string? Title { get; set; }

        public string Content { get; set; }

        public int NoOfClaps { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<Picturedto> pic{ get; set; }

        

        //public static Image LoadBase64(string base64)
        //{
        //    byte[] bytes = Convert.FromBase64String(base64);
        //    Image image;
        //    using (MemoryStream ms = new MemoryStream(bytes))
        //    {
        //        image = Image.FromStream(ms);
        //    }
        //    return image;
        //}


    }

}

