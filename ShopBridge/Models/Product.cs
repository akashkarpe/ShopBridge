using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product: IValidatableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if ( Math.Abs(Price) < 0)
            {
                yield return new ValidationResult("Price is Invalid");
            }

            if (Name == null || Name == string.Empty)
            {
                yield return new ValidationResult("Name should not be Empty");
            }

            if (Description == null || Description == string.Empty)
            {
                yield return new ValidationResult("Description should not be Empty");
            }

        }
    }
}
