using MediatR;

namespace Laul.Application.Services.ListeningStats.Command.CreateListeningStat
{
    public class CreateListeningStatCommand : IRequest<int>
    {
        public DateTime ListeningDate { get; set; }
        public int SongId { get; set; }
        public Guid UserId { get; set; }

    }
}
