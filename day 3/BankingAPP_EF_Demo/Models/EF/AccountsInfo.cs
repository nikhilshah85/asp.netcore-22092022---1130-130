using System;
using System.Collections.Generic;

namespace BankingAPP_EF_Demo.Models.EF
{
    public partial class AccountsInfo
    {
        public int AccNo { get; set; }
        public string? AccName { get; set; }
        public string? AccType { get; set; }
        public int? AccBalance { get; set; }
        public int? AccBranch { get; set; }

        public virtual BranchInfo? AccBranchNavigation { get; set; }
    }
}
