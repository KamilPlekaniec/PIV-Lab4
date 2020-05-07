using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplikacjaDrużynowa
{
    public class Teams
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string School { get; set; }
        public string Conference { get; set; }
        public string Abbreviation { get; set; }

        [JsonIgnore]
        public List<Coaches> Coachess { get; set; } = new List<Coaches>();

    }
}
