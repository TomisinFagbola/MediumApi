using Medium.Api.Entities;
using System.Drawing;

namespace Medium.Api.Services
{
    public interface IMediumApiRepository
    {
        Task<IEnumerable<Post>> GetPosts();
        Post GetPost(int postId);
        Task<Tag> GetTagPosts();
        //public Image GetImageString(int id);
        //byte[] GetImageString1(int id);

        Image LoadImage();
        Task<Tag> GetTag1Posts();

        Tag CreateorCheckingTag(string TagName, Post post);

        Task<IEnumerable<Post>> LeadershipPostsAsync(string TagName);

        Task<Tag> GetHighestClapWithPost();
        Task<Author> AuthorPostsAsync();
    }
}
