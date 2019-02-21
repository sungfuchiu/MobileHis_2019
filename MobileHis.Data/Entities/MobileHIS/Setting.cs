using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHis.Data
{
    public class Setting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? ParentId { get; set; }

        public string SettingName { get; set; }

        public string Value { get; set; }

        public bool Deletable { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public int CreatedBy { get; set; }

        #region ForeignKey
        [ForeignKey("ParentId")]
        public virtual Setting ParentSetting { get; set; }
        /// <summary>
        /// created by account
        /// </summary>
        [ForeignKey("CreatedBy")]
        public virtual Account Account { get; set; }
        #endregion

        #region iCollection
        public virtual ICollection<Setting> Settings { get; set; }
        #endregion
    }
}
