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
    public class wfDefaultApproverGroupsController : Controller
    {
        private WorkflowEngineEntities db = new WorkflowEngineEntities();

        // GET: wfDefaultApproverGroups
        public async Task<ActionResult> Index()
        {
            return View(await db.wfDefaultApproverGroup.ToListAsync());
        }

        // GET: wfDefaultApproverGroups/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wfDefaultApproverGroup wfDefaultApproverGroup = await db.wfDefaultApproverGroup.FindAsync(id);
            if (wfDefaultApproverGroup == null)
            {
                return HttpNotFound();
            }
            return View(wfDefaultApproverGroup);
        }

        // GET: wfDefaultApproverGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: wfDefaultApproverGroups/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,StepCode,GroupCode,wfCode")] wfDefaultApproverGroup wfDefaultApproverGroup)
        {
            if (ModelState.IsValid)
            {
                wfDefaultApproverGroup.id = Guid.NewGuid();
                db.wfDefaultApproverGroup.Add(wfDefaultApproverGroup);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(wfDefaultApproverGroup);
        }

        // GET: wfDefaultApproverGroups/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wfDefaultApproverGroup wfDefaultApproverGroup = await db.wfDefaultApproverGroup.FindAsync(id);
            if (wfDefaultApproverGroup == null)
            {
                return HttpNotFound();
            }
            return View(wfDefaultApproverGroup);
        }

        // POST: wfDefaultApproverGroups/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,StepCode,GroupCode,wfCode")] wfDefaultApproverGroup wfDefaultApproverGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wfDefaultApproverGroup).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(wfDefaultApproverGroup);
        }

        // GET: wfDefaultApproverGroups/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wfDefaultApproverGroup wfDefaultApproverGroup = await db.wfDefaultApproverGroup.FindAsync(id);
            if (wfDefaultApproverGroup == null)
            {
                return HttpNotFound();
            }
            return View(wfDefaultApproverGroup);
        }

        // POST: wfDefaultApproverGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            wfDefaultApproverGroup wfDefaultApproverGroup = await db.wfDefaultApproverGroup.FindAsync(id);
            db.wfDefaultApproverGroup.Remove(wfDefaultApproverGroup);
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
