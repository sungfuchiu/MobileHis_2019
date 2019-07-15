using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileHis.Data
{
    public class Account2Role
    {
        public Account2Role() { }
        public Account2Role(int roleID)
        {
            Role_id = roleID;
        }
        public Account2Role(int accountID, int roleID)
        {
            Account_id = accountID;
            Role_id = roleID;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int Role_id { get; set; }
        public int Account_id { get; set; }


        [ForeignKey("Role_id")]
        public virtual Role Role { get; set; }
        [ForeignKey("Account_id")]
        public virtual Account Account { get; set; }
    }

}