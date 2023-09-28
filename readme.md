# Local Development with Docker

## MacOS

### Visual Studio for Mac

* Install docker
* Install VS for Mac
* Run `dotnet dev-certs -t` in a terminal
* It'll probably ask for passwords and stuff
* RESTART visual studio AND docker completely (make sure they actually close) or jsut restart whole computer
* Re open VS 4 Mac and open Mangler Solution
* Choose the `docker-compose` run config
* Click the play button
* Open the docker dashboard, should see the docker project
* Web App
   * To open in browser, under the `ports` column click the :80 port
* API
   * Again, under ports click the :80 port
   * To get to swagger UI append `/swagger` to the URL
