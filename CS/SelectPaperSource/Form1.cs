using System;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using System.Drawing.Printing;
// ...

namespace SelectPaperSource {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            XtraReport1 rep = new XtraReport1();
            rep.PrintingSystem.StartPrint += 
                new PrintDocumentEventHandler(printingSystem_StartPrint);
            rep.PrintDialog();
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