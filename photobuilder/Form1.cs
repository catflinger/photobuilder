using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Photobuilder.Model;

namespace Photobuilder
{
    public partial class Form1 : Form
    {
        private AppSettings _settings;
        public Form1()
        {
            InitializeComponent();
            _settings = new AppSettings();
        }

        private void makeDiary()
        {
            PhotoSource source = new PhotoSource(_settings);
            Diary diary = new Diary(_settings);

            //remove any existing output
            diary.cleanOutputFolders();

            //load the source photos off disk
            source.loadPhotos();

            //get a list of all the years that the source images span
            IEnumerable<int> yearList = source.getYearList();

            //populate the diary with months, weeks, days et for the years in scope
            diary.buildIndex(yearList);

            //match up the phtos to the days in teh diary
            diary.addPhotos(source.photos);

            //make web images from the source photos for the output and index them
            diary.makeImages(source.photos);

            //create and save the index file
            diary.makeIndex();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            makeDiary();
            Cursor.Current = Cursors.Default;

            MessageBox.Show("Finished");
        }
    }
}
