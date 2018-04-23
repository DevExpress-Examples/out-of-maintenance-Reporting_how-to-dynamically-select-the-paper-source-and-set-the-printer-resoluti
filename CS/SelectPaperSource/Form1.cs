using System;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using System.Drawing.Printing;
using DevExpress.XtraReports.UI;
// ...

namespace SelectPaperSource {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

private void button1_Click(object sender, EventArgs e) {
    ReportPrintTool pt = new ReportPrintTool(new XtraReport1());
    pt.PrintingSystem.StartPrint += 
        new PrintDocumentEventHandler(printingSystem_StartPrint);
    pt.PrintDialog();
}

        private void printingSystem_StartPrint(object sender, PrintDocumentEventArgs e) {
            for (int i = 0; i < e.PrintDocument.PrinterSettings.PaperSources.Count; i++)
                if (e.PrintDocument.PrinterSettings.PaperSources[i].Kind == 
                    PaperSourceKind.TractorFeed) {
                    e.PrintDocument.DefaultPageSettings.PaperSource = 
                        e.PrintDocument.PrinterSettings.PaperSources[i];
                    break;
                }

            for (int i = 0; i < e.PrintDocument.PrinterSettings.PrinterResolutions.Count; i++)
                if (e.PrintDocument.PrinterSettings.PrinterResolutions[i].Kind == 
                    PrinterResolutionKind.High) {
                    e.PrintDocument.DefaultPageSettings.PrinterResolution = 
                        e.PrintDocument.PrinterSettings.PrinterResolutions[i];
                    break;
                }
        }

    }
}

