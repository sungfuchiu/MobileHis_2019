using MobileHis.Data;
using System;

namespace MobileHis.Models.Areas.Drug.ViewModels
{
    public class DrugsCost : MobileHis.Models.Areas.Drug.DrugDecorator
    {
       // private Guid? DrugID ;
        private MobileHISEntities db;
    
        public DrugsCost()
        {     
          db = new MobileHISEntities();         
        }
        
    }
}