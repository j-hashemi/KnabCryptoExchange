using System;
using System.ComponentModel.DataAnnotations;

namespace Exchange.Domain.Entity
{
    public class Currency : BusinessEntity
    {
        protected Currency() { }
        public Currency(string code, string name,string countryCode)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException(nameof(code));
            Code = code;

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            Name = name;

            CountryCode=countryCode ;
        }

        [Required]
        public string Code { get;private set; }

        [Required]
        public string Name { get; private set; }

        public string CountryCode { get; set; }

    }
}