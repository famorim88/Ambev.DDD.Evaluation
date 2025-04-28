using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MongoDb:ConnectionString"]);
            _database = client.GetDatabase(configuration["MongoDb:Database"]);
        }

        public IMongoCollection<Sales> Sales => _database.GetCollection<Sales>("Sales");
        public IMongoCollection<Counter> Counter => _database.GetCollection<Counter>("Counter");

    }
}
