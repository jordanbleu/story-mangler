using Microsoft.AspNetCore.Mvc;

namespace ManglerAPI.Infrastructure.Mvc;

public class InternalServerErrorObjectResult : ObjectResult
{
    public InternalServerErrorObjectResult(object obj) : base(obj)
    {
        StatusCode = 500;
    }
    
}

