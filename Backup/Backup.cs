using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backup
{
    public partial class Backup : Form
    {
        IniFile ini = new IniFile();
        public Backup(string[] args)
        {
            InitializeComponent();
            if ((args.Length > 0 && args[0] == "backup") || (args.Length > 1 && args[1] == "backup"))
            {
                lbLocations.Visible = false;
                this.Height = 100;
                progressBar1.Visible = true;


                string prefix = string.Empty, dateFormat = string.Empty;
                foreach (string kvp in ini.ReadKeyValuePairs("Common"))
                {
                    string[] common = kvp.Split('=');
                    switch (common[0])
                    {
                        case "Prefix":
                            prefix = common[1];
                            break;
                        case "DateFormat":
                            dateFormat = common[1];
                            break;
                    }
                }

                string DestinationPath = string.Format("{0}\\{1}{2:" + dateFormat + "}", ini.ReadKeyValuePairs("Destination")[0].Split('=')[1], prefix, DateTime.Now);
                if (!Directory.Exists(DestinationPath))
                {
                    Directory.CreateDirectory(DestinationPath);
                    foreach (string source in ini.ReadKeyValuePairs("Source"))
                    {
                        FileInfo fInfo = new FileInfo(source.Split('=')[1]);
                        if(fInfo.Exists)
                        {
                            fInfo.CopyTo(DestinationPath);
                        }
                        else
                        {
                            DirectoryInfo dInfo = new DirectoryInfo(source.Split('=')[1]);
                            if(dInfo.Exists)
                            {
                                //Now Create all of the directories
                                foreach (string dirPath in Directory.GetDirectories(dInfo.FullName, "*", SearchOption.AllDirectories))
                                {
                                    Directory.CreateDirectory(dirPath.Replace(dInfo.Parent.FullName, DestinationPath));
                                }

                                //Copy all the files & Replaces any files with the same name
                                foreach (string newPath in Directory.GetFiles(dInfo.FullName, "*.*", SearchOption.AllDirectories))
                                {
                                    File.Copy(newPath, newPath.Replace(dInfo.Parent.FullName, DestinationPath), true);
                                }
                            }
                        }
                    }
                }
            }
            try
            {
                foreach (string source in ini.ReadKeyValuePairs("Source"))
                {
                    lbLocations.Items.Add(source.Split('=')[1]);
                }
                foreach (string destination in ini.ReadKeyValuePairs("Destination"))
                {
                    tbTarget.Text = destination.Split('=')[1];
                    folderBrowserDialogTarget.SelectedPath = destination.Split('=')[1];
                }

                foreach (string kvp in ini.ReadKeyValuePairs("Common"))
                {
                    string[] common = kvp.Split('=');
                    switch (common[0])
                    {
                        case "Prefix":
                            tbName.Text = common[1];
                            break;
                        case "DateFormat":
                            tbDate.Text = common[1];
                            break;
                    }
                }
            }
            catch
            {

            }
        }

        private void btDirBrowse_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                tbDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btFileBrowse_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                tbFile.Text = openFileDialog1.FileName;
            }
        }

        private void lbLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            btDelete.Enabled = true;
        }

        private void btFileAdd_Click(object sender, EventArgs e)
        {
            foreach (string filename in openFileDialog1.FileNames)
            {
                lbLocations.Items.Add(filename);
            }
        }

        private void btDirAdd_Click(object sender, EventArgs e)
        {
            lbLocations.Items.Add(folderBrowserDialog1.SelectedPath);
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            lbLocations.Items.Remove(lbLocations.SelectedItem);
        }

        private void btTarget_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialogTarget.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                tbTarget.Text = folderBrowserDialogTarget.SelectedPath;
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            ini.DeleteSection("Source");
            for (int i = 0; i < lbLocations.Items.Count; i++)
            {
                ini.WriteValue("Source", string.Format("Location{0}", i), lbLocations.Items[i].ToString());
            }
            ini.WriteValue("Destination", string.Format("Location{0}", 0), folderBrowserDialogTarget.SelectedPath);
            ini.WriteValue("Common", "Prefix", tbName.Text);
            ini.WriteValue("Common", "DateFormat", tbDate.Text);
        }
    }
}
