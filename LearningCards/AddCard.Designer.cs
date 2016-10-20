namespace LearningCards
    {
    partial class AddCard
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
            {
            if (disposing && (components != null))
                {
                components.Dispose();
                }
            base.Dispose(disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
            {
            this.tbWord = new System.Windows.Forms.TextBox();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbWord
            // 
            this.tbWord.Location = new System.Drawing.Point(12, 23);
            this.tbWord.Multiline = true;
            this.tbWord.Name = "tbWord";
            this.tbWord.Size = new System.Drawing.Size(317, 59);
            this.tbWord.TabIndex = 0;
            // 
            // tbDesc
            // 
            this.tbDesc.Location = new System.Drawing.Point(12, 88);
            this.tbDesc.Multiline = true;
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(317, 160);
            this.tbDesc.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(254, 254);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // AddCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 289);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbDesc);
            this.Controls.Add(this.tbWord);
            this.Name = "AddCard";
            this.Text = "AddCard";
            this.Load += new System.EventHandler(this.AddCard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.TextBox tbWord;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.Button btnAdd;
        }
    }