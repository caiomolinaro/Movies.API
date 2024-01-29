using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Movies.Api.Model;

namespace Movies.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private IConfiguration Configuration;
    private IMongoCollection<MovieModel> _moviesCollection;

    public MoviesController(IConfiguration _configuration)
    {
        Configuration = _configuration;

        string connString = this.Configuration.GetConnectionString("MongoDb")!;

        var settings = MongoClientSettings.FromConnectionString(connString);

        settings.ServerApi = new ServerApi(ServerApiVersion.V1);

        var client = new MongoClient(settings);

        var dataBase = client.GetDatabase("sample_mflix");

        _moviesCollection = dataBase.GetCollection<MovieModel>("movies");
    }

    [HttpGet]
    public IEnumerable<MovieModel> Get()
    {
        return _moviesCollection.Find(_ => true).Limit(10).ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<MovieModel> Get(string id)
    {
        var movie = _moviesCollection.Find(x => x._id == id).FirstOrDefault();

        if (movie is null)
        {
            return NotFound();
        }

        return movie;
    }
}