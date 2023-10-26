using System.Globalization;
using ManglerAPI.Infrastructure.ErrorHandling;
using ManglerAPI.Infrastructure.Models;

namespace ManglerAPI.Infrastructure.Localization;

public interface ILocalizer
{
    string Localize(string cultureCode, string key);
}

/// <summary>
/// Since only english is supported it's fine to implement this in memory.  If we ever support new culture codes we would
/// want to break this out into a resource file such as resx / etc
/// </summary>
public class InMemoryLocalizer : ILocalizer
{
    private readonly ILogger<InMemoryLocalizer> _logger;
    
    /// <summary>Dictionary of dictionaries</summary>
    private static readonly Dictionary<string, Dictionary<string, string>> MegaDictionary = new()
    {
        { Culture.EnglishUSA, ErrorCode.DefaultLocalizations }
    };

    public InMemoryLocalizer(ILogger<InMemoryLocalizer> logger)
    {
        _logger = logger;
    }

    public string Localize(string cultureCode, string key)
    {
        Dictionary<string,string> dictionary = null;
        
        if (MegaDictionary.TryGetValue(cultureCode, out var dict))
        {
            dictionary = dict;
        }
        else
        {
            _logger.LogWarning("Unable to localize culture code '{cultureCode}'. Falling back to english.", cultureCode);
            dictionary = MegaDictionary[Culture.EnglishUSA];
        }

        if (dictionary.TryGetValue(key, out var copy))
        {
            return copy;
        }
        else
        {
            _logger.LogWarning("Missing key {key} in localizations for culture {cultureCode}.  Returning empty string.",
                key, cultureCode);
        }


        return string.Empty;
    }
    
}