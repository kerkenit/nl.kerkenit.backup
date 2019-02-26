using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Backup
{
    public partial class Backup : Form
    {
        IniFile ini = new IniFile();

        private static readonly ILogger log = new EventLogger();

        private static readonly string[] excludeFileList = new string[]
        {
            "desktop.ini",
            "Thumbs.db",
            ".DS_Store"
        };
        public Backup(string[] args)
        {
            try
            {
                CultureInfo ci = new CultureInfo("nl-NL");
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;

                InitializeComponent();
                if ((args.Length > 0 && args[0] == "backup") || (args.Length > 1 && args[1] == "backup"))
                {
                    backup(30, null);
                    Environment.Exit(-1);
                }
                try
                {
                    if (ini != null)
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
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    // MessageBox.Show(ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btDirBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = folderBrowserDialog1.ShowDialog();
                if (dr != DialogResult.Cancel)
                {
                    tbDir.Text = folderBrowserDialog1.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MessageBox.Show(ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btFileBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr != DialogResult.Cancel)
                {
                    tbFile.Text = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MessageBox.Show(ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            btDelete.Enabled = true;
        }

        private void btFileAdd_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (string filename in openFileDialog1.FileNames)
                {
                    lbLocations.Items.Add(filename);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MessageBox.Show(ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btDirAdd_Click(object sender, EventArgs e)
        {
            try
            {
                lbLocations.Items.Add(folderBrowserDialog1.SelectedPath);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MessageBox.Show(ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                lbLocations.Items.Remove(lbLocations.SelectedItem);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MessageBox.Show(ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btTarget_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = folderBrowserDialogTarget.ShowDialog();
                if (dr != DialogResult.Cancel)
                {
                    tbTarget.Text = folderBrowserDialogTarget.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MessageBox.Show(ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                log.Error(ex);
                MessageBox.Show(ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btBackup_Click(object sender, EventArgs e)
        {
            lbLocations.Visible = false;
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            progressBar1.Visible = true;
            this.Height = 100;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backup(int remove, BackgroundWorker backgroundWorker)
        {
            try
            {
                IniFile ini = new IniFile();
                ILogger log = new EventLogger();

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
                string folderpath = ini.ReadKeyValuePairs("Destination")[0].Split('=')[1];
                DirectoryInfo dir = new DirectoryInfo(folderpath);

                DirectoryInfo[] backupdirs = dir.GetDirectories().OrderByDescending(p => p.CreationTime).ToArray();
                int r = 0;


                foreach (DirectoryInfo dInfo in backupdirs)
                {
                    r++;
                    if (r > remove)
                    {
                        try
                        {
                            if (dInfo.Exists)
                            {
                                dInfo.Delete(true);
                            }
                        }
                        catch (Exception ex)
                        {
                            log.Info(dInfo.FullName, ex);
                            try
                            {
                                Directory.Delete(dInfo.FullName, true);
                            }
                            catch (Exception ex2)
                            {
                                log.Warn(dInfo.FullName, ex2);
                            }
                        }
                    }
                }

#if DEBUG
                for (DateTime dt = new DateTime(2018, 9, 1); dt < DateTime.Today; dt = dt.AddDays(1))
                {
                    DirectoryInfo d = new DirectoryInfo(string.Format("{0}\\{1} {2:" + dateFormat + "}", folderpath, prefix, dt));
                    if (!d.Exists)
                    {
                        d.Create();
                        d.CreationTime = dt;
                    }
                }
#endif
                string DestinationPath = string.Format("{0}\\{1}{2:" + dateFormat + "}", folderpath, (!string.IsNullOrWhiteSpace(prefix) ? prefix.Trim() + " " : ""), DateTime.Now);

#if DEBUG
                try
                {
                    if (Directory.Exists(DestinationPath))
                    {
                        Directory.Delete(DestinationPath, true);
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
#endif
                if (!Directory.Exists(DestinationPath))
                {
                    Directory.CreateDirectory(DestinationPath);
                    foreach (string source in ini.ReadKeyValuePairs("Source"))
                    {
                        try
                        {
                            backgroundWorker.ReportProgress(0);
                        }
                        catch (Exception ex)
                        {
                            log.Info(ex);
                        }
                        try
                        {
                            FileInfo fInfo = new FileInfo(source.Split('=')[1]);
                            if (fInfo.Exists && !excludeFileList.Contains(fInfo.Name) && !excludeFileList.Contains(fInfo.Extension))
                            {
                                try
                                {
                                    fInfo.CopyTo(DestinationPath.TrimEnd('\\') + "\\" + fInfo.Name, true);
                                }
                                catch (Exception ex)
                                {
                                    log.Error(ex);
                                }
                            }
                            else
                            {
                                try
                                {
                                    DirectoryInfo dInfo = new DirectoryInfo(source.Split('=')[1]);
                                    if (dInfo.Exists)
                                    {
                                        string[] dirs = Directory.GetDirectories(dInfo.Parent.FullName, "*", SearchOption.AllDirectories);
                                        string[] files = Directory.GetFiles(dInfo.Parent.FullName, "*.*", SearchOption.AllDirectories);
                                        double length = dirs.Length + files.Length;
                                        double i = 1;

                                        //Now Create all of the directories

                                        foreach (string dirPath in dirs)
                                        {
                                            try
                                            {
                                                Directory.CreateDirectory(dirPath.Replace(dInfo.Parent.FullName, DestinationPath));
                                            }
                                            catch (Exception ex)
                                            {
                                                log.Error(ex);
                                            }
                                            finally
                                            {
                                                try
                                                {
                                                    backgroundWorker.ReportProgress((int)Math.Floor((100 / length) * i));
                                                }
                                                catch (Exception ex)
                                                {
                                                    log.Info(ex);
                                                }
                                                i++;
                                            }
                                        }

                                        //Copy all the files & Replaces any files with the same name
                                        foreach (string newPath in files)
                                        {
                                            try
                                            {
                                                if (!excludeFileList.Contains(newPath) && !excludeFileList.Contains(newPath))
                                                {
                                                    File.Copy(newPath, newPath.Replace(dInfo.Parent.FullName.TrimEnd(Path.DirectorySeparatorChar), DestinationPath), true);
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                log.Error(ex);
                                            }
                                            finally
                                            {
                                                try
                                                {
                                                    backgroundWorker.ReportProgress((int)Math.Floor((100 / length) * i));
                                                }
                                                catch (Exception ex)
                                                {
                                                    log.Info(ex);
                                                }
                                                i++;
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    log.Warn(ex);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            log.Warn(ex);
                        }

                        try
                        {
                            backgroundWorker.ReportProgress(100);
                        }
                        catch (Exception ex)
                        {
                            log.Info(ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                backgroundWorker.ReportProgress(100);
            }
            catch (Exception ex)
            {
                log.Info(ex);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backup(30, (BackgroundWorker)sender);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                progressBar1.Value = e.ProgressPercentage;
#if DEBUG
                log.Debug(string.Format("{0:P0} complete", e.ProgressPercentage / 100));
#endif
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Backup is gemaakt. Wilt u de computer nu uitzetten?", "Backup gereed", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Process.Start("shutdown.exe", "-s -t 0");
                }
                else if (dr == DialogResult.No)
                {
                    Environment.Exit(-1);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MessageBox.Show(ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
