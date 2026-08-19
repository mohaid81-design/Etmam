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
    public partial class ucPriceQuotationMain : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly ucPriceQuotation _ucPriceQuotation = new();
        private readonly ucPriceQuotationCompare _ucPriceQuotationCompare = new();

        public ucPriceQuotationMain()
        {
            InitializeComponent();

            if (DesignMode) return;

            _ucPriceQuotation.Dock = DockStyle.Fill;
            navigationPage1.Controls.Add(_ucPriceQuotation);

            _ucPriceQuotationCompare.Dock = DockStyle.Fill;
            navigationPage2.Controls.Add(_ucPriceQuotationCompare);

            bbiPriceQutation.ItemClick += (s, e) => SelectPage(navigationPage1);
            bbiPriceQutationCompare.ItemClick += (s, e) => SelectPage(navigationPage2);

        }

        private void SelectPage(DevExpress.XtraBars.Navigation.NavigationPage page)
        {
            navigationFrame1.SelectedPage = page;
        }

        public void OnProjectChanged()
        {
            _ucPriceQuotation.OnProjectChanged();
            _ucPriceQuotationCompare.OnProjectChanged();
        }

    }
}
