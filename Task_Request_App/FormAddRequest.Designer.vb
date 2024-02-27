<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAddRequest
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
        Me.ComboBoxDivisi = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxDeskripsi = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextBoxSubject = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ButtonSimpan = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.LabelId = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBoxPrioritas = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'ComboBoxDivisi
        '
        Me.ComboBoxDivisi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDivisi.FormattingEnabled = True
        Me.ComboBoxDivisi.Location = New System.Drawing.Point(195, 74)
        Me.ComboBoxDivisi.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboBoxDivisi.Name = "ComboBoxDivisi"
        Me.ComboBoxDivisi.Size = New System.Drawing.Size(160, 24)
        Me.ComboBoxDivisi.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(43, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 21)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "KE DIVISI"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(45, 105)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(60, 21)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "SUBJEK"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(167, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 21)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(167, 141)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 21)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = ":"
        '
        'TextBoxDeskripsi
        '
        Me.TextBoxDeskripsi.Location = New System.Drawing.Point(195, 141)
        Me.TextBoxDeskripsi.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBoxDeskripsi.Multiline = True
        Me.TextBoxDeskripsi.Name = "TextBoxDeskripsi"
        Me.TextBoxDeskripsi.Size = New System.Drawing.Size(415, 204)
        Me.TextBoxDeskripsi.TabIndex = 3
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(45, 138)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 21)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "DESKRIPSI"
        '
        'TextBoxSubject
        '
        Me.TextBoxSubject.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxSubject.Location = New System.Drawing.Point(195, 108)
        Me.TextBoxSubject.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBoxSubject.Name = "TextBoxSubject"
        Me.TextBoxSubject.Size = New System.Drawing.Size(415, 22)
        Me.TextBoxSubject.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(166, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 21)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = ":"
        '
        'ButtonSimpan
        '
        Me.ButtonSimpan.BackColor = System.Drawing.Color.Blue
        Me.ButtonSimpan.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ButtonSimpan.Location = New System.Drawing.Point(493, 406)
        Me.ButtonSimpan.Name = "ButtonSimpan"
        Me.ButtonSimpan.Size = New System.Drawing.Size(117, 45)
        Me.ButtonSimpan.TabIndex = 4
        Me.ButtonSimpan.Text = "SIMPAN"
        Me.ButtonSimpan.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(43, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(178, 35)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ADD REQUEST"
        '
        'ButtonCancel
        '
        Me.ButtonCancel.BackColor = System.Drawing.Color.Yellow
        Me.ButtonCancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ButtonCancel.Location = New System.Drawing.Point(359, 406)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(117, 45)
        Me.ButtonCancel.TabIndex = 4
        Me.ButtonCancel.Text = "CANCEL"
        Me.ButtonCancel.UseVisualStyleBackColor = False
        '
        'LabelId
        '
        Me.LabelId.AutoSize = True
        Me.LabelId.Location = New System.Drawing.Point(12, 420)
        Me.LabelId.Name = "LabelId"
        Me.LabelId.Size = New System.Drawing.Size(19, 17)
        Me.LabelId.TabIndex = 34
        Me.LabelId.Text = "id"
        Me.LabelId.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(166, 359)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 21)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = ":"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(43, 359)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 21)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "PRIORITAS"
        '
        'ComboBoxPrioritas
        '
        Me.ComboBoxPrioritas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxPrioritas.FormattingEnabled = True
        Me.ComboBoxPrioritas.Location = New System.Drawing.Point(195, 359)
        Me.ComboBoxPrioritas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboBoxPrioritas.Name = "ComboBoxPrioritas"
        Me.ComboBoxPrioritas.Size = New System.Drawing.Size(160, 24)
        Me.ComboBoxPrioritas.TabIndex = 1
        '
        'FormAddRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PeachPuff
        Me.ClientSize = New System.Drawing.Size(667, 474)
        Me.Controls.Add(Me.LabelId)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonSimpan)
        Me.Controls.Add(Me.ComboBoxPrioritas)
        Me.Controls.Add(Me.ComboBoxDivisi)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxDeskripsi)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBoxSubject)
        Me.Controls.Add(Me.Label4)
        Me.Name = "FormAddRequest"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form Add Request"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBoxDivisi As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBoxDeskripsi As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TextBoxSubject As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ButtonSimpan As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents LabelId As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboBoxPrioritas As ComboBox
End Class
