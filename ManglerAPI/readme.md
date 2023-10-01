# ManglerAPI
### Backend for StoryMangler

## Code Standards

### Folder structure

* Async.
* Only use interfaces where it makes sense 
  * Service classes don't need interfaces, the implementation will always be the same and there will only ever be one implementation
  * Repos probably should have interfaces though, so we can easily swap data sources

#### Entities 

* Entities are DTO objects for database CRUD operations
* Entities should have only an all-parameter constructor, making them immutable
* One entity per SQL table

#### Models

* Exposed directly as contracts in the API
* Use swagger annotations
* Always have a request and response model for every controller action
  * Follow naming Conventions: {ControllerName}{HttpMethod}{Request/Response}


#### Repositories

* Always use interfaces for repos
* Generally repos are one to one with a sql table but don't have to be
* 
