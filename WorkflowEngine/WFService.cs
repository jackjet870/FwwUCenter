using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowEngine
{
    public class WFService
    {
        /*
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         */
        public int NewTicket(string userID, string wfCode)
        {
            int returnVal = 0;
            using(WorkflowEngineEntities db = new WorkflowEngineEntities())
            {            
                returnVal = db.Proc_NewTicket(userID, wfCode);
            };
            
            
            return returnVal;
        }

        public int ApprovalPassed(string userID, string ticketNum, string memo)
        {
            int returnVal = 0;
            using (WorkflowEngineEntities db = new WorkflowEngineEntities())
            {
                returnVal = db.Proc_ApprovalPassed(userID, ticketNum, memo);
            };


            return returnVal;
        
        }

        public int ApprovalDenied(string userID, string ticketNum, string memo)
        {
            int returnVal = 0;
            using (WorkflowEngineEntities db = new WorkflowEngineEntities())
            {
                returnVal = db.Proc_ApprovalDenied(userID, ticketNum, memo);
            };


            return returnVal;

        }

        public List<Proc_GetTodoTickets_Result> GetTodoTickets(string userid, string wfCode)
        {
            //获取待处理单子
            List<Proc_GetTodoTickets_Result> returnVal;
            using (WorkflowEngineEntities db = new WorkflowEngineEntities())
            {
                returnVal = db.Proc_GetTodoTickets(userid, wfCode).ToList();

            }
            return returnVal;
        }
        public List<Proc_GetInprogressTickets_Result> GetInprogressTickets(string userid, string wfCode)
        {
            //获取已处理单子
            List<Proc_GetInprogressTickets_Result> returnVal;
            using (WorkflowEngineEntities db = new WorkflowEngineEntities())
            {
                returnVal = db.Proc_GetInprogressTickets(userid, wfCode).ToList();

            }
            return returnVal;
        }
        public List<Proc_GetCompletedTickets_Result> GetCompletedTickets(string userid, string wfCode)
        {
            //获取已完成单子
            List<Proc_GetCompletedTickets_Result> returnVal;
            using (WorkflowEngineEntities db = new WorkflowEngineEntities())
            {
                returnVal = db.Proc_GetCompletedTickets(userid, wfCode).ToList();

            }
            return returnVal;
        }
        public bool IsCurrentApprover(string userid,string ticketNum)
        {
            bool returnVal = false;
            List<Proc_IsCurrentApprover_Result> templist;
            using (WorkflowEngineEntities db = new WorkflowEngineEntities())
            {
                templist = db.Proc_IsCurrentApprover(userid, ticketNum).ToList();
                if (templist != null)
                {
                    if (templist.Count() > 0)
                        returnVal = true;
                }

            }
            return returnVal;
        }
        public List<Proc_QueryCurrentApprovers_Result> QueryCurrentApprovers(string ticketNum,string stepCode)
        {
            List<Proc_QueryCurrentApprovers_Result> list;

            using (WorkflowEngineEntities db = new WorkflowEngineEntities())
            {
                list = db.Proc_QueryCurrentApprovers(ticketNum, stepCode).ToList();
            }

            return list;
        }

        public List<Proc_QueryTicketCurrentStep_Result> QueryTicketCurrentStep(string ticketNum)
        {
            List<Proc_QueryTicketCurrentStep_Result> list;

            using (WorkflowEngineEntities db = new WorkflowEngineEntities())
            {
                list = db.Proc_QueryTicketCurrentStep(ticketNum).ToList();
            }

            return list;
        }

        public List<Proc_QueryTicketProgress_Result> QueryTicketProgress(string ticketNum)
        {
            List<Proc_QueryTicketProgress_Result> list;

            using (WorkflowEngineEntities db = new WorkflowEngineEntities())
            {
                list = db.Proc_QueryTicketProgress(ticketNum).ToList();
            }

            return list;
        }




    }
}
