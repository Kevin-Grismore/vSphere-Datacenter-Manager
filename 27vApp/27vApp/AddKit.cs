using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace _27vApp
{
    public partial class AddKit : Form
    {
        public KitInfo kitInfo;
        private KitInfo editKit;
        private Form1 mainForm;
        private bool editing;

        SerializableDictionary<int, int> NICMapTemp;
        List<VMInfo> VMsTemp;

        //Generic constructor
        public AddKit()
        {
            InitializeComponent();
            NICMapTemp = new SerializableDictionary<int, int>();
            VMsTemp = new List<VMInfo>();
        }

        
        public AddKit(Form callingForm, bool editing)
        {
            InitializeComponent();

            //Create temporary VM list and network mapping to be written to file
            NICMapTemp = new SerializableDictionary<int, int>();
            VMsTemp = new List<VMInfo>();

            //Called from Form1
            mainForm = (Form1)callingForm;

            //Let Form1 know that the kit is being edited
            this.editing = editing;
        }

        private void AddKit_Load(object sender, EventArgs e)
        {
            if(editing)
            {
                //Activate the Save button when a change is made to the kit form
                AddKitButton.Text = "Save";

                editKit = null;

                //Check the kits from Form1 to see if an existing kit is being edited
                foreach(KitInfo kit in mainForm.kits)
                {
                    if (kit.name == mainForm.KitInfoListBox.SelectedItem.ToString())
                        editKit = kit;
                }

                NameBox.Text = editKit.name;
                LabNetworkBox.Text = editKit.labNetwork;
                StudentBox.Text = editKit.student;
                PortGroupBox.Text = editKit.numPortGroups.ToString();
                PrefixBox.Text = editKit.portGroupPrefix;

                //Add the VMs to the edited kit
                foreach(VMInfo VM in editKit.VMs)
                {
                    VMListBox.Items.Add(VM.bootOrder + " | " + VM.name);
                    VMsTemp.Add(VM);
                }
                
                //Delete the outdated kit from Form1
                mainForm.kits.Remove(editKit);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<VMInfo> VMs = new List<VMInfo>();

            //Add the VMs from VMTemp the the final VMs list
            foreach(VMInfo VM in VMsTemp)
            {
                VMs.Add(VM);
            }

            //Create a new kit based on the final VMs list and the entered info in text boxes
            kitInfo = new KitInfo(NameBox.Text, LabNetworkBox.Text, StudentBox.Text, Convert.ToInt32(PortGroupBox.Text), PrefixBox.Text, VMs);
            VMsTemp.Clear();


            //Write the new kit to the kits file
            XmlSerializer writer = new XmlSerializer(typeof(KitInfo));
            string path = Path.GetDirectoryName(Application.ExecutablePath) + "//Kits//" + kitInfo.name + ".xml";

            if (File.Exists(path) && editing)
            {
                File.Delete(path);
            }

            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, kitInfo);
            file.Close();

            //Remove the old kit from the file and the in-app list
            if(editing)
            {
                mainForm.kitPaths.Remove(mainForm.KitInfoListBox.SelectedItem.ToString());
                mainForm.KitInfoListBox.Items.Remove(mainForm.KitInfoListBox.SelectedItem);
            }

            //Add the new kit to the in-app list
            mainForm.KitInfoListBox.Items.Add(kitInfo.name);
            mainForm.kits.Add(kitInfo);
            mainForm.kitPaths.Add(kitInfo.name, path);

            AddKit.ActiveForm.Close();
        }

        //Adds the new kit to Form1's kit list when the Add button is clicked
        private void button2_Click(object sender, EventArgs e)
        {
            if(editing)
                mainForm.kits.Add(editKit);

            AddKit.ActiveForm.Close();
        }

        private void AddNICButton_Click(object sender, EventArgs e)
        {
            //Add the nework from the text box to the network list and update the list text
            NICMapTemp.Add(Convert.ToInt32(NICBox.Text), Convert.ToInt32(NICPortBox.Text));
            NICListBox.Items.Add(NICBox.Text + " | Port Group " + NICPortBox.Text);
            NICBox.Clear();
            NICPortBox.Clear();
        }

        private void AddVMButton_Click(object sender, EventArgs e)
        {
            //Create a new network mapping for this VM
            SerializableDictionary<int, int> NICMap = new SerializableDictionary<int, int>();

            //Add the netowrks to the map
            for(int i = 1; i < NICMapTemp.Count + 1; i++)
            {
                NICMap.Add(i, NICMapTemp[i]);
            }

            //Build a complete VMInfo from the VM and the NICMap
            VMInfo VM = new VMInfo(VMNameBox.Text, Convert.ToInt32(BootOrderBox.Text), NICMap);
            VMsTemp.Add(VM);
            VMListBox.Items.Add(BootOrderBox.Text + " | " + VMNameBox.Text);

            NICMapTemp.Clear();
            VMNameBox.Clear();
            BootOrderBox.Clear();
            NICListBox.Items.Clear();
        }

        //Removes a NIC from the NIC list for this kit
        private void RemoveNICButton_Click(object sender, EventArgs e)
        {
            NICMapTemp.Remove(Convert.ToInt32(NICListBox.SelectedItem.ToString().Substring(0, 1)));
            NICListBox.Items.Remove(NICListBox.SelectedItem);
        }

        //Uses the list text for a VM to find it in VMs and remove it
        private void RemoveVMButton_Click(object sender, EventArgs e)
        {
            VMInfo match = null;

            foreach (VMInfo VM in VMsTemp)
            {
                if(VM.bootOrder == Convert.ToInt32(VMListBox.SelectedItem.ToString().Substring(0, 1)))
                {
                     match = VM;
                }
            }

            if(match != null)
                VMsTemp.Remove(match);
            
            VMListBox.Items.Remove(VMListBox.SelectedItem);
        }
    }
}