using Karma.Services.Models.Enums;
using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Karma.Services.DataObjects
{
    public class MobileQuest : EntityData
    {
        /// <summary>
        /// 퀘스트 제목
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 퀘스트 설명
        /// </summary>
        public string Descriptions { get; set; }
        /// <summary>
        /// 생성일
        /// </summary>
        public DateTimeOffset CreatedTime { get; set; }
        /// <summary>
        /// 수정일
        /// </summary>
        public DateTimeOffset? UpdatedTime { get; set; }

        /// <summary>
        /// 퀘스트 만든사람 아이디
        /// </summary>
        public string CreatorId { get; set; }

        /// <summary>
        /// 퀘스트 만든사람 이름
        /// </summary>
        public string CreatorName { get; set; }

        /// <summary>
        /// 퀘스트 수행자 아이디
        /// </summary>
        public string ActorId { get; set; }

        /// <summary>
        /// 퀘스트 수행자
        /// </summary>
        public string ActorName { get; set; }

        /// <summary>
        /// 퀘스트 마감 요청일 
        /// </summary>
        public DateTimeOffset DueDate { get; set; }

        /// <summary>
        /// 퀘스트 상태
        /// </summary>
        public QuestState QuestState { get; set; }
    }
}