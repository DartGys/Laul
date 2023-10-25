using MediatR;

namespace Laul.Application.Services.ListeningStats.Command.CreateListeningStat
{
    public class CreateListeningStatCommand : IRequest<int>
    {
        public ulong SongId { get; set; }
        public Guid UserId { get; set; }

    }
}
