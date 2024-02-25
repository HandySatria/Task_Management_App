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
        Me.ComboBoxStatus = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxNama = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextBoxNIK = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ComboBoxStatus
        '
        Me.ComboBoxStatus.FormattingEnabled = True
        Me.ComboBoxStatus.Items.AddRange(New Object() {"PKWT", "PEGAWAI TETAP"})
        Me.ComboBoxStatus.Location = New System.Drawing.Point(195, 74)
        Me.ComboBoxStatus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboBoxStatus.Name = "ComboBoxStatus"
        Me.ComboBoxStatus.Size = New System.Drawing.Size(160, 24)
        Me.ComboBoxStatus.TabIndex = 1
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
        'TextBoxNama
        '
        Me.TextBoxNama.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxNama.Location = New System.Drawing.Point(195, 141)
        Me.TextBoxNama.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBoxNama.Multiline = True
        Me.TextBoxNama.Name = "TextBoxNama"
        Me.TextBoxNama.Size = New System.Drawing.Size(415, 204)
        Me.TextBoxNama.TabIndex = 3
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
        'TextBoxNIK
        '
        Me.TextBoxNIK.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxNIK.Location = New System.Drawing.Point(195, 108)
        Me.TextBoxNIK.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBoxNIK.Name = "TextBoxNIK"
        Me.TextBoxNIK.Size = New System.Drawing.Size(415, 22)
        Me.TextBoxNIK.TabIndex = 2
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
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Blue
        Me.Button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.Location = New System.Drawing.Point(493, 365)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(117, 45)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "SIMPAN"
        Me.Button1.UseVisualStyleBackColor = False
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
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Yellow
        Me.Button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button2.Location = New System.Drawing.Point(359, 365)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(117, 45)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "CANCEL"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'FormAddRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PeachPuff
        Me.ClientSize = New System.Drawing.Size(667, 446)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ComboBoxStatus)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxNama)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBoxNIK)
        Me.Controls.Add(Me.Label4)
        Me.Name = "FormAddRequest"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form Add Request"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBoxStatus As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBoxNama As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TextBoxNIK As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
End Class
