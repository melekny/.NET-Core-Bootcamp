using System;
using System.ComponentModel.DataAnnotations;

namespace First_App.Models
{
    public class CustomerViewModel
    {

        /*  public CustomerViewModel()
         {
             // This i a Constructor Method.
             Id = Guid.NewGuid();
         }
        */
        public Guid Id { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        // Each table in the database is an "Entity".
        // The data shown on the frontend is the "Model".
        // Classes in the business layer are "DTO (Data Transfer Object)".

        // Data Annotations 
        // The following code structure should be defined in Business Layer.

        [Display(Name = "Yaş")]

        private DateTime _birthdate;
        public DateTime BirthDate
        {
            get { return _birthdate; }
            set
            {
                if (value.Year > 1970)
                {
                    Description = "Customer's date of birth is greater than 1970";
                }

                _birthdate = value;
            }
        }
    }
}


