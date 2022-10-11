using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.server.validators
{
    public interface Validator<T>
    {
        void Validate(List<String> data);
    }
}
