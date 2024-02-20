using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForCRUD.Models.Reserve
{
    public class Reserve
    {
        /// <summary>
        /// 預約號碼
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 預約人員名稱
        /// </summary>
        public string? ReserveUserName { get; set; }
        /// <summary>
        /// 預約人員電話
        /// </summary>
        public string? ReserveUserPhone { get; set; }
        /// <summary>
        /// 預約人數
        /// </summary>
        public int NumberOfPeople { get; set; }
        /// <summary>
        /// 預約日期
        /// </summary>
        public DateTime ReserveDate { get; set; }
    }
}
