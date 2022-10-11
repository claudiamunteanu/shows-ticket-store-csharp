using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.model;
using app.services;

namespace app.server.validators
{
    public class UserValidator : Validator<User>
    {
        public void Validate(List<string> data)
        {
            String errors = "";

            if (data.ElementAt(0).Equals(""))
            {
                errors += "The username cannot be empty!\n";
            }

            if (data.ElementAt(1).Equals(""))
            {
                errors += "The password cannot be empty!\n";
            }

            if (!errors.Equals(""))
            {
                throw new AppException(errors);
            }
        }
    }
}
