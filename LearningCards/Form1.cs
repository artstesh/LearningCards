using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace LearningCards
    {
    public partial class Form1 : Form
        {
        public static DataBaseDataSet dataBaseDataSet = new DataBaseDataSet();
        public static BindingSource csharpBindingSource = new BindingSource();
        public static DataBaseDataSetTableAdapters.CSharpTableAdapter csharpTableAdapter = new DataBaseDataSetTableAdapters.CSharpTableAdapter();
        public static DataBaseDataSetTableAdapters.TableAdapterManager tableAdapterManager = new DataBaseDataSetTableAdapters.TableAdapterManager();
        WordCard wordCard = null;
        public static ToolStripMenuItem openItem;

        public Form1()
            {
            InitializeComponent();
            this.MouseClick += new MouseEventHandler(Learn_MouseClick);
            DicFile.getFileName(); openItem = openToolStripMenuItem1;
            openItem.DropDownItemClicked += OpenToolStripMenuItem1_DropDownItemClicked;
            }               
     

        protected void Learn_MouseClick(Object sender, MouseEventArgs e)
            {
            DataBaseDataSet.CSharpRow row;
            if (e.Button.ToString().Equals("Left"))
                {
                int counter = dataBaseDataSet.CSharp.Count;
                if (counter > 0)
                    {
                    row = dataBaseDataSet.CSharp[(new Random()).Next(0, counter)];
                    wordCard = new WordCard(row.word, row.description);
                    tbCard.Text = reverseToolStripMenuItem.Checked ? wordCard.description : wordCard.word;
                    }
                }
            else if (wordCard != null)
                {
                tbCard.Text = reverseToolStripMenuItem.Checked ? wordCard.word : wordCard.description;
                }
            }


        private void addWordToolStripMenuItem_Click(object sender, EventArgs e)
            {
            (new AddCard()).Show();
            }
                
        private void Form1_Load(object sender, EventArgs e)
            {

            }
        
        private void fillTable(string filename)
            {
            DataBaseDataSet.CSharpRow row;
            FileStream stream = new FileStream(filename, FileMode.Open);
            StreamReader reader = new StreamReader(stream);
            string allText = reader.ReadToEnd();            
            reader.Close();
            string[] mass = allText.Split('?');
            for (int i = 0; i < mass.Length; i++)
                {
                string[] card = mass[i].Split(':');
                if (card.Length == 2)
                    {
                    string word = card[0];
                    string desc = card[1];
                    row = dataBaseDataSet.CSharp.NewCSharpRow();
                    row.word = word;
                    row.description = desc;
                    DataBaseDataSet.CSharpRow findRow = dataBaseDataSet.CSharp.Where(cword => cword.word == word).SingleOrDefault();
                    if (findRow == null)
                        {
                        dataBaseDataSet.CSharp.Rows.Add(row);
                        }
                    else
                        {
                        findRow.word = word;
                        findRow.description = desc;
                        }
                    csharpTableAdapter.Update(dataBaseDataSet);
                    }                              
                }
            
            }

        private void cleanTableToolStripMenuItem_Click(object sender, EventArgs e)
            {
            cleanTable();
            }                    

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
            {            
            string fileName = DicFile.dialogOpen();
            if (String.IsNullOrEmpty(fileName)) return;
            cleanTable();
            fillTable(fileName);
            DicFile.addFileToLast(fileName);            
            }

        private void OpenToolStripMenuItem1_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
            {
            cleanTable();
            fillTable(e.ClickedItem.Text);            
            }

        private void cleanTable()
            {
            dataBaseDataSet.CSharp.Clear();
            csharpTableAdapter.Update(dataBaseDataSet.CSharp);
            }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
            {
            if (dataBaseDataSet.CSharp.Count > 0)
                {
                String text = "";
                foreach (DataBaseDataSet.CSharpRow row in dataBaseDataSet.CSharp)
                    {
                    text += row.word + ":" + row.description + "?";
                    }
                text = text.Substring(0, text.Length - 2); //delete last "?"
                SaveFileDialog save = new SaveFileDialog();
                save.ShowDialog();
                if (!String.IsNullOrEmpty(save.FileName) && save.FileName.EndsWith(".txt"))
                    {
                    string file = save.FileName;
                    File.WriteAllText(file, text);
                    DicFile.addFileToLast(file);
                    }
                }
            }
        }
    }
