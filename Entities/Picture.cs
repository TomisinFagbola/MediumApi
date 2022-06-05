namespace Medium.Api.Entities
{
    public class Picture
    {
        public int Id { get; set; }

        public string Pic { get; set; }

        public Post Post { get; set; }

        public int PostId { get; set; }
        public static string ToBase64(string path)
        {

            using var fileStream = File.OpenRead(path);
            using MemoryStream ms = new MemoryStream();
            fileStream.CopyTo(ms);
            byte[] imageBytes = ms.ToArray();
            return Convert.ToBase64String(imageBytes);
        }

    }
}
