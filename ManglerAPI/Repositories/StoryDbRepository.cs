using System.Text;
using Dapper;
using Mangler.Common.Results;
using ManglerAPI.Entities;
using MySqlConnector;

namespace ManglerAPI.Repositories;

public class StoryDbRepository : IStoryRepository
{
    private readonly MySqlConnection _sqlConnection;
    private readonly ILogger<StoryDbRepository> _logger;

    public StoryDbRepository(MySqlConnection sqlConnection, ILogger<StoryDbRepository> logger)
    {
        _sqlConnection = sqlConnection;
        _logger = logger;
    }

    public async Task<Result<Story>> GetById(long id)
    {
        const string sql = "select * from Story where id = @id limit 1";
        var parameters = new { id = id };

        return  Result<Story>.Success(await _sqlConnection.QueryFirstOrDefaultAsync<Story>(sql, parameters));
    }

    public async Task<Result<IEnumerable<Story>>> GetList(string guildIdentifier, string authorIdentifier, int pageSize,
        DateTime? beforeDate)
    {
        var sqlBuilder = new StringBuilder($"select * from Story where 1=1 ");

        var parameters = new Dictionary<string, object>();
        
        if (guildIdentifier != null)
        {
            sqlBuilder.Append("and guildIdentifier = @guildId ");
            parameters.Add("@guildId", guildIdentifier);
        }
        else
        {
            // if guild id is left out, only return stories that are allowed to be viewed by randos
            sqlBuilder.Append("and IsViewableByPublic = 1 ");
        }

        if (authorIdentifier != null)
        {
            sqlBuilder.Append("and authorIdentifier = @authorId ");
            parameters.Add("@authorId", authorIdentifier);
        }

        if (beforeDate != null)
        {
            sqlBuilder.Append("and createDt < @beforeDate ");
            parameters.Add("@beforeDate", beforeDate);
        }

        sqlBuilder.Append($"order by createDt desc limit {pageSize}");

        return Result<IEnumerable<Story>>.Success(await _sqlConnection.QueryAsync<Story>(sqlBuilder.ToString(), parameters));
    }
    
    
} 