using Microsoft.AspNetCore.Mvc;
using TestForCRUD.Models.Reserve;
using TestForCRUD.Reserve.Service.Services;
using TestForCRUD.ViewModel.Reserve;

namespace TestForCRUDApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReserveController : ControllerBase
    {
        private static readonly string[] FakeReserveUserName = new[]
        {
            "張參", "李寺", "陳武", "王陸", "吳戚", "許芭"
        };

        private ReserveService _reserveService;
        private readonly ILogger<ReserveController> _logger;

        public ReserveController(ILogger<ReserveController> logger)
        {
            _logger = logger;
        }

        //測試API
        [HttpGet(Name = "GetFakeList")]
        public IEnumerable<Reserve> GetFakeList()
        {
            return Enumerable.Range(1, 5).Select(index => new Reserve
            {
                ID= index,
                ReserveUserName = FakeReserveUserName[index],
                ReserveUserPhone="",
                NumberOfPeople=1,
                ReserveDate = DateTime.Now.AddDays(index)
            })
            .ToArray();
        }

        //先建立一個假的資料
        private static List<Reserve> _reserves = new List<Reserve>();

        [HttpGet]
        [Route("{id}")]
        public Reserve Get([FromRoute] int id)
        {
            return _reserves.FirstOrDefault(r => r.ID == id);
        }


        //簡單建立CRUD雛形
        /// <summary>
        /// 新增預約
        /// </summary>
        /// <param name="viewModel">畫面預約資訊</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Insert([FromBody] ReserveViewModel viewModel)
        {
            _reserves.Add(new Reserve
            {
                ID = _reserves.Any() ? _reserves.Max(r => r.ID) + 1 : 0, // 防呆，如果沒資料就從 0 開始
                ReserveUserName = viewModel.ReserveUserName,
                ReserveUserPhone = viewModel.ReserveUserPhone,
                NumberOfPeople = viewModel.NumberOfPeople,
                ReserveDate = viewModel.ReserveDate
            }) ;

            return Ok();
        }

        /// <summary>
        /// 更新預約
        /// </summary>
        /// <param name="id">預約號碼</param>
        /// <param name="viewModel">畫面預約資訊</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(
            [FromRoute] int id,
            [FromBody] ReserveViewModel viewModel)
        {
            var targetReserveData = _reserves.FirstOrDefault(r => r.ID == id);
            if (targetReserveData is null)
            {
                return NotFound();
            }

            targetReserveData.ReserveUserName = viewModel.ReserveUserName;
            targetReserveData.ReserveUserPhone = viewModel.ReserveUserPhone;
            targetReserveData.NumberOfPeople = viewModel.NumberOfPeople;
            targetReserveData.ReserveDate= viewModel.ReserveDate;

            return Ok();
        }

        /// <summary>
        /// 刪除預約
        /// </summary>
        /// <param name="id">預約號碼</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _reserves.RemoveAll(r => r.ID == id);
            return Ok();
        }
    }
}
