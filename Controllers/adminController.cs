using ChatApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using shipwithme.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace shipwithme.Controllers
{
    public class adminController : Controller
    {
        public static string passport;
        public static string recbypassport
        {
            get { return passport; }
            set { passport = value; }
        }
        public static string response;
        public static string recbyresponse
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
        public static string useralready;
        public static string useralreadyrecby
        {
            get { return useralready; }
            set { useralready = value; }
        }
        AppDBContext d = new AppDBContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Flight_Approvel()
        {
          // ViewBag.details = d.Flight.Where(o=> o.FlightStatus== "disapprove").ToList();
         ViewBag.details = d.Flight.ToList();
            ViewBag.reason = d.reasonlist.ToList();
            return View();
        }
        public IActionResult purposals()
        {
            ViewBag.purposal = d.Createpurposal.ToList();
            return View();
               
        }
        [HttpPost]
        public IActionResult customerreg(List<IFormFile> files, List<IFormFile> filess, string password_confirmation, string city, string extraphone, string phone, string fullName, string nationality, string email, string accounttype, string addresss)
        {
            var check = d.Registration.Where(o => o.FullName == fullName).Count();
            if (check == 0)
            {


                if (files != null)
                {


                    //    for (int i = 0; i <= files.Count; i++)
                    //{ 
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
                            recby = String.Concat(myUniqueFileName, fileExtension);

                            // Combines two strings into a path.
                            var filepath =
               new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedImages")).Root + $@"\{recby}";

                            using (FileStream fs = System.IO.File.Create(filepath))
                            {
                                file.CopyTo(fs);
                                fs.Flush();

                            }




                        }
                    }
                }

                if (filess != null)
                {


                    //    for (int i = 0; i <= files.Count; i++)
                    //{ 
                    foreach (var file in filess)
                    {
                        {
                            //Getting FileName
                            var fileName = Path.GetFileName(file.FileName);

                            //Assigning Unique Filename (Guid)
                            var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                            //Getting file Extension
                            var fileExtension = Path.GetExtension(fileName);

                            // concatenating  FileName + FileExtension
                            recbypassport = String.Concat(myUniqueFileName, fileExtension);

                            // Combines two strings into a path.
                            var filepath =
               new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedImages")).Root + $@"\{passport}";

                            using (FileStream fs = System.IO.File.Create(filepath))
                            {
                                file.CopyTo(fs);
                                fs.Flush();

                            }




                        }
                    }
                }
                Registration r = new Registration();


                r.Nationality = nationality;
                r.FullName = fullName;
                r.ProfileImage = recby;
                r.PassportImage = recbypassport;
                r.PhoneNumber = phone;
                r.ExtraPhoneNumber = extraphone;
                r.City = city;
                r.status = "approved";
                r.accounttype = accounttype;
                r.address = addresss;
                r.notify = "foruser";
                r.rating = "0";
                r.Password = password_confirmation;
                r.email = email;
                d.Registration.Add(r);
                d.SaveChanges();
                Users u = new Users();
                u.Name = fullName;
                u.UserName = fullName;
                u.Password = password_confirmation;
                u.Gender = "Male";
                u.CreatedOn = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                u.DOB = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                u.UpdatedOn = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                d.Users.Add(u);
                d.SaveChanges();

                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("mail.maeen.online@gmail.com", "SWM");
                    var recievermaill = new MailAddress(email, "Reciever");
                    var pass = "Maeen@804";

                    var sub = "Sign Up Successfully";
                    var body = "Hi " + fullName + "!You have SignUp on to SWM on " + DateTime.Now.ToShortDateString() + "at " + DateTime.Now.ToLongTimeString() + "";
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
                recbyresponse = "save";
                return RedirectToAction("systemuser", "admin");
            }
            else
            {
                recbyresponse = "alreadyexist";
                useralreadyrecby = "User Already Exist Please try with Different Name";
                return RedirectToAction("systemuser", "admin");
            }
        }

        public IActionResult systemuser()
        {
            //ViewBag.externaluser = d.Registration.Where(o => o.status == "disapprove").ToList() ;

            ViewBag.response = recbyresponse;
            ViewBag.reason = d.reasonlist.ToList();
            ViewBag.user = d.Adminlogin.ToList();
            ViewBag.externaluser = d.Registration.ToList() ;
            ViewBag.accounttype = d.accountlimit.ToList() ;
            ViewBag.city = d.Citylist.ToList();
            ViewBag.country = d.countrylist.ToList();
            recbyresponse = " ";
            return View();
            ///////https://www.codingpot.com/2018/10/signalr-push-notification-in-asp.net.html
        }
        [HttpGet]
        public IActionResult approve(string departid)
        {
            var data = d.Adminlogin.Find(Convert.ToInt32(departid));
            data.status = "Approved";
            d.Entry(data).State = EntityState.Modified;
            d.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public IActionResult blacklist(string departid)
        {
            var data = d.Adminlogin.Find(Convert.ToInt32(departid));
            data.status = "blacklisted";
            d.Entry(data).State = EntityState.Modified;
            d.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public IActionResult getnotifications()
        {
            var find = d.Flight.Where(o => o.notify == "foradmin").Count();

            return Json(find);
        }
        [HttpPost]
        public IActionResult submitnewuser(string roll, string password, string gmail, string name)
        {
            Adminlogin s = new Adminlogin();
            s.Username = name;
            s.systemroll = roll;
            s.Gmail = gmail;
            s.status = "Approved";
            s.password = password;
            d.Adminlogin.Add(s);
            d.SaveChanges();

            return Ok();
        }
        public IActionResult systemuserinfo(string tid)
        {
            //ViewBag.externaluser = d.Registration.Where(o => o.status == "disapprove").ToList() ;
            ViewBag.externaluserinfo = d.Registration.Where(o=> o.Id==Convert.ToInt32(tid)).ToList();
            ViewBag.user = d.Adminlogin.ToList();
            ViewBag.externaluser = d.Registration.ToList();
            ViewBag.response = recbyresponse;
            ViewBag.user = d.Adminlogin.ToList();
            ViewBag.externaluser = d.Registration.ToList();
            ViewBag.accounttype = d.accountlimit.ToList();
            ViewBag.city = d.Citylist.ToList();
            ViewBag.country = d.countrylist.ToList();

            ViewBag.reason = d.reasonlist.ToList();
    
            recbyresponse = " ";
        
            return View();

        }
        [HttpPost]
        public IActionResult submitreasons( string reasonid, string wherefrom, string status, string reason)
        {
            if (wherefrom== "externaluser")
            {
                var data = d.Registration.Find(Convert.ToInt32(reasonid));
                data.status = status;
                data.Reason = reason;
                d.Entry(data).State = EntityState.Modified;
                d.SaveChanges();
            }
            if (wherefrom == "enternaluser")
            {
                var data = d.Adminlogin.Find(Convert.ToInt32(reasonid));
                data.status = status;
                data.Reason = reason;
                d.Entry(data).State = EntityState.Modified;
                d.SaveChanges();
            }

            return Ok();
        }
        public IActionResult Flight_Status()
        {
            ViewBag.details = d.Flight.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult updateaccounttype(string accounttype, string accountid)
        {
          

                var data = d.Registration.Find(Convert.ToInt32(accountid));
                data.accounttype = accounttype;
                d.Entry(data).State = EntityState.Modified;
                d.SaveChanges();
                return Ok();
            }
            
            [HttpPost]
        public IActionResult submitreasonlist(string reasonid, string reason)
        {
            if (reasonid != null && reasonid != " ")
            {

                var data = d.reasonlist.Find(Convert.ToInt32(reasonid));
                data.reasons = reason;
                d.Entry(data).State = EntityState.Modified;
                d.SaveChanges();
                return Ok();
            }
            else
            {
                reasonlist c = new reasonlist();
                c.reasons = reason;
                c.Status = "activate";
                d.reasonlist.Add(c);
                d.SaveChanges();
                return Ok();
            }

        }
        [HttpPost]
        public IActionResult submitcountrylist(string countryid, string country)
        {
            if (countryid != null && countryid != " ")
            {
                
                var data = d.countrylist.Find(Convert.ToInt32(countryid));
                data.Country = country;
                d.Entry(data).State = EntityState.Modified;
                d.SaveChanges();
                return Ok();
            }
            else
            {
                countrylist c = new countrylist();
                c.Status = "activate";
                c.Country = country;
                d.countrylist.Add(c);
                d.SaveChanges();
                return Ok();
            }
        
        }

        [HttpPost]
        public IActionResult submitaccountlist(string account, string accountlimit, string accountid)
        {
            if (accountid != null && accountid != " ")
            {

                var data = d.accountlimit.Find(Convert.ToInt32(accountid));
                data.accountlimits = accountlimit;
                data.accounttitle = account;
                d.Entry(data).State = EntityState.Modified;
                d.SaveChanges();
                return Ok();
            }
            else
            {
                accountlimit c = new accountlimit();
                c.accounttitle = account;
                c.Status = "activate";

                c.accountlimits = accountlimit;
                d.accountlimit.Add(c);
                d.SaveChanges();
                return Ok();
            }

        }
        [HttpPost]
        public IActionResult submitcitylist(string cityid, string city,string nationality)
        {
            if (cityid != null && cityid != " ")
            {

                var data = d.Citylist.Find(Convert.ToInt32(cityid));
                data.City = city;
                data.country = nationality;
                d.Entry(data).State = EntityState.Modified;
                d.SaveChanges();
                return Ok();
            }
            else
            {
                Citylist c = new Citylist();
                c.City = city;
                c.country = nationality;
                c.Status = "activate";
                d.Citylist.Add(c);
                d.SaveChanges();
                return Ok();
            }

        }
        [HttpPost]
        public IActionResult submitweightlist(string weightid, string weight)
        {
            if (weightid != null && weightid != " ")
            {

                var data = d.weight.Find(Convert.ToInt32(weightid));
                data.weightlimit = weight;
                d.Entry(data).State = EntityState.Modified;
                d.SaveChanges();
                return Ok();
            }
            else
            {
                weight c = new weight();
                c.weightlimit = weight;
                c.Status = "activate";
                d.weight.Add(c);
                d.SaveChanges();
                return Ok();
            }

        }
        [HttpPost]
        public IActionResult submitairportlist(string airportid, string airport)
        {
            if (airportid != null && airportid != " ")
            {

                var data = d.Airportlist.Find(Convert.ToInt32(airportid));
                data.Airport = airport;
                d.Entry(data).State = EntityState.Modified;
                d.SaveChanges();
                return Ok();
            }
            else
            {
               Airportlist c = new Airportlist();
                c.Airport = airport;
                c.Status = "activate";
                d.Airportlist.Add(c);
                d.SaveChanges();
                return Ok();
            }

        }
        [HttpGet]
        public string getcitylist(string counntrytid)
        {


            //  var record = d.tblsections.Where(o => o.classname == id).ToList();
            var citylist = d.Citylist.Where(o => o.country == counntrytid).ToList();
            string html = " ";
            html += "<option value=" + 0 + ">" + "Select Section" + "</option> ";
            foreach (var item in citylist)
            {
                html += "<option value=" + item.City + ">" + item.City + "</option> ";
            }
            return html;
          
        }
        public IActionResult lookups()
        {
            ViewBag.airport= d.Airportlist.ToList();
            ViewBag.country= d.countrylist.ToList();
            ViewBag.city= d.Citylist.ToList();
            ViewBag.reason = d.reasonlist.ToList();
            ViewBag.accoutlist = d.accountlimit.ToList();
            ViewBag.weightlist = d.weight.ToList();
          

            return View();
        }
        [HttpGet]
        public IActionResult approveflight(string departid)
        {
            var data = d.Flight.Find(Convert.ToInt32(departid));
            data.FlightStatus = "approved";
            data.notify = "foruser";
            d.Entry(data).State = EntityState.Modified;
            d.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public IActionResult delcity(string departid, string statuss)
        {
            var data = d.Citylist.Find(Convert.ToInt32(departid));
            if (statuss == "activate")
            {
                data.Status = "deactivate";


                //d.Citylist.Remove(data);
            }
            if (statuss == "deactivate")
            {
                data.Status = "activate";


            }

            d.Entry(data).State = EntityState.Modified;

            d.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public IActionResult delweight(string departid, string statuss)
        {
            var data = d.weight.Find(Convert.ToInt32(departid));
            if (statuss == "activate")
            {
                data.Status = "deactivate";


                //d.Citylist.Remove(data);
            }
            if (statuss == "deactivate")
            {
                data.Status = "activate";


            }

            d.Entry(data).State = EntityState.Modified;

            d.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public IActionResult delaccount(string departid, string statuss)
        {
            var data = d.accountlimit.Find(Convert.ToInt32(departid));
            if (statuss == "activate")
            {
                data.Status = "deactivate";


                //d.Citylist.Remove(data);
            }
            if (statuss == "deactivate")
            {
                data.Status = "activate";


            }

            d.Entry(data).State = EntityState.Modified;

            d.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public IActionResult delreason(string departid,string statuss)
        {
            var data = d.reasonlist.Find(Convert.ToInt32(departid));
            if (statuss == "activate")
            {
                data.Status = "deactivate";

             
                //d.Citylist.Remove(data);
            }
            if (statuss == "deactivate")
            {
                data.Status = "activate";

           
            }


            d.Entry(data).State = EntityState.Modified;
            d.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public IActionResult delcountry(string departid, string statuss)
        {
            var data = d.countrylist.Find(Convert.ToInt32(departid));
            if (statuss == "activate")
            {
                data.Status = "deactivate";


                //d.Citylist.Remove(data);
            }
            if (statuss == "deactivate")
            {
                data.Status = "activate";


            }


            d.Entry(data).State = EntityState.Modified;
            d.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public IActionResult delairport(string departid, string statuss)
        {
            var data = d.Airportlist.Find(Convert.ToInt32(departid));
            if (statuss == "activate")
            {
                data.Status = "deactivate";


                //d.Citylist.Remove(data);
            }
            if (statuss == "deactivate")
            {
                data.Status = "activate";


            }

            d.Entry(data).State = EntityState.Modified;
            d.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult blacklistflights(string reasonid, string wherefrom, string status, string reason)
        {
            var data = d.Flight.Find(Convert.ToInt32(reasonid));
            data.FlightStatus = status;
            data.Reason = reason;
            data.notify = "foruser";
            d.Entry(data).State = EntityState.Modified;
            d.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult blacklistflight(string departid)
        {
            var data = d.Flight.Find(Convert.ToInt32(departid));
            data.FlightStatus = "blacklisted";
            data.notify = "foruser";
            d.Entry(data).State = EntityState.Modified;
            d.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public IActionResult approveuser(string departid)
        {
            var data = d.Registration.Find(Convert.ToInt32(departid));

            data.status = "approved";
            data.notify = "foruser";
            d.Entry(data).State = EntityState.Modified;
            d.SaveChanges();
          
            if (ModelState.IsValid)
            {
                string email="";
                string FullName="";
                var userlist = d.Registration.Where(o => o.Id == Convert.ToInt32(departid)).ToList();
                foreach (var item in userlist)
                {
                    email = item.email;
                    FullName = item.FullName;
                }
                var senderEmail = new MailAddress("mail.maeen.online@gmail.com", "SWM");
                var recievermaill = new MailAddress(email, "Reciever");
                var pass = "Maeen@804";

                var sub = "Account Approved Successfully";
                var body = "Hi "+FullName+"!You have Approved successfully on " + DateTime.Now.ToShortDateString() + "at " + DateTime.Now.ToLongTimeString() + " Now you can access your dashboard ";
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
           

            return Ok();
        }
        [HttpGet]
        public IActionResult blacklistuser(string departid)
        {
            var data = d.Registration.Find(Convert.ToInt32(departid));
            data.status = "blacklisted";
            data.notify = "foruser";
            d.Entry(data).State = EntityState.Modified;
            d.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public IActionResult getdata()
        {
            var list = d.accountlimit.ToList();

            return Json(list);

        }
    }
}
