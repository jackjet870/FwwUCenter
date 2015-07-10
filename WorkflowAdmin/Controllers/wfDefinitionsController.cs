using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using WorkflowEngine;

namespace WorkflowAdmin.Controllers
{
     [Authorize]
    public class wfDefinitionsController : Controller
    {
        private WorkflowEngineEntities db = new WorkflowEngineEntities();

        // GET: wfDefinitions
        public async Task<ActionResult> Index()
        {
            return View(await db.wfDefinition.ToListAsync());
        }

        // GET: wfDefinitions/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wfDefinition wfDefinition = await db.wfDefinition.FindAsync(id);
            if (wfDefinition == null)
            {
                return HttpNotFound();
            }
            return View(wfDefinition);
        }

        // GET: wfDefinitions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: wfDefinitions/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "wfCode,wfName")] wfDefinition wfDefinition)
        {
            if (ModelState.IsValid)
            {
                db.wfDefinition.Add(wfDefinition);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(wfDefinition);
        }

        // GET: wfDefinitions/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wfDefinition wfDefinition = await db.wfDefinition.FindAsync(id);
            if (wfDefinition == null)
            {
                return HttpNotFound();
            }
            return View(wfDefinition);
        }

        // POST: wfDefinitions/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "wfCode,wfName")] wfDefinition wfDefinition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wfDefinition).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(wfDefinition);
        }

        // GET: wfDefinitions/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wfDefinition wfDefinition = await db.wfDefinition.FindAsync(id);
            if (wfDefinition == null)
            {
                return HttpNotFound();
            }
            return View(wfDefinition);
        }

        // POST: wfDefinitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            wfDefinition wfDefinition = await db.wfDefinition.FindAsync(id);
            db.wfDefinition.Remove(wfDefinition);
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
