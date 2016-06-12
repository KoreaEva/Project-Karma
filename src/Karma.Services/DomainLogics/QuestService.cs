using Karma.Services.DomainLogics.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karma.Services.ViewModels;
using Karma.Services.Models;
using System.Data.Entity;

namespace Karma.Services.DomainLogics
{
    public class QuestService : IQuestService
    {
        private ApplicationDbContext DbContext;

        public QuestService(ApplicationDbContext context)
        {
            DbContext = context;
        }

        /// <summary>
        /// Quest 상세정보
        /// </summary>
        /// <param name="id">Quest id</param>
        /// <returns></returns>
        public QuestViewModel Get(long id)
        {
            var quest = DbContext.Quests.Include(x => x.ActorId).Include(x => x.Creator).Where(x => x.Id == id).Select(x => new QuestViewModel
            {
                ActorId = x.ActorId,
                ActorName = x.Actor.Name,
                CreatorId = x.CreatorId,
                CreatorName = x.Creator.Name,
                Descriptions = x.Descriptions,
                DueDate = x.DueDate,
                Id = x.Id,
                Title = x.Title,
                UpdatedTime = x.UpdatedTime
            }).FirstOrDefault();

            return quest;
        }

        /// <summary>
        /// Quest 추가 / 알림
        /// </summary>
        /// <param name="model">추가할 Quest 정보</param>
        public void Add(QuestViewModel model)
        {
            var quest = new Quest
            {
                ActorId = model.ActorId,
                CreatedTime = DateTimeOffset.Now,
                CreatorId = model.CreatorId,
                Descriptions = model.Descriptions,
                DueDate = model.DueDate,
                QuestState = Models.Enums.QuestState.Created,
                Title = model.Title,
                UpdatedTime = DateTimeOffset.Now
            };
            DbContext.Quests.Add(quest);
            DbContext.SaveChanges();

            // TODO: Quest 받는 사람에게 이메일 보내기.

            // TODO: Quest 받는 사람에게 Push Notification
        }
    }
}
