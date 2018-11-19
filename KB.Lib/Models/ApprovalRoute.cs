using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace KB.Models
{
    [Serializable()]
    public class ApprovalRoute
    {
        public DATA0497 Data0497;
        public List<ApprovalRouteStep> ApprovalRouteStepList;
        public ApprovalRoute()
        {
            ApprovalRouteStepList = new List<ApprovalRouteStep>();
        }
    }
    [Serializable()]
    public class ApprovalRouteStep
    {
        public DATA0498 Data0498;
        public List<ApprovalRouteStepUser> ApprovalRouteStepUserList;
        public ApprovalRouteStep()
        {
            ApprovalRouteStepUserList = new List<ApprovalRouteStepUser>();
        }
    }
    [Serializable()]
    public class ApprovalRouteStepUser
    {
        public DATA0499 Data0499;
        public DATA0073 Data0073;
        public ApprovalRouteStepUser()
        { 
        
        }
    }
}
