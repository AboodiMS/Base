using System;

namespace Base.Shared.Time
{
    internal sealed class UtcClock : IClock
    {
        public DateTimeOffset CurrentDate() => DateTimeOffset.UtcNow;
    }
}