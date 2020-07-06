namespace _27vApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbvmLabel = new System.Windows.Forms.Label();
            this.serverLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.loginBox = new System.Windows.Forms.GroupBox();
            this.ServerComboBox = new System.Windows.Forms.ComboBox();
            this.console = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cloneProgressBar = new System.Windows.Forms.ProgressBar();
            this.CloneTargetList = new System.Windows.Forms.ListBox();
            this.ToText = new System.Windows.Forms.Label();
            this.CloneInfo = new System.Windows.Forms.Label();
            this.BasevAppListBox = new System.Windows.Forms.ListBox();
            this.CloneToTargets = new System.Windows.Forms.Button();
            this.ScanCloneTargets = new System.Windows.Forms.Button();
            this.CloneTargetsLabel = new System.Windows.Forms.Label();
            this.CloneTargetsListBox = new System.Windows.Forms.CheckedListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.RearmCheckBox = new System.Windows.Forms.CheckBox();
            this.DeployAndBootButton = new System.Windows.Forms.Button();
            this.deployProgressBar = new System.Windows.Forms.ProgressBar();
            this.PortGroupSelectedLabel = new System.Windows.Forms.Label();
            this.PortGroupCountLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LabAccessLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CopyCountTextBox = new System.Windows.Forms.TextBox();
            this.DeployButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PortGroupListBox = new System.Windows.Forms.CheckedListBox();
            this.DeployTargetsListBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EditKitButton = new System.Windows.Forms.Button();
            this.RemoveKitButton = new System.Windows.Forms.Button();
            this.ScanKitsButton = new System.Windows.Forms.Button();
            this.AddKitButton = new System.Windows.Forms.Button();
            this.KitsLabel = new System.Windows.Forms.Label();
            this.KitInfoListBox = new System.Windows.Forms.ListBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.PowerOffAndDeleteButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.PowerOffButton = new System.Windows.Forms.Button();
            this.RefreshDeleteListButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.DeleteTargetListBox = new System.Windows.Forms.CheckedListBox();
            this.loginBox.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbvmLabel
            // 
            this.lbvmLabel.AutoSize = true;
            this.lbvmLabel.Location = new System.Drawing.Point(22, 23);
            this.lbvmLabel.Name = "lbvmLabel";
            this.lbvmLabel.Size = new System.Drawing.Size(68, 13);
            this.lbvmLabel.TabIndex = 1;
            this.lbvmLabel.Text = "BASE vApps";
            // 
            // serverLabel
            // 
            this.serverLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.serverLabel.AutoSize = true;
            this.serverLabel.Location = new System.Drawing.Point(184, 39);
            this.serverLabel.Name = "serverLabel";
            this.serverLabel.Size = new System.Drawing.Size(78, 13);
            this.serverLabel.TabIndex = 2;
            this.serverLabel.Text = "vCenter Server";
            // 
            // usernameLabel
            // 
            this.usernameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(184, 65);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(55, 13);
            this.usernameLabel.TabIndex = 3;
            this.usernameLabel.Text = "Username";
            // 
            // passwordLabel
            // 
            this.passwordLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(184, 91);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 4;
            this.passwordLabel.Text = "Password";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.usernameTextBox.Location = new System.Drawing.Point(277, 62);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(265, 20);
            this.usernameTextBox.TabIndex = 6;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.passwordTextBox.Location = new System.Drawing.Point(277, 88);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(265, 20);
            this.passwordTextBox.TabIndex = 7;
            // 
            // connectButton
            // 
            this.connectButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.connectButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.connectButton.Location = new System.Drawing.Point(356, 133);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 8;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // loginBox
            // 
            this.loginBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.loginBox.Controls.Add(this.ServerComboBox);
            this.loginBox.Controls.Add(this.connectButton);
            this.loginBox.Controls.Add(this.serverLabel);
            this.loginBox.Controls.Add(this.passwordTextBox);
            this.loginBox.Controls.Add(this.usernameLabel);
            this.loginBox.Controls.Add(this.usernameTextBox);
            this.loginBox.Controls.Add(this.passwordLabel);
            this.loginBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginBox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.loginBox.Location = new System.Drawing.Point(3, 3);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(786, 505);
            this.loginBox.TabIndex = 9;
            this.loginBox.TabStop = false;
            this.loginBox.Text = "vCenter Login";
            // 
            // ServerComboBox
            // 
            this.ServerComboBox.AllowDrop = true;
            this.ServerComboBox.FormattingEnabled = true;
            this.ServerComboBox.Location = new System.Drawing.Point(277, 35);
            this.ServerComboBox.Name = "ServerComboBox";
            this.ServerComboBox.Size = new System.Drawing.Size(265, 21);
            this.ServerComboBox.TabIndex = 9;
            this.ServerComboBox.Text = "https://27vc67.27v.local";
            this.ServerComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // console
            // 
            this.console.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.console.FormattingEnabled = true;
            this.console.Location = new System.Drawing.Point(0, 537);
            this.console.Name = "console";
            this.console.Size = new System.Drawing.Size(800, 95);
            this.console.TabIndex = 10;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 537);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.loginBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 511);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Connections";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cloneProgressBar);
            this.tabPage2.Controls.Add(this.CloneTargetList);
            this.tabPage2.Controls.Add(this.ToText);
            this.tabPage2.Controls.Add(this.CloneInfo);
            this.tabPage2.Controls.Add(this.BasevAppListBox);
            this.tabPage2.Controls.Add(this.CloneToTargets);
            this.tabPage2.Controls.Add(this.ScanCloneTargets);
            this.tabPage2.Controls.Add(this.CloneTargetsLabel);
            this.tabPage2.Controls.Add(this.CloneTargetsListBox);
            this.tabPage2.Controls.Add(this.lbvmLabel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 511);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Clone";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cloneProgressBar
            // 
            this.cloneProgressBar.Location = new System.Drawing.Point(8, 482);
            this.cloneProgressBar.Name = "cloneProgressBar";
            this.cloneProgressBar.Size = new System.Drawing.Size(776, 23);
            this.cloneProgressBar.TabIndex = 11;
            // 
            // CloneTargetList
            // 
            this.CloneTargetList.FormattingEnabled = true;
            this.CloneTargetList.Location = new System.Drawing.Point(533, 77);
            this.CloneTargetList.Name = "CloneTargetList";
            this.CloneTargetList.Size = new System.Drawing.Size(233, 264);
            this.CloneTargetList.TabIndex = 10;
            // 
            // ToText
            // 
            this.ToText.AutoSize = true;
            this.ToText.Location = new System.Drawing.Point(533, 55);
            this.ToText.Name = "ToText";
            this.ToText.Size = new System.Drawing.Size(0, 13);
            this.ToText.TabIndex = 9;
            // 
            // CloneInfo
            // 
            this.CloneInfo.AutoSize = true;
            this.CloneInfo.Location = new System.Drawing.Point(533, 38);
            this.CloneInfo.Name = "CloneInfo";
            this.CloneInfo.Size = new System.Drawing.Size(0, 13);
            this.CloneInfo.TabIndex = 8;
            // 
            // BasevAppListBox
            // 
            this.BasevAppListBox.FormattingEnabled = true;
            this.BasevAppListBox.Location = new System.Drawing.Point(25, 39);
            this.BasevAppListBox.Name = "BasevAppListBox";
            this.BasevAppListBox.Size = new System.Drawing.Size(224, 303);
            this.BasevAppListBox.TabIndex = 7;
            this.BasevAppListBox.SelectedIndexChanged += new System.EventHandler(this.BasevAppListBox_SelectedIndexChanged_1);
            // 
            // CloneToTargets
            // 
            this.CloneToTargets.Location = new System.Drawing.Point(691, 347);
            this.CloneToTargets.Name = "CloneToTargets";
            this.CloneToTargets.Size = new System.Drawing.Size(75, 23);
            this.CloneToTargets.TabIndex = 6;
            this.CloneToTargets.Text = "Clone";
            this.CloneToTargets.UseVisualStyleBackColor = true;
            this.CloneToTargets.Click += new System.EventHandler(this.CloneToTargets_Click);
            // 
            // ScanCloneTargets
            // 
            this.ScanCloneTargets.Location = new System.Drawing.Point(174, 348);
            this.ScanCloneTargets.Name = "ScanCloneTargets";
            this.ScanCloneTargets.Size = new System.Drawing.Size(75, 23);
            this.ScanCloneTargets.TabIndex = 5;
            this.ScanCloneTargets.Text = "Scan";
            this.ScanCloneTargets.UseVisualStyleBackColor = true;
            this.ScanCloneTargets.Click += new System.EventHandler(this.ScanCloneTargets_Click);
            // 
            // CloneTargetsLabel
            // 
            this.CloneTargetsLabel.AutoSize = true;
            this.CloneTargetsLabel.Location = new System.Drawing.Point(275, 22);
            this.CloneTargetsLabel.Name = "CloneTargetsLabel";
            this.CloneTargetsLabel.Size = new System.Drawing.Size(73, 13);
            this.CloneTargetsLabel.TabIndex = 4;
            this.CloneTargetsLabel.Text = "Clone Targets";
            // 
            // CloneTargetsListBox
            // 
            this.CloneTargetsListBox.FormattingEnabled = true;
            this.CloneTargetsListBox.Location = new System.Drawing.Point(278, 38);
            this.CloneTargetsListBox.Name = "CloneTargetsListBox";
            this.CloneTargetsListBox.Size = new System.Drawing.Size(223, 304);
            this.CloneTargetsListBox.TabIndex = 3;
            this.CloneTargetsListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CloneTargetsListBox_ItemCheck);
            this.CloneTargetsListBox.SelectedIndexChanged += new System.EventHandler(this.CloneTargetsListBox_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.RearmCheckBox);
            this.tabPage3.Controls.Add(this.DeployAndBootButton);
            this.tabPage3.Controls.Add(this.deployProgressBar);
            this.tabPage3.Controls.Add(this.PortGroupSelectedLabel);
            this.tabPage3.Controls.Add(this.PortGroupCountLabel);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.LabAccessLabel);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.CopyCountTextBox);
            this.tabPage3.Controls.Add(this.DeployButton);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.PortGroupListBox);
            this.tabPage3.Controls.Add(this.DeployTargetsListBox);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.EditKitButton);
            this.tabPage3.Controls.Add(this.RemoveKitButton);
            this.tabPage3.Controls.Add(this.ScanKitsButton);
            this.tabPage3.Controls.Add(this.AddKitButton);
            this.tabPage3.Controls.Add(this.KitsLabel);
            this.tabPage3.Controls.Add(this.KitInfoListBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(792, 511);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Deploy";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // RearmCheckBox
            // 
            this.RearmCheckBox.AutoSize = true;
            this.RearmCheckBox.Location = new System.Drawing.Point(518, 412);
            this.RearmCheckBox.Name = "RearmCheckBox";
            this.RearmCheckBox.Size = new System.Drawing.Size(57, 17);
            this.RearmCheckBox.TabIndex = 21;
            this.RearmCheckBox.Text = "Rearm";
            this.RearmCheckBox.UseVisualStyleBackColor = true;
            // 
            // DeployAndBootButton
            // 
            this.DeployAndBootButton.Location = new System.Drawing.Point(612, 442);
            this.DeployAndBootButton.Name = "DeployAndBootButton";
            this.DeployAndBootButton.Size = new System.Drawing.Size(116, 23);
            this.DeployAndBootButton.TabIndex = 20;
            this.DeployAndBootButton.Text = "Deploy and Boot";
            this.DeployAndBootButton.UseVisualStyleBackColor = true;
            this.DeployAndBootButton.Click += new System.EventHandler(this.DeployAndBootButton_Click);
            // 
            // deployProgressBar
            // 
            this.deployProgressBar.Location = new System.Drawing.Point(8, 482);
            this.deployProgressBar.Name = "deployProgressBar";
            this.deployProgressBar.Size = new System.Drawing.Size(776, 23);
            this.deployProgressBar.TabIndex = 19;
            // 
            // PortGroupSelectedLabel
            // 
            this.PortGroupSelectedLabel.AutoSize = true;
            this.PortGroupSelectedLabel.Location = new System.Drawing.Point(635, 387);
            this.PortGroupSelectedLabel.Name = "PortGroupSelectedLabel";
            this.PortGroupSelectedLabel.Size = new System.Drawing.Size(0, 13);
            this.PortGroupSelectedLabel.TabIndex = 18;
            // 
            // PortGroupCountLabel
            // 
            this.PortGroupCountLabel.AutoSize = true;
            this.PortGroupCountLabel.Location = new System.Drawing.Point(668, 387);
            this.PortGroupCountLabel.Name = "PortGroupCountLabel";
            this.PortGroupCountLabel.Size = new System.Drawing.Size(0, 13);
            this.PortGroupCountLabel.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(515, 387);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Selected Port Groups:";
            // 
            // LabAccessLabel
            // 
            this.LabAccessLabel.AutoSize = true;
            this.LabAccessLabel.Location = new System.Drawing.Point(641, 358);
            this.LabAccessLabel.Name = "LabAccessLabel";
            this.LabAccessLabel.Size = new System.Drawing.Size(0, 13);
            this.LabAccessLabel.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(515, 358);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Lab Access Port Group:";
            // 
            // CopyCountTextBox
            // 
            this.CopyCountTextBox.Location = new System.Drawing.Point(612, 324);
            this.CopyCountTextBox.Name = "CopyCountTextBox";
            this.CopyCountTextBox.Size = new System.Drawing.Size(100, 20);
            this.CopyCountTextBox.TabIndex = 13;
            this.CopyCountTextBox.TextChanged += new System.EventHandler(this.CopyCountTextBox_TextChanged);
            // 
            // DeployButton
            // 
            this.DeployButton.Location = new System.Drawing.Point(518, 442);
            this.DeployButton.Name = "DeployButton";
            this.DeployButton.Size = new System.Drawing.Size(75, 23);
            this.DeployButton.TabIndex = 12;
            this.DeployButton.Text = "Deploy";
            this.DeployButton.UseVisualStyleBackColor = true;
            this.DeployButton.Click += new System.EventHandler(this.DeployButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(515, 328);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Number of Copies";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(515, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Port Groups";
            // 
            // PortGroupListBox
            // 
            this.PortGroupListBox.FormattingEnabled = true;
            this.PortGroupListBox.Location = new System.Drawing.Point(518, 40);
            this.PortGroupListBox.Name = "PortGroupListBox";
            this.PortGroupListBox.Size = new System.Drawing.Size(210, 274);
            this.PortGroupListBox.TabIndex = 9;
            this.PortGroupListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.PortGroupListBox_ItemCheck);
            // 
            // DeployTargetsListBox
            // 
            this.DeployTargetsListBox.FormattingEnabled = true;
            this.DeployTargetsListBox.Location = new System.Drawing.Point(269, 40);
            this.DeployTargetsListBox.Name = "DeployTargetsListBox";
            this.DeployTargetsListBox.Size = new System.Drawing.Size(215, 274);
            this.DeployTargetsListBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Deploy Targets";
            // 
            // EditKitButton
            // 
            this.EditKitButton.Location = new System.Drawing.Point(25, 353);
            this.EditKitButton.Name = "EditKitButton";
            this.EditKitButton.Size = new System.Drawing.Size(75, 23);
            this.EditKitButton.TabIndex = 5;
            this.EditKitButton.Text = "Edit...";
            this.EditKitButton.UseVisualStyleBackColor = true;
            this.EditKitButton.Click += new System.EventHandler(this.EditKitButton_Click);
            // 
            // RemoveKitButton
            // 
            this.RemoveKitButton.Location = new System.Drawing.Point(25, 382);
            this.RemoveKitButton.Name = "RemoveKitButton";
            this.RemoveKitButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveKitButton.TabIndex = 4;
            this.RemoveKitButton.Text = "Remove";
            this.RemoveKitButton.UseVisualStyleBackColor = true;
            this.RemoveKitButton.Click += new System.EventHandler(this.RemoveKitButton_Click);
            // 
            // ScanKitsButton
            // 
            this.ScanKitsButton.Location = new System.Drawing.Point(157, 323);
            this.ScanKitsButton.Name = "ScanKitsButton";
            this.ScanKitsButton.Size = new System.Drawing.Size(75, 23);
            this.ScanKitsButton.TabIndex = 3;
            this.ScanKitsButton.Text = "Scan";
            this.ScanKitsButton.UseVisualStyleBackColor = true;
            this.ScanKitsButton.Click += new System.EventHandler(this.ScanKitsButton_Click);
            // 
            // AddKitButton
            // 
            this.AddKitButton.Location = new System.Drawing.Point(25, 324);
            this.AddKitButton.Name = "AddKitButton";
            this.AddKitButton.Size = new System.Drawing.Size(75, 23);
            this.AddKitButton.TabIndex = 2;
            this.AddKitButton.Text = "Add...";
            this.AddKitButton.UseVisualStyleBackColor = true;
            this.AddKitButton.Click += new System.EventHandler(this.AddKitButton_Click);
            // 
            // KitsLabel
            // 
            this.KitsLabel.AutoSize = true;
            this.KitsLabel.Location = new System.Drawing.Point(22, 24);
            this.KitsLabel.Name = "KitsLabel";
            this.KitsLabel.Size = new System.Drawing.Size(24, 13);
            this.KitsLabel.TabIndex = 1;
            this.KitsLabel.Text = "Kits";
            // 
            // KitInfoListBox
            // 
            this.KitInfoListBox.FormattingEnabled = true;
            this.KitInfoListBox.Location = new System.Drawing.Point(25, 40);
            this.KitInfoListBox.Name = "KitInfoListBox";
            this.KitInfoListBox.Size = new System.Drawing.Size(207, 277);
            this.KitInfoListBox.TabIndex = 0;
            this.KitInfoListBox.SelectedIndexChanged += new System.EventHandler(this.KitInfoListBox_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.PowerOffAndDeleteButton);
            this.tabPage4.Controls.Add(this.DeleteButton);
            this.tabPage4.Controls.Add(this.PowerOffButton);
            this.tabPage4.Controls.Add(this.RefreshDeleteListButton);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.DeleteTargetListBox);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(792, 511);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Cleanup";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // PowerOffAndDeleteButton
            // 
            this.PowerOffAndDeleteButton.Location = new System.Drawing.Point(136, 406);
            this.PowerOffAndDeleteButton.Name = "PowerOffAndDeleteButton";
            this.PowerOffAndDeleteButton.Size = new System.Drawing.Size(122, 23);
            this.PowerOffAndDeleteButton.TabIndex = 5;
            this.PowerOffAndDeleteButton.Text = "Power Off and Delete";
            this.PowerOffAndDeleteButton.UseVisualStyleBackColor = true;
            this.PowerOffAndDeleteButton.Click += new System.EventHandler(this.PowerOffAndDeleteButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(183, 377);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 4;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // PowerOffButton
            // 
            this.PowerOffButton.Location = new System.Drawing.Point(183, 348);
            this.PowerOffButton.Name = "PowerOffButton";
            this.PowerOffButton.Size = new System.Drawing.Size(75, 23);
            this.PowerOffButton.TabIndex = 3;
            this.PowerOffButton.Text = "Power Off";
            this.PowerOffButton.UseVisualStyleBackColor = true;
            this.PowerOffButton.Click += new System.EventHandler(this.PowerOffButton_Click);
            // 
            // RefreshDeleteListButton
            // 
            this.RefreshDeleteListButton.Location = new System.Drawing.Point(31, 348);
            this.RefreshDeleteListButton.Name = "RefreshDeleteListButton";
            this.RefreshDeleteListButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshDeleteListButton.TabIndex = 2;
            this.RefreshDeleteListButton.Text = "Refresh";
            this.RefreshDeleteListButton.UseVisualStyleBackColor = true;
            this.RefreshDeleteListButton.Click += new System.EventHandler(this.RefreshDeleteListButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Class Kits vApps";
            // 
            // DeleteTargetListBox
            // 
            this.DeleteTargetListBox.FormattingEnabled = true;
            this.DeleteTargetListBox.Location = new System.Drawing.Point(31, 38);
            this.DeleteTargetListBox.Name = "DeleteTargetListBox";
            this.DeleteTargetListBox.Size = new System.Drawing.Size(227, 304);
            this.DeleteTargetListBox.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 632);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.console);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "27v Datacenter Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.loginBox.ResumeLayout(false);
            this.loginBox.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbvmLabel;
        private System.Windows.Forms.Label serverLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.GroupBox loginBox;
        private System.Windows.Forms.ListBox console;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button CloneToTargets;
        private System.Windows.Forms.Button ScanCloneTargets;
        private System.Windows.Forms.Label CloneTargetsLabel;
        private System.Windows.Forms.CheckedListBox CloneTargetsListBox;
        private System.Windows.Forms.ListBox BasevAppListBox;
        private System.Windows.Forms.ComboBox ServerComboBox;
        private System.Windows.Forms.Label CloneInfo;
        private System.Windows.Forms.Label ToText;
        private System.Windows.Forms.ListBox CloneTargetList;
        private System.Windows.Forms.ProgressBar cloneProgressBar;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button AddKitButton;
        private System.Windows.Forms.Label KitsLabel;
        private System.Windows.Forms.Button ScanKitsButton;
        public System.Windows.Forms.ListBox KitInfoListBox;
        private System.Windows.Forms.Button RemoveKitButton;
        private System.Windows.Forms.Button EditKitButton;
        private System.Windows.Forms.CheckedListBox DeployTargetsListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox PortGroupListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CopyCountTextBox;
        private System.Windows.Forms.Button DeployButton;
        private System.Windows.Forms.Label LabAccessLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label PortGroupCountLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label PortGroupSelectedLabel;
        private System.Windows.Forms.ProgressBar deployProgressBar;
        private System.Windows.Forms.Button DeployAndBootButton;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox DeleteTargetListBox;
        private System.Windows.Forms.Button RefreshDeleteListButton;
        private System.Windows.Forms.Button PowerOffButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button PowerOffAndDeleteButton;
        private System.Windows.Forms.CheckBox RearmCheckBox;
    }
}

