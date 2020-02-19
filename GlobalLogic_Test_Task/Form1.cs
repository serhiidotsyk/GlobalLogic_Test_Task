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
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = folderBrowserDialog.SelectedPath;

                    bool result = await Task.Run(() => Json_Folder_Hierarchy_Formatter(folderPath));
                    if (result)
                        label_if_success.Text = "Success";
                    else
                        label_if_success.Text = "Failde";
                }
            }
        }
        private bool Json_Folder_Hierarchy_Formatter(string folderPath)
        {
            label_if_success.Text = "Proccessing";
            DirectoryInfo base_folder = new DirectoryInfo(folderPath);
            if (base_folder.Exists)
            {
                MyTreeHelper<DirectoryModel> myTree = new MyTreeHelper<DirectoryModel>(new DirectoryModel
                {
                    Name = base_folder.Name,
                    DateCreated = base_folder.CreationTime.ToString("dd-MMMM-yy hh:mm tt"),
                    Files = base_folder.GetFiles()
                        .Select(x => new FileModel
                        {
                            Name = x.Name,
                            Size = x.Length.ToString() + " B",
                            Path = x.FullName
                        }).ToList()
                });
                MakeTreeView(folderPath, myTree);
                JsonSerializer jsonSerializer = new JsonSerializer();
                jsonSerializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                using (StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "\\test.json"))
                {
                    using (JsonWriter writer = new JsonTextWriter(sw))
                    {
                        jsonSerializer.Serialize(writer, myTree);
                    }
                }
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

            MyTreeHelper<DirectoryModel> dir_node;
            DirectoryModel directoryModel = new DirectoryModel
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

            if (parent == null)
                dir_node = treeView.AddChild(directoryModel);
            else
                dir_node = parent.AddChild(directoryModel);

            foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
                AddDirectoryNodes(treeView, subdir, dir_node);

        }
    }
}
