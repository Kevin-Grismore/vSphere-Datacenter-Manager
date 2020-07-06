using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Web.Services.Protocols;
using VMware.Vim;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Xml.Serialization;

namespace _27vApp
{
    public partial class Form1 : Form
    {
        private static AppUtil.AppUtil cb = null;
        
        private VimClient client = new VimClientImpl();

        private List<EntityViewBase> basevApps = new List<EntityViewBase>();
        private List<EntityViewBase> basePools = new List<EntityViewBase>();

        public List<KitInfo> kits = new List<KitInfo>();
        public Dictionary<string, string> kitPaths = new Dictionary<string, string>();

        private string[] args = new string[3];
        private string cloneTargetName;
        private string deployTargetName;

        private KitInfo vAppToDeploy;

        private Network labKitAccess;

        private SerializableDictionary<string, VirtualApp> hostNamevAppMap = new SerializableDictionary<string, VirtualApp>();
        private SerializableDictionary<string, HostSystem> vAppNameHostMap = new SerializableDictionary<string, HostSystem>();
        private SerializableDictionary<string, DistributedVirtualPortgroup> portGroupNameMap = new SerializableDictionary<string, DistributedVirtualPortgroup>();

        public void CreateServiceRef(string name, string[] args)
        {
            var svcCon = cb.getConnection();
        }

        public Form1()
        {
            InitializeComponent();

            //Get conncetion to vSphere server
            ServerComboBox.Items.Add("Removed server address");

            ServerComboBox.SelectedItem = ServerComboBox.Items[0];

            //Prepare to open kits file
            XmlSerializer reader = new XmlSerializer(typeof(KitInfo));
            
            //Open kits file
            string[] filePaths = Directory.GetFiles(Path.GetDirectoryName(Application.ExecutablePath) + "//Kits");

            foreach (string path in filePaths)
            {
                StreamReader file = new StreamReader(path);

                KitInfo kitInfo = (KitInfo)reader.Deserialize(file);
                kits.Add(kitInfo);
                kitPaths.Add(kitInfo.name, path);

                file.Close();
            }

            //Fill in-app kit list
            foreach(KitInfo info in kits)
            {
                KitInfoListBox.Items.Add(info.name);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Required settings for accepting and ignoring certificates to create valid connection to private vSphere server
        private void IgnoreBadCertificates()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
        }

        private bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        //Upon successful connection to the selected server, this will attempt to find the required base
        //resource pool and vApp that will be used for cloning later
        private void connectButton_Click(object sender, EventArgs e)
        {
            //Get entered username and password
            args[0] = ServerComboBox.SelectedItem.ToString();
            args[1] = usernameTextBox.Text;
            args[2] = passwordTextBox.Text;

            try
            {
                // Connect to the Service
                console.Items.Add("Connecting to " + args[0] + "/sdk...");
                IgnoreBadCertificates();
                client.Connect(args[0] + "/sdk");
                console.Items.Add("Connection successful");
            }

            catch (Exception ex)
            {
                console.Items.Add("Connection to " + args[0] + " failed");
                console.Items.Add(ex.Message);
            }

            try
            {
                //Login to vCenter
                client.Login(args[1], args[2]);
                console.Items.Add("Login successful");
            }

            catch (Exception ex)
            {
                console.Items.Add("Login failed");
                console.Items.Add(ex.Message);
            }

            //Set up naming conventions to locate existing base vApp
            NameValueCollection ICMBase = new NameValueCollection();
            Regex basevAppName = new Regex(@"\ZBASE-111",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);
            
            ICMBase.Add("name", "BASE-111$");

            //Locate base resource pool and vApp given specified naming convention
            NameValueCollection basePoolName = new NameValueCollection();
            basePoolName.Add("name", "BASE vApps");

            basePools = client.FindEntityViews(typeof(ResourcePool), null, basePoolName, null);

            basevApps = client.FindEntityViews(typeof(VirtualApp), null, ICMBase, null);

            //Add the found vApp names to the visible list
            foreach(VirtualApp vApp in basevApps)
            {
                BasevAppListBox.Items.Add(vApp.Name);
            }

            //Find the port group for student connections
            NameValueCollection studentPortGroupName = new NameValueCollection();
            studentPortGroupName.Add("name", "100-LabKitAccess$");

            labKitAccess = (Network)client.FindEntityView(typeof(Network), null, studentPortGroupName, null);

            //Set the name for the lab access network
            LabAccessLabel.Text = labKitAccess.Name;
        }

        //This checks to see if copies of the base vApp exist on each host
        //Cloning across hosts takes too long, so a base vApp must exist in each intended cloning location
        private void ScanCloneTargets_Click(object sender, EventArgs e)
        {
            CloneTargetsListBox.Items.Clear();
            
            //Sets up names for the vApp to be cloned and the target servers
            NameValueCollection basevAppName = new NameValueCollection();
            basevAppName.Add("name", cloneTargetName);

            NameValueCollection hostNames = new NameValueCollection();
            hostNames.Add("name", "^tampa-11");

            List<EntityViewBase> currentBasevApps = new List<EntityViewBase>();
            List<EntityViewBase> classHosts = new List<EntityViewBase>();
            List<HostSystem> classHostSystems = new List<HostSystem>();

            //Finds the base vApp on each target server
            currentBasevApps = client.FindEntityViews(typeof(VirtualApp), null, basevAppName, null);
            classHosts = client.FindEntityViews(typeof(HostSystem), null, hostNames, null);

            foreach (HostSystem host in classHosts)
            {
                classHostSystems.Add(host);
            }

            console.Items.Add("Checking hosts for existing copies of " + cloneTargetName + "...");

            foreach (VirtualApp vApp in currentBasevApps)
            {
                ResourcePool parentPool = (ResourcePool)client.GetView(vApp.Parent, null);
                ResourcePool parentRes = (ResourcePool)client.GetView(parentPool.Parent, null);
                ComputeResource parentComp = (ComputeResource)client.GetView(parentRes.Parent, null);
                HostSystem parentHost = (HostSystem)client.GetView(parentComp.Host[0], null);

                int foundIndex = 0;
                bool found = false;
                for(int i = 0; i < classHostSystems.Count; i++)
                {
                    if (classHostSystems[i].Name == parentHost.Name)
                    {
                        found = true;
                        foundIndex = i;
                    }
                }

                if (found)
                    classHostSystems.RemoveAt(foundIndex);
            }

            console.Items.Add("Displaying hosts that do not have a copy of " + cloneTargetName + " in BASE vApps");
            
            foreach (HostSystem host in classHostSystems)
            {
                CloneTargetsListBox.Items.Add(host.Name);
            }

            UpdateDeleteTargetListBox();
        }

        //Since this tool can also delete vApps, display a list of potential deletion targets
        private void UpdateDeleteTargetListBox()
        {

            List<EntityViewBase> allvApps = new List<EntityViewBase>();
            List<EntityViewBase> classHosts = new List<EntityViewBase>();
            List<HostSystem> classHostSystems = new List<HostSystem>();


            NameValueCollection hostNames = new NameValueCollection();
            hostNames.Add("name", "^tampa-11");
            classHosts = client.FindEntityViews(typeof(HostSystem), null, hostNames, null);

            foreach (HostSystem host in classHosts)
            {
                classHostSystems.Add(host);
            }

            DeleteTargetListBox.Items.Clear();


            allvApps = client.FindEntityViews(typeof(VirtualApp), null, null, null);

            foreach (VirtualApp vApp in allvApps)
            {
                ResourcePool parentPool = (ResourcePool)client.GetView(vApp.Parent, null);
                ResourcePool parentRes = (ResourcePool)client.GetView(parentPool.Parent, null);
                ComputeResource parentComp = (ComputeResource)client.GetView(parentRes.Parent, null);
                HostSystem parentHost = (HostSystem)client.GetView(parentComp.Host[0], null);

                for (int i = 0; i < classHostSystems.Count; i++)
                {
                    if (classHostSystems[i].Name == parentHost.Name && parentPool.Name == "KITS")
                    {
                        DeleteTargetListBox.Items.Add(vApp.Name);
                    }
                }
            }
        }

        //Update in-app text displays
        private void BasevAppListBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            String vAppName = BasevAppListBox.SelectedItem.ToString();
            vAppName = vAppName.Remove(vAppName.Length - 4, 4);
            cloneTargetName = vAppName;

            CloneInfo.Text = "Clone " + cloneTargetName;
            ToText.Text = "to";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //The first step clone-deploy-boot process. This is a preparatory step that runs on each server. 
        //It creates clones of each base vApp to other servers to act as targets for eventual VM cloning. It then 
        //creates linked clone snapshots of each of the VMs on the base vApp for each server, which will be 
        //used as the reference point for each cloned VM
        private void CloneToTargets_Click(object sender, EventArgs e)
        {
            //Get the name of the clone target vApp
            String vAppName = BasevAppListBox.SelectedItem.ToString();

            NameValueCollection vAppToCloneName = new NameValueCollection();
            vAppToCloneName.Add("name", vAppName);

            //Get the clone target vApp using its name
            VirtualApp vAppToClone = (VirtualApp)client.FindEntityView(typeof(VirtualApp), null, vAppToCloneName, null);

            //For each of the servers to clone on
            foreach (object obj in CloneTargetsListBox.CheckedItems)
            {
                //Get the name of the server
                NameValueCollection hostName = new NameValueCollection();
                hostName.Add("name", (string)obj);

                //Find the server given its name
                HostSystem targetHost = (HostSystem)client.FindEntityView(typeof(HostSystem), null, hostName, null);

                //Get the datastore name for the server
                NameValueCollection targetStoreName = new NameValueCollection();
                targetStoreName.Add("name", Convert.ToInt32(targetHost.Name.Substring(7, 2)) + "$");

                //Fill out all the info the clone task needs to begin
                VAppCloneSpec spec = new VAppCloneSpec();

                //Including its host,
                int basePoolIndex = Convert.ToInt32(targetHost.Name.Substring(8, 1));
                spec.Host = targetHost.MoRef;

                //its datastore,
                Datastore targetStore = (Datastore)client.FindEntityView(typeof(Datastore), null, targetStoreName, null);
                spec.Location = targetStore.MoRef;

                //its folder,
                NameValueCollection folderName = new NameValueCollection();
                folderName.Add("name", "vmDevelopment");

                Folder targetFolder = (Folder)client.FindEntityView(typeof(Folder), null, folderName, null);
                spec.VmFolder = targetFolder.MoRef;

                //and its resource pool
                ResourcePool targetPool = null;

                foreach (ResourcePool pool in basePools)
                {
                    ComputeResource ownerComp = (ComputeResource)client.GetView(pool.Owner, null);
                    HostSystem parentHost = (HostSystem)client.GetView(ownerComp.Host[0], null);

                    if(parentHost.Name == targetHost.Name)
                    {
                        targetPool = pool;
                    }
                }

                if(targetPool == null)
                {
                    console.Items.Add("Target resourcepool could not be found");
                }

                //Display cloning message
                console.Items.Add("Attempting to clone " + vAppName + " to " + targetHost.Name + " in " + targetPool.Name + " on " +
                    targetStore.Name + " in " + targetFolder.Name + " folder...");

                //Format the name of the vApp clone
                string vAppCloneName = vAppToClone.Name.Remove(vAppToClone.Name.Length - 1, 1) + basePoolIndex.ToString();

                //Begin the vApp cloning task
                ManagedObjectReference cloneTask_MoRef = vAppToClone.CloneVApp_Task(vAppCloneName, targetPool.MoRef, spec);
                VMware.Vim.Task cloneTask = (VMware.Vim.Task)client.GetView(cloneTask_MoRef, null);
                
                //Check and display cloning progress
                while(cloneTask.Info.State != TaskInfoState.success)
                {
                    Thread.Sleep(1000);
                    cloneTask.UpdateViewData();
                    if (cloneTask.Info.Progress != null)
                        cloneProgressBar.Value = (int)cloneTask.Info.Progress;

                    else
                        cloneProgressBar.Value = 0;
                }

                //Notify user of completed clone
                console.Items.Add("Cloning finished");

                //Find the cloned vApp by name
                NameValueCollection clonedvAppName = new NameValueCollection();
                clonedvAppName.Add("name", vAppCloneName);

                VirtualApp clonedvApp = (VirtualApp)client.FindEntityView(typeof(VirtualApp), null, clonedvAppName, null);

                //Create a linked clone snapshot each individual VM contained in the clone target
                foreach(VAppEntityConfigInfo vmInfo in clonedvApp.VAppConfig.EntityConfig)
                {
                    //Begin the VM snapshot task
                    VirtualMachine currentVM = (VirtualMachine)client.GetView(vmInfo.Key, null);
                    ManagedObjectReference snapshotTaskMoRef = currentVM.CreateSnapshot_Task(currentVM.Name + "LinkedCloneSnapshot", 
                        "Snapshot for linked cloning", false, true);

                    VMware.Vim.Task snapshotTask = (VMware.Vim.Task)client.GetView(cloneTask_MoRef, null);

                    //Check and display snapshot progress
                    while (snapshotTask.Info.State != TaskInfoState.success)
                    {
                        Thread.Sleep(1000);
                        cloneTask.UpdateViewData();
                        if (cloneTask.Info.Progress != null)
                            cloneProgressBar.Value = (int)cloneTask.Info.Progress;

                        else
                            cloneProgressBar.Value = 0;
                    }

                    //Notify user of completed snapshot
                    console.Items.Add(currentVM.Name + " snapshot created");
                }
            }
        }

        private void CloneTargetsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Add a clone target to the list when its checkbox is checked
        private void CloneTargetsListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                CloneTargetList.Items.Clear();

                foreach (object obj in CloneTargetsListBox.CheckedItems)
                {
                    CloneTargetList.Items.Add(obj.ToString());
                }
            });
        }

        //Open the Add Kit window
        private void AddKitButton_Click(object sender, EventArgs e)
        {
            AddKit addKit = new AddKit(this, false);
            addKit.Show();
        }

        //Delete a kit from the kit list
        private void RemoveKitButton_Click(object sender, EventArgs e)
        {
            KitInfo deleteKit = null;

            foreach (KitInfo kit in kits)
            {
                if (kit.name == KitInfoListBox.SelectedItem.ToString())
                    deleteKit = kit;
            }

            kits.Remove(deleteKit);
            KitInfoListBox.Items.Remove(KitInfoListBox.SelectedItem);
            File.Delete(kitPaths[deleteKit.name]);
        }

        //Edit an existing kit on the kit list
        private void EditKitButton_Click(object sender, EventArgs e)
        {
            AddKit addKit = new AddKit(this, true);
            addKit.Show();
        }

        //Find and list all the kits on a selected server
        //This can be a slow task, so it's mapped to a button instead of happening at login
        private void ScanKitsButton_Click(object sender, EventArgs e)
        {
            DeployTargetsListBox.Items.Clear();
            PortGroupListBox.Items.Clear();
            hostNamevAppMap.Clear();
            vAppNameHostMap.Clear();

            //Find any kit that has a name matching the server
            NameValueCollection basevAppName = new NameValueCollection();
            basevAppName.Add("name", "^" + deployTargetName);

            NameValueCollection hostNames = new NameValueCollection();
            hostNames.Add("name", "^tampa-11");

            List<EntityViewBase> currentBasevApps = new List<EntityViewBase>();
            List<EntityViewBase> classHosts = new List<EntityViewBase>();
            List<HostSystem> deployHostSystems = new List<HostSystem>();

            currentBasevApps = client.FindEntityViews(typeof(VirtualApp), null, basevAppName, null);
            classHosts = client.FindEntityViews(typeof(HostSystem), null, hostNames, null);

            console.Items.Add("Checking hosts for existing copies of " + deployTargetName + "...");

            //Climb up the hierarchy to ensure the server of each matching vApp is the correct one
            foreach (VirtualApp vApp in currentBasevApps)
            {
                ResourcePool parentPool = (ResourcePool)client.GetView(vApp.Parent, null);
                ResourcePool parentRes = (ResourcePool)client.GetView(parentPool.Parent, null);
                ComputeResource parentComp = (ComputeResource)client.GetView(parentRes.Parent, null);
                HostSystem parentHost = (HostSystem)client.GetView(parentComp.Host[0], null);

                //Add the found vApp and server to the list
                deployHostSystems.Add(parentHost);
                hostNamevAppMap.Add(parentHost.Name, vApp);
                vAppNameHostMap.Add(vApp.Name, parentHost);
            }

            List<string> deployHostNames = new List<string>();

            foreach (HostSystem host in deployHostSystems)
            {
                deployHostNames.Add(host.Name);
            }

            deployHostNames.Sort();

            //Show the server names in-app
            foreach (string name in deployHostNames)
            {
                foreach (HostSystem host in deployHostSystems)
                {
                    if (name == host.Name)
                        DeployTargetsListBox.Items.Add(host.Name);
                }
            }
            
            console.Items.Add("Displaying hosts that have a copy of " + deployTargetName + " in BASE vApps");

            //Find the matching networks for each server by name
            NameValueCollection portGroupName = new NameValueCollection();
            portGroupName.Add("name", "^" + vAppToDeploy.portGroupPrefix);

            List<EntityViewBase> portGroupsEVB = client.FindEntityViews(typeof(DistributedVirtualPortgroup), null, portGroupName, null);
            List<string> portGroupNames = new List<string>();
            List<DistributedVirtualPortgroup> portGroups = new List<DistributedVirtualPortgroup>();

            foreach(DistributedVirtualPortgroup portGroup in portGroupsEVB)
            {
                portGroupNames.Add(portGroup.Name);
            }

            portGroupNames.Sort();

            foreach(string name in portGroupNames)
            {
                foreach (DistributedVirtualPortgroup portGroup in portGroupsEVB)
                {
                    if (name == portGroup.Name)
                    {
                        portGroupNameMap.Add(portGroup.Name, portGroup);
                        portGroups.Add(portGroup);
                    }
                }
            }

            //Show the network names in-app
            foreach(DistributedVirtualPortgroup portGroup in portGroups)
            {
                PortGroupListBox.Items.Add(portGroup.Name);
            }
        }

        //Update the deploy target based on in-app selection
        private void KitInfoListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(KitInfo kit in kits)
            {
                if (KitInfoListBox.SelectedItem.ToString() == kit.name)
                    vAppToDeploy = kit;
            }

            deployTargetName = vAppToDeploy.name;
        }

        private void DeployButton_Click(object sender, EventArgs e)
        {
            Deploy();
        }

        //Set how many clones to deploy to each server
        private void CopyCountTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                PortGroupCountLabel.Text = "of " + (vAppToDeploy.numPortGroups * Convert.ToInt32(CopyCountTextBox.Text)).ToString();
            }

            catch(Exception ex)
            {

            }
        }
        //Update which networks to attach to cloned vApps
        private void PortGroupListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                PortGroupSelectedLabel.Text = PortGroupListBox.CheckedItems.Count.ToString();
            });
        }

        //The middle step of the clone-deploy-boot process. It clones the actual VMs from their linked clone snapshots
        //to their target vApps on each server, connects them to their intended networks, and applies their custom settings,
        //such as default power operations and boot order
        private List<VirtualApp> Deploy()
        {
            List<VirtualApp> vAppsToBoot = new List<VirtualApp>();

            List<HostSystem> selectedHosts = new List<HostSystem>();
            List<VirtualApp> selectedvApps = new List<VirtualApp>();
            List<EntityViewBase> kitsPoolsEVB = new List<EntityViewBase>();
            List<ResourcePool> kitsPools = new List<ResourcePool>();
            List<DistributedVirtualPortgroup> selectedPortGroups = new List<DistributedVirtualPortgroup>();
            List<ManagedObjectReference> networks_MoRef = new List<ManagedObjectReference>();

            networks_MoRef.Add(labKitAccess.MoRef);

            NameValueCollection kitsRPName = new NameValueCollection();
            kitsRPName.Add("name", "KITS");

            //Create lists for the vApps and servers VMs will be deployed to
            foreach (object item in DeployTargetsListBox.CheckedItems)
            {
                VirtualApp vApp = hostNamevAppMap[item.ToString()];
                selectedvApps.Add(vApp);
                selectedHosts.Add(vAppNameHostMap[vApp.Name]);
            }

            //Get each of the networks that will be mapped to VMs
            foreach (object item in PortGroupListBox.CheckedItems)
            {
                selectedPortGroups.Add(portGroupNameMap[item.ToString()]);
                networks_MoRef.Add(portGroupNameMap[item.ToString()].MoRef);
            }

            kitsPoolsEVB = client.FindEntityViews(typeof(ResourcePool), null, kitsRPName, null);

            //Get the resource pools used for each vApp
            foreach (ResourcePool pool in kitsPoolsEVB)
            {
                ComputeResource ownerComp = (ComputeResource)client.GetView(pool.Owner, null);
                HostSystem parentHost = (HostSystem)client.GetView(ownerComp.Host[0], null);

                foreach (HostSystem host in selectedHosts)
                {
                    if (host.Name == parentHost.Name)
                        kitsPools.Add(pool);
                }
            }

            foreach (HostSystem host in selectedHosts)
            {
                kitsPools.Add((ResourcePool)client.FindEntityView(typeof(ResourcePool), host.MoRef, kitsRPName, null));
            }

            //Get the number of copies to deploy
            int copyCount = Convert.ToInt32(CopyCountTextBox.Text);

            //Get the empty vApps from the clone step
            NameValueCollection emptyvAppName = new NameValueCollection();
            emptyvAppName.Add("name", "^Empty");

            VirtualApp emptyvApp = (VirtualApp)client.FindEntityView(typeof(VirtualApp), null, emptyvAppName, null);

            //For each vApp to deploy
            for (int i = 0; i < copyCount; i++)
            {
                //Get the network for this vApp
                List<ManagedObjectReference> vAppNetworks = new List<ManagedObjectReference>();

                vAppNetworks.Add(networks_MoRef[0]);

                for (int j = 0; j < vAppToDeploy.numPortGroups; j++)
                {
                    vAppNetworks.Add(networks_MoRef[1 + j + (vAppToDeploy.numPortGroups * i)]);
                }

                //Get the datastore for this vApp
                NameValueCollection targetStoreName = new NameValueCollection();
                targetStoreName.Add("name", Convert.ToInt32(selectedHosts[i % selectedHosts.Count].Name.Substring(7, 2)) + "$");

                //Build a clone spec for this vVapp, including
                VAppCloneSpec spec = new VAppCloneSpec();

                //tts server
                int basePoolIndex = Convert.ToInt32(selectedHosts[i % selectedHosts.Count].Name.Substring(8, 1));
                spec.Host = selectedHosts[i % selectedHosts.Count].MoRef;

                //its datastore
                Datastore targetStore = (Datastore)client.FindEntityView(typeof(Datastore), null, targetStoreName, null);
                spec.Location = targetStore.MoRef;

                //its folder
                NameValueCollection folderName = new NameValueCollection();
                folderName.Add("name", "vmDevelopment");

                Folder targetFolder = (Folder)client.FindEntityView(typeof(Folder), null, folderName, null);
                spec.VmFolder = targetFolder.MoRef;

                //and its name, based on its server, network, and number
                string vAppName = selectedPortGroups[i * vAppToDeploy.numPortGroups].Name.Substring(4, 3) + "-" + selectedHosts[i % selectedHosts.Count].Name.Substring(6, 3) + "-" + vAppToDeploy.name;

                //Run a clone task to create empty vApp clones on the curent server to receive eventual VM clones
                ManagedObjectReference emptyvAppCloneTask_MoRef = emptyvApp.CloneVApp_Task(vAppName, kitsPools[i % selectedHosts.Count].MoRef, spec);
                VMware.Vim.Task vAppCloneTask = (VMware.Vim.Task)client.GetView(emptyvAppCloneTask_MoRef, null);

                //Track and update vApp clone task progress
                while (vAppCloneTask.Info.State != TaskInfoState.success)
                {
                    Thread.Sleep(1000);
                    vAppCloneTask.UpdateViewData();
                    if (vAppCloneTask.Info.Progress != null)
                        deployProgressBar.Value = (int)vAppCloneTask.Info.Progress;

                    else
                        deployProgressBar.Value = 0;
                }

                //Add the newly created vApp to a list of vApps to boot later
                NameValueCollection newvAppName = new NameValueCollection();
                newvAppName.Add("name", vAppName);

                VirtualApp newvApp = (VirtualApp)client.FindEntityView(typeof(VirtualApp), null, newvAppName, null);

                vAppsToBoot.Add(newvApp);

                VAppEntityConfigInfo[] eConfigInfo = new VAppEntityConfigInfo[vAppToDeploy.VMs.Count];

                //Steps for each VM on the current vApp
                for (int j = 0; j < vAppToDeploy.VMs.Count; j++)
                {
                    //Get info on the VM about to be cloned
                    VirtualMachine childVM = (VirtualMachine)client.GetView(selectedvApps[i % selectedvApps.Count].Vm[j], null);

                    VMInfo currentVM = null;

                    foreach (VMInfo VM in vAppToDeploy.VMs)
                    {
                        if (childVM.Name == VM.name)
                            currentVM = VM;
                    }

                    //Get the linked clone snapshot of this VM
                    string snapshotName = childVM.Name + "LinkedCloneSnapshot";
                    string cloneVMName = selectedPortGroups[i * vAppToDeploy.numPortGroups].Name.Substring(4, 3) + "-" + childVM.Name;
                    VirtualMachineSnapshot snapshot = (VirtualMachineSnapshot)client.GetView(childVM.Snapshot.CurrentSnapshot, null);

                    //Create a clone spec for this VM
                    VirtualMachineCloneSpec cloneSpec = new VirtualMachineCloneSpec();
                    cloneSpec.Snapshot = snapshot.MoRef;

                    //Create a relocate spec for this VM
                    VirtualMachineRelocateSpec location = new VirtualMachineRelocateSpec();
                    location.Datastore = targetStore.MoRef;
                    location.Folder = targetFolder.MoRef;
                    location.Pool = newvApp.MoRef;
                    location.Host = selectedHosts[i % selectedHosts.Count].MoRef;
                    location.DiskMoveType = "createNewChildDiskBacking";

                    //Add the relocate spec to the clone spec
                    cloneSpec.Location = location;
                    cloneSpec.PowerOn = false;
                    cloneSpec.Template = false;

                    //Inform user individual VM cloning is beginning
                    console.Items.Add("Cloning " + childVM.Name + " to " + newvApp.Name + " in " + kitsPools[i % selectedHosts.Count].Name + " on " + selectedHosts[i % selectedHosts.Count].Name + "...");

                    //Begin clone VM task
                    ManagedObjectReference cloneVMTask_MoRef = childVM.CloneVM_Task(targetFolder.MoRef, cloneVMName, cloneSpec);
                    VMware.Vim.Task cloneVMTask = (VMware.Vim.Task)client.GetView(cloneVMTask_MoRef, null);

                    //Track and update clone VM task progress
                    while (cloneVMTask.Info.State != TaskInfoState.success)
                    {
                        Thread.Sleep(1000);
                        cloneVMTask.UpdateViewData();
                        if (cloneVMTask.Info.Progress != null)
                            deployProgressBar.Value = (int)cloneVMTask.Info.Progress;

                        else
                            deployProgressBar.Value = 0;
                    }

                    console.Items.Add("Cloning complete");

                    //When cloning is finished, get the new VM by name
                    NameValueCollection newVMName = new NameValueCollection();
                    newVMName.Add("name", cloneVMName);

                    VirtualMachine newVM = (VirtualMachine)client.FindEntityView(typeof(VirtualMachine), null, newVMName, null);

                    int netCount = 0;

                    //Iterate throught the new VM's virtual hardware to find the correct network adapter device
                    for (int k = 0; k < newVM.Config.Hardware.Device.Length; k++)
                    {
                        if (newVM.Config.Hardware.Device[k].DeviceInfo.Label.Length > 15)
                        {
                            if ("Network adapter" == newVM.Config.Hardware.Device[k].DeviceInfo.Label.Substring(0, 15))
                            {
                                console.Items.Add("Setting NIC " + newVM.Config.Hardware.Device[k].DeviceInfo.Label + " to port group " + ((Network)client.GetView(vAppNetworks[currentVM.NICMap[netCount + 1]], null)).Name);

                                //If this is a student VM, connect it to the student network for login access
                                if (currentVM.NICMap[netCount + 1] == 0)
                                {
                                    VirtualDeviceConfigSpec nicSpec = new VirtualDeviceConfigSpec();
                                    VirtualMachineConfigSpec configSpec = new VirtualMachineConfigSpec();
                                    VirtualEthernetCardNetworkBackingInfo backing = new VirtualEthernetCardNetworkBackingInfo();
                                    backing.Network = vAppNetworks[currentVM.NICMap[netCount + 1]];
                                    backing.DeviceName = ((Network)client.GetView(vAppNetworks[currentVM.NICMap[netCount + 1]], null)).Name;
                                    backing.UseAutoDetect = false;

                                    nicSpec.Device = newVM.Config.Hardware.Device[k];
                                    nicSpec.Device.Backing = backing;
                                    nicSpec.Operation = VirtualDeviceConfigSpecOperation.edit;

                                    configSpec.DeviceChange = new VirtualDeviceConfigSpec[]
                                    {
                                        nicSpec
                                    };

                                    newVM.ReconfigVM_Task(configSpec);
                                }

                                //Otherwise, connect it to the nework specified by the user
                                else
                                {
                                    VirtualDeviceConfigSpec nicSpec = new VirtualDeviceConfigSpec();
                                    VirtualMachineConfigSpec configSpec = new VirtualMachineConfigSpec();
                                    DistributedVirtualSwitchPortConnection conn = new DistributedVirtualSwitchPortConnection();
                                    conn.PortgroupKey = ((DistributedVirtualPortgroup)client.GetView(vAppNetworks[currentVM.NICMap[netCount + 1]], null)).Key;
                                    conn.SwitchUuid = ((DistributedVirtualSwitch)client.GetView(((DistributedVirtualPortgroup)client.GetView(vAppNetworks[currentVM.NICMap[netCount + 1]], null)).Config.DistributedVirtualSwitch, null)).Uuid;

                                    VirtualEthernetCardDistributedVirtualPortBackingInfo backing = new VirtualEthernetCardDistributedVirtualPortBackingInfo();

                                    backing.Port = conn;
                                    nicSpec.Device = newVM.Config.Hardware.Device[k];
                                    nicSpec.Device.Backing = backing;
                                    nicSpec.Operation = VirtualDeviceConfigSpecOperation.edit;

                                    configSpec.DeviceChange = new VirtualDeviceConfigSpec[]
                                    {
                                        nicSpec
                                    };

                                    newVM.ReconfigVM_Task(configSpec);
                                }

                                netCount++;
                            }
                        }
                    }

                    //Define custom VM settings
                    eConfigInfo[j] = new VAppEntityConfigInfo();
                    eConfigInfo[j].Key = newVM.MoRef;
                    eConfigInfo[j].StartOrder = currentVM.bootOrder;
                    eConfigInfo[j].WaitingForGuest = true;
                    eConfigInfo[j].StartAction = "powerOn";
                    eConfigInfo[j].StopAction = "powerOff";

                    console.Items.Add(currentVM.name + " boot order set to Group " + eConfigInfo[j].StartOrder);
                }

                //Apply custom vApp settings
                VAppConfigSpec vSpec = new VAppConfigSpec();
                vSpec.EntityConfig = eConfigInfo;
                newvApp.UpdateVAppConfig(vSpec);
            }

            return vAppsToBoot;
        }

        //The final step in the clone-deploy-boot process. It boots each vApp, then sets the IP address 
        //of the student VM in each kit to enable eventual user login. The user may also request that the
        //student VM be rearmed and rebooted to reset the Windows activation process.
        private void Boot(List<VirtualApp> vAppsToBoot)
        {
            List<VMware.Vim.Task> bootTasks = new List<VMware.Vim.Task>();
            List<VirtualMachine> studentVMs = new List<VirtualMachine>();
            List<VirtualApp> vApps = new List<VirtualApp>();

            //Get the vApps that need to boot from the list of cloned vApps
            foreach(VirtualApp vApp in vAppsToBoot)
            {
                NameValueCollection vAppName = new NameValueCollection();
                vAppName.Add("name", vApp.Name);


                vApps.Add((VirtualApp)client.FindEntityView(typeof(VirtualApp), null, vAppName, null));
            }

            bool bootFinished = false;

            //Wait 10 seconds to ensure vApps exist
            Thread.Sleep(10000);

            //Begin boot task for each vApp
            foreach (VirtualApp vApp in vApps)
            {

                ManagedObjectReference bootTask_MoRef = vApp.PowerOnVApp_Task();
                VMware.Vim.Task bootTask = (VMware.Vim.Task)client.GetView(bootTask_MoRef, null);
                bootTasks.Add(bootTask);
            }

            //Track and update boot task progress
            while(!bootFinished)
            {
                bool finishedFlag = true;

                foreach(VMware.Vim.Task task in bootTasks)
                {
                    Thread.Sleep(1000);
                    task.UpdateViewData();

                    if (task.Info.State != TaskInfoState.success)
                        finishedFlag = false;
                }

                if (finishedFlag)
                {
                    bootFinished = true;
                    console.Items.Add("Booting complete");
                }
            }
            
            //Find the student VM in this vApp by comparing the name of the VM to the student name in the kit info
            console.Items.Add("Searching for name match to " + vAppToDeploy.student);

            foreach (VirtualApp vApp in vApps)
            {
                foreach(ManagedObjectReference vm in vApp.Vm)
                {
                    VirtualMachine VM = (VirtualMachine)client.GetView(vm, null);

                    console.Items.Add("Comparing VM " + VM.Name.Substring(4) + " to " + vAppToDeploy.student);

                    if (VM.Name.Substring(4) == vAppToDeploy.student)
                    {
                        console.Items.Add("Found Student VM: " + VM.Name.Substring(4));
                        studentVMs.Add(VM);
                    }
                }
            }

            //Wait one minute for the VMs to boot
            Thread.Sleep(60000);

            foreach (VirtualMachine VM in studentVMs)
            {
                //Create a guest operations manager to execute scripts directly on the student VM
                GuestOperationsManager GOM = new GuestOperationsManager(client, client.ServiceContent.GuestOperationsManager);

                //Use the provided username and password to login to the student VM
                GuestAuthManager GAM = new GuestAuthManager(client, ((GuestOperationsManager)client.GetView(client.ServiceContent.GuestOperationsManager, null)).AuthManager);
                NamePasswordAuthentication NPA = new NamePasswordAuthentication();
                NPA.Username = "administrator";
                NPA.Password = "VMware1!";

                //Create a program spec, containing a target executable (powershell in this case) and arguments to set the IP
                GuestWindowsProgramSpec GWPS = new GuestWindowsProgramSpec();
                GWPS.ProgramPath = "C:\\Windows\\system32\\WindowsPowerShell\\v1.0\\powershell.exe";
                GWPS.Arguments = "netsh int ip set address " + vAppToDeploy.labNetwork + " static 10.10.100." + VM.Name.Substring(0, 3) + " 255.255.255.0 | cmd";

                //Create a GPM from the GOM, which finally logs in and runs the program spec
                GuestProcessManager GPM = new GuestProcessManager(client, ((GuestOperationsManager)client.GetView(client.ServiceContent.GuestOperationsManager, null)).ProcessManager);

                console.Items.Add("Setting IP address of " + VM.Name + " to 10.10.100." + VM.Name.Substring(0, 3));

                long pid = 0;

                //Attempt to run the program spec on the student VM
                try
                {
                    pid = GPM.StartProgramInGuest(VM.MoRef, NPA, GWPS);
                    console.Items.Add("PowerShell process pid: " + pid.ToString());

                    Thread.Sleep(10000);

                    GPM.TerminateProcessInGuest(VM.MoRef, NPA, pid);
                }

                catch (Exception ex)
                {
                    console.Items.Add(ex.Message);
                }

                //If the rearm checkbox is selected, also try to run the rearm Windows script
                if (RearmCheckBox.Checked)
                {

                    GWPS.Arguments = "slmgr.vbs -rearm | cmd";

                    console.Items.Add("Resetting Windows activation grace period, then rebooting " + VM.Name);

                    try
                    {
                        pid = GPM.StartProgramInGuest(VM.MoRef, NPA, GWPS);
                        console.Items.Add("PowerShell process pid: " + pid.ToString());

                        Thread.Sleep(10000);

                        GPM.TerminateProcessInGuest(VM.MoRef, NPA, pid);
                    }

                    catch (Exception ex)
                    {
                        console.Items.Add(ex.Message);
                    }

                    //Reboot after the rearm script runs
                    GWPS.Arguments = "shutdown /r /t 0 | cmd";

                    try
                    {
                        pid = GPM.StartProgramInGuest(VM.MoRef, NPA, GWPS);
                        console.Items.Add("PowerShell process pid: " + pid.ToString());
                    }

                    catch (Exception ex)
                    {
                        console.Items.Add(ex.Message);
                    }
                }
            }
        }

        private void DeployAndBootButton_Click(object sender, EventArgs e)
        {
            List<VirtualApp> vAppsToBoot = Deploy();
            Boot(vAppsToBoot);
        }

        private void RefreshDeleteListButton_Click(object sender, EventArgs e)
        {
            UpdateDeleteTargetListBox();
        }

        private void PowerOffButton_Click(object sender, EventArgs e)
        {
            PowerOffvApps();
        }

        //Attempts to power off selected vApps
        private void PowerOffvApps()
        {
            bool success = false;

            List<VirtualApp> vAppsToPowerOff = new List<VirtualApp>();
            List<VMware.Vim.Task> powerOffTasks = new List<VMware.Vim.Task>();

            //Get the list of vApps to power off from the checked boxes
            foreach (object item in DeleteTargetListBox.CheckedItems)
            {
                NameValueCollection vAppName = new NameValueCollection();
                vAppName.Add("name", item.ToString());

                vAppsToPowerOff.Add((VirtualApp)client.FindEntityView(typeof(VirtualApp), null, vAppName, null));
            }

            //Run the power off task on each vApp in the list
            foreach (VirtualApp vApp in vAppsToPowerOff)
            {
                ManagedObjectReference powerOffTask_MoRef = vApp.PowerOffVApp_Task(false);
                VMware.Vim.Task powerOffTask = (VMware.Vim.Task)client.GetView(powerOffTask_MoRef, null);
                powerOffTasks.Add(powerOffTask);
            }

            //Track and update power off task progress
            while (!success)
            {
                bool finishedFlag = true;

                foreach (VMware.Vim.Task task in powerOffTasks)
                {
                    Thread.Sleep(1000);
                    task.UpdateViewData();

                    if (task.Info.State != TaskInfoState.success)
                        finishedFlag = false;
                }

                if (finishedFlag)
                {
                    success = true;
                    console.Items.Add("Power off complete");
                }
            }
        }

        //Attempts to delete selected vApps
        private void DeletevApps()
        {
            bool success = false;

            List<VirtualApp> vAppsToDelete = new List<VirtualApp>();
            List<VMware.Vim.Task> deleteTasks = new List<VMware.Vim.Task>();


            //Get the list of vApps to delete from the checked boxes
            foreach (object item in DeleteTargetListBox.CheckedItems)
            {
                NameValueCollection vAppName = new NameValueCollection();
                vAppName.Add("name", item.ToString());

                vAppsToDelete.Add((VirtualApp)client.FindEntityView(typeof(VirtualApp), null, vAppName, null));
            }

            //Remove the checked vApps from the vApp list
            for(int i = DeleteTargetListBox.CheckedItems.Count; i > 0; i--)
            {
                DeleteTargetListBox.Items.RemoveAt(DeleteTargetListBox.CheckedIndices[i - 1]);
            }

            //Run the delete task on each vApp in the list
            foreach (VirtualApp vApp in vAppsToDelete)
            {
                ManagedObjectReference deleteTask_MoRef = vApp.Destroy_Task();
                VMware.Vim.Task powerOffTask = (VMware.Vim.Task)client.GetView(deleteTask_MoRef, null);
                deleteTasks.Add(powerOffTask);
            }

            //Track and update delete task progress
            while (!success)
            {
                bool finishedFlag = true;

                foreach (VMware.Vim.Task task in deleteTasks)
                {
                    Thread.Sleep(1000);
                    task.UpdateViewData();

                    if (task.Info.State != TaskInfoState.success)
                        finishedFlag = false;
                }

                if (finishedFlag)
                {
                    success = true;
                    console.Items.Add("Deletion complete");
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeletevApps();
        }

        private void PowerOffAndDeleteButton_Click(object sender, EventArgs e)
        {
            PowerOffvApps();
            DeletevApps();
        }
    }
}