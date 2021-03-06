﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xWin.Forms.AutoCompleteForms
{
    public partial class AutoCompleteDictionary : Form
    {
        public AutoCompleteDictionary()
        {
            InitializeComponent();
        }

        private void LoadWordsToList()
        {
            Library.AutoCompleteDB db = new Library.AutoCompleteDB();
            List<string> allWords = db.GetAllWords();
            Library.Log.GetLogger().Info("Number of words in dictionary table: " + allWords.Count);
            foreach (string word in allWords)
            {
                ListViewItem list = new ListViewItem();
                list.SubItems.Add(word);
                DictionaryListView.Items.Add(list);
            }
        }
        private void AutoCompleteDictionary_Load(object sender, EventArgs e)
        {
            try
            {
                LoadWordsToList();
            }
            catch (Exception ex)
            {
                Library.Log.GetLogger().Error(ex);
            }
        }

        private void removeWordsButton_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (ListViewItem item in DictionaryListView.SelectedItems)
                {
                    Library.Log.GetLogger().Debug("removing " + item.SubItems[0].Text + " from database");
                    Library.AutoCompleteDB db = new Library.AutoCompleteDB();
                    string word = item.SubItems[1].Text;
                    bool status = db.RemoveWord(word);
                    if (status)
                    {
                        DictionaryListView.Items.Remove(item);
                        Library.Log.GetLogger().Warn("removed " + word  + " from database");
                    }
                }
            }
            catch (Exception ex)
            {
                Library.Log.GetLogger().Error(ex);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            try
            {
                Library.AutoCompleteDB db = new Library.AutoCompleteDB();
                db.ClearDictionary();
                DictionaryListView.Items.Clear();
            }
            catch (Exception ex)
            {
                Library.Log.GetLogger().Error(ex);
            }
        }

        private void addWordButton_Click(object sender, EventArgs e)
        {
            try
            {
                AutoCompleteAddNewWord dialog = new AutoCompleteAddNewWord();
                dialog.ShowDialog();
                Library.AutoCompleteDB db = new Library.AutoCompleteDB();
                if (dialog.newWord != "")
                {
                    db.UpdateOrInsertWord(dialog.newWord);
                    ListViewItem list = new ListViewItem();
                    list.SubItems.Add(dialog.newWord);
                    DictionaryListView.Items.Add(list);
                }
            }
            catch (Exception ex)
            {
                Library.Log.GetLogger().Error(ex);
            }
        }
    }
}
