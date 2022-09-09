using System;

namespace Financio.Domain.Validator
{
    public class ResponseErrors<T>
    {
        List<FluentValidation.Results.ValidationFailure> _errors;
        public ResponseErrors(List<FluentValidation.Results.ValidationFailure> errors)
        {
            _errors = errors;
        }

        public Dictionary<string, Dictionary<string, string>> GetErrors()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (var errorObj in _errors)
            {
                if (!result.ContainsKey(errorObj.PropertyName))
                {
                    result.Add(errorObj.PropertyName, errorObj.ErrorMessage);
                }
            }
            Dictionary<string, Dictionary<string, string>> errorMap = new Dictionary<string, Dictionary<string, string>>();
            errorMap.Add("errors", result);
            return errorMap;
        }
       
    }
}
