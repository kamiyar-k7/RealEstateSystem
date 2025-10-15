

namespace Domain.Entities.ProperetyEntities;

public class PropertyCommentsEntity
{

    public Guid Id { get; set; }
    public Guid PropertyId { get; set; }
    public PropertyEntity Property { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }

    public Guid? AuthorId { get; set; }
    public string AuthorName { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}
