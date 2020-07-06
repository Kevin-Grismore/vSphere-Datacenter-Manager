using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Basic constructor for VM object, saved when adding new VM to kit
namespace _27vApp
{
    [Serializable]
    public class VMInfo
    {
        public string name;
        public int bootOrder;
        public SerializableDictionary<int, int> NICMap;

        public VMInfo()
        {

        }

        public VMInfo(string name, int bootOrder, SerializableDictionary<int, int> NICMap)
        {
            this.name = name;
            this.bootOrder = bootOrder;

            this.NICMap = NICMap;
        }
    }
}