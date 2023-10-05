# Local Development with Docker

## MacOS
* Run `dotnet dev-certs https --clean` in a terminal
* After that finishes, run `dotnet dev-certs https --trust`
* It'll probably ask for passwords and stuff
* if you've got any running containers in docker, delete them
* If docker or any IDE is open, forcibly close them
  * For rider, go to top left `JetBrains Rider menu item > Quit Jetbrains Rider`
* Install docker

### Visual Studio for Mac

* Install VS for Mac, open the project
* Choose the `docker-compose` run config
* Click the play button

### Rider

* Install rider
* Choose the 'docker-compose' build config.  If you don't see it then:
  * In the top right are the build configs, click the drop down and go to `Edit Configuration`
  * Click the `+` in the top left to add a new config
  * Chose `docker-compose`
  * type a name at the top (can be anything) and point it to the docker-compose.yml file
  * save the build config
  * now, on the build config drop down, choose the one you just created
* Click the debug button 
* **If docker warns you that another application modified your config DO NOT CLICK RE-APPLY CONFIGURATIONS**
* Docker Links:
  * Website: http://localhost:51557/
  * WebAPI Swagger UI: localhost:51554/swagger/


### Opening the apps from Docker
* Web App
  * To open in browser, under the `ports` column click the :80 port
* API
  * Again, under ports click the :80 port
  * To get to swagger UI append `/swagger` to the URL

### Troubleshooting

#### Docker hangs, stays at 'stopped'

* Open mac os settings > Privacy and security > Full Disk Access
* add Docker as an app that has access to everything
* Now go to settings > Privacy and security > Developer Tools
* Also add Docker here (not sure if needed but just do it)
* Force quit docker desktop and re-open.