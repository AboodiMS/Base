using System;

namespace Base.Shared.Time
{
    public interface IClock
    {
        DateTimeOffset CurrentDate();
    }
}