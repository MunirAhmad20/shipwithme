using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using System.Net.Mail;
using System.Net;
using Money_Finder.Models;
using shipwithme.Models;
using Newtonsoft.Json;
using Nancy.Json;
using Microsoft.EntityFrameworkCore;

namespace Money_Finder.Controllers
{
    public class customerController :Controller
    {
        AppDBContext d = new AppDBContext();

        public static string response;
        public static string responserecby
        {
            get { return response; }
            set { response = value; }

        }
        public static string profile;
        public static string recby
        {
            get { return profile; }
            set { profile = value; }
        }
        public static string passport;
        public static string recbypassport
        {
            get { return passport; }
            set { passport = value; }
        }
        public static string UserName;
        public static string recbyUserName
        {
            get { return UserName; }
            set { UserName = value; }
        }
        public IActionResult siteunsub()
        {

            ///ViewBag.site = d.siteunsubscribe.ToList();
            return View();

        }
        [HttpPost]
        public IActionResult isvalid( string password, string email)

        {
            var check = d.Registration.Where(o => o.email == email && o.Password == password).Count();
            var list = d.Registration.Where(o => o.email == email && o.Password == password).ToList();
            if (check>=1)
            {
                foreach (var i in list)
                {
                    recby = i.ProfileImage;
                    recbyUserName = i.FullName;

                    if (ModelState.IsValid)
                    {
                        var senderEmail = new MailAddress("mail.maeen.online@gmail.com", "SWM");
                        var recievermaill = new MailAddress(email, "Reciever");
                        var pass = "Maeen@804";
                    
                        var sub = "Login Successfully";
                        var body = "Hi "+i.FullName +"!You have logged on to SWM on " + DateTime.Now.ToShortDateString() + "at " + DateTime.Now.ToLongTimeString() + ".If you do not recognize this login attempt,reset through web.";
                        var smtp = new SmtpClient
                        {
                            Host = "smtp.gmail.com",
                            Port = 587,
                            EnableSsl = true,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential(senderEmail.Address, pass)





                        };
                        using (var message = new MailMessage(senderEmail, recievermaill)

                        {
                            Subject = sub,
                            Body = body

                        }
                            )

                        {
                            smtp.Send(message);
                        }

                    }
                    }




                    return RedirectToAction("upcommingflight", "customer");
            }
            else
            {

                return RedirectToAction("login", "public");
            }
           
        }
        public IActionResult addprefrence()
        {
            ViewBag.profile = recby;
            ///ViewBag.site = d.siteunsubscribe.ToList();
            return View();

        }
        public IActionResult submitshopping(string reward, string paymentType, string url, string timeto, string fromtime , string location, string city, string fri, string thu , string wed , string tue, string mon , string sun)
        {
            onlineshopping o = new onlineshopping();
            o.Reward = reward;
            o.PaymentType = paymentType;
            o.url = url;
            o.TimeTo = timeto;
            o.TimeFrom = fromtime;
            o.Location = location;
            o.City = city;
            o.PassengerName = recbyUserName;
            o.Days = thu + sun + mon + tue + wed+fri;
            d.onlineshopping.Add(o);
            d.SaveChanges();
            ///ViewBag.site = d.siteunsubscribe.ToList();
            return Ok();

        }
        public IActionResult myupcommingflight()
        {
          
            
            return View();
        }
        //[HttpGet]
        //public JsonResult AjaxGetCall()
        //{
        //    var employee = d.Flight.Count();


        //    return Json();
        //    //return Json(employee, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        //}
        public IActionResult upcommingflight()
        {
            ViewBag.response = responserecby;
            ViewBag.details = d.Flight.ToList();
            ViewBag.profile = recby;
            ViewBag.city = d.Citylist.ToList();
            ViewBag.country = d.countrylist.ToList();
            ViewBag.airport = d.Airportlist.ToList();
            ViewBag.blacklist = d.Flight.Where(o=> o.FlightStatus== "blacklisted").ToList();

            ViewBag.user = d.Registration.Where(o => o.FullName == recbyUserName).ToList();

            ViewBag.onlineshopping = d.onlineshopping.ToList();

            responserecby = string.Empty;
            return View();
        }
        public IActionResult recievedpurposal()
        {
            ViewBag.profile = recby;
            ViewBag.purposal= d.Createpurposal.OrderByDescending(o => o.Id).ToList();
            ViewBag.recieved = d.Createpurposal.Where(o=> o.PassengerName==recbyUserName).OrderByDescending(o => o.Id).ToList();

            return View();
        }
        public IActionResult createpurposal()
        {
            ViewBag.profile = recby;
            return View();
        }
        public IActionResult purposaldetails()
        {
            ViewBag.profile = recby;
            var purposal = d.Createpurposal.Where(o => o.OwnerName == recbyUserName).ToList();
            ViewBag.purposal = purposal;
            return View();
        }
        public IActionResult flighdetails()
        {


            ViewBag.profile = recby;
            return View();
        }
        [HttpPost]
        public IActionResult submitpurposal(string flightid,  string date,string passengername, string currency, string tch3_22, string tch3, string fromcity, string fromcountry, string fromairport, string tocity, string tocountry, string toairport, string arivaldate, string isnegotionable, string priceperkg, string ppdestination, string pdd, string ppt,string packagetype,string packagesubtype, string morepackage,string tch2, List<IFormFile> files)
        {
            

   
            if (files != null)
            {


                foreach (var file in files)
                {
                    {
                        //Getting FileName
                        var fileName = Path.GetFileName(file.FileName);

                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        //Getting file Extension
                        var fileExtension = Path.GetExtension(fileName);

                        // concatenating  FileName + FileExtension
                        var newfilename = String.Concat(myUniqueFileName, fileExtension);

                        // Combines two strings into a path.
                        var filepath =
           new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedImages")).Root + $@"\{newfilename}";

                        using (FileStream fs = System.IO.File.Create(filepath))
                        {
                            file.CopyTo(fs);
                            fs.Flush();

                        }
                        PurposalImage p = new PurposalImage();
                        p.purposalId = 2;
                        p.PurposalImages = newfilename;
                        d.PurposalImage.Add(p);
                        d.SaveChanges();

                    }
                }
            }
            createpurposal f = new createpurposal();
          
            f.FlightDate = date;
            f.FlightID = flightid;
            f.RequiredWeight = tch3;

            f.AvailableWeight = tch3_22;
            f.PricePerKG = priceperkg;
            f.FromCity = fromcity;
            f.FromCountry = fromcountry;
            f.FromAirport = fromairport;
            f.City = tocity;
            f.Country = tocountry;
            f.ToAirport = toairport;
            f.IsNegotionable = isnegotionable;
            f.PrefferedPickupDestination = ppdestination;
            f.MorePackageSubType = ppt;
            f.PrefferedDeliveryDestination = pdd;
            f.MorePackageSubType = morepackage;
            f.PackageSubType = packagesubtype;
            f.PackageType = packagetype;
            f.PrefferedDeliveryTimeAfterArival = tch2;
            f.OwnerName = recbyUserName;
            f.PassengerName = passengername;
           
            d.Createpurposal.Add(f);
            d.SaveChanges();
            var purposalcount = "";
            var data = d.Flight.Where(o=> o.Id==  Convert.ToInt32(flightid)).ToList();
            var datas = d.Flight.Find(Convert.ToInt32(flightid));
            foreach (var item in data)
            {
                purposalcount = (Convert.ToInt32(item.numberofpurposals) + Convert.ToInt32 (1)).ToString();
            }
            datas.numberofpurposals= purposalcount;
            d.Entry(datas).State = EntityState.Modified;
            d.SaveChanges();

            responserecby = "save";
            return RedirectToAction("upcommingflight", "customer");



        }
        [HttpPost]
        public IActionResult submitpreference(string date, string currency, string tch3_22, string tch3, string fromcity, string fromcountry, string fromairport, string tocity, string tocountry, string toairport, string arivaldate, string isnegotionable, string priceperkg, string ppdestination, string pdd, string ppt, string packagetype, string packagesubtype, string morepackage, string tch2)
        {
     
        Preference f = new Preference();

            f.FlightDate = date;
            f.AvailableWeight = tch3_22;
            f.FromCity = fromcity;
            f.FromCountry = fromcountry;
            f.FromAirport = fromairport;
            f.City = tocity;
            f.Country = tocountry;
            f.ToAirport = toairport;
        
            d.Preference.Add(f);
            d.SaveChanges();
            return Ok();
            //return RedirectToAction("prefrence", "customer");



        }

        [HttpPost]
        public IActionResult submitflight(string date, string currency, string tch3_22,string tch3, string fromcity ,string fromcountry, string fromairport,string tocity,string tocountry,string toairport , string arivaldate, string isnegotionable , string priceperkg, string ppdestination , string pdd , string ppt )
        {

            Flight f = new Flight();
            f.FlightDate = date;
            f.ArivalDate = arivaldate;
            f.AvailableWeight = tch3_22;
            f.PricePerKG = tch3;
            f.FromCity = fromcity;
            f.FromCountry = fromcountry;
            f.FromAirport = fromairport;
            f.Currency = currency;

            f.City = tocity;
            f.Country = tocountry;
            f.ToAirport = toairport;
            f.IsNegotionable = isnegotionable;
            f.PricePerKG = priceperkg;
            f.PrefferedPickupDestination = ppdestination;
            f.PrefferedPackageType = ppt;
            f.PrefferedDeliveryDestination = pdd;
            f.PassengerName = recbyUserName;
            f.FlightStatus = "disapprove";
            f.numberofpurposals = "0";
            f.notify = "foradmin";
            d.Flight.Add(f);
            d.SaveChanges();
            return RedirectToAction("upcommingflight", "customer");


            
        }
      public IActionResult  addpurposal(string tid)
        {
            var find = d.Flight.Where(o => o.Id == Convert.ToInt32(tid)).ToList();
            ViewBag.find = find;
            return View();
        }
        [HttpGet]
        public IActionResult getnotifications()
        {
            var find = d.Flight.Where(o => o.notify == "foruser" && o.PassengerName==recbyUserName).Count();
            var finds = d.Registration.Where(o => o.notify == "foruser" && o.FullName==recbyUserName).Count();
            // var finds = d.p.Where(o => o.notify == "foruser" && o.FullName==recbyUserName).Count();
            var count = find + finds;
            return Json(count);
        }
        public IActionResult addflight()
        {
            ViewBag.profile = recby;
            return View();
        }
        public IActionResult prefrence()
        {
            ViewBag.profile = recby;
            return View();
        }
        public IActionResult notification()
        {
            ViewBag.userblock = d.Registration.Where(o => o.FullName == recbyUserName && o.status == "blacklisted" && o.notify == "foruser").ToList();
            ViewBag.userapprove = d.Registration.Where(o => o.FullName == recbyUserName && o.status == "approved" && o.notify == "foruser").ToList();
            ViewBag.flightdeactivated = d.Flight.Where(o => o.PassengerName == recbyUserName && o.FlightStatus == "disapprove" && o.notify == "foruser").ToList();
            return View();
        }
        public IActionResult prefrencedetails()
        {
            ViewBag.profile = recby;
            return View();
        }
        public IActionResult registration()
        {
            ViewBag.profile = recby;
            return View();
        }
        [HttpGet]
        public IActionResult getflightinfo(string departid)
        {
            var flightdetail= d.Flight.Where(o => o.Id==Convert.ToInt32 (departid)).ToList();
          
            return Json(flightdetail);
        }
        [HttpGet]
        public IActionResult getpassengerinfo(string departid, string flighidd)
        {
            var getpassengerinfo = d.Registration.Where(s=> s.FullName== departid).ToList();
            var flightdetail = d.Flight.Where(o => o.Id == Convert.ToInt32(flighidd)).ToList();

            var myResult = new
            {
                ProductList = getpassengerinfo,
                FlavourList = flightdetail
            };
            return Json(myResult);
           
            
        }
        [HttpGet]
        public IActionResult getownerinfo(string departid, string flighidd)
        {
            var getownerinfo = d.Registration.Where(s => s.FullName == departid).ToList();
            var flightdetail = d.Createpurposal.Where(o => o.Id == Convert.ToInt32(flighidd)).ToList();

            var myResult = new
            {
                ProductList = getownerinfo,
                FlavourList = flightdetail
            };
            return Json(myResult);


        }
        [HttpGet]
        public IActionResult testjquery(string departid)
        {
            var employeee = d.Flight.Where(o => o.AvailableWeight == departid).ToList();
            List <Flight> employee = d.Flight.Where(o => o.AvailableWeight == departid).ToList();
            return Json(employeee);


    //        Flight flight = JsonConvert.DeserializeObject<List<Flight>>(Response.Content.ReadAsStringAsync().Result);
    //        if (response.Data != null)
    //        {
    //            var responseObject = response.Data;
    //            return Json(responseObject);
    //        }
    //        else
    //        {
    //            TempData["response"] = "Unable to get details of Items.";
    //            return Json(JsonConvert.DeserializeObject("false."));
    //        }
    //    }
    //            return Json(JsonConvert.DeserializeObject("false."));
    //        }

    //JavaScriptSerializer js = new JavaScriptSerializer();
           
    //        HttpContext.Response.WriteAsync(js.Serialize(employee));
        }
    }
}





