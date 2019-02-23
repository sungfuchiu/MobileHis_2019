using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;


namespace MobileHis.Models.Areas.Exam.ViewModels
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class ExamsValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IEnumerable<ExamsOrderView> drugs = value as IEnumerable<ExamsOrderView>;
            if (drugs == null) { return null; }

            var dupCheck = drugs.GroupBy(g => g.DrugID).Where(g => g.Count() > 1);
            if (dupCheck.Any())
            {
                foreach (var dup in dupCheck) dup.First().Error = "Exam duplicates";
                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            }

            return null;
        }
    }
}