Imports MySql.Data.MySqlClient
Public Class FormRequestDetail
    Dim hist_request_id, request_id, ref_status_id, status_name, catatan, estimation_start_dt, estimation_end_dt, realisation_start_dt, realisation_end_dt, dtm_crt As String

    Private Sub FormRequestDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Dim baris As Integer


    Sub getHistoryRequest()
        Try
            PanelStep.Controls.Clear()
            PanelStep.Visible = True
            Call Koneksi()
            Cmd = New MySqlCommand("select hr.hist_request_id as hist_request_id, hr.request_id as request_id, hr.ref_status_id as ref_status_id, rs.status_name as status_name, hr.catatan as catatan, hr.estimation_start_dt as estimation_start_dt, hr.estimation_end_dt as estimation_end_dt, hr.realisation_start_dt as realisation_start_dt, hr.realisation_end_dt as realisation_end_dt, hr.dtm_crt as dtm_crt, hr.user_crt as user_crt  from hist_request hr left join ref_status rs on hr.ref_status_id = rs.ref_status_id where request_id = '" & LabelId.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Dim yPosition As Integer = 0 ' Y-coordinate position for each HistoryCard
            baris = 0
            Do While Rd.Read
                Dim historyCard As New HistoryCard
                With historyCard
                    .LabelStatus.Text = Rd.Item("status_name")
                    .LabelUser.Text = Rd.Item("user_crt")
                    .LabelTanggal.Text = Rd.Item("dtm_crt")
                    .LabelStatusId.Text = Rd.Item("ref_status_id")
                    .LabelEstimasiStart.Text = Rd.Item("estimation_start_dt")
                    .LabelEstimasiEnd.Text = Rd.Item("estimation_end_dt")
                    .LabelRealisasiStart.Text = Rd.Item("realisation_start_dt")
                    .LabelRealisasiEnd.Text = Rd.Item("realisation_end_dt")
                    .LabelCatatan.Text = Rd.Item("catatan")
                    .Anchor = AnchorStyles.Left
                    If (baris Mod 2) = 0 Then .BackColor = Color.LightYellow
                    .Location = New Point(0, yPosition)
                    AddHandler historyCard.Click, AddressOf historyCardClick
                    AddHandler historyCard.LabelStatus.Click, AddressOf historyCardClick
                    AddHandler historyCard.LabelUser.Click, AddressOf historyCardClick
                    AddHandler historyCard.LabelTanggal.Click, AddressOf historyCardClick
                    AddHandler historyCard.Label1.Click, AddressOf historyCardClick
                    AddHandler historyCard.Label2.Click, AddressOf historyCardClick
                    AddHandler historyCard.Label3.Click, AddressOf historyCardClick
                    AddHandler historyCard.Label4.Click, AddressOf historyCardClick
                    AddHandler historyCard.Label5.Click, AddressOf historyCardClick
                    AddHandler historyCard.Label6.Click, AddressOf historyCardClick
                    AddHandler historyCard.LabelStatusId.Click, AddressOf historyCardClick
                End With
                baris += 1
                PanelStep.Controls.Add(historyCard)
                yPosition += historyCard.Height ' Increment the Y-coordinate for the next card
            Loop
            If PanelStep.Controls.Count = 0 Then
                Dim historyCard As New HistoryCard
                With historyCard
                    .LabelStatus.Text = "Belum ada respon dari divisi terkait"
                    .Anchor = AnchorStyles.Left And AnchorStyles.Right
                End With
                PanelStep.Controls.Add(historyCard)
            End If
            GroupBox2.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub resetStatusInfo()
        LabelTgl1.Visible = False
        LabelTgl2.Visible = False
        LabelTglText1.Visible = False
        LabelTglText2.Visible = False
        LabelCatatan.Visible = False
        Label23.Visible = False
        Label18.Visible = False
        Label14.Visible = False
        TextBoxCatatan.Visible = False
    End Sub

    Sub showTgl1()
        LabelTgl1.Visible = True
        LabelTglText1.Visible = True
        Label23.Visible = True
    End Sub

    Sub showTgl2()
        LabelTgl2.Visible = True
        LabelTglText2.Visible = True
        Label18.Visible = True
    End Sub

    Sub showCatatan()
        LabelCatatan.Visible = True
        TextBoxCatatan.Visible = True
        Label14.Visible = True
    End Sub

    Sub historyCardClick(sender As Object, e As EventArgs)
        Dim senderType As HistoryCard = Nothing
        Dim alternateType As Label = Nothing
        Try
            senderType = CType(sender, HistoryCard)
        Catch ex As Exception
            alternateType = CType(sender, Label)
            senderType = alternateType.Parent
        End Try
        LabelStatusBawah.Text = senderType.LabelStatus.Text
        LabelTglUpdate.Text = senderType.LabelTanggal.Text
        LabelUserUpdate.Text = senderType.LabelUser.Text

        resetStatusInfo()
        GroupBox2.Visible = True
        If senderType.LabelStatusId.Text = 4 Then
            showCatatan()
            TextBoxCatatan.Text = senderType.LabelCatatan.Text
        End If

        If senderType.LabelStatusId.Text = 5 Then
            showTgl1()
            showTgl2()
            showCatatan()
            LabelTgl1.Text = "ESTIMASI TGL MULAI"
            LabelTgl2.Text = "ESTIMASI TGL SELESAI"
            LabelTglText1.Text = senderType.LabelEstimasiStart.Text
            LabelTglText2.Text = senderType.LabelEstimasiEnd.Text
            TextBoxCatatan.Text = senderType.LabelCatatan.Text
        End If

        If senderType.LabelStatusId.Text = 6 Then
            showTgl1()
            showCatatan()
            LabelTgl1.Text = "REALISASI TGL MULAI"
            LabelTglText1.Text = senderType.LabelRealisasiStart.Text
            TextBoxCatatan.Text = senderType.LabelCatatan.Text
        End If

        If senderType.LabelStatusId.Text = 7 Then
            showTgl1()
            showCatatan()
            LabelTgl1.Text = "REALISASI TGL SELESAI"
            LabelTglText1.Text = senderType.LabelRealisasiEnd.Text
            TextBoxCatatan.Text = senderType.LabelCatatan.Text
        End If

        If senderType.LabelStatusId.Text = 9 Then
            showCatatan()
            TextBoxCatatan.Text = senderType.LabelCatatan.Text
        End If

    End Sub


    Private Sub StepProgressBar1_Click(sender As Object, e As EventArgs)

    End Sub
End Class