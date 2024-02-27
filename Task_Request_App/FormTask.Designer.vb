<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormTask
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
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DateEdit2 = New DevExpress.XtraEditors.DateEdit()
        Me.DateEdit1 = New DevExpress.XtraEditors.DateEdit()
        Me.ButtonExport = New System.Windows.Forms.Button()
        Me.ButtonReset = New System.Windows.Forms.Button()
        Me.ButtonSearch = New System.Windows.Forms.Button()
        Me.ComboBoxStatus = New System.Windows.Forms.ComboBox()
        Me.ComboBoxDivisi = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBoxSubject = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxTaskId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SetujuiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TidakSetujuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OnProgressToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DoneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LabelTotal = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DateEdit2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox1.Controls.Add(Me.DateEdit2)
        Me.GroupBox1.Controls.Add(Me.DateEdit1)
        Me.GroupBox1.Controls.Add(Me.ButtonExport)
        Me.GroupBox1.Controls.Add(Me.ButtonReset)
        Me.GroupBox1.Controls.Add(Me.ButtonSearch)
        Me.GroupBox1.Controls.Add(Me.ComboBoxStatus)
        Me.GroupBox1.Controls.Add(Me.ComboBoxDivisi)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TextBoxSubject)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TextBoxTaskId)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(49, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1362, 301)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "TASK"
        '
        'DateEdit2
        '
        Me.DateEdit2.EditValue = Nothing
        Me.DateEdit2.Location = New System.Drawing.Point(270, 176)
        Me.DateEdit2.Name = "DateEdit2"
        Me.DateEdit2.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateEdit2.Properties.Appearance.Options.UseFont = True
        Me.DateEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit2.Size = New System.Drawing.Size(340, 30)
        Me.DateEdit2.TabIndex = 4
        '
        'DateEdit1
        '
        Me.DateEdit1.EditValue = Nothing
        Me.DateEdit1.Location = New System.Drawing.Point(270, 128)
        Me.DateEdit1.Name = "DateEdit1"
        Me.DateEdit1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateEdit1.Properties.Appearance.Options.UseFont = True
        Me.DateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Size = New System.Drawing.Size(340, 30)
        Me.DateEdit1.TabIndex = 4
        '
        'ButtonExport
        '
        Me.ButtonExport.BackColor = System.Drawing.Color.LimeGreen
        Me.ButtonExport.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonExport.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ButtonExport.Location = New System.Drawing.Point(810, 234)
        Me.ButtonExport.Name = "ButtonExport"
        Me.ButtonExport.Size = New System.Drawing.Size(176, 43)
        Me.ButtonExport.TabIndex = 3
        Me.ButtonExport.Text = "EXPORT EXCEL"
        Me.ButtonExport.UseVisualStyleBackColor = False
        '
        'ButtonReset
        '
        Me.ButtonReset.BackColor = System.Drawing.Color.Yellow
        Me.ButtonReset.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonReset.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ButtonReset.Location = New System.Drawing.Point(1015, 234)
        Me.ButtonReset.Name = "ButtonReset"
        Me.ButtonReset.Size = New System.Drawing.Size(135, 43)
        Me.ButtonReset.TabIndex = 3
        Me.ButtonReset.Text = "RESET"
        Me.ButtonReset.UseVisualStyleBackColor = False
        '
        'ButtonSearch
        '
        Me.ButtonSearch.BackColor = System.Drawing.Color.DodgerBlue
        Me.ButtonSearch.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ButtonSearch.Location = New System.Drawing.Point(1180, 234)
        Me.ButtonSearch.Name = "ButtonSearch"
        Me.ButtonSearch.Size = New System.Drawing.Size(135, 43)
        Me.ButtonSearch.TabIndex = 3
        Me.ButtonSearch.Text = "SEARCH"
        Me.ButtonSearch.UseVisualStyleBackColor = False
        '
        'ComboBoxStatus
        '
        Me.ComboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxStatus.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxStatus.FormattingEnabled = True
        Me.ComboBoxStatus.Location = New System.Drawing.Point(951, 174)
        Me.ComboBoxStatus.Name = "ComboBoxStatus"
        Me.ComboBoxStatus.Size = New System.Drawing.Size(340, 32)
        Me.ComboBoxStatus.TabIndex = 1
        '
        'ComboBoxDivisi
        '
        Me.ComboBoxDivisi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDivisi.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxDivisi.FormattingEnabled = True
        Me.ComboBoxDivisi.Location = New System.Drawing.Point(951, 125)
        Me.ComboBoxDivisi.Name = "ComboBoxDivisi"
        Me.ComboBoxDivisi.Size = New System.Drawing.Size(340, 32)
        Me.ComboBoxDivisi.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(45, 179)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(166, 24)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Tanggal Task <="
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(726, 180)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(114, 24)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Status Task"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(45, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(166, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Tanggal Task >="
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(726, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 24)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Dari Divisi"
        '
        'TextBoxSubject
        '
        Me.TextBoxSubject.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxSubject.Location = New System.Drawing.Point(951, 80)
        Me.TextBoxSubject.Name = "TextBoxSubject"
        Me.TextBoxSubject.Size = New System.Drawing.Size(340, 32)
        Me.TextBoxSubject.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(726, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 24)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Subjek"
        '
        'TextBoxTaskId
        '
        Me.TextBoxTaskId.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxTaskId.Location = New System.Drawing.Point(270, 77)
        Me.TextBoxTaskId.Name = "TextBoxTaskId"
        Me.TextBoxTaskId.Size = New System.Drawing.Size(340, 32)
        Me.TextBoxTaskId.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(45, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Task Id"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.Lavender
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DataGridView1.Location = New System.Drawing.Point(50, 363)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1361, 477)
        Me.DataGridView1.TabIndex = 13
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SetujuiToolStripMenuItem, Me.TidakSetujuToolStripMenuItem, Me.OnProgressToolStripMenuItem, Me.DoneToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(160, 100)
        '
        'SetujuiToolStripMenuItem
        '
        Me.SetujuiToolStripMenuItem.BackColor = System.Drawing.Color.Yellow
        Me.SetujuiToolStripMenuItem.Name = "SetujuiToolStripMenuItem"
        Me.SetujuiToolStripMenuItem.Size = New System.Drawing.Size(159, 24)
        Me.SetujuiToolStripMenuItem.Text = "Setujui"
        '
        'TidakSetujuToolStripMenuItem
        '
        Me.TidakSetujuToolStripMenuItem.BackColor = System.Drawing.Color.LightCoral
        Me.TidakSetujuToolStripMenuItem.Name = "TidakSetujuToolStripMenuItem"
        Me.TidakSetujuToolStripMenuItem.Size = New System.Drawing.Size(159, 24)
        Me.TidakSetujuToolStripMenuItem.Text = "Tidak Setuju"
        '
        'OnProgressToolStripMenuItem
        '
        Me.OnProgressToolStripMenuItem.BackColor = System.Drawing.Color.Blue
        Me.OnProgressToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.OnProgressToolStripMenuItem.Name = "OnProgressToolStripMenuItem"
        Me.OnProgressToolStripMenuItem.Size = New System.Drawing.Size(159, 24)
        Me.OnProgressToolStripMenuItem.Text = "On Progress"
        '
        'DoneToolStripMenuItem
        '
        Me.DoneToolStripMenuItem.BackColor = System.Drawing.Color.LightGreen
        Me.DoneToolStripMenuItem.Name = "DoneToolStripMenuItem"
        Me.DoneToolStripMenuItem.Size = New System.Drawing.Size(159, 24)
        Me.DoneToolStripMenuItem.Text = "Done"
        '
        'LabelTotal
        '
        Me.LabelTotal.AutoSize = True
        Me.LabelTotal.Font = New System.Drawing.Font("Tahoma", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotal.Location = New System.Drawing.Point(52, 847)
        Me.LabelTotal.Name = "LabelTotal"
        Me.LabelTotal.Size = New System.Drawing.Size(0, 29)
        Me.LabelTotal.TabIndex = 12
        '
        'FormTask
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.GhostWhite
        Me.ClientSize = New System.Drawing.Size(1584, 866)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.LabelTotal)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormTask"
        Me.Text = "FormTask"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DateEdit2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DateEdit2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateEdit1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ButtonExport As Button
    Friend WithEvents ButtonReset As Button
    Friend WithEvents ButtonSearch As Button
    Friend WithEvents ComboBoxStatus As ComboBox
    Friend WithEvents ComboBoxDivisi As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBoxSubject As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBoxTaskId As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents LabelTotal As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents SetujuiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TidakSetujuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OnProgressToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DoneToolStripMenuItem As ToolStripMenuItem
End Class
