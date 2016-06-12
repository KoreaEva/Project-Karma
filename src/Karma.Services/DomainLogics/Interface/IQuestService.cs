using Karma.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Services.DomainLogics.Interface
{
    public interface IQuestService
    {
        QuestViewModel Get(long id);
        void Add(QuestViewModel model);
        void Update(QuestViewModel model);
        void Delete(long id);
        IEnumerable<QuestViewModel> Get();
    }
}
