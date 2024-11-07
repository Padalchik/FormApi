using FormApi.Entities;

namespace FormApi.Mappers
{
    public static class RelativeMapper
    {
        public static Entities.Relative ToEntity(Models.Relative relativeModel)
        {
            var relativeEntity = new Entities.Relative
            {
                FirstName    = relativeModel.FirstName,
                LastName     = relativeModel.LastName,
                MiddleName   = relativeModel.MiddleName,
                BirthDate    = relativeModel.BirthDate.ToUniversalTime(),
                RelativeType = relativeModel.RelativeType
            };

            return relativeEntity;
        }

        public static Models.Relative ToModel(FormEntity form, Entities.Relative relativeEntity)
        {
            var relativeModel = new Models.Relative(form, relativeEntity.FirstName, relativeEntity.LastName, relativeEntity.MiddleName, relativeEntity.RelativeType);

            return relativeModel;
        }
    }
}
