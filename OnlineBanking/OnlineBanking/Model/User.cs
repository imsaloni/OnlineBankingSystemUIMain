using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBanking.Model
{
    public class User
    {
        public int Userid { get; set; }
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string AadharNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Occupation { get; set; }
        public string AnnualIncome { get; set; }
        public string pwd { get; set; }
        public DateTime MemberSince { get; set; }
}
}
