<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Reports
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Text = "frm_Reports"

        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnu_Select = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_NewModel = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_CloseModel = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_CloseWindow = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnl_Excel = New System.Windows.Forms.Panel()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu_Select})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(746, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnu_Select
        '
        Me.mnu_Select.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu_NewModel, Me.mnu_CloseModel, Me.mnu_CloseWindow})
        Me.mnu_Select.Name = "mnu_Select"
        Me.mnu_Select.Size = New System.Drawing.Size(50, 20)
        Me.mnu_Select.Text = "Select"
        '
        'mnu_NewModel
        '
        Me.mnu_NewModel.Name = "mnu_NewModel"
        Me.mnu_NewModel.Size = New System.Drawing.Size(180, 22)
        Me.mnu_NewModel.Text = "New Model"
        '
        'mnu_CloseModel
        '
        Me.mnu_CloseModel.Name = "mnu_CloseModel"
        Me.mnu_CloseModel.Size = New System.Drawing.Size(180, 22)
        Me.mnu_CloseModel.Text = "Close Model"
        '
        'mnu_CloseWindow
        '
        Me.mnu_CloseWindow.Name = "mnu_CloseWindow"
        Me.mnu_CloseWindow.Size = New System.Drawing.Size(180, 22)
        Me.mnu_CloseWindow.Text = "Close Window"
        '
        'pnl_Excel
        '
        Me.pnl_Excel.Location = New System.Drawing.Point(88, 85)
        Me.pnl_Excel.Name = "pnl_Excel"
        Me.pnl_Excel.Size = New System.Drawing.Size(599, 238)
        Me.pnl_Excel.TabIndex = 1
        '
        'frm_Reports
        '
        Me.ClientSize = New System.Drawing.Size(746, 409)
        Me.Controls.Add(Me.pnl_Excel)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frm_Reports"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
