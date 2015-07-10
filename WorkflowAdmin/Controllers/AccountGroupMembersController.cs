using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using WorkflowEngine;

namespace WorkflowAdmin.Controllers
{
    [Authorize]
    public class AccountGroupMembersController : Controller
    {
        private WorkflowEngineEntities db = new WorkflowEngineEntities();

        // GET: AccountGroupMembers
        public async Task<ActionResult> Index()
        {
            return View(await db.AccountGroupMembers.ToListAsync());
        }

        // GET: AccountGroupMembers/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountGroupMembers accountGroupMembers = await db.AccountGroupMembers.FindAsync(id);
            if (accountGroupMembers == null)
            {
                return HttpNotFound();
            }
            return View(accountGroupMembers);
        }

        // GET: AccountGroupMembers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountGroupMembers/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,GroupCode,AccountID")] AccountGroupMembers accountGroupMembers)
        {
            if (ModelState.IsValid)
            {
                accountGroupMembers.id = Guid.NewGuid();
                db.AccountGroupMembers.Add(accountGroupMembers);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(accountGroupMembers);
        }

        // GET: AccountGroupMembers/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountGroupMembers accountGroupMembers = await db.AccountGroupMembers.FindAsync(id);
            if (accountGroupMembers == null)
            {
                return HttpNotFound();
            }
            return View(accountGroupMembers);
        }

        // POST: AccountGroupMembers/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,GroupCode,AccountID")] AccountGroupMembers accountGroupMembers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountGroupMembers).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(accountGroupMembers);
        }

        // GET: AccountGroupMembers/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountGroupMembers accountGroupMembers = await db.AccountGroupMembers.FindAsync(id);
            if (accountGroupMembers == null)
            {
                return HttpNotFound();
            }
            return View(accountGroupMembers);
        }

        // POST: AccountGroupMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            AccountGroupMembers accountGroupMembers = await db.AccountGroupMembers.FindAsync(id);
            db.AccountGroupMembers.Remove(accountGroupMembers);
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
