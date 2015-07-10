using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using WorkflowEngine;

namespace WorkflowAdmin.Controllers
{
     [Authorize]
    public class wfStepsController : Controller
    {
        private WorkflowEngineEntities db = new WorkflowEngineEntities();

        // GET: wfSteps
        public async Task<ActionResult> Index()
        {
            return View(await db.wfSteps.ToListAsync());
        }

        // GET: wfSteps/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wfSteps wfSteps = await db.wfSteps.FindAsync(id);
            if (wfSteps == null)
            {
                return HttpNotFound();
            }
            return View(wfSteps);
        }

        // GET: wfSteps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: wfSteps/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StepCode,StepName,Flag,wfCode")] wfSteps wfSteps)
        {
            if (ModelState.IsValid)
            {
                db.wfSteps.Add(wfSteps);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(wfSteps);
        }

        // GET: wfSteps/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wfSteps wfSteps = await db.wfSteps.FindAsync(id);
            if (wfSteps == null)
            {
                return HttpNotFound();
            }
            return View(wfSteps);
        }

        // POST: wfSteps/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StepCode,StepName,Flag,wfCode")] wfSteps wfSteps)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wfSteps).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(wfSteps);
        }

        // GET: wfSteps/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wfSteps wfSteps = await db.wfSteps.FindAsync(id);
            if (wfSteps == null)
            {
                return HttpNotFound();
            }
            return View(wfSteps);
        }

        // POST: wfSteps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            wfSteps wfSteps = await db.wfSteps.FindAsync(id);
            db.wfSteps.Remove(wfSteps);
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
