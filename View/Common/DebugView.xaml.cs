using System.IO;
using System.Windows;
using System.Windows.Controls;
using KH_Editor.Model.KH_DDD.btlparam;
using Xe.BinaryMapper;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace KH_Editor.View.Common
{
    /// <summary>
    /// Interaction logic for DebugView.xaml
    /// </summary>
    public partial class DebugView : Page
    {
        public DebugView()
        {
            InitializeComponent();
        }

        private void actionFileDrop(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                // Assuming you have one file that you care about, pass it off to whatever
                // handling code you have defined.
                checkBtlparam(files[0]);
            }
        }

        private void checkBtlparam(string filePath)
        {
            List<byte> myByteArray = File.ReadAllBytes(filePath).ToList();
            for (int i = 0; i < 229; i++)
            {
                List<byte> entryBytes = myByteArray.GetRange(i*72, 72);
                DDD_btlparam_Entry myEntry = BinaryMapping.ReadObject<DDD_btlparam_Entry>(new MemoryStream(entryBytes.ToArray()));
                Debug.WriteLine("["+i+"] " + myEntry.entity + "[" + myEntry.ele_physical + "]" + "[" + myEntry.ele_fire + "]"  + " - " + myEntry.hp);
            }
            //DDD_btlparam_Entry myEntry = BinaryMapping.ReadObject<DDD_btlparam_Entry>(new MemoryStream(myByteArray));
        }
    }
}
