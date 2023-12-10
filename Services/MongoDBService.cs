using Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;


namespace Services.MongoDBService;


public class MongoDBService{
    private readonly IMongoCollection<Note> _notes;


    public MongoDBService(IOptions<MongoDBSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionURI);
        var database = client.GetDatabase(settings.Value.DatabaseName);
        _notes = database.GetCollection<Note>(settings.Value.CollectionName);
    }


    public async Task CreateAsync (Note note)
    {
        await _notes.InsertOneAsync(note);
        return;
    }

    public async Task<List<Note>> GetAllAsync()
    {
        return await _notes.Find(note => true).ToListAsync();
    }
}