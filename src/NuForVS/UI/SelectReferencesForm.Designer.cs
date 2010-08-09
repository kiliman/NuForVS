namespace NuForVS.UI
{
    partial class SelectReferencesForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node4");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("framework", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("nunit", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("castle-dynamicproxy2");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectReferencesForm));
            this.assembliesList = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.addAssemblies = new System.Windows.Forms.Button();
            this.closeForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // assembliesList
            // 
            this.assembliesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.assembliesList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.assembliesList.CheckBoxes = true;
            this.assembliesList.Location = new System.Drawing.Point(12, 29);
            this.assembliesList.Name = "assembliesList";
            treeNode1.Name = "Node4";
            treeNode1.Text = "Node4";
            treeNode2.Name = "Node2";
            treeNode2.Text = "framework";
            treeNode3.Name = "Node0";
            treeNode3.Text = "nunit";
            treeNode4.Name = "Node1";
            treeNode4.Text = "castle-dynamicproxy2";
            this.assembliesList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            this.assembliesList.ShowLines = false;
            this.assembliesList.ShowPlusMinus = false;
            this.assembliesList.Size = new System.Drawing.Size(402, 291);
            this.assembliesList.TabIndex = 0;
            this.assembliesList.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.assembliesList_AfterCheck);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select assemblies to reference:";
            // 
            // addAssemblies
            // 
            this.addAssemblies.Location = new System.Drawing.Point(258, 326);
            this.addAssemblies.Name = "addAssemblies";
            this.addAssemblies.Size = new System.Drawing.Size(75, 23);
            this.addAssemblies.TabIndex = 2;
            this.addAssemblies.Text = "Add";
            this.addAssemblies.UseVisualStyleBackColor = true;
            this.addAssemblies.Click += new System.EventHandler(this.addAssemblies_Click);
            // 
            // closeForm
            // 
            this.closeForm.Location = new System.Drawing.Point(339, 326);
            this.closeForm.Name = "closeForm";
            this.closeForm.Size = new System.Drawing.Size(75, 23);
            this.closeForm.TabIndex = 2;
            this.closeForm.Text = "Close";
            this.closeForm.UseVisualStyleBackColor = true;
            this.closeForm.Click += new System.EventHandler(this.closeForm_Click);
            // 
            // SelectReferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 360);
            this.Controls.Add(this.closeForm);
            this.Controls.Add(this.addAssemblies);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.assembliesList);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SelectReferencesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select assemblies";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView assembliesList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addAssemblies;
        private System.Windows.Forms.Button closeForm;

    }
}