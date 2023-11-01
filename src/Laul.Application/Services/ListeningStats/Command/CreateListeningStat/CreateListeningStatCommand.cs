using MediatR;

namespace Laul.Application.Services.ListeningStats.Command.CreateListeningStat
{
    public class CreateListeningStatCommand : IRequest<long>
    {
        public long SongId { get; set; }
        public Guid UserId { get; set; }

    }
}
