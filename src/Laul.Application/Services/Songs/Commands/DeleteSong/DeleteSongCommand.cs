using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Laul.Application.Services.Songs.Commands.DeleteSong
{
    public class DeleteSongCommand : IRequest<Unit>
    {
        public int Id;
        public Guid ArtistId;
    }
}
