# ManglerBot

Discord bot for the story mangler project

## Developing

### Adding new slash commands

* Add a new `ISlashCommand` implementation in the `Commands` directory.
* With the discord bot running, hit the `regenSlashCommands` endpoint to begin regenerating slash commands

### Command conventions / guidelines

* Minimize command parameters, prefer separate commands where it makes sense
* Default command parameters to the most common use case
* Commands should ideally work with no command parameters passed in at all
* Specify default values for every slash command.

### Troubleshooting

* Debugger won't attach in my command
  * make sure it is registered for DI via `program.cs`
  * I have yet to solve this random issue, but when adding a command sometimes docker won't work.
    * Eventually, it randomly decides to work.