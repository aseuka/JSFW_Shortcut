using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace JSFW.Project.History.Exec
{
    static class Program
    {
        /*
            바로가기 실행용 프로그램!!          
        */
        
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            /*
               # 파일 백업!
               # 실행!
            */
            string FilePath = string.Join(" ", args );
            
            if (string.IsNullOrEmpty(FilePath)) return;
            if (File.Exists(FilePath) == false) { MessageBox.Show("파일이 존재하지 않습니다."); return; }

            // FilePath = D:\JSFW\TODO\일일보고.txt 라면
            // backupFilePath = D:\JSFW\TODO\Bak_일일보고.txt\일일보고.txt.{일자} 
            string backupFullPath = GetBackupFullPath(FilePath, Form.ModifierKeys == Keys.Control);

            if (!File.Exists(backupFullPath) && ".bmp|.jpg|.gif|.png|.tif|.icon|.sln".IndexOf(Path.GetExtension(FilePath).ToLower()) < 0)
            {
                File.Copy(FilePath, backupFullPath);  // 백업본 생성!
            }

            try
            {
                System.Diagnostics.Process.Start(FilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static string GetBackupFullPath(string fullPath, bool isCurrentTimeSaving = false)
        {
            string backupFileFullPath = fullPath;

            string date = DateTime.Now.ToString(isCurrentTimeSaving ? "yyyyMMddHHmmss" : "yyyyMMdd");

            string dir = Path.GetDirectoryName(backupFileFullPath);
            string fileName = Path.GetFileName(backupFileFullPath);

            dir = dir + "\\bak_" + fileName;

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            backupFileFullPath = dir + "\\" + fileName + "." + date;
            return backupFileFullPath;
        }
    }
}
