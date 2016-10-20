using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningCards
    {
    class DicFile
        {
        public static string lastFilesPath()
            {
            string appName = Application.ExecutablePath;
            string fullAppPath = System.IO.Path.GetDirectoryName(appName);
            return System.IO.Path.Combine(fullAppPath, "lastfiles.txt");
            }

        public static void rewriteLastFiles(string[] arr) //rewrite lastfiles.txt
            {
            string text = "";
            foreach (string name in arr)
                {
                text += name + "?";
                }
            text = text.Substring(0, text.Length - 2); //delete last "?"
            File.WriteAllText(lastFilesPath(), text);
            }

        public static bool checkFileName(string newfile) //is new file in lastfiles.txt
            {
            string[] lastfiles = getLFarr();
            return lastfiles.Contains(newfile);
            }

        public static string[] getLFarr() //array of last files names
            {
            string fileName = lastFilesPath();//lastFilesPath();
            string[] massNames;
            using (FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                StreamReader reader = new StreamReader(stream);
                String files = reader.ReadToEnd(); reader.Close();
                massNames = files.Split('?');
                }
            return massNames;
            }

        public static void addFileToLast(string newFile)
            {
            if (!DicFile.checkFileName(newFile))
                {
                if (DicFile.getLFarr().Count() < 10)
                    {
                    File.AppendAllText(newFile, "?" + newFile);                    
                    //Form1.openToolStripMenuItem1.DropDownItems.Add(newFile);
                    Form1.openItem.DropDownItems.Add(newFile);
                    }
                else
                    {
                    string[] lastfiles = DicFile.getLFarr();
                    lastfiles[0] = newFile;
                    DicFile.rewriteLastFiles(lastfiles);
                    }
                }
            }

        public static void getFileName()
            {
            string[] massNames = DicFile.getLFarr();
            string fileName = DicFile.lastFilesPath();//lastFilesPath();            
            foreach (string name in massNames)
                {
                if (!String.IsNullOrEmpty(name))
                    //Form1.openToolStripMenuItem1.DropDownItems.Add(name);
                    Form1.openItem.DropDownItems.Add(name);
                }
            }

        public static string dialogOpen()
            {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.Cancel) return "";
            return dialog.FileName;
            }
        }

        
    }
