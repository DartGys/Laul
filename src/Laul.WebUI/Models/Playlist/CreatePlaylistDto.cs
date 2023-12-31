﻿using System.ComponentModel.DataAnnotations;

namespace Laul.WebUI.Models.Playlist
{
    public class CreatePlaylistDto
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
    }
}
