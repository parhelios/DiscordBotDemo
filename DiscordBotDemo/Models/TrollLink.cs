using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotDemo.Models
{
    public class TrollLink
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Link { get; set; }
    }
}
