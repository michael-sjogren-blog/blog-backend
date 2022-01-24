using Blog.Data.DataAccess;

namespace Blog.Data.Models.Repository
{
    public class PostsRepository : BaseRepository<Post , int>
    {
        public PostsRepository(ApplicationDbContext context) : base(context)
        {
        }
        
        
    }
}