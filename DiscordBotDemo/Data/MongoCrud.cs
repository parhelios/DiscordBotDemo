using DiscordBotDemo.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotDemo.Data
{
    public class MongoCrud
    {
        private IMongoDatabase _db;

        public MongoCrud(string database)
        {
            var client = new MongoClient("mongodb://ptoatis:0VbY8x6ydAoIrq9mOeDADERbHJwTfxzwl4lirDbki7vj7qYeYqdDBBN65v7Kltf7lXpUniv5NwSMACDblIVnkA==@ptoatis.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@ptoatis@");
            _db = client.GetDatabase(database);
        }

        public Task<List<User>> GetAllUsers(string table)
        {
            var collection = _db.GetCollection<User>(table);
            return collection.AsQueryable().ToListAsync();
        }

        public async Task<User> AddUser(string table)
        {
            User user = new User()
            {
                Name = "Joe",
                Email = "Joe@Joe.se"
            };

            var collection = _db.GetCollection<User>(table);
            await collection.InsertOneAsync(user);
            return user;
        }
    }
}
