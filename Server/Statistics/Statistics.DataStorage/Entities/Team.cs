using System.Collections.Generic;

namespace Statistics.DataStorage.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string City { get; set; }
        public string Conference { get; set; }
        public string Division { get; set; }
        public string Logo { get; set; }
    }
}
