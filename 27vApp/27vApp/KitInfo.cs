using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Basic constructor for KitInfo object, saved when submitting new kit form
namespace _27vApp
{
    [Serializable]

    public class KitInfo
    {
        public string name;
        public string labNetwork;
        public string student;
        public int numPortGroups;
        public string portGroupPrefix;
        public List<VMInfo> VMs;

        public KitInfo()
        {

        }

        public KitInfo(string name, string labNetwork, string student, int numPortGroups, string portGroupPrefix, List<VMInfo> VMs)
        {
            this.name = name;
            this.labNetwork = labNetwork;
            this.student = student;
            this.numPortGroups = numPortGroups;
            this.portGroupPrefix = portGroupPrefix;

            this.VMs = VMs;
        }
    }
}