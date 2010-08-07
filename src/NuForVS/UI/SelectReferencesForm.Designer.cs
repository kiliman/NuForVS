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
            this.assembliesList = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // assembliesList
            // 
            this.assembliesList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.assembliesList.CheckBoxes = true;
            this.assembliesList.Location = new System.Drawing.Point(0, 29);
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
            this.assembliesList.Size = new System.Drawing.Size(426, 291);
            this.assembliesList.TabIndex = 0;
            // 
            // SelectReferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 360);
            this.Controls.Add(this.assembliesList);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SelectReferencesForm";
            this.Text = "SelectReferencesForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView assembliesList;
    }
}