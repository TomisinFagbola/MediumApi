using Medium.Api.Contexts;
using Medium.Api.Entities;
using Medium.Api.Services;
using System.Drawing;

namespace Medium.Api.Dtos
{
    public class Picturedto
    {
        public  int Id { get; set; }

        public string Pic { get; set; }

        public Image GetImageString(byte[] Pic)
        {
            Image image;
            using (MemoryStream ms = new MemoryStream(Pic)) 
            {
                image = Image.FromStream(ms);
            }

            return image;
        }


           
      
    }
}
