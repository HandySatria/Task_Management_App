Imports System.Windows.Forms
Imports DevExpress.XtraWaitForm

Public Class ProgressPanelUtil
    Private Shared _progressPanel As New ProgressPanel()

    Public Shared Sub ShowProgressPanel(ByVal parentForm As Form)
        _progressPanel = New ProgressPanel()
        Dim panelWidth As Integer = _progressPanel.Width
        Dim panelHeight As Integer = _progressPanel.Height

        Dim parentWidth As Integer = parentForm.ClientSize.Width
        Dim parentHeight As Integer = parentForm.ClientSize.Height

        Dim x As Integer = (parentWidth - panelWidth) \ 2
        Dim y As Integer = (parentHeight - panelHeight) \ 2

        _progressPanel.Location = New Point(x, y)
        parentForm.Controls.Add(_progressPanel)
        _progressPanel.BringToFront()
        _progressPanel.Show()
    End Sub

    Public Shared Sub HideProgressPanel()
        If _progressPanel IsNot Nothing Then
            _progressPanel.Hide()
        End If
    End Sub
End Class
