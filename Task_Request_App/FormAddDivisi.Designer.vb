<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAddDivisi
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
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxNamaDivisi = New System.Windows.Forms.TextBox()
        Me.LabelId = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Yellow
        Me.Button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button2.Location = New System.Drawing.Point(344, 149)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(117, 45)
        Me.Button2.TabIndex = 30
        Me.Button2.Text = "CANCEL"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Blue
        Me.Button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.Location = New System.Drawing.Point(478, 149)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(117, 45)
        Me.Button1.TabIndex = 31
        Me.Button1.Text = "SIMPAN"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(30, 86)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(116, 24)
        Me.Label19.TabIndex = 19
        Me.Label19.Text = "NAMA DIVISI"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(28, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 35)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "ADD DIVISI"
        '
        'TextBoxNamaDivisi
        '
        Me.TextBoxNamaDivisi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxNamaDivisi.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxNamaDivisi.Location = New System.Drawing.Point(180, 86)
        Me.TextBoxNamaDivisi.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBoxNamaDivisi.Name = "TextBoxNamaDivisi"
        Me.TextBoxNamaDivisi.Size = New System.Drawing.Size(415, 30)
        Me.TextBoxNamaDivisi.TabIndex = 29
        '
        'LabelId
        '
        Me.LabelId.AutoSize = True
        Me.LabelId.Location = New System.Drawing.Point(31, 177)
        Me.LabelId.Name = "LabelId"
        Me.LabelId.Size = New System.Drawing.Size(19, 17)
        Me.LabelId.TabIndex = 32
        Me.LabelId.Text = "id"
        Me.LabelId.Visible = False
        '
        'FormAddDivisi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PeachPuff
        Me.ClientSize = New System.Drawing.Size(645, 218)
        Me.Controls.Add(Me.LabelId)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxNamaDivisi)
        Me.Name = "FormAddDivisi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormAddDivisi"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxNamaDivisi As TextBox
    Friend WithEvents LabelId As Label
End Class
