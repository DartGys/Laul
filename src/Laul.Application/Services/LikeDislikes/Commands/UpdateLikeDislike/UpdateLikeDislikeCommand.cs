﻿using MediatR;

namespace Laul.Application.Services.LikeDislikes.Commands.UpdateLikeDislike
{
    public class UpdateLikeDislikeCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public long SongId { get; set; }
    }
}
