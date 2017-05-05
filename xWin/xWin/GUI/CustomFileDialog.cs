using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xWin.GUI
{
    class CustomFileDialog
    {
        private static OpenFileDialog FD;
        private static string extension;
        public static OpenFileDialog Get(string path, string description, string ext)
        {
            FD = new OpenFileDialog();
            extension = ext;
            FD.InitialDirectory = path;
            FD.FileOk += new System.ComponentModel.CancelEventHandler(open_Ok);
            FD.Filter = description + "|*" + ext;
            return FD;
        }

        static void open_Ok(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!FD.FileName.ToLower().EndsWith(extension))
            {
                e.Cancel = true;
            }
        }
    }
}
