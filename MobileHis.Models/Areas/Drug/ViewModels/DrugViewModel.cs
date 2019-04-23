using MobileHis.Data;
using MobileHis.Models.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Transactions;

namespace MobileHis.Models.Areas.Drug.ViewModels
{
    public class DrugViewModel //: absDrugComponent
    {
        public DrugViewModel() { }
        public DrugViewModel(Data.Drug drug)
        {
            GID = drug.GID;
            DrugCode = drug.DrugCode;
            OrderCode = drug.OrderCode;
            Title = drug.Title;
            DrugStockAmount = drug.DrugStock.Sum(a => a.CurrentStock);

        }
        public static DrugViewModel Load(MobileHis.Data.Drug drug, DrugCost cost)
        {
            var v = new DrugViewModel();
            v.GID = drug.GID;
            v.Title = drug.Title;
            v.DrugCode = drug.DrugCode;
            v.OrderCode = drug.OrderCode;
            //v.Form = drug.Form;
            v.DrugType = drug.DrugType;
            v.Unit = drug.Unit;
            //v.Price = cost == null || !cost.Price.HasValue ? 0 : Convert.ToDecimal(cost.Price);
            v.Price = cost == null ? 0 : Convert.ToDecimal(cost.Price);
            v.IsHighRisk = drug.IsHighRisk;
            v.IsPediatrics = drug.IsPediatrics;
            if (drug.DrugAppearance != null)
            {
                v.Shape = drug.DrugAppearance.Shape;
                v.MajorType = drug.DrugAppearance.MajorType;
                v.Color = drug.DrugAppearance.Color;
            }
            v.InitialFee = cost == null ? 0 : cost.InitialFee;
            v.DailyFee = cost == null ? 0 : cost.DailyFee;
            v.PatientFrom = drug.PatientFromType;
            v.Formulation = drug.Formulation;
            v.SubCategory = drug.SubCategory;
            v.DrugStockAmount = drug.DrugStock.Sum(a => a.CurrentStock);
            return v;
        }

        public Guid? GID { get; set; }

        [Required(ErrorMessage = "Brand name is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Drug Code is required")]
        public string DrugCode { get; set; }
        [Required(ErrorMessage = "Order Code is required")]
        public string OrderCode { get; set; }

        //[Required(ErrorMessage = "Form is required")]
        //public string Form { get; set; }

        public System.Web.HttpPostedFileBase Photo { get; set; }

        public string Color { get; set; }

        public int? Unit { get; set; }
        public int? SubCategory { get; set; }
        public int? Formulation { get; set; }

        public string DrugType { get; set; }

        public string MajorType { get; set; }

        public string Shape { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        //[Required(ErrorMessage = "Price must be a number")]      
        public decimal Price { get; set; }

        public bool IsHighRisk { get; set; }

        public bool IsPediatrics { get; set; }

        public PatientFrom? PatientFrom { get; set; }

        public double? InitialFee { get; set; }

        public double? DailyFee { get; set; }
        public decimal DrugStockAmount { get; set; }
        public bool IsDefaultType
        {
            get
            {
                return DrugType == "Default";
            }
        }
        public bool HasAppearance
        {
            get
            {
                return Color != null || MajorType != null || Shape != null;
            }
        }
    }
}