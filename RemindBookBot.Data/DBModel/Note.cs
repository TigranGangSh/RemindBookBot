using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemindBookBot.Data.Model
{
    public class Note
    {
        public int Id { get; set; }

        public int ChatId { get; set; }

        public DateTime SendTime { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public string ImageURL { get; set; }

    }
}
