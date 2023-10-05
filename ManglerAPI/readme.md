# ManglerAPI
### Backend for StoryMangler

## Code Standards

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


## Controllers

* Every single controller method needs a `[ProducesResponseType]` attribute for success responses.  This is used by the code gen process.
* Other http status codes are registered automatically as returning the `ErrorResponse`.
* If a method doesn't return anything, as good practice add `[ProducesResponseType(StatusCodes.Status204NoContent)]`.  
This isn't needed by the client generator but it tells swagger consumers what to expect.

## REST

* Idempotent controller methods
* Use JSON for everything, no plaintext or anything weird.
* No verbs in endpoints, only nouns.  Use the HTTP method as the noun.  For example, DONT do 'POST /story/delete/{id}' do `DELETE /story/{id}`
* Nest routes within endpoints in a logical way.  Example, a story has storylines -> `GET /story/{id}/storylines`
* (not a characteristic of REST technically) but keep presentation logic OUT of the API.  API is data driven, return data only.