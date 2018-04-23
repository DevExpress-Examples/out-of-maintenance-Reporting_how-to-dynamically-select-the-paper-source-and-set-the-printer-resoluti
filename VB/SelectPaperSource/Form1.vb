Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraPrinting
Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI
' ...

Namespace SelectPaperSource
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
	Dim pt As New ReportPrintTool(New XtraReport1())
	AddHandler pt.PrintingSystem.StartPrint, AddressOf printingSystem_StartPrint
	pt.PrintDialog()
End Sub

		Private Sub printingSystem_StartPrint(ByVal sender As Object, ByVal e As PrintDocumentEventArgs)
			For i As Integer = 0 To e.PrintDocument.PrinterSettings.PaperSources.Count - 1
				If e.PrintDocument.PrinterSettings.PaperSources(i).Kind = PaperSourceKind.TractorFeed Then
					e.PrintDocument.DefaultPageSettings.PaperSource = e.PrintDocument.PrinterSettings.PaperSources(i)
					Exit For
				End If
			Next i

			For i As Integer = 0 To e.PrintDocument.PrinterSettings.PrinterResolutions.Count - 1
				If e.PrintDocument.PrinterSettings.PrinterResolutions(i).Kind = PrinterResolutionKind.High Then
					e.PrintDocument.DefaultPageSettings.PrinterResolution = e.PrintDocument.PrinterSettings.PrinterResolutions(i)
					Exit For
				End If
			Next i
		End Sub

	End Class
End Namespace

