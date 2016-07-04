using Karma.Services.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Services.ViewModels
{
    public class QuestViewModel
    {
        public long QuestId { get; set; }

        public string Title { get; set; }

        public string Descriptions { get; set; }

        public DateTimeOffset? UpdatedTime { get; set; }

        public string CreatorName { get; set; }

        public string CreatorId { get; set; }

        public string ActorId { get; set; }

        public string ActorName { get; set; }

        public DateTimeOffset DueDate { get; set; }

        public QuestState QuestState { get; set; }

    }
}
