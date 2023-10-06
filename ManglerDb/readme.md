# ManglerDb

```Text
⚠ 
Note: This project is a class library as a hack to get 
around Rider's lack of sqlproj support.  Don't reference it as code anywhere.
```

This is the repository where sql scripts are added.  The database is a MySql db.

## Accessing the database

### Rider

For a bit of outdated information: https://www.jetbrains.com/help/rider/Managing_data_sources.html#27824ab0

* Start the docker container
* Open the `database` window View > Tool Windows > Database
* Click the plus / Connect to database 
  * Add datasource manually
  * For datasource, select mysql
  * For server host, leave as localhost
  * For the port, type `3306`
  * username is `root`, password is `password`

#### Notes:
* Since rider doesn't attach a debugger to the mysql it will keep running if you click the stop button
  * Use the docker console to stop it
* Data outside the mangler database will persist even after terminating.  To dump everything, use the command `docker-compose down -v`
  * Note that this will require you to reconnect to the db after rebuilding.
  * Also note that this will delete all the containers (which is fine, they'll just be rebuilt)

## Development

### init.sql

This file defines the database structure.  It gets automatically run by docker on startup.  It should represent the latest schema.


