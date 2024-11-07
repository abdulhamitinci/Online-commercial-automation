﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using myfirstproject.Models.siniflar;
using MyProject.Models.siniflar;

namespace WebApplication2.Controllers
{
    [AllowAnonymous] //giiş olmasada bu sayfaya girebilir herkese açık
    public class LoginController : Controller
    {
        // GET: Login

        Context baglan=new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult KayitOl()  //partialView
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult KayitOl(Cariler cari)  //partialView
        {
        //    if (!ModelState.IsValid)  //validasyon kontrolü
        //    {
        //        return View("CariEkle"); //validasyon işlemleri doğru değilse ekleme ekranına geri dön 
        //    }
            cari.Durum = true; // ilk eklendiğinde true yap 
            baglan.Carilers.Add(cari);
            baglan.SaveChanges();
            return PartialView();
        }

        [HttpGet]
        public ActionResult CariGiris()
        {
           return  View();
        }

        [HttpPost]
        public ActionResult CariGiris(Cariler cari)
        {
            var bilgiler=baglan.Carilers.FirstOrDefault(x=>x.CariMail==cari.CariMail && x.Sifre==cari.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CariMail"] = bilgiler.CariMail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        [HttpGet]
        public ActionResult AdminGiris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminGiris(Admin admin)
        {
            var bilgiler = baglan.Admins.FirstOrDefault
                (x => x.KullaniciAd == admin.KullaniciAd && x.Sifre == admin.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd, false);
                Session["KullaniciAd"] = bilgiler.KullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    
    }
}