using SqlViewer.Dal;
using SqlViewer.Models;
using System.Drawing.Text;

namespace SqlViewer.View
{
    public partial class MainForm : Form
    {
        private List<Database>? databases;
        private enum TagType
        {
            DataBases, Tables, Views, Procedures
        }
        public MainForm()
        {
            InitializeComponent();
            LoadDataBases();
            InitTree();
            ClearForm();

        }

        private void LoadDataBases()
        {
            databases = new List<Database>(Repository.GetDatabases());
        }

        private void InitTree()
        {
            var dbNode = new TreeNode(
                TagType.DataBases.ToString(),
                new[] { new TreeNode() }
                )
            { Tag = TagType.DataBases };
            tvServer.Nodes.Add(dbNode);
        }

        private void ClearForm()
        {
            tbContent.Text = string.Empty;
            tsbSave.Enabled = false;
            tsbSelect.Enabled = false;
            dbEntity = null;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
            => Application.Exit();

        private void TsbSave_Click(object sender, EventArgs e)
        {

        }

        private void TsbSave(object sender, EventArgs e)
        {

        }

        private Database? database;
        private void TwServer_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e is null || databases == null)
            {
                return;
            }

            ClearForm();
            tvServer.BeginUpdate();
            switch (e.Node)
            {
                case { Tag: TagType.DataBases }:
                    e.Node.Nodes.Clear();
                    databases
                        .ForEach(db => e.Node.Nodes.Add(
                            new TreeNode(
                                 db.ToString(),
                                 new[] { new TreeNode() }
                                 )
                            { Tag = db }
                        ));
                    break;


                case { Tag: TagType.Tables }:
                    e.Node.Nodes.Clear();
                    database?
                        .Tables
                        .ToList()
                        .ForEach(t => e.Node.Nodes.Add(
                            new TreeNode(
                                 t.ToString(),
                                 new[] { new TreeNode() }
                                 )
                            { Tag = t }
                        ));
                    break;

                case { Tag: TagType.Views }:
                    e.Node.Nodes.Clear();
                    database?
                        .Views
                        .ToList()
                        .ForEach(v => e.Node.Nodes.Add(
                            new TreeNode(
                                 v.ToString(),
                                 new[] { new TreeNode() }
                                 )
                            { Tag = v }
                        ));
                    break;

                case { Tag: TagType.Procedures }:
                    e.Node.Nodes.Clear();
                    database?
                        .Procedures
                        .ToList()
                        .ForEach(p => e.Node.Nodes.Add(
                            new TreeNode(
                                 p.ToString(),
                                 new[] { new TreeNode() }
                                 )
                            { Tag = p }
                        ));
                    break;

               

                case { Tag: Database db }:
                    e.Node.Nodes.Clear();
                    database = db;
                    e.Node.Nodes.Add(new TreeNode(
                     TagType.Tables.ToString(),
                     new[] { new TreeNode() }
                     )
                    { Tag = TagType.Tables });

                    e.Node.Nodes.Add(new TreeNode(
                    TagType.Views.ToString(),
                    new[] { new TreeNode() }
                    )
                    { Tag = TagType.Views });

                    e.Node.Nodes.Add(new TreeNode(
                      TagType.Procedures.ToString(),
                      new[] { new TreeNode() }
                      )
                    { Tag = TagType.Procedures });
                                      
                    break;

                case { Tag: DbEntity entity }:
                    dbEntity = entity;
                    e.Node.Nodes.Clear();
                    entity?
                        .Columns
                        .ToList()
                        .ForEach(t => e.Node.Nodes.Add(
                            new TreeNode(t.ToString())));

                    tsbSave.Enabled = true;
                    tsbSelect.Enabled = true;
                    break;

            }

            tvServer.EndUpdate();
        }
        private DbEntity? dbEntity;
    }
}