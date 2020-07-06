namespace _27vApp
{
    partial class AddKit
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.LabNetworkBox = new System.Windows.Forms.TextBox();
            this.StudentBox = new System.Windows.Forms.TextBox();
            this.AddKitButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.PortGroupBox = new System.Windows.Forms.TextBox();
            this.VMListBox = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PrefixBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.VMNameBox = new System.Windows.Forms.TextBox();
            this.BootOrderBox = new System.Windows.Forms.TextBox();
            this.NICListBox = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.NICBox = new System.Windows.Forms.TextBox();
            this.NICPortBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RemoveNICButton = new System.Windows.Forms.Button();
            this.AddNICButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RemoveVMButton = new System.Windows.Forms.Button();
            this.AddVMButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kit Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lab Network Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Student VM Name";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(153, 30);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(100, 20);
            this.NameBox.TabIndex = 4;
            // 
            // LabNetworkBox
            // 
            this.LabNetworkBox.Location = new System.Drawing.Point(153, 57);
            this.LabNetworkBox.Name = "LabNetworkBox";
            this.LabNetworkBox.Size = new System.Drawing.Size(100, 20);
            this.LabNetworkBox.TabIndex = 5;
            // 
            // StudentBox
            // 
            this.StudentBox.Location = new System.Drawing.Point(153, 84);
            this.StudentBox.Name = "StudentBox";
            this.StudentBox.Size = new System.Drawing.Size(100, 20);
            this.StudentBox.TabIndex = 6;
            // 
            // AddKitButton
            // 
            this.AddKitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddKitButton.Location = new System.Drawing.Point(926, 554);
            this.AddKitButton.Name = "AddKitButton";
            this.AddKitButton.Size = new System.Drawing.Size(75, 23);
            this.AddKitButton.TabIndex = 8;
            this.AddKitButton.Text = "Add";
            this.AddKitButton.UseVisualStyleBackColor = true;
            this.AddKitButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(1007, 554);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(297, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Number of Port Groups";
            // 
            // PortGroupBox
            // 
            this.PortGroupBox.Location = new System.Drawing.Point(439, 30);
            this.PortGroupBox.Name = "PortGroupBox";
            this.PortGroupBox.Size = new System.Drawing.Size(100, 20);
            this.PortGroupBox.TabIndex = 12;
            // 
            // VMListBox
            // 
            this.VMListBox.FormattingEnabled = true;
            this.VMListBox.Location = new System.Drawing.Point(779, 72);
            this.VMListBox.Name = "VMListBox";
            this.VMListBox.Size = new System.Drawing.Size(200, 186);
            this.VMListBox.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(776, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "VMs";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.PrefixBox);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.PortGroupBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.NameBox);
            this.groupBox1.Controls.Add(this.LabNetworkBox);
            this.groupBox1.Controls.Add(this.StudentBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1038, 132);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kit Info";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(545, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(339, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "(Excludes Lab Access port group. Lab Access is always Port Group 0.)";
            // 
            // PrefixBox
            // 
            this.PrefixBox.Location = new System.Drawing.Point(439, 56);
            this.PrefixBox.Name = "PrefixBox";
            this.PrefixBox.Size = new System.Drawing.Size(100, 20);
            this.PrefixBox.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(297, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Port Group Prefix";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "VM Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Boot Order";
            // 
            // VMNameBox
            // 
            this.VMNameBox.Location = new System.Drawing.Point(98, 75);
            this.VMNameBox.Name = "VMNameBox";
            this.VMNameBox.Size = new System.Drawing.Size(100, 20);
            this.VMNameBox.TabIndex = 18;
            // 
            // BootOrderBox
            // 
            this.BootOrderBox.Location = new System.Drawing.Point(98, 101);
            this.BootOrderBox.Name = "BootOrderBox";
            this.BootOrderBox.Size = new System.Drawing.Size(100, 20);
            this.BootOrderBox.TabIndex = 19;
            // 
            // NICListBox
            // 
            this.NICListBox.FormattingEnabled = true;
            this.NICListBox.Location = new System.Drawing.Point(303, 33);
            this.NICListBox.Name = "NICListBox";
            this.NICListBox.Size = new System.Drawing.Size(189, 186);
            this.NICListBox.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "NIC Number";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Port Group Number";
            // 
            // NICBox
            // 
            this.NICBox.Location = new System.Drawing.Point(156, 36);
            this.NICBox.Name = "NICBox";
            this.NICBox.Size = new System.Drawing.Size(100, 20);
            this.NICBox.TabIndex = 23;
            // 
            // NICPortBox
            // 
            this.NICPortBox.Location = new System.Drawing.Point(156, 62);
            this.NICPortBox.Name = "NICPortBox";
            this.NICPortBox.Size = new System.Drawing.Size(100, 20);
            this.NICPortBox.TabIndex = 24;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RemoveNICButton);
            this.groupBox2.Controls.Add(this.AddNICButton);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.NICListBox);
            this.groupBox2.Controls.Add(this.NICPortBox);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.NICBox);
            this.groupBox2.Location = new System.Drawing.Point(219, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(529, 302);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add NICs";
            // 
            // RemoveNICButton
            // 
            this.RemoveNICButton.Location = new System.Drawing.Point(303, 254);
            this.RemoveNICButton.Name = "RemoveNICButton";
            this.RemoveNICButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveNICButton.TabIndex = 27;
            this.RemoveNICButton.Text = "Remove";
            this.RemoveNICButton.UseVisualStyleBackColor = true;
            this.RemoveNICButton.Click += new System.EventHandler(this.RemoveNICButton_Click);
            // 
            // AddNICButton
            // 
            this.AddNICButton.Location = new System.Drawing.Point(303, 225);
            this.AddNICButton.Name = "AddNICButton";
            this.AddNICButton.Size = new System.Drawing.Size(75, 23);
            this.AddNICButton.TabIndex = 26;
            this.AddNICButton.Text = "Add";
            this.AddNICButton.UseVisualStyleBackColor = true;
            this.AddNICButton.Click += new System.EventHandler(this.AddNICButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(300, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "NICs";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RemoveVMButton);
            this.groupBox3.Controls.Add(this.AddVMButton);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.BootOrderBox);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.VMListBox);
            this.groupBox3.Controls.Add(this.VMNameBox);
            this.groupBox3.Location = new System.Drawing.Point(12, 173);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1038, 362);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Add VMs";
            // 
            // RemoveVMButton
            // 
            this.RemoveVMButton.Location = new System.Drawing.Point(779, 293);
            this.RemoveVMButton.Name = "RemoveVMButton";
            this.RemoveVMButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveVMButton.TabIndex = 27;
            this.RemoveVMButton.Text = "Remove";
            this.RemoveVMButton.UseVisualStyleBackColor = true;
            this.RemoveVMButton.Click += new System.EventHandler(this.RemoveVMButton_Click);
            // 
            // AddVMButton
            // 
            this.AddVMButton.Location = new System.Drawing.Point(779, 264);
            this.AddVMButton.Name = "AddVMButton";
            this.AddVMButton.Size = new System.Drawing.Size(75, 23);
            this.AddVMButton.TabIndex = 26;
            this.AddVMButton.Text = "Add";
            this.AddVMButton.UseVisualStyleBackColor = true;
            this.AddVMButton.Click += new System.EventHandler(this.AddVMButton_Click);
            // 
            // AddKit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 589);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.AddKitButton);
            this.Name = "AddKit";
            this.Text = "AddKit";
            this.Load += new System.EventHandler(this.AddKit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox LabNetworkBox;
        private System.Windows.Forms.TextBox StudentBox;
        private System.Windows.Forms.Button AddKitButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PortGroupBox;
        private System.Windows.Forms.ListBox VMListBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox VMNameBox;
        private System.Windows.Forms.TextBox BootOrderBox;
        private System.Windows.Forms.ListBox NICListBox;
        private System.Windows.Forms.TextBox PrefixBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox NICBox;
        private System.Windows.Forms.TextBox NICPortBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button AddNICButton;
        private System.Windows.Forms.Button AddVMButton;
        private System.Windows.Forms.Button RemoveNICButton;
        private System.Windows.Forms.Button RemoveVMButton;
        private System.Windows.Forms.Label label4;
    }
}