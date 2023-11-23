using MediatR;

namespace Laul.Application.Services.ListeningStats.Commands.CreateListeningStat
{
    public class CreateListeningStatCommand : IRequest<long>
    {
        public long SongId { get; set; }
        public string ArtistName { get; set; }

    }
}
