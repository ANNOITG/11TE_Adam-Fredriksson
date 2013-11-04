using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Windows_fileExplorer {
    public partial class Form1 : Form {
        public string path = @"C:\";
        public string[] filePaths;
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            List<directoryClass> durr = getFilesInDirectory(path);
        }

        private List<directoryClass> getFilesInDirectory(string path) {
            string[] files = Directory.GetDirectories(path);
            if (files.Count() != 0) {
                List<directoryClass> fileNames = new List<directoryClass>();
                for (int i = 0; i < files.Count(); i++) {
                    if (Path.GetFileName(files[i]) != "$Recycle.Bin")
                        fileNames.Add(new directoryClass(files[i], Path.GetFileName(files[i])));
                }

                return fileNames;
            }
            return new List<directoryClass>();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {

        }


    }
    public class directoryClass {
        public string filePath { get; set; }
        public string fileName { get; set; }

        public directoryClass(string filePath, string fileName) {
            this.filePath = filePath;
            this.fileName = fileName;
        }
    }
}
