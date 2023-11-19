using AppSettingManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace AppSettingManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private SocialLoginSettings _socialLoginSettings;
        private SocialLoginSettings _socialLoginSettings1;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IOptions<SocialLoginSettings> options)
        {
            _logger = logger;
            _configuration = configuration;

            // C1
            _socialLoginSettings = new SocialLoginSettings();
            configuration.GetSection("SocialLoginSettings").Bind(_socialLoginSettings);

            // C2
            _socialLoginSettings1 = options.Value;
        }

        public IActionResult Index()
        {
            ViewBag.SendingKey = _configuration["SendingKey"];

            ViewBag.BottomLevelSetting1  = _configuration["FirstLevelSetting:SecondLevelSetting:BottomLevelSetting"];
            ViewBag.BottomLevelSetting2 = _configuration.GetSection("FirstLevelSetting").GetSection("SecondLevelSetting").GetSection("BottomLevelSetting").Value;

            // C1
            ViewBag.FacebookKey1 = _socialLoginSettings.FacebookSettings.Key;
            ViewBag.GoogleKey1 = _socialLoginSettings.GoogleSettings.Key;

            // C1
            ViewBag.FacebookKey2 = _socialLoginSettings1.FacebookSettings.Key;
            ViewBag.GoogleKey2 = _socialLoginSettings1.GoogleSettings.Key;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
