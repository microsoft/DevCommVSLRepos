Option Explicit On
Option Strict On

Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop.Excel
Imports XL = Microsoft.Office.Interop.Excel

Public Module Global_Definitions
    Friend ExcelRunning As Boolean = False

    Friend Const WM_ACTIVATE As Integer = &H6&          ' = 6
    Friend Const WM_QUIT As Integer = &H12&             ' = 18
    Friend Const WM_ACTIVATEAPP As Long = &H1C          ' = 28
    Friend Const WM_SYSCOMMAND As Integer = &H112&      ' = 274
    Friend Const SC_MINIMIZE As Integer = &HF020&       ' = 61472
    Friend Const SC_MAXIMIZE As Integer = &HF030&       ' = 61488
    Friend Const SC_CLOSE As Integer = &HF060&          ' = 61536

    Friend Const WA_INACTIVE As Integer = 0
    Friend Const WA_ACTIVE As Integer = 1
    Friend Const WA_CLICKACTIVE As Integer = 2

End Module

Public Class frm_Reports
    Inherits Form

    Declare Auto Function SetParent _
                 Lib "user32" (ByVal hWndChild As Integer,
                           ByVal hWndNewParent As Integer) As Integer

    Declare Auto Function MoveWindow _
                  Lib "user32.dll" (hWnd As IntPtr,
                            X As Integer,
                        Y As Integer,
                        nWidth As Integer,
                        nHeight As Integer,
                        bRepaint As Boolean) As Boolean

    Friend Declare Auto Function SendMessage _
                Lib "user32.dll" (ByVal hWnd As IntPtr,
                          ByVal Msg As Integer,
                          ByVal wParam As Integer,
                          ByVal lParam As Integer) As Integer

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents mnu_Select As ToolStripMenuItem
    Friend WithEvents mnu_NewModel As ToolStripMenuItem
    Friend WithEvents mnu_CloseModel As ToolStripMenuItem

    'Private Sub InitializeComponent()
    '    Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
    '    Me.mnu_Select = New System.Windows.Forms.ToolStripMenuItem()
    '    Me.mnu_NewModel = New System.Windows.Forms.ToolStripMenuItem()
    '    Me.mnu_CloseModel = New System.Windows.Forms.ToolStripMenuItem()
    '    Me.mnu_CloseWindow = New System.Windows.Forms.ToolStripMenuItem()
    '    Me.pnl_Excel = New System.Windows.Forms.Panel()
    '    Me.MenuStrip1.SuspendLayout()
    '    Me.SuspendLayout()
    '    '
    '    'MenuStrip1
    '    '
    '    Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu_Select})
    '    Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
    '    Me.MenuStrip1.Name = "MenuStrip1"
    '    Me.MenuStrip1.Size = New System.Drawing.Size(746, 24)
    '    Me.MenuStrip1.TabIndex = 0
    '    Me.MenuStrip1.Text = "MenuStrip1"
    '    '
    '    'mnu_Select
    '    '
    '    Me.mnu_Select.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu_NewModel, Me.mnu_CloseModel, Me.mnu_CloseWindow})
    '    Me.mnu_Select.Name = "mnu_Select"
    '    Me.mnu_Select.Size = New System.Drawing.Size(50, 20)
    '    Me.mnu_Select.Text = "Select"
    '    '
    '    'mnu_NewModel
    '    '
    '    Me.mnu_NewModel.Name = "mnu_NewModel"
    '    Me.mnu_NewModel.Size = New System.Drawing.Size(180, 22)
    '    Me.mnu_NewModel.Text = "New Model"
    '    '
    '    'mnu_CloseModel
    '    '
    '    Me.mnu_CloseModel.Name = "mnu_CloseModel"
    '    Me.mnu_CloseModel.Size = New System.Drawing.Size(180, 22)
    '    Me.mnu_CloseModel.Text = "Close Model"
    '    '
    '    'mnu_CloseWindow
    '    '
    '    Me.mnu_CloseWindow.Name = "mnu_CloseWindow"
    '    Me.mnu_CloseWindow.Size = New System.Drawing.Size(180, 22)
    '    Me.mnu_CloseWindow.Text = "Close Window"
    '    '
    '    'pnl_Excel
    '    '
    '    Me.pnl_Excel.Location = New System.Drawing.Point(88, 85)
    '    Me.pnl_Excel.Name = "pnl_Excel"
    '    Me.pnl_Excel.Size = New System.Drawing.Size(599, 238)
    '    Me.pnl_Excel.TabIndex = 1
    '    '
    '    'frm_Reports
    '    '
    '    Me.ClientSize = New System.Drawing.Size(746, 409)
    '    Me.Controls.Add(Me.pnl_Excel)
    '    Me.Controls.Add(Me.MenuStrip1)
    '    Me.MainMenuStrip = Me.MenuStrip1
    '    Me.Name = "frm_Reports"
    '    Me.MenuStrip1.ResumeLayout(False)
    '    Me.MenuStrip1.PerformLayout()
    '    Me.ResumeLayout(False)
    '    Me.PerformLayout()

    'End Sub

    Friend WithEvents pnl_Excel As Panel
    Friend WithEvents mnu_CloseWindow As ToolStripMenuItem
    Private WithEvents oExcel As Application = Nothing        ' Excel Application.
    Private WithEvents oWB As Workbook = Nothing
    Private WithEvents oSheet As Worksheet = Nothing
    Private ExcelRunning As Boolean = False
    Private ExHwnd As IntPtr

    Private Const CtrlOffset As Integer = 29        ' Vertical offset to hide Excel Controls.

    Private Sub mdl_Reports_Load(ByVal sender As System.Object,
                     ByVal e As System.EventArgs) _
                     Handles MyBase.Load
        Call InitializeComponent()
        pnl_Excel.Visible = False
        Me.MdiParent = frm_Main
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub mnu_NewModel_Click(sender As Object,
                       e As EventArgs) _
                       Handles mnu_NewModel.Click
        Dim Workbooks As Workbooks

        pnl_Excel.Visible = True
        pnl_Excel.Dock = DockStyle.Fill
        oExcel = qExcel.Run_Excel()
        ExHwnd = CType(oExcel.Hwnd, IntPtr)

        With oExcel
            SetParent(CInt(ExHwnd), CInt(pnl_Excel.Handle))
            SendMessage(ExHwnd, WM_SYSCOMMAND, SC_MAXIMIZE, 0)
            MoveWindow(ExHwnd, 0, -CtrlOffset, pnl_Excel.Width, pnl_Excel.Height + CtrlOffset, True)
        End With

        Workbooks = oExcel.Workbooks
        Workbooks.Add()
        oWB = oExcel.ActiveWorkbook
        With oWB
            .Activate()
            .Title = "Template"
            oSheet = CType(.Sheets.Add(), Worksheet)
        End With
        With oSheet
            .Activate()
            .Name = "Reports"
            .Visible = XlSheetVisibility.xlSheetVisible
            .Range("A1").Value = "Model Name"
            With oExcel
                .SendKeys("{DOWN}", True)
                .SendKeys("{DOWN}", True)
                .SendKeys("^A", True)
            End With
            '  Weirdness here - had to use above code because oExcel.Range("A3").Activate()
            '                   or oExcel.Range("A3").Select() (or both together) did not work!
            '  Any comments or suggestions?
        End With
        With oExcel
            .Visible = True
            .EnableEvents = True
        End With
        SendMessage(ExHwnd, WM_ACTIVATE, WA_ACTIVE, 0)
    End Sub

    'Private Sub CloseModel()
    Private Sub mnu_CloseModel_Click(sender As Object,
                     e As EventArgs) _
                     Handles mnu_CloseModel.Click
        pnl_Excel.Visible = False
        Call ReleaseWB()
        Call qExcel.QuitExcel(oExcel)
    End Sub

    Private Sub ReleaseWB()

        Dim ExcelWorkbooks As Workbooks = Nothing
        Dim worksheets As Sheets = Nothing

        Try
            ExcelWorkbooks = oExcel.Workbooks
        Catch ex As Exception
            Exit Sub
        End Try
        For Each WB As Workbook In oExcel.Workbooks
            worksheets = WB.Worksheets
            For Each ws As Worksheet In worksheets
                Try
                    Marshal.ReleaseComObject(ws)
                Catch ex As Exception
                End Try
            Next
            WB.Close(False)                     'Don't save
            Marshal.ReleaseComObject(WB)
        Next

        Try
            Marshal.ReleaseComObject(worksheets)
            worksheets = Nothing
        Catch ex As Exception
        End Try

        Try
            ExcelWorkbooks.Close()
            Marshal.ReleaseComObject(ExcelWorkbooks)
            ExcelWorkbooks = Nothing
        Catch ex As Exception
        End Try
    End Sub

    Private Sub mnu_CloseWindow_Click(sender As Object,
                      e As EventArgs) _
                      Handles mnu_CloseWindow.Click
        Call ReleaseWB()
        Call qExcel.QuitExcel(oExcel)
        Me.Close()
    End Sub
End Class

Friend Class qExcel
    Shared WithEvents oExcel As doExcel = Nothing
    Private Shared Running As Boolean = False

    Friend Shared Function Run_Excel() As XL.Application
        Dim rExcel = New XL.Application
        oExcel = New doExcel(rExcel)
        rExcel.Application.Workbooks.Add()
        Running = True
        ExcelRunning = True
        Return rExcel
    End Function

    Friend Shared Sub QuitExcel(ByRef rExcel As XL.Application)
        If Running Then
            Try
                rExcel.Quit()
                rExcel = Nothing
                oExcel.Dispose()
                oExcel = Nothing
                GC.Collect()
                Running = False
                ExcelRunning = False
            Catch ex As Exception
            End Try
        End If
    End Sub

End Class

Friend Class doExcel
    Implements IDisposable

    Public Sub New(ByRef oExcel As XL.Application)
        oExcel = New XL.Application
    End Sub

    Public Overloads Sub Dispose() Implements IDisposable.Dispose
    End Sub

    Protected Overrides Sub Finalize()
        Dispose()
    End Sub

End Class