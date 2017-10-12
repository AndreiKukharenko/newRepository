using System;

namespace FilmsWebApi.DAL.Models
{
    public class Film : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
