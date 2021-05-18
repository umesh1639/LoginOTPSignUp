using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Assignment.Controllers
{
    public class LogInAndSignUpController : Controller
    {
        private LoginAndSignupEntities entity;

        private static bool _isRegistered = false;
        private static string PhoneNumber=String.Empty;
        private readonly Random _random = new Random();

        private static int _otp;
        // GET: LogInAndSignUp
        public ActionResult SignIn()
        {
            return View();
        }
        public ActionResult SendOTP()
        {
            if (Session["Mobile"] != null)
            {
                return RedirectToAction("WelcomePage");
            }
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        // Post: LogInAndSignUp
        public ActionResult SignIn(OTP otp)
        {
            ViewBag.Message = null;
            entity =new LoginAndSignupEntities();
            if (otp == null || otp.OneTimePassword.ToString() != _otp.ToString())
            {
                return RedirectToAction("SignIn", "LogInAndSignUp");
            }

            else if (_isRegistered)
            {
                Session["Mobile"] = PhoneNumber.ToString();
                return RedirectToAction("WelcomePage","LogInAndSignUp");
            }

            return RedirectToAction("SignUp", "LogInAndSignUp");

        }
        [HttpPost]
        public ActionResult SendOTP(MobileNumber phone)
        {
            ViewBag.Message = null;

            entity = new LoginAndSignupEntities();
            
            _isRegistered = entity.UserData.Any(x => x.MobileNumber.ToString() == phone.PhoneNumber.ToString());
            if (phone.PhoneNumber.ToString().Length != 10)
            {
                ViewBag.Message = "Incorrect Mobile number. Enter again";
                return RedirectToAction("SendOTP","LogInAndSignUp");
            }

            PhoneNumber = phone.PhoneNumber.ToString();
            _otp=_random.Next(100000, 999999);
            SendOtp();
            return RedirectToAction("SignIn","LogInAndSignUp");
        }

        private void SendOtp()
        {
            TwilioClient.Init("AC318cda7e962685e27f04a0536881b5e8", "73da481e508fed76fc4d19072f443485");

            var message = MessageResource.Create(
                body: $"Hi there! your OTP is {_otp.ToString()}",
                from: new Twilio.Types.PhoneNumber("+13852090911"),
                to: new Twilio.Types.PhoneNumber("+91" + PhoneNumber)
            );
        }

        [HttpPost]
        public ActionResult SignUp(UserData data)
        {
            entity=new LoginAndSignupEntities();
            if (data != null)
            {
                entity.UserData.Add(data);
                entity.SaveChanges();
            }

            return RedirectToAction("SendOTP", "LogInAndSignUp");
        }

        public ActionResult WelcomePage()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["Mobile"] = null;
            Session.Abandon();
            return View();
        }
    }
}