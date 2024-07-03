

namespace Domain.Entities
{
    public class Posts
    {
        public Guid PostId { get; set; }
        public string Title { get; set; }
        public Guid UserId { get; set; }    
        public DateTime PublishDate { get; set; }
        public string Body { get; set; }
        public int TotalLikes { get; set; }
        public int TotalComments { get; set; }


        public User User { get; set; }

    }
}
