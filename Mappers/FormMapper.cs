using FormApi.Entities;
using FormApi.Models;

namespace FormApi.Mappers
{
    public class FormMapper
    {
        public static FormEntity ToEntity(FormModel formModel)
        {
            var formEntity = new FormEntity();
            formEntity.FirstName  = formModel.FirstName;
            formEntity.LastName   = formModel.LastName;
            formEntity.MiddleName = formModel.MiddleName;

            formModel.PhoneRecords.Select(q => q.Id).ToList().ForEach(id => formEntity.PhoneRecords.Add(id));
            //Relative

            return formEntity;
        }

        public static FormModel ToModel(FormEntity formEntity)
        {
            var candidate = new Candidate
            {
                FirstName  = formEntity.FirstName,
                LastName   = formEntity.LastName,
                MiddleName = formEntity.MiddleName
            };

            var formModel = new FormModel(candidate);

            //formModel.AddPhoneRecordPhoneRecords = 
            //formEntity.PhoneRecords.ForEach(pr =>
            //{
            //    PhoneRecord phoneRecord = new PhoneRecord();
            //    phoneRecord.PhoneNumber =
            //    formModel.AddPhoneRecord(pr)
            //});

            return formModel;
        }
    }
}
