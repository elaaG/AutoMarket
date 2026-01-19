using MongoDB.Driver;
using AutoMarket.Models;
using Microsoft.Extensions.Configuration;

namespace AutoMarket.Services
{
    public class MongoAvisService
    {
        private readonly IMongoCollection<Avis> _avisCollection;

        public MongoAvisService(IConfiguration config)
        {
            var client = new MongoClient(
                config["MongoDB:ConnectionString"]
            );

            var database = client.GetDatabase(
                config["MongoDB:DatabaseName"]
            );

            _avisCollection = database.GetCollection<Avis>("Avis");
        }

        public async Task<List<Avis>> GetAvisByAnnonceAsync(int annonceId)
        {
            return await _avisCollection
                .Find(a => a.AnnonceId == annonceId)
                .ToListAsync();
        }

        public async Task AddAvisAsync(Avis avis)
        {
            await _avisCollection.InsertOneAsync(avis);
        }
    }
}
