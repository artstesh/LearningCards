using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningCards
    {
    public partial class Card : Form
        {
        private DataBaseDataSet dataBaseDataSet = Form1.dataBaseDataSet;
        private System.Windows.Forms.BindingSource csharpBindingSource = Form1.csharpBindingSource;
        private DataBaseDataSetTableAdapters.CSharpTableAdapter csharpTableAdapter = Form1.csharpTableAdapter;
        private DataBaseDataSetTableAdapters.TableAdapterManager tableAdapterManager = Form1.tableAdapterManager;
        WordCard wordCard = null;
        DataBaseDataSet.CSharpRow row;
        public Card()
            {
            InitializeComponent();
            this.MouseClick += new MouseEventHandler(Learn_MouseClick);
            }

        protected void Learn_MouseClick(Object sender, MouseEventArgs e)
            {
            if (e.Button.ToString().Equals("Left"))
                {
                int counter = dataBaseDataSet.CSharp.Count;
                if (counter > 0)
                    {
                    row = dataBaseDataSet.CSharp[(new Random()).Next(0, counter)];
                    wordCard = new WordCard(row.word, row.description);
                    textBox1.Text = wordCard.word;
                    }
                }
            else if (wordCard != null)
                {
                textBox1.Text = wordCard.description;
                }
            }

        private void Card_Load(object sender, EventArgs e)
            {

            }
        }
    }
