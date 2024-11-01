﻿
using FormApi.Mappers;
using System.Text.Json.Serialization;

namespace FormApi.Entities
{
    public class Form
    {
        // Публичный конструктор по умолчанию, который нужен EF Core
        public Form()
        {
        }

        private Form(Candidate candidate)
        {
            Id = Guid.NewGuid();

            CandidateId = candidate.Id;
            FirstName   = candidate.FirstName;
            LastName    = candidate.LastName;
            MiddleName  = candidate.MiddleName;
        }

        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public virtual List<PhoneRecord> PhoneRecords { get; set; } = new List<PhoneRecord>();

        public virtual List<Relative> Relatives { get; set; } = new List<Relative>();

        public void AddPhoneRecord(PhoneRecord record)
        {
            PhoneRecords.Add(record);
        }

        public Guid AddRelative(Models.Relative relative)
        {
            var relativeEntity = RelativeMapper.ToEntity(relative);

            //relativeEntity.Id = Guid.NewGuid();
            relativeEntity.OwnerId = Id;
            relativeEntity.CreatedDate = DateTime.Now.ToUniversalTime();

            Relatives.Add(relativeEntity);

            return relativeEntity.Id;
        }

        public static (Form Form, string Error) Create(Candidate candidate)
        {
            var error = string.Empty;
            var form = new Form(candidate);

            return (form, error);
        }
    }
}
