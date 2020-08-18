using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Uibasoft.Smedia.Core.DTOs
{
    public class PostDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime? Date { get; set; }        
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
