using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AplikacjaDrużynowa
{
    public class Coaches
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        public List<Seasons> Seasonss { get; set; }

        public class Seasons
        {
            [JsonIgnore]
            public int Id { get; set; }
            public string School { get; set; }

        }


    }
}
