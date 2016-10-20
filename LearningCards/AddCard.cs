using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LearningCards
    {
    public partial class AddCard : Form
        {
        private DataBaseDataSet dataBaseDataSet = Form1.dataBaseDataSet;
        private System.Windows.Forms.BindingSource csharpBindingSource = Form1.csharpBindingSource;
        private DataBaseDataSetTableAdapters.CSharpTableAdapter csharpTableAdapter = Form1.csharpTableAdapter;
        private DataBaseDataSetTableAdapters.TableAdapterManager tableAdapterManager = Form1.tableAdapterManager;
        private DataBaseDataSet.CSharpRow row;
            
        public AddCard()
            {
            InitializeComponent();
            }

        private void btnAdd_Click(object sender, EventArgs e)
            {
            if(!isEmpty(tbWord.Text) && !isEmpty(tbDesc.Text))
                {
                string word = tbWord.Text;
                string desc = tbDesc.Text;
                row = dataBaseDataSet.CSharp.NewCSharpRow();
                row.word = word;
                row.description = desc;
                
                DataBaseDataSet.CSharpRow findRow = dataBaseDataSet.CSharp.Where(cword => cword.word == word).SingleOrDefault();
                if(findRow == null)
                    {
                    this.dataBaseDataSet.CSharp.Rows.Add(row);
                    }
                else
                    {
                    findRow.word = word;
                    findRow.description = desc;
                    }
                csharpTableAdapter.Update(this.dataBaseDataSet);
                tbDesc.Text = ""; tbWord.Text = "";
                }
            }

        private bool isEmpty(string text)
            {
            return String.IsNullOrEmpty(text);
            }

        private void AddCard_Load(object sender, EventArgs e)
            {
            
            }
                
        }
    }
