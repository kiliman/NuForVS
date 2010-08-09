using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NuForVS.Core;

namespace NuForVS.UI
{
    public partial class SelectReferencesForm : Form
    {
        private IProject _project;
        private IList<Gem> _gems;

        public SelectReferencesForm(IProject project, IList<Gem> gems)
        {
            InitializeComponent();

            _project = project;
            _gems = gems;
            populateTreeView();
        }

        private void populateTreeView()
        {
            assembliesList.Nodes.Clear();

            _gems
                .ToList()
                .ForEach(gem =>
                                       {
                                           var root = assembliesList.Nodes.Add(gem.Name, gem.Name);
                                           root.Checked = gem.IsReferenced;
                                           gem.Assemblies.ToList().ForEach(a =>
                                                                               {
                                                                                   var n = root.Nodes.Add(a, a);
                                                                                   n.Checked = gem.IsReferenced;
                                                                               });
                                       });

            assembliesList.ExpandAll();
        }

        private void closeForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addAssemblies_Click(object sender, EventArgs e)
        {
            foreach (TreeNode root in assembliesList.Nodes)
            {
                foreach (TreeNode node in root.Nodes)
                {
                    if (node.Checked)
                    {
                        if (!_project.HasReference(node.Text))
                        {
                            _project.AddReference(node.Text);
                        }
                    }
                }
            }
            this.Close();
        }

        private void assembliesList_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // if root node, toggle all child assemblies
            if (e.Node.Parent == null)
            {
                foreach (TreeNode node in e.Node.Nodes)
                {
                    node.Checked = e.Node.Checked;
                }
            }
        }
    }
}
