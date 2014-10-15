using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using KGSBrowseMVC.Models;
using Newtonsoft.Json;

namespace KGSBrowseMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Uploadfiles(HttpPostedFileBase file)
        {
            try
            {
                // Deal with a series of possible input file error conditions
                var lasFileName = MakeLasFileName(file);
                IsLasFileNameNullOrWhiteSpace(lasFileName);
                IsExtensionLAS(lasFileName);
                IsFileTooBig(file, lasFileName);

                // Error conditions are finished with, so load the posted LAS data, and thin the data to JSON form suitable for D3JS and C3JS
                var path = Path.Combine(Server.MapPath("~/"), lasFileName);
                using (var fs = file.InputStream)
                using (var sr = new StreamReader(fs))
                {
                    // Return for display
                    var well = new Well(sr);
                    var ldw = well.WellToLinearDoubleWell();
                    var serialisedLdw = JsonConvert.SerializeObject(ldw);
//                    var model = new Model(well.WellToJson(40, 13));

//                    return View( model );
                    return View(new Model(serialisedLdw));
                }
            }

            catch (Exception ex)
            // Catch any unforseen blowups
            {
                return View(ex.Message);
            }
        }

        private static void IsFileTooBig(HttpPostedFileBase file, string lasFileName)
        {
            // As a safety check, refuse files bigger than 100,000,000 characters
            if (file.ContentLength > 100000000)
            {
                var argEx =
                    new ArgumentException(lasFileName +
                                          " Upload error: More than 100000000 Bytes of data was received by the server.");
                throw argEx;
            }
        }

        private static void IsExtensionLAS(string lasFileName)
        {
            // No .las file extension.  Could check the file by parsing it but that is beyond the scope of this story. 
            var extension = Path.GetExtension(lasFileName).ToLowerInvariant();
            var tester = ".LAS".ToLowerInvariant();
            if (! string.Equals(extension, tester))
            {
                throw
                    new ArgumentException(lasFileName +
                                          " Upload error: The file received by the server did not have a LAS file extension:" +
                                          extension + " and " + tester);
            }
        }

        private static void IsLasFileNameNullOrWhiteSpace(string lasFileName)
        {
            // Empty file name
            if (String.IsNullOrWhiteSpace(lasFileName))
            {
                throw
                    new ArgumentException(lasFileName +
                                          " Upload error: The file name received by the server was null or white space.");
            }
        }

        private static string MakeLasFileName(HttpPostedFileBase file)
        {
            // The file is zero length therefore not a LAS file by definition
            var lasFileName = Path.GetFileName(file.FileName);
            if (file.ContentLength == 0)
            {
                throw new ArgumentException(lasFileName + " Upload error: Empty file received by the server.");
            }
            return lasFileName;
        }
    }
}
