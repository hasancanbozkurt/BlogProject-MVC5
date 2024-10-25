using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using PagedList;
using DataAccessLayer.Concrete;
using Context = DataAccessLayer.Concrete.Context;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using ActionResult = System.Web.Mvc.ActionResult;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;
using PagedList;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog

        BlogManager bm = new BlogManager(new EfBlogDal());
        CommentManager cm = new CommentManager(new EfCommentDal());

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogList(int page = 1)
        {
            var bloglist = bm.GetList().OrderByDescending(x => x.BlogDate).ToPagedList(page, 6);
            return PartialView(bloglist);
        }

        [AllowAnonymous]
        public PartialViewResult FeaturedPost()
        {
            //1. Post
            var posttitle1 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y =>
                    y.BlogTitle).FirstOrDefault();
            var postimage1 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y =>
                   y.BlogImage).FirstOrDefault();
            var blogdate1 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y =>
                    y.BlogDate).FirstOrDefault();
            var blogpostid1 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y =>
                   y.BlogID).FirstOrDefault();

            ViewBag.posttitle1 = posttitle1;
            ViewBag.postimage1 = postimage1;
            ViewBag.blogdate1 = blogdate1;
            ViewBag.blogpostid1 = blogpostid1;

            //2. Post
            var posttitle2 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y =>
                    y.BlogTitle).FirstOrDefault();
            var postimage2 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y =>
                   y.BlogImage).FirstOrDefault();
            var blogdate2 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y =>
                    y.BlogDate).FirstOrDefault();
            var blogpostid2 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y =>
                    y.BlogID).FirstOrDefault();

            ViewBag.posttitle2 = posttitle2;
            ViewBag.postimage2 = postimage2;
            ViewBag.blogdate2 = blogdate2;
            ViewBag.blogpostid2 = blogpostid2;

            //3. Post
            var posttitle3 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y =>
                    y.BlogTitle).FirstOrDefault();
            var postimage3 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y =>
                   y.BlogImage).FirstOrDefault();
            var blogdate3 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y =>
                    y.BlogDate).FirstOrDefault();
            var blogpostid3 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y =>
                    y.BlogID).FirstOrDefault();

            ViewBag.posttitle3 = posttitle3;
            ViewBag.postimage3 = postimage3;
            ViewBag.blogdate3 = blogdate3;
            ViewBag.blogpostid3 = blogpostid3;

            //4. Post
            var posttitle4 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1002).Select(y =>
                    y.BlogTitle).FirstOrDefault();
            var postimage4 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1002).Select(y =>
                   y.BlogImage).FirstOrDefault();
            var blogdate4 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1002).Select(y =>
                    y.BlogDate).FirstOrDefault();
            var blogpostid4 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1002).Select(y =>
                    y.BlogID).FirstOrDefault();

            ViewBag.posttitle4 = posttitle4;
            ViewBag.postimage4 = postimage4;
            ViewBag.blogdate4 = blogdate4;
            ViewBag.blogpostid4 = blogpostid4;

            //5. Post
            var posttitle5 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1004).Select(y =>
                    y.BlogTitle).FirstOrDefault();
            var postimage5 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1004).Select(y =>
                   y.BlogImage).FirstOrDefault();
            var blogdate5 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1004).Select(y =>
                    y.BlogDate).FirstOrDefault();
            var blogpostid5 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1004).Select(y =>
                    y.BlogID).FirstOrDefault();

            ViewBag.posttitle5 = posttitle5;
            ViewBag.postimage5 = postimage5;
            ViewBag.blogdate5 = blogdate5;
            ViewBag.blogpostid5 = blogpostid5;

            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult OtherFeaturedPost()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public ActionResult BlogDetails()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var BlogDetailsList = bm.GetBlogByID(id);
            return PartialView(BlogDetailsList);
        }
        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id)
        {
            var BlogDetailsList = bm.GetBlogByID(id);
            return PartialView(BlogDetailsList);
        }
        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {
            var BlogListByCategory = bm.GetBlogByCategory(id);
            var CategoryName = bm.GetBlogByCategory(id).Select
                (y => y.Category.CategoryName).FirstOrDefault();
            ViewBag.CategoryName = CategoryName;
            var CategoryDesc = bm.GetBlogByCategory(id).Select
                (y => y.Category.CategoryDescription).FirstOrDefault();
            ViewBag.CategoryDesc = CategoryDesc;
            return View(BlogListByCategory);
        }
        public ActionResult AdminBlogList(int page = 1, string searchQuery = "")
        {
            int pageSize = 7; // Her sayfada 7 blog gösterilecek

            // Blog listesini al
            var bloglist = bm.GetList();

            // Eğer arama yapılmışsa arama sorgusuna göre listeyi filtrele
            if (!string.IsNullOrEmpty(searchQuery))
            {
                bloglist = bloglist.Where(x => x.BlogTitle.Contains(searchQuery) ||
                                               x.BlogContent.Contains(searchQuery)).ToList();
                ViewBag.SearchQuery = searchQuery; // Arama sorgusunu geri göndermek için ViewBag'e ekle
            }

            // Blog listesini tarihe göre sırala ve sayfala
            var pagedBlogList = bloglist.OrderByDescending(x => x.BlogDate).ToPagedList(page, pageSize);

            return View(pagedBlogList);
        }


        public ActionResult AdminBlogList2(int page = 1, string searchQuery = "")
        {
            int pageSize = 7; // Her sayfada 7 blog gösterilecek

            // Blog listesini al
            var bloglist = bm.GetList();

            // Eğer arama yapılmışsa arama sorgusuna göre listeyi filtrele
            if (!string.IsNullOrEmpty(searchQuery))
            {
                bloglist = bloglist.Where(x => x.BlogTitle.Contains(searchQuery) ||
                                               x.BlogContent.Contains(searchQuery)).ToList();
                ViewBag.SearchQuery = searchQuery; // Arama sorgusunu geri göndermek için ViewBag'e ekle
            }

            // Blog listesini tarihe göre sırala ve sayfala
            var pagedBlogList = bloglist.OrderByDescending(x => x.BlogDate).ToPagedList(page, pageSize);

            return View(pagedBlogList);
        }


        [Authorize(Roles= "A")]
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

            return View();
        }

        [HttpPost]
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
                return RedirectToAction("AdminBlogList");
            }

            return View(p);
        }
        public ActionResult DeleteBlog(int id)
        {
            EntityLayer.Concrete.Blog blog = bm.GetByID(id);
            bm.TDelete(blog);
            return RedirectToAction("AdminBlogList");
        }

        public void ResizeAndSaveImage(HttpPostedFileBase file, string savePath, int maxWidth, int maxHeight, long quality)
        {
            using (var image = System.Drawing.Image.FromStream(file.InputStream))
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                float ratioX = (float)maxWidth / originalWidth;
                float ratioY = (float)maxHeight / originalHeight;
                float ratio = Math.Min(ratioX, ratioY);

                int newWidth = (int)(originalWidth * ratio);
                int newHeight = (int)(originalHeight * ratio);

                using (var newImage = new Bitmap(newWidth, newHeight))
                {
                    using (var graphics = Graphics.FromImage(newImage))
                    {
                        graphics.CompositingQuality = CompositingQuality.HighQuality;
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.DrawImage(image, 0, 0, newWidth, newHeight);
                    }

                    var encoder = ImageCodecInfo.GetImageEncoders().FirstOrDefault(e => e.FormatID == ImageFormat.Jpeg.Guid);
                    var encoderParameters = new EncoderParameters(1);
                    encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, quality);

                    newImage.Save(savePath, encoder, encoderParameters);
                }
            }
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
                if (BlogImage.ContentLength > 5 * 1024 * 1024) // 5 MB'den büyük resim kontrolü
                {
                    ModelState.AddModelError("BlogImage", "Görsel boyutu 5 MB'den büyük olamaz.");
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
                    // Resmi boyutlandır ve sıkıştır (800x600 ve kalite %75)
                    ResizeAndSaveImage(BlogImage, savePath, 800, 600, 75L);

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
                return RedirectToAction("AdminBlogList");
            }

            return View(p);
        }


        public ActionResult GetCommentByBlog(int id)
        {            
            var commentlist = cm.CommentByBlog(id);
            return View(commentlist);
        }

        public ActionResult AuthorBlogList(int id)
        {
            var blogs = bm.GetBlogByAuthor(id);
            return View(blogs);
        }

        [AllowAnonymous]
        public ActionResult Search(string search)
        {
            var result = bm.GetList()
                            .Where(x => x.BlogTitle.Contains(search) ||
                                        x.BlogContent.Contains(search))
                            .ToList();
            return View(result);
        }
    }
}