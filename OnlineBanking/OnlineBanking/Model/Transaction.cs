using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBanking.Model
{
    public class Transaction
    {
        [Key]
        public int Transactionid { get; set; }



        public AccountDetails AccountDetails { get; set; }

        //  Account no foregion key
        [ForeignKey("AccountDetails")]
        public int AccountNumber { get; set; }




        public int payeeAccountNo { get; set; }



        public int TransationAmount { get; set; }

        public string TransactionType { get; set; }


        public DateTime TransactionDate { get; set; }
    }
}
