

using System;

namespace Base.Shared.Filter;

public class MasterFilter : PagingFilter
{
    public DateTimeOffset? FromCreateDate { get; set; } = null;
    public DateTimeOffset? ToCreateDate { get; set; } = null;
    public DateTimeOffset? FromUpdateDate { get; set; } = null;
    public DateTimeOffset? ToUpdateDate { get; set; } = null;
    public DateTimeOffset? FromDeleteDate { get; set; } = null;
    public DateTimeOffset? ToDeleteDate { get; set; } = null;
    public bool IsDeleted { get; set; } = false;
}
