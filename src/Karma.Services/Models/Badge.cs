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
    /// <summary>
    /// 뱃지
    /// </summary>
    public class Badge
    {
        /// <summary>
        /// Badge Id
        /// </summary>
        [Key]
        public long Id { get; set; }
        /// <summary>
        /// Badge Title
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// Badge Descrition
        /// </summary>
        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        /// <summary>
        /// Badge Status 
        /// </summary>
        [Index]
        public PublishState PublishState { get; set; }

        /// <summary>
        /// 뱃지를 가진 User 
        /// 한 User는 여러개의 뱃지를 가질 수 있다. M-to-M
        /// </summary>
        public virtual ICollection<User> Users { get; set; }
    }
}
