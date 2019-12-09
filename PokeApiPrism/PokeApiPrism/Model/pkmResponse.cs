using System;
using System.Collections.Generic;
using System.Text;

namespace PokeApiPrism.Model
{
    public class pkmResponse
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<pkmnInfo> results { get; set; }
    }
}
