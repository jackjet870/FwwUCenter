using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using WorkflowEngine;

namespace WorkflowAdmin.Controllers
{
     [Authorize]
    public class wfStepPathsController : Controller
    {
        private WorkflowEngineEntities db = new WorkflowEngineEntities();

        // GET: wfStepPaths
        public async Task<ActionResult> Index()
        {
            return View(await db.wfStepPath.ToListAsync());
        }

        // GET: wfStepPaths/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wfStepPath wfStepPath = await db.wfStepPath.FindAsync(id);
            if (wfStepPath == null)
            {
                return HttpNotFound();
            }
            return View(wfStepPath);
        }

        // GET: wfStepPaths/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: wfStepPaths/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,FromStepCode,ToStepCode,wfCode,PathType")] wfStepPath wfStepPath)
        {
            if (ModelState.IsValid)
            {
                wfStepPath.id = Guid.NewGuid();
                db.wfStepPath.Add(wfStepPath);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(wfStepPath);
        }

        // GET: wfStepPaths/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wfStepPath wfStepPath = await db.wfStepPath.FindAsync(id);
            if (wfStepPath == null)
            {
                return HttpNotFound();
            }
            return View(wfStepPath);
        }

        // POST: wfStepPaths/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,FromStepCode,ToStepCode,wfCode,PathType")] wfStepPath wfStepPath)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wfStepPath).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(wfStepPath);
        }

        // GET: wfStepPaths/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wfStepPath wfStepPath = await db.wfStepPath.FindAsync(id);
            if (wfStepPath == null)
            {
                return HttpNotFound();
            }
            return View(wfStepPath);
        }

        // POST: wfStepPaths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            wfStepPath wfStepPath = await db.wfStepPath.FindAsync(id);
            db.wfStepPath.Remove(wfStepPath);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
