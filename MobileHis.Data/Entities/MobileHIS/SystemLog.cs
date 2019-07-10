using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MobileHis.Data
{
    public class SystemLog : IUserEntity
    {
        public SystemLog()
        {
            CreateAt = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(50)]
        public string Message { get; set; }
        [MaxLength(20)]
        public string Controller { get; set; }
        [MaxLength(20)]
        public string Action { get; set; }
        [MaxLength(20)]
        public string FunctionType { get; set; }
        [MaxLength(20)]
        public string ModUser { get; set; }
        public string UserIPAddress { get; set; }
        public DateTime CreateAt { get; set; }


    }
}