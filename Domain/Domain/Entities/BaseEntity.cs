﻿

namespace Domain.Entities;

public class BaseEntity
{

    public Guid Id { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.Now;
    public bool IsDeleted { get; set; } = false;

}
