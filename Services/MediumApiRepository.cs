using Medium.Api.Contexts;
using Medium.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


using System.Drawing;
using System.Text;

namespace Medium.Api.Services
{
    public class MediumApiRepository : IMediumApiRepository
    {
        private readonly MediumApiContext _context;

        public MediumApiRepository(MediumApiContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public MediumApiRepository()
        {
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _context.Posts.Include(p => p.pic).Where(p => p.Id > 0).OrderByDescending(p => p.CreatedDate).ToListAsync();
        }

        //public byte[] GetImageString1(int id)
        //{
        //    return _context.Pics.Where(p => p.Id == id).Select(p => p.Pic).SingleOrDefault();
        //}

        //public Image GetImageString(int id)
        //{
        //    var item = _context.Pics.Where(p => p.Id == id).Select(p => p.Pic).SingleOrDefault();
        //    byte[] bytes = Convert.FromBase64String(item);


        //    Image image;
        //    using (MemoryStream ms = new MemoryStream(bytes))
        //    {
        //        image = Image.FromStream(ms);
        //    }

        //    return image;
        //}
        public Post GetPost(int postId)
        {
        //    _context.Posts.Include(p => p.pic).FirstOrDefault
            var gottenpost = _context.Posts.Where(p => p.Id == postId).FirstOrDefault();
             
            if (gottenpost.Id == postId)
                return gottenpost;
            else
                return gottenpost;
        }


        //public async Task<Tag> GetTag1Posts()
        //{
        //    return await _context.Tags.Include(a => a.PostTags).FirstAsync(t => t.Name.Equals("leadership"));
        //}
        public async Task<Tag> GetTag1Posts()
        {
            return await _context.Tags.Include(a => a.Posts).FirstAsync(t => t.Name.Equals("leadership"));

        }

        //public Image GetBase64FromImage()
        //{
        //    /*return _context.Pics.Where(p => p.Id > 0).Select(p => p.Pic).ToList()*/;
        //    foreach(var ss in _context.Pics.Where(p => p.Id > 0).Select(p => p.Pic).ToList())
        //    {
        //        byte[] bytes = Encoding.ASCII.GetBytes(ss);
        //        Image image;
        //        using (MemoryStream ms = new MemoryStream(bytes))
        //        {
        //            image = Image.FromStream(ms);
        //            return image;
        //        }
        //        return null;
               
        //    }
        //}

        public Image LoadImage()
        {
            foreach (var item in _context.Pics.Where(p => p.Id > 0).Select(p => p.Pic).ToList())
            {
                byte[] bytes = Convert.FromBase64String(item);

                Image image;
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    image = Image.FromStream(ms);
                }
                return image;
            }
            return null;
        }
        public async Task<Tag> GetTagPosts()
        {
            return await _context.Tags.Include(a => a.Posts.OrderByDescending(p => p.CreatedDate)).FirstAsync(t => t.Name.Equals("leadership"));

        }
       

        public PostTag GetParticularPostAssociatedWithTag(int PostId, int TagId)
        {
            return _context.PostTags
                          .Where(pt => pt.PostId == PostId && pt.TagId == TagId).FirstOrDefault();
        }

        public async  Task<Tag> GetHighestClapWithPost()
        {
            return await _context.Tags.Include(a => a.Posts.OrderByDescending(p => p.NoOfClaps)).FirstAsync(t => t.Name.Equals("leadership"));

             
        }


        public Tag CreateorCheckingTag(string TagName, Post post)
        {
            if(_context.Tags.Any(t => t.Name == TagName)) 
            {
               return _context.Tags.Where(t => t.Name == TagName).FirstOrDefault();
            }
            else 
            {
               var count = _context.Tags.Count<Tag>();
               var newtag = _context.Tags.Add(new Tag
                {
                    Id = ++count,
                    Name = TagName,
                }) ;
                Save();
                return _context.Tags.Where(t => t.Name == TagName).FirstOrDefault();
            }
        }


        public async Task<Tag> LeadershipPostsAsync() 
        {
         return await _context.Tags.Include(t => t.Posts.OrderByDescending(p => p.CreatedDate)).FirstOrDefaultAsync(t => t.Name.Equals("leadership"));
        }

        public async Task<Author> AuthorPostsAsync()
        { 
        
        return await _context.Authors.Include(a => a.Posts).FirstOrDefaultAsync(a => a.Name.Equals("Raji Fashola"));
        }
        public bool PostExists(int postId)
        {
            return _context.Posts.Any(c => c.Id == postId);
        }

        
        

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public Task<IEnumerable<Post>> LeadershipPostsAsync(string TagName)
        {
            throw new NotImplementedException();
        }
    }
}


 