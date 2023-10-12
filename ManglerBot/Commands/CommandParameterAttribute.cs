using Discord;

namespace ManglerBot.Commands;

/// <summary>
/// This is used by the command generator to tell discord what parameters we allow.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class CommandParameterAttribute : Attribute
{
    /// <summary>
    /// The parameter name
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// The description of what the parameter is for
    /// </summary>
    public string Description { get; set; }= string.Empty;

    /// <summary>
    /// Tells the discord client what type we expect.  Default = string.
    /// </summary>
    public ApplicationCommandOptionType Type { get; set; } = ApplicationCommandOptionType.String;

    /// <summary>
    /// If true, the parameter is required.  If false, it is not.
    /// </summary>
    public bool IsRequired { get; set; } = true;
    
    
}