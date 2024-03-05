using FluentValidation.Results;
using SisNet.Api.Models;

namespace SisNet.Api.Adapters
{
    public static class ValidationAdapter
    {
        public static List<ValidationErrorModel> Parse(IEnumerable<ValidationFailure> errors)
        {
            List<ValidationErrorModel> result = errors.Select(er => new { er.PropertyName,Errors = er.ErrorMessage })
                                                      .GroupBy(g => g.PropertyName).ToList()
                                                      .Select(s => new ValidationErrorModel 
                                                        { 
                                                            PropertyName = s.Key, 
                                                            Errors = s.Select(e => e.Errors).ToList() 
                                                        })
                                                      .ToList();
                
            return result;
        }
    }
}
