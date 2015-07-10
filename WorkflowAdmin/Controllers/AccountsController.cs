using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using WorkflowEngine;

namespace WorkflowAdmin.Controllers
{
     [Authorize]
    public class AccountsController : Controller
    {
        private WorkflowEngineEntities db = new WorkflowEngineEntities();

        // GET: Accounts
        public async Task<ActionResult> Index()
        {
            return View(await db.Accounts.ToListAsync());
        }

        // GET: Accounts/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accounts accounts = await db.Accounts.FindAsync(id);
            if (accounts == null)
            {
                return HttpNotFound();
            }
            return View(accounts);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AccountID,AccountPWD,UserName,AccountStatus")] Accounts accounts)
        {
            if (ModelState.IsValid)
            {
                db.Accounts.Add(accounts);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(accounts);
        }

        // GET: Accounts/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accounts accounts = await db.Accounts.FindAsync(id);
            if (accounts == null)
            {
                return HttpNotFound();
            }
            return View(accounts);
        }

        // POST: Accounts/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AccountID,AccountPWD,UserName,AccountStatus")] Accounts accounts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accounts).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(accounts);
        }

        // GET: Accounts/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accounts accounts = await db.Accounts.FindAsync(id);
            if (accounts == null)
            {
                return HttpNotFound();
            }
            return View(accounts);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Accounts accounts = await db.Accounts.FindAsync(id);
            db.Accounts.Remove(accounts);
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
