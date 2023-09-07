namespace GlobalQueryFilters.Entities;

public class Post
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime PublishOn { get; set; }
    public bool IsDeleted { get; set; } = false;
}