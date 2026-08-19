using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Etmam
{
    public partial class ucItemsMain : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly ucItems _ucItems = new();
        private readonly ucItemsCategories _ucItemsCategories = new();

        public ucItemsMain()
        {
            InitializeComponent();

            if (DesignMode) return;

            _ucItems.Dock = DockStyle.Fill;
            navigationPage1.Controls.Add(_ucItems);

            _ucItemsCategories.Dock = DockStyle.Fill;
            navigationPage2.Controls.Add(_ucItemsCategories);

            bbiPriceQutationCompare.ItemClick += (s, e) => SelectPage(navigationPage2);
            bbiPriceQutation.ItemClick += (s, e) => SelectPage(navigationPage1);

        }

        private void SelectPage(DevExpress.XtraBars.Navigation.NavigationPage page)
        {
            navigationFrame1.SelectedPage = page;
        }

    }
}
