using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xWin.Config;

namespace xWin.GUI
{
    public partial class KeysetWindow : Form
    {
        private KeysetWindow()
        {
            InitializeComponent();
        }
        public KeysetWindow(KeyboardSet ks, List<string> l, int t1, int t2) : this()
        {
            for(int i = 0; i < t1; ++i)
            {
                Panel.Controls.Add(new StringListControl(t2));
            }
            populate(ks);
            io = new IO<KeyboardSet>(l, IO<KeyboardSet>.KEYBOARDSET_EXT);
            keyboardset = new KeyboardSet(); 
        }

        private void populate(KeyboardSet ks)
        {
            NameBox.Text = ks.Name == null ? "" : ks.Name;
            int i = 0;
            foreach (var cont in Panel.Controls.OfType<StringListControl>())
            {
                int j = 0;
                cont.namebox.Text = ks.Count > i ? ks.Set[i].Display : "";
                foreach (var tb in cont.StringArray.Controls.OfType<TextBox>())
                {
                    tb.Text = ks.Count > i && ks.Subcount > j ? ks.Set[i].Subset[j] : "";
                    ++j;
                }
                ++i;
            }
        }
        private IO<KeyboardSet> io;


       


        //OpenFileDialog FD;

        private void Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog FD = CustomFileDialog.Get(io.SearchPaths[0],"charactersets",io.ext);
            //FD.FileOk += new CancelEventHandler(open_KeyboardSetOk);
            if (FD.ShowDialog() == DialogResult.OK)
            {
                string fileToOpen = FD.FileName;
                var ks = io.ReadFromFile(fileToOpen);
                NameBox.Text = ks.Name;
                DescriptionBox.Text = ks.Description;
                populate(ks);
            }
        }

        private KeyboardSet conglomerate()
        {
            KeyboardSet ks = new KeyboardSet
            {
                Name = NameBox.Text == null ? "" : NameBox.Text,
                Description = DescriptionBox.Text == null ? "" : DescriptionBox.Text,
                Count = Panel.Controls.OfType<StringListControl>().Count(),
                Subcount = Panel.Controls.OfType<StringListControl>().Count() == 0 ? 0 : Panel.Controls.OfType<StringListControl>().ElementAt(0).StringArray.Controls.Count,
                Set = { }
            };
            foreach (var cont in Panel.Controls.OfType<StringListControl>())
            {
                var sc = new KeyboardSet.Types.StringChoice();
                sc.Display = cont.namebox.Text;
                foreach (var tb in cont.StringArray.Controls.OfType<TextBox>())
                {
                    if (tb.Text != null)
                        sc.Subset.Add(tb.Text);
                    else
                        sc.Subset.Add("");
                }
                ks.Set.Add(sc);
            }
            return ks;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if(NameBox.Text.Length == 0)
            {
                return;
            }
            var ks = conglomerate();
            io.WriteToFile(ks, ks.Name);
        }

        public KeyboardSet keyboardset;
        private void Confirm_Click(object sender, EventArgs e)
        {
            keyboardset = conglomerate();
            this.Close();
        }
    }
}
