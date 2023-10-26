

using ManglerAPI.Infrastructure.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace ManglerAPI.Infrastructure.Mongo;


public class MongoClientFactory
{
    private readonly ManglerDbSettings _manglerDbSettings;

    public MongoClientFactory(IOptions<ManglerDbSettings> manglerDbSettings)
    {
        _manglerDbSettings = manglerDbSettings.Value;
    }

    public (IMongoCollection<T> collection, IMongoQueryable<T> queryable) GetQueryable<T>(string collectionName)
    {
        var mongoClientSettings = MongoClientSettings.FromConnectionString(_manglerDbSettings.ConnectionString);
        mongoClientSettings.LinqProvider = LinqProvider.V3;
        mongoClientSettings.Credential = MongoCredential.CreateCredential("manglerDb","appUser", "password");

        var client = new MongoClient(mongoClientSettings);
        var db = client.GetDatabase(_manglerDbSettings.DatabaseName);

        var collection = db.GetCollection<T>(collectionName);
        
        return (collection, collection.AsQueryable());
    }
}