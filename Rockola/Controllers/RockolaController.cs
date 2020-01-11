using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rockola.Controllers;
using Rockola.Models;
using System.Threading.Tasks;

namespace Rockola.Controllers
{
    public class RockolaController : Controller
    {
        // GET: Rockola
        public ActionResult Rockola()
        {
           // var vid = RockolaModel.Buscars("");
            List<Videos> video = Task.Run(() => RockolaModel.Buscars("")).Result;
            
            return View(video);
        }

        public ActionResult SearchVideo(FormCollection formCollection)
        {
            List<Videos> video = RockolaModel.Buscars(formCollection["buscar"]);
            //SearchVideos video = Task.Run(() => RockolaModel.Buscars(formCollection["buscar"])).Result;
            return View("Rockola",video);
        }
    }
}