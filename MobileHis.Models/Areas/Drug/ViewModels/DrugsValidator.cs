using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MobileHis.Models.Areas.Drug.ViewModels
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class DrugsValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IEnumerable<DrugsOrderView> drugs = value as IEnumerable<DrugsOrderView>;
            if (drugs == null) { return null; }

            var dupCheck = drugs.GroupBy(g => g.DrugID).Where(g => g.Count() > 1);
            if (dupCheck.Any())
            {
                foreach (var dup in dupCheck) dup.First().Error = "Drug duplicates";
                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            }

            return null;
        }
    }
}