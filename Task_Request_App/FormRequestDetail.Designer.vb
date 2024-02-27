<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRequestDetail
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
        Me.components = New System.ComponentModel.Container()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.StepProgressBar1 = New DevExpress.XtraEditors.StepProgressBar()
        Me.StepProgressBarItem1 = New DevExpress.XtraEditors.StepProgressBarItem()
        Me.StepProgressBarItem2 = New DevExpress.XtraEditors.StepProgressBarItem()
        Me.StepProgressBarItem3 = New DevExpress.XtraEditors.StepProgressBarItem()
        Me.StepProgressBarItem4 = New DevExpress.XtraEditors.StepProgressBarItem()
        CType(Me.StepProgressBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'StepProgressBar1
        '
        Me.StepProgressBar1.Items.Add(Me.StepProgressBarItem1)
        Me.StepProgressBar1.Items.Add(Me.StepProgressBarItem2)
        Me.StepProgressBar1.Items.Add(Me.StepProgressBarItem3)
        Me.StepProgressBar1.Items.Add(Me.StepProgressBarItem4)
        Me.StepProgressBar1.Location = New System.Drawing.Point(346, 117)
        Me.StepProgressBar1.Name = "StepProgressBar1"
        Me.StepProgressBar1.Size = New System.Drawing.Size(362, 122)
        Me.StepProgressBar1.TabIndex = 0
        '
        'StepProgressBarItem1
        '
        Me.StepProgressBarItem1.ContentBlock2.Caption = "Item1"
        Me.StepProgressBarItem1.Name = "StepProgressBarItem1"
        '
        'StepProgressBarItem2
        '
        Me.StepProgressBarItem2.ContentBlock2.Caption = "Item2"
        Me.StepProgressBarItem2.Name = "StepProgressBarItem2"
        '
        'StepProgressBarItem3
        '
        Me.StepProgressBarItem3.ContentBlock2.Caption = "Item3"
        Me.StepProgressBarItem3.Name = "StepProgressBarItem3"
        '
        'StepProgressBarItem4
        '
        Me.StepProgressBarItem4.ContentBlock2.Caption = "Item4"
        Me.StepProgressBarItem4.Name = "StepProgressBarItem4"
        '
        'FormRequestDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1240, 648)
        Me.Controls.Add(Me.StepProgressBar1)
        Me.Name = "FormRequestDetail"
        Me.Text = "FormRequestDetail"
        CType(Me.StepProgressBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents StepProgressBar1 As DevExpress.XtraEditors.StepProgressBar
    Friend WithEvents StepProgressBarItem1 As DevExpress.XtraEditors.StepProgressBarItem
    Friend WithEvents StepProgressBarItem2 As DevExpress.XtraEditors.StepProgressBarItem
    Friend WithEvents StepProgressBarItem3 As DevExpress.XtraEditors.StepProgressBarItem
    Friend WithEvents StepProgressBarItem4 As DevExpress.XtraEditors.StepProgressBarItem
End Class
