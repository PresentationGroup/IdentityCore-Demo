using Authentication.IdentityCoreConfiguration;
using Domain.BusinessObjects;
using Domain.Users;
using EFSteressTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace EFSteressTest.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        private Authentication.Configuration.Config.IAuthenticationConfig _authConfig;
        public HomeController(Authentication.Configuration.Config.AuthenticationConfig authConfig)
        {
            _authConfig = authConfig;
        }


        [HttpGet("Test")]
        public void Test()
        {

            var names = new List<string>();
            names.Add("name1");
            names.Add("name2");
            names.Add("name3");
            names.Add("name4");
            names.Add("name5");

            //
            names.ForEach(Console.WriteLine);
            //
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            //
            names.ForEach(delegate (string name)
            {
                Console.WriteLine(name);
            });
        }

        //public IActionResult Register()
        //{
        //    return View();
        //}
        [AllowAnonymous]
        [HttpPost("Register")]
        //public IActionResult Register(RegisterViewModel model)
        public void Register()
        {
            //if (!ModelState.IsValid)
            //    return View(model);
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < 100; i++)
            {
                #region UserDTO
                Random rd = new Random();
                int rand_num = rd.Next(1, 20000000);
                int rand_e = rd.Next(1, 500000);
                RegisterViewModel model = new RegisterViewModel()
                {
                    UserName = rand_num.ToString().PadLeft(10, '0'),
                    FullName = rand_num.ToString() + " Tata",
                    Password = "!@fdgfdf",
                    RePassword = "!@fdgfdf",
                    Email = rand_e.ToString() + "x@gmail.com",
                    PhoneNumber = "09192458633",

                };
                #endregion UserDTO


                UserModel userModel = new UserModel();
                userModel.FullName= model.FullName;
                userModel.Password= model.Password;
                userModel.UserName= model.UserName;
                userModel.RePassword= model.RePassword;

                _authConfig.RegisterUser(userModel, "IdentityCore");
               
            }
            stopWatch.Stop();
            ;

        }

      

        [AllowAnonymous]
        [HttpPost("Login")]
        public void Login()
        {
            Repository repository = new Repository();
            Random rd = new Random();
            var q = repository.Data[(int)rd.Next(0, repository.Data.Count() - 1)];

            LoginViewModel model = new LoginViewModel
            {
                UserName = "0015021764",//q.PadLeft(10, '0'),
                Password = "!@fdgfdf"
            };



            //var user = _userManager.FindByNameAsync(model.UserName).Result;
            //if (user == null)
            //{ }
            //else { }
            //_signInManager.SignOutAsync();
            //var result = _signInManager.PasswordSignInAsync(user, model.Password, model.IsPersistent, true).Result;
            //if (result.Succeeded)
            //{ }
            //else { }








            //2
            //var result = _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, true).Result;
            //if (result.Succeeded)
            //{ }
            //else { }

            //3
            //var user = new User()
            //{
            //    UserName = q.PadLeft(10, '0'),
            //    NormalizedUserName = q.PadLeft(10, '0'),
            //    PasswordHash = "AQAAAAEAACcQAAAAELvvgy5tiGYZbp0jwv5lVUV6nqsbxexPQ6iYkLiSNeWB7OEkcR2egprdXqAWIX9lHw== "// "!@fdgfdf__"
            //};

            //var result = _signInManager.PasswordSignInAsync(user, model.Password, false, true).Result;
            //if (result.Succeeded)
            //{ }
            //else { }

            //if (!result.Succeeded)
            //    ModelState.AddModelError(string.Empty, "خطا در زمان ورود کاربر");


        }

        [HttpPost("Profile")]
        public void Profile()
        {

        }


    }


    public class Repository
    {
        public List<string> Data { get; set; }
        public Repository()
        {
            Data = new List<string>();
            Data.Add("15921617");
            Data.Add("1331863");
            Data.Add("3791130");
            Data.Add("15568454");
            Data.Add("4313678");
            Data.Add("2696353");
            Data.Add("14339075");
            Data.Add("14836624");
            Data.Add("9824044");
            Data.Add("904255");
            Data.Add("2797687");
            Data.Add("10373401");
            Data.Add("4229273");
            Data.Add("11825908");
            Data.Add("317870");
            Data.Add("425763");
            Data.Add("10391512");
            Data.Add("2066125");
            Data.Add("7654585");
            Data.Add("18840637");
            Data.Add("12494109");
            Data.Add("1557823");
            Data.Add("17919391");
            Data.Add("6082506");
            Data.Add("10850624");
            Data.Add("17883171");
            Data.Add("13721512");
            Data.Add("17700840");
            Data.Add("11715456");
            Data.Add("3894579");
            Data.Add("14988075");
            Data.Add("7999548");
            Data.Add("307798");
            Data.Add("16213214");
            Data.Add("15479447");
            Data.Add("1376833");
            Data.Add("13423439");
            Data.Add("5734300");
            Data.Add("8279387");
            Data.Add("17702731");
            Data.Add("15398859");
            Data.Add("18656660");
            Data.Add("12327351");
            Data.Add("2847938");
            Data.Add("1260379");
            Data.Add("1300541");
            Data.Add("7267603");
            Data.Add("2014640");
            Data.Add("4959106");
            Data.Add("8424059");
            Data.Add("5581107");
            Data.Add("3237394");
            Data.Add("10887796");
            Data.Add("10283128");
            Data.Add("14905500");
            Data.Add("18023930");
            Data.Add("14653039");
            Data.Add("14506445");
            Data.Add("5834040");
            Data.Add("7179800");
            Data.Add("2051518");
            Data.Add("14539803");
            Data.Add("19314823");
            Data.Add("6191533");
            Data.Add("12898354");
            Data.Add("19553666");
            Data.Add("5514463");
            Data.Add("6843367");
            Data.Add("2181946");
            Data.Add("4552113");
            Data.Add("12193586");
            Data.Add("7291974");
            Data.Add("18656548");
            Data.Add("4174534");
            Data.Add("2590146");
            Data.Add("9537478");
            Data.Add("12836561");
            Data.Add("9342238");
            Data.Add("19958200");
            Data.Add("8878596");
            Data.Add("6632295");
            Data.Add("6553276");
            Data.Add("17947678");
            Data.Add("3488666");
            Data.Add("2421875");
            Data.Add("9546318");
            Data.Add("2583575");
            Data.Add("741441");
            Data.Add("10299205");
            Data.Add("8616895");
            Data.Add("19168147");
            Data.Add("6007109");
            Data.Add("6381897");
            Data.Add("2786879");
            Data.Add("943228");
            Data.Add("4083254");
            Data.Add("6267608");
            Data.Add("13014468");
            Data.Add("15967098");
            Data.Add("18268102");
            Data.Add("15236562");
            Data.Add("6230531");
            Data.Add("16174652");
            Data.Add("4967457");
            Data.Add("8502096");
            Data.Add("15185267");
            Data.Add("7658982");
            Data.Add("9332810");
            Data.Add("507627");
            Data.Add("11799542");
            Data.Add("15668056");
            Data.Add("3302819");
            Data.Add("4772782");
            Data.Add("10936190");
            Data.Add("1886824");
            Data.Add("10237262");
            Data.Add("581355");
            Data.Add("961648");
            Data.Add("7187257");
            Data.Add("5997749");
            Data.Add("3527133");
            Data.Add("5056280");
            Data.Add("504110");
            Data.Add("17968591");
            Data.Add("1999655");
            Data.Add("7116226");
            Data.Add("1632193");
            Data.Add("4420261");
            Data.Add("19084206");
            Data.Add("12792037");
            Data.Add("3801857");
            Data.Add("17128583");
            Data.Add("17194645");
            Data.Add("19155008");
            Data.Add("17836805");
            Data.Add("15512278");
            Data.Add("19420937");
            Data.Add("7950923");
            Data.Add("4323531");
            Data.Add("12404813");
            Data.Add("12063870");
            Data.Add("13131057");
            Data.Add("1141235");
            Data.Add("9124278");
            Data.Add("3439006");
            Data.Add("19448612");
            Data.Add("4793158");
            Data.Add("2271683");
            Data.Add("1672974");
            Data.Add("17419814");
            Data.Add("1515347");
            Data.Add("5378659");
            Data.Add("9651497");
            Data.Add("12562847");
            Data.Add("6341424");
            Data.Add("5172944");
            Data.Add("3968274");
            Data.Add("5737109");
            Data.Add("18965948");
            Data.Add("9004510");
            Data.Add("2780137");
            Data.Add("17996258");
            Data.Add("16123558");
            Data.Add("4433227");
            Data.Add("3413324");
            Data.Add("13638226");
            Data.Add("5770363");
            Data.Add("2174055");
            Data.Add("14622758");
            Data.Add("578721");
            Data.Add("17897198");
            Data.Add("743427");
            Data.Add("5701302");
            Data.Add("8474369");
            Data.Add("572600");
            Data.Add("2664104");
            Data.Add("19770630");
            Data.Add("10434179");
            Data.Add("7229670");
            Data.Add("19356782");
            Data.Add("3570642");
            Data.Add("10185996");
            Data.Add("1075459");
            Data.Add("18213565");
            Data.Add("5993350");
            Data.Add("18247464");
            Data.Add("16462640");
            Data.Add("18564735");
            Data.Add("4130418");
            Data.Add("18637659");
            Data.Add("13818377");
            Data.Add("3073049");
            Data.Add("14929092");
            Data.Add("13683390");
            Data.Add("18142290");
            Data.Add("10554829");
            Data.Add("146537");
            Data.Add("9959746");
            Data.Add("19538490");
            Data.Add("16715318");
            Data.Add("17722589");
            Data.Add("19960701");
            Data.Add("427185");
            Data.Add("11666370");
            Data.Add("1872888");
            Data.Add("12885216");
            Data.Add("8733473");
            Data.Add("12045121");
            Data.Add("6984305");
            Data.Add("12220371");
            Data.Add("3466440");
            Data.Add("16207725");
            Data.Add("15619252");
            Data.Add("16611528");
            Data.Add("6554629");
            Data.Add("9873808");
            Data.Add("18309223");
            Data.Add("7376691");
            Data.Add("9827657");
            Data.Add("884359");
            Data.Add("3670281");
            Data.Add("16005422");
            Data.Add("11914737");
            Data.Add("9274942");
            Data.Add("11045261");
            Data.Add("18877156");
            Data.Add("12580594");
            Data.Add("7073570");
            Data.Add("13948615");
            Data.Add("19494223");
            Data.Add("7314787");
            Data.Add("1387865");
            Data.Add("6225857");
            Data.Add("5799371");
            Data.Add("12271396");
            Data.Add("19968968");
            Data.Add("6110576");
            Data.Add("17134651");
            Data.Add("18744972");
            Data.Add("6566753");
            Data.Add("6981291");
            Data.Add("6081945");
            Data.Add("15361290");
            Data.Add("15737250");
            Data.Add("9089569");
            Data.Add("3764862");
            Data.Add("9282273");
            Data.Add("12865289");
            Data.Add("16061909");
            Data.Add("5485174");
            Data.Add("8328874");
            Data.Add("634529");
            Data.Add("16657251");
            Data.Add("4400774");
            Data.Add("7925222");
            Data.Add("14386051");
            Data.Add("2097229");
            Data.Add("16761434");
            Data.Add("13198776");
            Data.Add("12932564");
            Data.Add("10555468");
            Data.Add("7967595");
            Data.Add("17391304");
            Data.Add("1002923");
            Data.Add("4336546");
            Data.Add("3698279");
            Data.Add("10561277");
            Data.Add("3469787");
            Data.Add("7633789");
            Data.Add("2076762");
            Data.Add("14753357");
            Data.Add("19435651");
            Data.Add("12106229");
            Data.Add("1643314");
            Data.Add("5749658");
            Data.Add("19527190");
            Data.Add("18570546");
            Data.Add("12503575");
            Data.Add("9178683");
            Data.Add("6577000");
            Data.Add("15068273");
            Data.Add("2736373");
            Data.Add("14966696");
            Data.Add("14479255");
            Data.Add("2067542");
            Data.Add("19723202");
            Data.Add("3406859");
            Data.Add("12143156");
            Data.Add("16345533");
            Data.Add("10725189");
            Data.Add("17614984");
            Data.Add("19191918");
            Data.Add("3555228");
            Data.Add("5066567");
            Data.Add("10959884");
            Data.Add("6020115");
            Data.Add("16026006");
            Data.Add("3062356");
            Data.Add("19549094");
            Data.Add("18934331");
            Data.Add("4472260");
            Data.Add("10331131");
            Data.Add("8748387");
            Data.Add("5440827");
            Data.Add("18389094");
            Data.Add("773749");
            Data.Add("13716038");
            Data.Add("6769376");
            Data.Add("16632244");
            Data.Add("11037913");
            Data.Add("5766012");
            Data.Add("2365746");
            Data.Add("9183874");
            Data.Add("6920014");
            Data.Add("15583630");
            Data.Add("1578982");
            Data.Add("9202160");
            Data.Add("10825185");
            Data.Add("10271898");
            Data.Add("18061409");
            Data.Add("17990178");
            Data.Add("1060206");
            Data.Add("14255997");
            Data.Add("19208182");
            Data.Add("8484471");
            Data.Add("137430");
            Data.Add("3476302");
            Data.Add("16509468");
            Data.Add("18435141");
            Data.Add("7101496");
            Data.Add("12390442");
            Data.Add("15452246");
            Data.Add("7664621");
            Data.Add("15897634");
            Data.Add("3371181");
            Data.Add("6029564");
            Data.Add("11925715");
            Data.Add("6027525");
            Data.Add("8584622");
            Data.Add("332649");
            Data.Add("13901828");
            Data.Add("1382779");
            Data.Add("718392");
            Data.Add("15088803");
            Data.Add("2836387");
            Data.Add("763508");
            Data.Add("7294020");
            Data.Add("13493957");
            Data.Add("16324614");
            Data.Add("11565791");
            Data.Add("15527313");
            Data.Add("15411438");
            Data.Add("19960630");
            Data.Add("14958076");
            Data.Add("3047737");
            Data.Add("9098161");
            Data.Add("4980519");
            Data.Add("1885389");
            Data.Add("7333579");
            Data.Add("2923876");
            Data.Add("16336389");
            Data.Add("19357416");
            Data.Add("13392805");
            Data.Add("1288764");
            Data.Add("850223");
            Data.Add("17660172");
            Data.Add("6113798");
            Data.Add("18383141");
            Data.Add("16053992");
            Data.Add("1681176");
            Data.Add("9858871");
            Data.Add("10602279");
            Data.Add("17500741");
            Data.Add("14251196");
            Data.Add("10121235");
            Data.Add("13297659");
            Data.Add("10421111");
            Data.Add("8623461");
            Data.Add("17681521");
            Data.Add("18670745");
            Data.Add("4335907");
            Data.Add("5983400");
            Data.Add("2979904");
            Data.Add("14006327");
            Data.Add("8947681");
            Data.Add("2044670");
            Data.Add("18597063");
            Data.Add("19881967");
            Data.Add("1422257");
            Data.Add("18092577");
            Data.Add("784526");
            Data.Add("15607642");
            Data.Add("14365155");
            Data.Add("4402384");
            Data.Add("7490810");
            Data.Add("16593207");
            Data.Add("1416726");
            Data.Add("19897951");
            Data.Add("9350");
            Data.Add("15911281");


        }
    }
}
