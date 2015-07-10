using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using WorkflowEngine;

namespace WorkflowAdmin.Controllers
{
     [Authorize]
    public class AccountGroupsController : Controller
    {
        private WorkflowEngineEntities db = new WorkflowEngineEntities();

        // GET: AccountGroups
        public async Task<ActionResult> Index()
        {
            return View(await db.AccountGroup.ToListAsync());
        }

        // GET: AccountGroups/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountGroup accountGroup = await db.AccountGroup.FindAsync(id);
            if (accountGroup == null)
            {
                return HttpNotFound();
            }
            return View(accountGroup);
        }

        // GET: AccountGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountGroups/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "GroupCode,GroupName")] AccountGroup accountGroup)
        {
            if (ModelState.IsValid)
            {
                db.AccountGroup.Add(accountGroup);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(accountGroup);
        }

        // GET: AccountGroups/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountGroup accountGroup = await db.AccountGroup.FindAsync(id);
            if (accountGroup == null)
            {
                return HttpNotFound();
            }
            return View(accountGroup);
        }

        // POST: AccountGroups/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "GroupCode,GroupName")] AccountGroup accountGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountGroup).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(accountGroup);
        }

        // GET: AccountGroups/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountGroup accountGroup = await db.AccountGroup.FindAsync(id);
            if (accountGroup == null)
            {
                return HttpNotFound();
            }
            return View(accountGroup);
        }

        // POST: AccountGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            AccountGroup accountGroup = await db.AccountGroup.FindAsync(id);
            db.AccountGroup.Remove(accountGroup);
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
