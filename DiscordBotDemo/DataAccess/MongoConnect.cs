using DiscordBotDemo.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotDemo.DataAccess
{
    public class MongoConnect
    {
        private IMongoDatabase _db;

        public MongoConnect(string database)
        {
            var client = new MongoClient("https://github.com/josephRashidMaalouf/DiscordBotDemo");
            _db = client.GetDatabase(database);
        }

        public async Task AddLink(string table, string link)
        {
            TrollLink tl = new ()
            {
                Link = link
            };

            var collection = _db.GetCollection<TrollLink>(table);

            await collection.InsertOneAsync(tl);
            
        }

        public Task<List<TrollLink>> GetAllLinks(string table)
        {
            var collection = _db.GetCollection<TrollLink>(table);

            return collection.AsQueryable().ToListAsync();
        }
    }
}
