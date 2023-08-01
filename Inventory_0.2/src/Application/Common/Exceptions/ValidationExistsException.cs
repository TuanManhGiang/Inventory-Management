using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Inventory_0._2.Application.Common.Exceptions
{ 
public class ValidationExistsException : Exception
{
    public ValidationExistsException(string name) : base($"{name} already exists")
    {
        Errors = new Dictionary<string, string[]>();
    }



    public IDictionary<string, string[]> Errors { get; }
}
}