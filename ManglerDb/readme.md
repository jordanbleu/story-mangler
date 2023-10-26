# ManglerDb

```Text
⚠ 
Note: This project is a class library but don't reference it as code anywhere.
```

This is the repository where scripts are added.  The database is a MongoDb.

## Accessing the database

### Rider

For a bit of outdated information: https://www.jetbrains.com/help/rider/Managing_data_sources.html#27824ab0

* Start the docker container
* Open the `database` window View > Tool Windows > Database
* Click the plus / Connect to database 
  * Add datasource manually
  * For datasource, select mongodb
  * Leave default server host / port
  * username is `root`, password is `password`
  * database is 'manglerDb'

#### Notes:
* Since rider doesn't attach a debugger to mongo it will keep running if you click the stop button
  * Use the docker console to stop it with `docker compose down`
* Data outside the mangler database will persist even after terminating.  To dump everything, use the command `docker-compose down -v`
  * Note that this will require you to reconnect to the db after rebuilding.
  * Also note that this will delete all the containers (which is fine, they'll just be rebuilt)

## Development

### mongo-init.js

* 