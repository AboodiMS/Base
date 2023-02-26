//using Infrastructure.Validation.Attribute;

namespace Base.Shared.Filter;

public class PagingFilter
{
    public string OrderBy { get; set; } = "CreateDate";
    public int PageNo { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public bool IsDesc { get; set; } = true;
}