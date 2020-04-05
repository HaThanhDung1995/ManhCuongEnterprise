namespace WebEnter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Arranx
    {
        public int Id { get; set; }

        public int? TutorId { get; set; }

        public int? StudentId { get; set; }

        public virtual Student Student { get; set; }

        public virtual Turtor Turtor { get; set; }
    }
}
