﻿using Karma.Services.Models.Enums;
using Microsoft.Azure.Mobile.Server.Tables;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Karma.Services.Models
{
    public class Quest
    {
        #region "For Mobile Offline Sync"

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Index]
        [TableColumn(TableColumnType.CreatedAt)]
        public DateTimeOffset? CreatedAt { get; set; }

        [TableColumn(TableColumnType.Deleted)]
        public bool Deleted { get; set; }

        [Index]
        [TableColumn(TableColumnType.Id)]
        [MaxLength(36)]
        public string Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [TableColumn(TableColumnType.UpdatedAt)]
        public DateTimeOffset? UpdatedAt { get; set; }

        [TableColumn(TableColumnType.Version)]
        [Timestamp]
        public byte[] Version { get; set; }

        #endregion
        /// <summary>
        /// 아이디
        /// </summary>
        [Key]
        public long QuestId { get; set; }
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
        [Required]
        public DateTimeOffset DueDate { get; set; }

        /// <summary>
        /// 퀘스트 상태
        /// </summary>
        [Index]
        public QuestState QuestState { get; set; }
    }
}