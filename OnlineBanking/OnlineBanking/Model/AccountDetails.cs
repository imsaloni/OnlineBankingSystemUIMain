using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBanking.Model
{
    public class AccountDetails
    {
        [Key]
        public int AccountNumber { get; set; }

        //This is for foreign key refrence
        
       

     
        public User User { get; set; }
        [ForeignKey("User")]
        public int Userid { get; set; }

        public int Balance { get; set; }
    }
}
