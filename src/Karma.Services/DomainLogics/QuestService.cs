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
        /// Quest 조회 (삭제된 것 제외)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<QuestViewModel> Get()
        {
            var quests = DbContext.Quests.Where(x => x.QuestState != Models.Enums.QuestState.Removed).Select(x => new QuestViewModel
            {
                ActorId = x.ActorId,
                ActorName = x.Actor.Name,
                CreatorId = x.CreatorId,
                CreatorName = x.Creator.Name,
                Descriptions = x.Descriptions,
                DueDate = x.DueDate,
                QuestId = x.QuestId,
                Title = x.Title,
                UpdatedTime = x.UpdatedAt,
                QuestState = x.QuestState
            }).ToList();

            return quests;
        }

        /// <summary>
        /// Quest 상세정보
        /// </summary>
        /// <param name="id">Quest id</param>
        /// <returns></returns>
        public QuestViewModel Get(long id)
        {
            var quest = DbContext.Quests.Include(x => x.ActorId).Include(x => x.Creator).Where(x => x.QuestId == id).Select(x => new QuestViewModel
            {
                ActorId = x.ActorId,
                ActorName = x.Actor.Name,
                CreatorId = x.CreatorId,
                CreatorName = x.Creator.Name,
                Descriptions = x.Descriptions,
                DueDate = x.DueDate,
                QuestId = x.QuestId,
                Title = x.Title,
                UpdatedTime = x.UpdatedAt,
                QuestState = x.QuestState
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
                CreatedAt = DateTimeOffset.Now,
                CreatorId = model.CreatorId,
                Descriptions = model.Descriptions,
                DueDate = model.DueDate,
                QuestState = Models.Enums.QuestState.Created,
                Title = model.Title,
                UpdatedAt = DateTimeOffset.Now
            };
            DbContext.Quests.Add(quest);
            DbContext.SaveChanges();

            // TODO: Quest 받는 사람에게 이메일 보내기.

            // TODO: Quest 받는 사람에게 Push Notification
        }

        /// <summary>
        /// Quest 정보 업데이트
        /// </summary>
        /// <param name="model"></param>
        public void Update(QuestViewModel model)
        {
            var quest = DbContext.Quests.Where(x => x.QuestId == model.QuestId).FirstOrDefault();
            if (quest == null) throw new ArgumentNullException("model", "No quest to update");
            
            // 일부 데이터만 업데이트 가능 
            // Actor / Creator는 변경 불가능 
            quest.Descriptions = model.Descriptions;
            quest.Title = model.Title;
            quest.DueDate = model.DueDate;
            quest.QuestState = model.QuestState;
            quest.UpdatedAt = DateTimeOffset.Now;

            DbContext.SaveChanges();

            // TODO: 상태 변경에 따른 Push Notification / Email
            switch(quest.QuestState)
            {
                case Models.Enums.QuestState.Rejected:
                    break;
            }

        }

        /// <summary>
        /// 삭제
        /// 삭제는 State 만 변경한다. 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(long id)
        {
            var quest = DbContext.Quests.Where(x => x.QuestId == id).FirstOrDefault();
            if (quest == null) throw new ArgumentNullException("id", "No quest to update");

            quest.QuestState = Models.Enums.QuestState.Removed;

            DbContext.SaveChanges();

            // TODO: 삭제에 따른 알림
        }
    }
}
