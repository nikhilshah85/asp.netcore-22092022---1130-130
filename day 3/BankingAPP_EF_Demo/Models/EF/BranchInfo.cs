using System;
using System.Collections.Generic;

namespace BankingAPP_EF_Demo.Models.EF
{
    public partial class BranchInfo
    {
        public BranchInfo()
        {
            AccountsInfos = new HashSet<AccountsInfo>();
        }

        public int BranchNo { get; set; }
        public string? BranchName { get; set; }
        public string? BranchCity { get; set; }

        public virtual ICollection<AccountsInfo> AccountsInfos { get; set; }
    }
}
