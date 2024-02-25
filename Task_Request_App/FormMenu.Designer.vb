<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PanelDekstop = New System.Windows.Forms.Panel()
        Me.ButtonLogin = New System.Windows.Forms.Button()
        Me.PanelLogo = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelJudul = New System.Windows.Forms.Panel()
        Me.LabelHeader = New System.Windows.Forms.Label()
        Me.PanelMenu = New System.Windows.Forms.Panel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.RequestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TaskToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MASTERUSERToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MASTERDIVISIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBoxLogo = New System.Windows.Forms.PictureBox()
        Me.PanelLogo.SuspendLayout()
        Me.PanelJudul.SuspendLayout()
        Me.PanelMenu.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.PictureBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelDekstop
        '
        Me.PanelDekstop.BackColor = System.Drawing.Color.GhostWhite
        Me.PanelDekstop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelDekstop.Location = New System.Drawing.Point(204, 65)
        Me.PanelDekstop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelDekstop.Name = "PanelDekstop"
        Me.PanelDekstop.Size = New System.Drawing.Size(1124, 638)
        Me.PanelDekstop.TabIndex = 5
        '
        'ButtonLogin
        '
        Me.ButtonLogin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonLogin.BackColor = System.Drawing.Color.Transparent
        Me.ButtonLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonLogin.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonLogin.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ButtonLogin.Location = New System.Drawing.Point(991, 18)
        Me.ButtonLogin.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonLogin.Name = "ButtonLogin"
        Me.ButtonLogin.Size = New System.Drawing.Size(116, 30)
        Me.ButtonLogin.TabIndex = 1
        Me.ButtonLogin.Text = "LOGIN"
        Me.ButtonLogin.UseVisualStyleBackColor = False
        '
        'PanelLogo
        '
        Me.PanelLogo.Controls.Add(Me.Label1)
        Me.PanelLogo.Controls.Add(Me.PictureBoxLogo)
        Me.PanelLogo.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelLogo.Location = New System.Drawing.Point(0, 0)
        Me.PanelLogo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelLogo.Name = "PanelLogo"
        Me.PanelLogo.Size = New System.Drawing.Size(204, 169)
        Me.PanelLogo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(16, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Task Management"
        '
        'PanelJudul
        '
        Me.PanelJudul.BackColor = System.Drawing.Color.LightPink
        Me.PanelJudul.Controls.Add(Me.LabelHeader)
        Me.PanelJudul.Controls.Add(Me.ButtonLogin)
        Me.PanelJudul.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelJudul.Location = New System.Drawing.Point(204, 0)
        Me.PanelJudul.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelJudul.Name = "PanelJudul"
        Me.PanelJudul.Size = New System.Drawing.Size(1124, 65)
        Me.PanelJudul.TabIndex = 4
        '
        'LabelHeader
        '
        Me.LabelHeader.AutoSize = True
        Me.LabelHeader.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeader.ForeColor = System.Drawing.SystemColors.GrayText
        Me.LabelHeader.Location = New System.Drawing.Point(36, 20)
        Me.LabelHeader.Name = "LabelHeader"
        Me.LabelHeader.Size = New System.Drawing.Size(0, 25)
        Me.LabelHeader.TabIndex = 19
        '
        'PanelMenu
        '
        Me.PanelMenu.BackColor = System.Drawing.Color.LightPink
        Me.PanelMenu.Controls.Add(Me.MenuStrip2)
        Me.PanelMenu.Controls.Add(Me.PanelLogo)
        Me.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelMenu.Location = New System.Drawing.Point(0, 0)
        Me.PanelMenu.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelMenu.Name = "PanelMenu"
        Me.PanelMenu.Size = New System.Drawing.Size(204, 703)
        Me.PanelMenu.TabIndex = 3
        '
        'MenuStrip2
        '
        Me.MenuStrip2.AutoSize = False
        Me.MenuStrip2.BackColor = System.Drawing.Color.LightPink
        Me.MenuStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip2.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 6)
        Me.MenuStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RequestToolStripMenuItem, Me.TaskToolStripMenuItem, Me.SettingToolStripMenuItem})
        Me.MenuStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 184)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(204, 141)
        Me.MenuStrip2.TabIndex = 0
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'RequestToolStripMenuItem
        '
        Me.RequestToolStripMenuItem.BackColor = System.Drawing.Color.LightPink
        Me.RequestToolStripMenuItem.Image = Global.Task_Request_App.My.Resources.Resources.quote_request
        Me.RequestToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 0, 0, 14)
        Me.RequestToolStripMenuItem.Name = "RequestToolStripMenuItem"
        Me.RequestToolStripMenuItem.Size = New System.Drawing.Size(197, 32)
        Me.RequestToolStripMenuItem.Text = "   REQUEST"
        '
        'TaskToolStripMenuItem
        '
        Me.TaskToolStripMenuItem.Image = Global.Task_Request_App.My.Resources.Resources.pngegg
        Me.TaskToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 0, 0, 14)
        Me.TaskToolStripMenuItem.Name = "TaskToolStripMenuItem"
        Me.TaskToolStripMenuItem.Size = New System.Drawing.Size(197, 32)
        Me.TaskToolStripMenuItem.Text = "   TASK       "
        '
        'SettingToolStripMenuItem
        '
        Me.SettingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MASTERUSERToolStripMenuItem, Me.MASTERDIVISIToolStripMenuItem})
        Me.SettingToolStripMenuItem.Image = Global.Task_Request_App.My.Resources.Resources.vecteezy_profile_settings_icon_12791178_1_removebg_preview1
        Me.SettingToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 0, 0, 14)
        Me.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem"
        Me.SettingToolStripMenuItem.Size = New System.Drawing.Size(197, 32)
        Me.SettingToolStripMenuItem.Text = "   SETTING  "
        '
        'MASTERUSERToolStripMenuItem
        '
        Me.MASTERUSERToolStripMenuItem.BackColor = System.Drawing.Color.LightPink
        Me.MASTERUSERToolStripMenuItem.Name = "MASTERUSERToolStripMenuItem"
        Me.MASTERUSERToolStripMenuItem.Size = New System.Drawing.Size(221, 32)
        Me.MASTERUSERToolStripMenuItem.Text = "MASTER USER"
        '
        'MASTERDIVISIToolStripMenuItem
        '
        Me.MASTERDIVISIToolStripMenuItem.BackColor = System.Drawing.Color.LightPink
        Me.MASTERDIVISIToolStripMenuItem.Name = "MASTERDIVISIToolStripMenuItem"
        Me.MASTERDIVISIToolStripMenuItem.Size = New System.Drawing.Size(221, 32)
        Me.MASTERDIVISIToolStripMenuItem.Text = "MASTER DIVISI"
        '
        'PictureBoxLogo
        '
        Me.PictureBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxLogo.Image = Global.Task_Request_App.My.Resources.Resources.LaRitta_removebg_preview
        Me.PictureBoxLogo.Location = New System.Drawing.Point(28, 2)
        Me.PictureBoxLogo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PictureBoxLogo.Name = "PictureBoxLogo"
        Me.PictureBoxLogo.Size = New System.Drawing.Size(149, 126)
        Me.PictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxLogo.TabIndex = 0
        Me.PictureBoxLogo.TabStop = False
        '
        'FormMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1328, 703)
        Me.Controls.Add(Me.PanelDekstop)
        Me.Controls.Add(Me.PanelJudul)
        Me.Controls.Add(Me.PanelMenu)
        Me.MainMenuStrip = Me.MenuStrip2
        Me.Name = "FormMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form Menu"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PanelLogo.ResumeLayout(False)
        Me.PanelLogo.PerformLayout()
        Me.PanelJudul.ResumeLayout(False)
        Me.PanelJudul.PerformLayout()
        Me.PanelMenu.ResumeLayout(False)
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.PictureBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelDekstop As Panel
    Friend WithEvents ButtonLogin As Button
    Friend WithEvents PictureBoxLogo As PictureBox
    Friend WithEvents PanelLogo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents PanelJudul As Panel
    Friend WithEvents LabelHeader As Label
    Friend WithEvents PanelMenu As Panel
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents RequestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TaskToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MASTERUSERToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MASTERDIVISIToolStripMenuItem As ToolStripMenuItem
End Class
