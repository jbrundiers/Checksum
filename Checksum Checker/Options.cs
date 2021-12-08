using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.Globalization;


namespace Checksum_Checker
{
    public partial class dlgOptions : Form
    {

        private CultureInfo SelectedCulture;
        private int CultureIndex;
        public dlgOptions()
        {
            InitializeComponent();

            // uses the SupportedCultures array
            UICulture Lng = new UICulture();
            List<String> liste = Lng.SupportedCulture;

            String CultName = Properties.Settings.Default.Culture; // read from properties
            CultureInfo CultInfo = new CultureInfo(CultName);
            SelectedCulture = CultInfo;

            foreach (string IetfTag in liste)
            {
                CultureInfo Cult = new CultureInfo(IetfTag);

                // Note: The property listBoxCultures.DisplayName is set to "NativeName" in order to
                //       show language name in its own language.
                listBoxCultures.Items.Add(Cult);
            }

            listBoxCultures.SelectedItem = SelectedCulture;

            CultureIndex = listBoxCultures.SelectedIndex;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (listBoxCultures.SelectedItem != null)
            {
                if (CultureIndex != listBoxCultures.SelectedIndex)
                {
                    SelectedCulture = (CultureInfo)listBoxCultures.SelectedItem;
                    Properties.Settings.Default.Culture = SelectedCulture.Name;

                    //MessageBox.Show(this, Resources.RES_ID_CultureChange, "Smtp Mail Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show(this, "Info message ...", "CheckSum", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            Properties.Settings.Default.Save();

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
