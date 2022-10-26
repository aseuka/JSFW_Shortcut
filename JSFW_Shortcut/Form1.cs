using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace JSFW_Shortcut
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("FileDrop"))
            {
                e.Effect = DragDropEffects.All;
            }
            else {
                e.Effect = DragDropEffects.None;
            }
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            Array dropfiles = e.Data.GetData("FileDrop") as Array;
            foreach (string filepath in dropfiles)
            {
                if (File.Exists(filepath))
                {
                    CreateDesckTopShortcut(filepath);
                }
            }
        }


        private void CreateDesckTopShortcut(string FileFullPath)
        {
            if (string.IsNullOrEmpty(("" + FileFullPath).Trim()) == false)
            {
                string FileName = Path.GetFileName(FileFullPath);
                string Extension = Path.GetExtension(FileName); 

                /*
                   바로가기 만들기!
                   [참조] - C:\Windows\System32\Shell32.dll [추가]   
                */
                string MMPS_Application_FolderPath = Environment.CurrentDirectory + @"\JSFW.Project.History.Exec.exe";
                string MMPS_DiskTop_Path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string Application_ShortCut_Name = Path.GetFileName(FileName).Replace(Extension, "");
                Shell32.Shell ShellClass_iNstance = new Shell32.ShellClass();
                using (System.IO.StreamWriter StreamWriter_iNstance = new System.IO.StreamWriter(MMPS_DiskTop_Path + @"\" + Application_ShortCut_Name + ".lnk", false))
                {
                    StreamWriter_iNstance.Close();
                    Shell32.Folder DeskTop_Folder = ShellClass_iNstance.NameSpace(MMPS_DiskTop_Path);
                    Shell32.FolderItem DeskTop_FolderiTem = DeskTop_Folder.Items().Item(Application_ShortCut_Name + ".lnk");
                    Shell32.ShellLinkObject ShortCut_Link = (Shell32.ShellLinkObject)DeskTop_FolderiTem.GetLink;
                    ShortCut_Link.Path = MMPS_Application_FolderPath;
                    ShortCut_Link.Arguments = @"""""" + FileFullPath + @"""""";
                    ShortCut_Link.Description = Application_ShortCut_Name;
                    ShortCut_Link.SetIconLocation(GetIConPath(Extension), 0);
                    ShortCut_Link.WorkingDirectory = Environment.CurrentDirectory + "\\";
                    ShortCut_Link.Save();
                }
            }
        }

        private string GetIConPath(string Extension)
        {
            string iconDir = "Icon\\";
            string iconPath = Path.GetFullPath(iconDir + "txt.ico");
            switch (Extension.ToLower())
            {
                default:
                case ".txt":
                    break;
                case ".xls":
                case ".xlsx":
                    iconPath = Path.GetFullPath(iconDir + "xls.ico");
                    break;
                case ".doc":
                case ".docx":
                    iconPath = Path.GetFullPath(iconDir + "doc.ico");
                    break;

                case ".ppt":
                case ".pptx":
                    iconPath = Path.GetFullPath(iconDir + "ppt.ico");
                    break;

            }
            return iconPath;
        }
    }
}
