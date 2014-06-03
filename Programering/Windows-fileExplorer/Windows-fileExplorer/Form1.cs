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
        public List<directoryItems> listOfDirectoryItems = new List<directoryItems>();
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
        }

        private void getListOfSearchIndex(string searchIndex) {
        }

        private void Form1_Load(object sender, EventArgs e) {
            IEnumerable<string> listOfFiles = GetFileList("*", @"C:\");
        }
        public static IEnumerable<string> GetFileList(string fileSearchPattern, string rootFolderPath) {
            Queue<string> pending = new Queue<string>();
            pending.Enqueue(rootFolderPath);
            string[] tmp;
            while (pending.Count > 0) {
                rootFolderPath = pending.Dequeue();
                tmp = Directory.GetFiles(rootFolderPath, fileSearchPattern);
                for (int i = 0; i < tmp.Length; i++) {
                    yield return tmp[i];
                }
                tmp = Directory.GetDirectories(rootFolderPath);
                for (int i = 0; i < tmp.Length; i++) {
                    pending.Enqueue(tmp[i]);
                }
            }
        }

    }

    public class directoryItems {
        public string fileName { get; set; }
        public string filePath { get; set; }
        public List<directoryItems> listOfItemsInDirectory { get; set; }

        public directoryItems(string fileName, string filePath) {
            this.fileName = fileName;
            this.filePath = filePath;
        }
    }
}
