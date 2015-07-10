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
         * 流程步骤缺少是否强制审批属性，用于流程正向、逆向来回跳转，默认为非强制审批
         * 
         * 
         * 
         * 
         * 
         * 
         */
        public string TestFunc()
        {
            return "Hello World";
        }

        public string NewTicket(string userID, string wfCode)
        {
            return "dlfjalfdsjkfa";
        }

        public int GotoNextStep(string userID, string approveResult, string ticketNum,string currentStemCode)
        {
            return 1;
        
        }

        public string GetTodoTickets()
        {
            //获取待处理单子
            return "dlfjalfdsjkfa";
        }
        public string GetInprogressTickets()
        {
            //获取已处理单子
            return "dlfjalfdsjkfa";
        }
        public string GetCompletedTickets()
        {
            //获取已完成单子
            return "dlfjalfdsjkfa";
        }
        public string GetCurrentStep()
        {
            return "dlfjalfdsjkfa";
        }
        public string GetNextStepApprovers()
        {
            return "dlfjalfdsjkfa";
        }
        public string GetCurrentStepApprovers()
        {
            return "dlfjalfdsjkfa";
        }

        public string GetIFCurrentStepApproverOrNot()
        {
            return "dlfjalfdsjkfa";
        }




    }
}
