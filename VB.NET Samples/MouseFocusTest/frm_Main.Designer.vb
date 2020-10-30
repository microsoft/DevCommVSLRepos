<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Main
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MainMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_OpenModels = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_CloseModels = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MainMenu})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(956, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MainMenu
        '
        Me.MainMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu_OpenModels, Me.mnu_CloseModels, Me.mnu_Exit})
        Me.MainMenu.Name = "MainMenu"
        Me.MainMenu.Size = New System.Drawing.Size(50, 20)
        Me.MainMenu.Text = "Menu3"
        '
        'mnu_OpenModels
        '
        Me.mnu_OpenModels.Name = "mnu_OpenModels"
        Me.mnu_OpenModels.Size = New System.Drawing.Size(180, 22)
        Me.mnu_OpenModels.Text = "Open Window"
        '
        'mnu_CloseModels
        '
        Me.mnu_CloseModels.Name = "mnu_CloseModels"
        Me.mnu_CloseModels.Size = New System.Drawing.Size(180, 22)
        Me.mnu_CloseModels.Text = "Close Window"
        '
        'mnu_Exit
        '
        Me.mnu_Exit.Name = "mnu_Exit"
        Me.mnu_Exit.Size = New System.Drawing.Size(180, 22)
        Me.mnu_Exit.Text = "Exit"
        '
        'frm_Main
        '
        Me.ClientSize = New System.Drawing.Size(956, 519)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frm_Main"
        Me.Text = "Main"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
End Class
