using FluentValidation.Results;
using System.Collections.Generic;

namespace NetWebApp.Models
{

    public class Errors : List<Error>
    {
        public Errors() { }

        public Errors(IList<ValidationFailure> errors)
        {
            foreach (var error in errors) this.Add(new Error(error));
        }
    }
}