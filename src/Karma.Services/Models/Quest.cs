using Karma.Services.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Services.Models
{
    public class Quest
    {
        /// <summary>
        /// 아이디
        /// </summary>
        [Key]
        public long Id { get; set; }
        /// <summary>
        /// 퀘스트 제목
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 퀘스트 설명
        /// </summary>
        [Column(TypeName = "ntext")]
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
        /// 퀘스트 만든사람 Navi property
        /// </summary>
        public User Creator { get; set; }

        /// <summary>
        /// 퀘스트 수행자 아이디
        /// </summary>
        public string ActorId { get; set; }

        /// <summary>
        /// 퀘스트 수행자
        /// </summary>
        public User Actor { get; set; }

        /// <summary>
        /// 퀘스트 마감 요청일 
        /// </summary>
        public DateTimeOffset DueDate { get; set; }

        /// <summary>
        /// 퀘스트 상태
        /// </summary>
        [Index]
        public QuestState QuestState { get; set; }


    }
}
