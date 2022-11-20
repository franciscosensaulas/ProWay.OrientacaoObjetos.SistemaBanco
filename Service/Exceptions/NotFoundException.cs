using Globalization.Resources;
using Service.Extensions;

namespace Service.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entity, int id)
            : base(Resource.EntityNotFound.Format(entity, id))
        {

        }
    }
}
