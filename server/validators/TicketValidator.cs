using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.model;
using app.services;

namespace app.server.validators
{
    public class TicketValidator : Validator<Ticket>
    {
        public void Validate(List<String> data)
        {
            String errors = "";

            if (data.ElementAt(0).Equals(""))
            {
                errors += "You have to select a show!\n";
            }

            if (data.ElementAt(1).Equals(""))
            {
                errors += "Buyer name cannot be empty!\n";
            }

            if (!errors.Equals(""))
            {
                throw new AppException(errors);
            }
        }
    }
}
