# Story Mangler

## Docker container app URLs:

Once you have the docker container running, you can access your local instances via these URLs:

* Web App: http://localhost:57232/
* Web API Swagger Page: http://localhost:50883/swagger/index.html
* Bot API Swagger Page: http://localhost:57222/swagger/index.html

## Local Workspace setup with Docker + MacOS + JetBrains Rider

### Setting stuff up

1. [Install Docker](https://www.docker.com/)
2. [Install Rider](https://www.jetbrains.com/rider/)
3. [Connect Rider to docker](https://www.jetbrains.com/help/rider/docker.html)
   1. **If docker warns you that another application modified your config DO NOT CLICK RE-APPLY CONFIGURATIONS**
4. Add hosts file entries (see below)
5. Pull down the project in Rider
6. Open a terminal in the solution root directory and run `dotnet dev-certs https --clean` in a terminal
7. Right after that, run `dotnet dev-certs https --trust`
8. Type password if prompted (you should be)
9. If you already tried to run the storymangler docker container (please stop running ahead 😉) run `docker compose down -v` to wipe it out completely
10. Restart your whole dang computer
11. Re-open Rider and open another terminal in the solution root directory
12. Retrieve the bot token, and have it ready
     1. `DO NOT COMMIT THE BOT TOKEN TO THE REPOSITORY`
13. run `cd ./ManglerBot` to get into the mangler bot project directory
14. run `dotnet user-secrets set "DiscordBot:Token" "XXX"`, replacing XXX with the token.  (Keep the quotes)
     1. All this does is populate a json file on your machine with the bot token in plain text.
15. Once all of this is done, go to rider and choose the docker-compose build config
     1. If you don't see it, you might need to create it:
         * In the top right are the build configs, click the drop down and go to `Edit Configuration`
         * Click the `+` in the top left to add a new config
         * Chose `docker-compose`
         * type a name at the top (can be anything) and point it to the docker-compose.yml file
         * save the build config
         * now, on the build config drop down, choose the one you just created
16. Click `debug` to run the project
    1. Clicking `Run` won't work yet.
    2. Again, **If docker warns you that another application modified your config DO NOT CLICK RE-APPLY CONFIGURATIONS**


### hosts file entries needed:
```
127.0.0.1       localhost
::1             localhost
127.0.0.1       host.docker.internal
```

## Troubleshooting

### Docker hangs, stays at 'stopped'

* Open mac os settings > Privacy and security > Full Disk Access
* add Docker as an app that has access to everything
* Now go to settings > Privacy and security > Developer Tools
* Also add Docker here (not sure if needed but just do it)
* Force quit docker desktop and re-open.