using Laul.Application.Common.Mapping;
using Laul.Domain.Entities;
using MediatR;
using System.Security.Cryptography.X509Certificates;

namespace Laul.Application.Songs.Queries.GetSongDetails
{
    public class GetSongDetailsQuery : IRequest<SongDetailsVm>
    {
        public int Id { get; set; }
        public Guid ArtistId { get; set; }
    }
}
