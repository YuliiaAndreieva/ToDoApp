using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ToDoApp.BLL.Mapping;

namespace ToDoApp.API.Mapping;

public static class ErrorResultMapping
{
    public static string ToResponse(this List<Error> errors)
    {
        var errorMessages = errors.Select(error => new
        {
            Code = error.Code,
            Description = error.Description,
            Type = error.Type.ToString(),
            NumericType = error.NumericType,
            Metadata = error.Metadata
        });
        
        return JsonConvert.SerializeObject(errorMessages);
    }
}