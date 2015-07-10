using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorkflowEngine;

namespace WorkflowAdmin.Controllers
{
    public class wfDefaultApproversController : Controller
    {
        private WorkflowEngineEntities db = new WorkflowEngineEntities();

        // GET: wfDefaultApprovers
        public async Task<ActionResult> Index()
        {
            return View(await db.wfDefaultApprovers.ToListAsync());
        }

        // GET: wfDefaultApprovers/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wfDefaultApprovers wfDefaultApprovers = await db.wfDefaultApprovers.FindAsync(id);
            if (wfDefaultApprovers == null)
            {
                return HttpNotFound();
            }
            return View(wfDefaultApprovers);
        }

        // GET: wfDefaultApprovers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: wfDefaultApprovers/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,StepCode,AccountID,wfCode")] wfDefaultApprovers wfDefaultApprovers)
        {
            if (ModelState.IsValid)
            {
                wfDefaultApprovers.id = Guid.NewGuid();
                db.wfDefaultApprovers.Add(wfDefaultApprovers);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(wfDefaultApprovers);
        }

        // GET: wfDefaultApprovers/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wfDefaultApprovers wfDefaultApprovers = await db.wfDefaultApprovers.FindAsync(id);
            if (wfDefaultApprovers == null)
            {
                return HttpNotFound();
            }
            return View(wfDefaultApprovers);
        }

        // POST: wfDefaultApprovers/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,StepCode,AccountID,wfCode")] wfDefaultApprovers wfDefaultApprovers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wfDefaultApprovers).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(wfDefaultApprovers);
        }

        // GET: wfDefaultApprovers/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wfDefaultApprovers wfDefaultApprovers = await db.wfDefaultApprovers.FindAsync(id);
            if (wfDefaultApprovers == null)
            {
                return HttpNotFound();
            }
            return View(wfDefaultApprovers);
        }

        // POST: wfDefaultApprovers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            wfDefaultApprovers wfDefaultApprovers = await db.wfDefaultApprovers.FindAsync(id);
            db.wfDefaultApprovers.Remove(wfDefaultApprovers);
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
