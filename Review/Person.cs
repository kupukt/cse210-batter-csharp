using System;
using cse210_batter_csharp.Services;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Scripting;
using System.Collections.Generic;

namespace cse210_batter_csharp
{
    class Person
    {
        string _firstName;
        string _lastName;

        public void setFirstName(string fName)
        {
            _firstName = fName;
        }

        public void setLastName(string lName)
        {
            _lastName = lName;
        }

        public string getFirstName()
        {
            return _firstName;
        }

        public string getLastName()
        {
            return _lastName;
        }
    }
}