using System;
using System.Collections.Generic;
using System.Text;

namespace InCoqnito.Kalender.Data.KalenderEntities
{
    public partial class EmailTemplate
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Template { get; set; }
    }
}
