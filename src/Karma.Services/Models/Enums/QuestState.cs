using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Karma.Services.Models.Enums
{
    public enum QuestState
    {
        Created = 0,
        Accepted = 1,
        Committed = 2, 
        Rejected = 3,
        Removed = 4
    }
}