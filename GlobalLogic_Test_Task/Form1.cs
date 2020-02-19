using GlobalLogic_Test_Task.Models;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlobalLogic_Test_Task
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btn_choose_folder_Click(object sender, EventArgs e)
        {
            btn_choose_folder.Enabled = false;
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = folderBrowserDialog.SelectedPath;
                    textBox_input.Text = folderPath;
                    bool result = await Task.Run(() => JsonFolderHierarchyFormatter(folderPath));
                    if (result)
                        label_if_success.Text = "Success";
                    else
                        label_if_success.Text = "Failed";
                }
            }
            btn_choose_folder.Enabled = true;
        }
        private bool JsonFolderHierarchyFormatter(string folderPath)
        {
            string outputFile = Environment.CurrentDirectory + "\\FolderHierarchy.json";
            label_if_success.Text = "Proccessing";
            DirectoryInfo baseFolder = new DirectoryInfo(folderPath);
            if (baseFolder.Exists)
            {
                MyTreeHelper<DirectoryModel> myTree = new MyTreeHelper<DirectoryModel>(SetDirectoryModel(baseFolder));
                MakeTreeView(folderPath, myTree);
                JsonSerializer jsonSerializer = new JsonSerializer()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore
                };
                using (StreamWriter sw = new StreamWriter(outputFile))
                {
                    using (JsonWriter writer = new JsonTextWriter(sw))
                    {
                        jsonSerializer.Serialize(writer, myTree);
                    }
                }
                textBox_output.Text = outputFile;
                return true;
            }
            return false;
        }

        private void MakeTreeView(string path, MyTreeHelper<DirectoryModel> treeView)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            AddDirectoryNodes(treeView, directoryInfo, null);
        }
        private void AddDirectoryNodes(MyTreeHelper<DirectoryModel> treeView, DirectoryInfo directoryInfo, MyTreeHelper<DirectoryModel> parent)
        {

            MyTreeHelper<DirectoryModel> dirNode;
            DirectoryModel directoryModel = SetDirectoryModel(directoryInfo);

            if (parent == null)
                dirNode = treeView.AddChild(directoryModel);
            else
                dirNode = parent.AddChild(directoryModel);

            foreach (DirectoryInfo subDir in directoryInfo.GetDirectories())
                AddDirectoryNodes(treeView, subDir, dirNode);

        }

        private DirectoryModel SetDirectoryModel(DirectoryInfo directoryInfo)
        {
            return new DirectoryModel
            {
                Name = directoryInfo.Name,
                DateCreated = directoryInfo.CreationTime.ToString("dd-MMMM-yy hh:mm tt"),
                Files = directoryInfo.GetFiles()
                    .Select(x => new FileModel
                    {
                        Name = x.Name,
                        Size = x.Length.ToString() + " B",
                        Path = x.FullName
                    }).ToList()
            };
        }
    }
}
