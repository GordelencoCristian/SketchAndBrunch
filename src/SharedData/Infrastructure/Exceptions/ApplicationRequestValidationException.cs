using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedData.Infrastructure.Exceptions
{
    public class ApplicationRequestValidationException : Exception
    {
        public ApplicationRequestValidationException(List<ValidationMessage> validationMessages)
        {
            ValidationMessages = validationMessages;
        }

        public List<ValidationMessage> ValidationMessages { private set; get; }
    }

    public class ValidationMessage
    {
        public string MessageText { get; set; }
        public string Code { get; set; }
    }
}
