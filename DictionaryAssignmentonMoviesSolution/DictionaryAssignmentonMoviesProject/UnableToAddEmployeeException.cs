using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryAssignmentonMoviesProject
{
    public class UnableToAddEmployeeException:ApplicationException
    {
        string _message;
        public UnableToAddEmployeeException()
        {
            _message = "Unable to add employee because of ID duplication. Try Again";

        }
        public override string Message => _message;
    }
}
