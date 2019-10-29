using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTwolCore
{
    public class ValidationStatus
    {
        public string Title { get; }
        public string Description { get; }
        public bool IsError { get; }

        public ValidationStatus(string title, string description, bool isError)
        {
            Title = title;
            Description = description;
            IsError = isError;
        }

    }
}
