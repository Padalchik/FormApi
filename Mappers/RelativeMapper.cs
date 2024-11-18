using FormApi.Entities;
using FormApi.Models;

namespace FormApi.Mappers
{
    public static class RelativeMapper
    {
        public static RelativeEntity ToEntity(RelativeModel relativeModel)
        {
            var relativeEntity = new RelativeEntity
            {
                Form = FormMapper.ToEntity(relativeModel.Form),
                FirstName = relativeModel.FirstName,
                LastName = relativeModel.LastName,
                MiddleName = relativeModel.MiddleName,
                BirthDate = relativeModel.BirthDate.ToUniversalTime(),
                RelativeType = relativeModel.RelativeType
            };

            return relativeEntity;
        }

        public static RelativeModel ToModel(FormModel formModel, RelativeEntity relativeEntity)
        {
            var createRelativeParams = new Dictionary<string, object>();
            createRelativeParams.Add("FirstName", relativeEntity.FirstName);
            createRelativeParams.Add("LastName", relativeEntity.LastName);
            createRelativeParams.Add("MiddleName", relativeEntity.MiddleName);
            createRelativeParams.Add("RelativeType", relativeEntity.RelativeType);

            var relativeAnswer = RelativeModel.Create(formModel, createRelativeParams);

            if (String.IsNullOrEmpty(relativeAnswer.Error) == false)
                throw new Exception(relativeAnswer.Error);

            if ( relativeAnswer.RelativeModel == null )
                throw new Exception("Не найден `RelativeModel`");

            return relativeAnswer.RelativeModel;
        }
    }
}
