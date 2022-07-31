using System.Threading.Channels;
using Base.Shared.Events;

namespace Base.Shared.Messaging
{
    internal interface IEventChannel
    {
        ChannelReader<IEvent> Reader { get; }
        ChannelWriter<IEvent> Writer { get; }
    }
}