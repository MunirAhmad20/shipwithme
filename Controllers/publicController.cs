using ChatApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using shipwithme.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace shipwithme.Controllers
{
    public class publicController : Controller
    {
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
        public static string passport;
        public static string recbypassport
        {
            get { return passport; }
            set { passport = value; }
        }
        AppDBContext d = new AppDBContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult customerreg(List<IFormFile> files , List<IFormFile> filess , string password_confirmation, string city , string extraphone, string phone , string fullName, string nationality,string email)
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
                r.status = "disapprove";
                r.Password = password_confirmation;
                r.email = email;
                d.Registration.Add(r);
                d.SaveChanges();
                Users u = new Users();
                u.Name = fullName;
                u.UserName = fullName;
                u.Password = password_confirmation;
                u.Gender = "Male";
                u.CreatedOn=Convert.ToDateTime(DateTime.Now.ToShortDateString());
                u.DOB=Convert.ToDateTime(DateTime.Now.ToShortDateString());
                u.UpdatedOn=Convert.ToDateTime(DateTime.Now.ToShortDateString());
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
                return RedirectToAction("regapproval", "public");
            }
            else
            {
                useralreadyrecby = "User Already Exist Please try with Different Name";
                return RedirectToAction("registration", "public");
            }
        }
        public IActionResult home()
        {
           
         
            return View();
        }
        public IActionResult registration()
        {
            ViewBag.error = useralreadyrecby;
            useralready = string.Empty;
            return View();
        }
        public IActionResult terms()
        {
            return View();
        }
        public IActionResult regapproval()
        {
            return View();
        }
        public IActionResult privacy()
        {
            return View();
        }
    }
}
