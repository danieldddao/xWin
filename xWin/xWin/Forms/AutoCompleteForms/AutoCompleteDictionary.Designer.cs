namespace xWin.Forms.AutoCompleteForms
{
    partial class AutoCompleteDictionary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoCompleteDictionary));
            this.DictionaryListView = new System.Windows.Forms.ListView();
            this.wordHeaderHide = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.removeWordsButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.addWordButton = new System.Windows.Forms.Button();
            this.WordHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // DictionaryListView
            // 
            this.DictionaryListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.wordHeaderHide,
            this.WordHeader});
            this.DictionaryListView.GridLines = true;
            this.DictionaryListView.Location = new System.Drawing.Point(0, 0);
            this.DictionaryListView.Name = "DictionaryListView";
            this.DictionaryListView.Size = new System.Drawing.Size(305, 715);
            this.DictionaryListView.TabIndex = 0;
            this.DictionaryListView.UseCompatibleStateImageBehavior = false;
            this.DictionaryListView.View = System.Windows.Forms.View.Details;
            // 
            // wordHeaderHide
            // 
            this.wordHeaderHide.Text = "Word";
            this.wordHeaderHide.Width = 0;
            // 
            // removeWordsButton
            // 
            this.removeWordsButton.BackgroundImage = global::xWin.Properties.Resources.buttonBackground;
            this.removeWordsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.removeWordsButton.Location = new System.Drawing.Point(383, 28);
            this.removeWordsButton.Name = "removeWordsButton";
            this.removeWordsButton.Size = new System.Drawing.Size(298, 64);
            this.removeWordsButton.TabIndex = 1;
            this.removeWordsButton.Text = "Remove Selected Words";
            this.removeWordsButton.UseVisualStyleBackColor = true;
            this.removeWordsButton.Click += new System.EventHandler(this.removeWordsButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.BackgroundImage = global::xWin.Properties.Resources.buttonBackground;
            this.clearButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.clearButton.Location = new System.Drawing.Point(383, 274);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(298, 64);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "Clear Dictionary";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // addWordButton
            // 
            this.addWordButton.BackgroundImage = global::xWin.Properties.Resources.buttonBackground;
            this.addWordButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.addWordButton.Location = new System.Drawing.Point(383, 149);
            this.addWordButton.Name = "addWordButton";
            this.addWordButton.Size = new System.Drawing.Size(298, 64);
            this.addWordButton.TabIndex = 3;
            this.addWordButton.Text = "Add Word To Dictionary";
            this.addWordButton.UseVisualStyleBackColor = true;
            this.addWordButton.Click += new System.EventHandler(this.addWordButton_Click);
            // 
            // WordHeader
            // 
            this.WordHeader.Text = "Word";
            this.WordHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WordHeader.Width = 150;
            // 
            // AutoCompleteDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 739);
            this.Controls.Add(this.addWordButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.removeWordsButton);
            this.Controls.Add(this.DictionaryListView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AutoCompleteDictionary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto-Complete Dictionary";
            this.Load += new System.EventHandler(this.AutoCompleteDictionary_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView DictionaryListView;
        private System.Windows.Forms.Button removeWordsButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.ColumnHeader wordHeaderHide;
        private System.Windows.Forms.Button addWordButton;
        private System.Windows.Forms.ColumnHeader WordHeader;
    }
}