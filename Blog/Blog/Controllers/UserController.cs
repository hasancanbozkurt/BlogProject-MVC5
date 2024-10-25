using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using ActionResult = System.Web.Mvc.ActionResult;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;

namespace Blog.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        UserProfileManager userProfile = new UserProfileManager();
        BlogManager bm = new BlogManager(new EfBlogDal());
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Partial1(string p)
        {
            p = (string)Session["Mail"];
            var profilevalues = userProfile.GetAuthorByMail(p);
            return PartialView(profilevalues);
        }
        public ActionResult UpdateUserProfile(Author p)
        {
            userProfile.EditAuthor(p);
            return RedirectToAction("Index");
        }
        public ActionResult BlogList(string p)
        {
            p = (string)Session["Mail"];
            Context c= new Context();
            int id = c.Authors.Where(x => x.Mail == p).Select(y => y.AuthorID).FirstOrDefault();
            var blogs = userProfile.GetBlogByAuthor(id);
            return View(blogs);
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            EntityLayer.Concrete.Blog blog = bm.GetByID(id);
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categorys.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.values = values;

            List<SelectListItem> values2 = (from x in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString()
                                            }).ToList();
            ViewBag.values2 = values2;
            return View(blog);
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        public ActionResult UpdateBlog(EntityLayer.Concrete.Blog p, HttpPostedFileBase BlogImage, string ExistingImage)
        {
            var defaultImagePath = "/Resimler/default-image.jpg"; // Varsayılan görsel yolu

            if (BlogImage != null && BlogImage.ContentLength > 0)
            {
                if (BlogImage.ContentLength > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("BlogImage", "Görsel boyutu 2 MB'den büyük olamaz.");
                    return View(p);
                }

                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var fileExtension = Path.GetExtension(BlogImage.FileName).ToLower();
                if (!allowedExtensions.Contains(fileExtension))
                {
                    ModelState.AddModelError("BlogImage", "Geçersiz dosya türü.");
                    return View(p);
                }

                var filePath = Server.MapPath("~/Resimler/");
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                // Dosya adını GUID ve uzantı ile oluşturuyoruz.
                var fileName = Guid.NewGuid().ToString() + fileExtension;
                var savePath = Path.Combine(filePath, fileName);

                try
                {
                    // Dosya sunucuya kaydedilir
                    BlogImage.SaveAs(savePath);
                    // Dosya yolunu veritabanına kaydetmeden önce tam yolunu oluşturuyoruz
                    p.BlogImage = "/Resimler/" + fileName; // Web için doğru yolu kaydediyoruz
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Görsel yükleme sırasında bir hata oluştu: " + ex.Message);
                    ViewBag.UploadError = ex.Message; // Hata mesajını ViewBag ile döndürüyoruz
                    return View(p);
                }
            }
            else
            {
                // Yeni bir resim yüklenmemişse mevcut resmi koruyoruz
                p.BlogImage = string.IsNullOrEmpty(ExistingImage) ? defaultImagePath : ExistingImage;
            }

            // ModelState doğruysa veritabanına kaydet
            if (ModelState.IsValid)
            {
                bm.TUpdate(p); // Burada, kaydedilen yeni yol veritabanına eklenir
                return RedirectToAction("BlogList");
            }

            return View(p);
        }

        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categorys.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.values = values;

            List<SelectListItem> values2 = (from x in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString()
                                            }).ToList();
            ViewBag.values2 = values2;

    // Yeni bir Blog model nesnesi oluştur ve varsayılan değerleri ata
    var newBlog = new EntityLayer.Concrete.Blog
    {
        BlogDate = DateTime.Now // Varsayılan olarak bugünün tarihini ata
    };

    return View(newBlog);
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        public ActionResult AddNewBlog(EntityLayer.Concrete.Blog p, HttpPostedFileBase BlogImage)
        {
            var defaultImagePath = "/Resimler/default-image.jpg"; // Varsayılan görsel yolu

            if (BlogImage != null && BlogImage.ContentLength > 0)
            {
                if (BlogImage.ContentLength > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("BlogImage", "Görsel boyutu 2 MB'den büyük olamaz.");
                    return View(p);
                }

                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var fileExtension = Path.GetExtension(BlogImage.FileName).ToLower();
                if (!allowedExtensions.Contains(fileExtension))
                {
                    ModelState.AddModelError("BlogImage", "Geçersiz dosya türü.");
                    return View(p);
                }

                var filePath = Server.MapPath("~/Resimler/");
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                // Dosya adını GUID ve uzantı ile oluşturuyoruz.
                var fileName = Guid.NewGuid().ToString() + fileExtension;
                var savePath = Path.Combine(filePath, fileName);

                try
                {
                    // Dosya sunucuya kaydedilir
                    BlogImage.SaveAs(savePath);
                    // Dosya yolunu veritabanına kaydetmeden önce tam yolunu oluşturuyoruz
                    p.BlogImage = "/Resimler/" + fileName; // Web için doğru yolu kaydediyoruz
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Görsel yükleme sırasında bir hata oluştu: " + ex.Message);
                    ViewBag.UploadError = ex.Message; // Hata mesajını ViewBag ile döndürüyoruz
                    return View(p);
                }
            }
            else
            {
                // Eğer yeni bir resim yüklenmemişse, varsayılan resmi kullanıyoruz
                p.BlogImage = defaultImagePath;
            }

            // ModelState doğruysa veritabanına kaydet
            if (ModelState.IsValid)
            {
                bm.TAdd(p); // Blog ekleme işlemi
                return RedirectToAction("BlogList");
            }

            return View(p);
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin", "Login");
        }
    }
}