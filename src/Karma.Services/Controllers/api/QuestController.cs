using Karma.Services.DomainLogics.Interface;
using Karma.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Karma.Services.Controllers.api
{
    public class QuestController : ApiController
    {
        private IQuestService QuestService;

        public QuestController(IQuestService questService)
        {
            QuestService = questService;
        }
        // GET: api/Quest
        public IEnumerable<QuestViewModel> Get()
        {
            var quests = QuestService.Get();
            return quests;
        }

        // GET: api/Quest/5
        public QuestViewModel Get(long id)
        {
            var quest = QuestService.Get(id);
            return quest;
        }

        // POST: api/Quest
        public void Post([FromBody]QuestViewModel value)
        {
            QuestService.Add(value);

        }

        // PUT: api/Quest/5
        public void Put([FromBody]QuestViewModel value)
        {
            QuestService.Update(value);
        }

        // DELETE: api/Quest/5
        public void Delete(long id)
        {
            QuestService.Delete(id);
        }
    }
}
