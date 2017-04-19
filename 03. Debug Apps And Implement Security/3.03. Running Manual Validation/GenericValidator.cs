using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public static class GenericValidator<T>
{
    public static IList<ValidationResult> Validate(T entity)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(entity, null, null);
        Validator.TryValidateObject(entity, context, results);
        return results;
    }
}