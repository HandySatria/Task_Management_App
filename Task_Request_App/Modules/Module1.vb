Imports MySql.Data.MySqlClient
Imports System.Threading
Imports Telegram.Bot
Imports Telegram.Bot.Exceptions
Imports Telegram.Bot.Types
Imports Telegram.Bot.Types.Enums
Imports Telegram.Bot.Types.ReplyMarkups
Module Module1
    Public Conn As MySqlConnection
    Public Da As MySqlDataAdapter
    Public Rd As MySqlDataReader
    Public Cmd As MySqlCommand
    Public Ds As DataSet
    Public MyDB As String
    Public HasilEnkripsi As String
    Public activeUserData As UserData = Nothing
    Public log As String
    Public botClient As TelegramBotClient
    Public cts As CancellationTokenSource

    Public Sub Koneksi()
        Try
            MyDB = "Host=LocalHost;Server=127.0.0.1;User=root;password=;database=task_request;allow user variables=true;Convert Zero Datetime=True"
            Conn = New MySqlConnection(MyDB)
            If Conn.State = ConnectionState.Open Then Conn.Close()
            If Conn.State = ConnectionState.Closed Then Conn.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function GenerteRequestNo()
        Try
            Dim last_number As Integer
            Dim result As String
            Call Koneksi()
            Cmd = New MySqlCommand("select count(request_id) as last_number from request where month(now()) = month(dtm_crt) and year(now()) = year(dtm_crt)", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            last_number = Rd.Item("last_number") + 1
            If last_number < 10 Then
                result = "REQ00" & last_number
            ElseIf last_number < 100 Then
                result = "REQ0" & last_number
            Else
                result = "REQ" & last_number
            End If

            If Month(Date.Now()) < 10 Then
                result = result & "/0" & Month(Date.Now())
            Else
                result = result & "/" & Month(Date.Now())
            End If
            result = result & "/" & Year(Date.Now)
            Return result

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Function

    Sub Enkripsi(input As String)
        Dim xc As New DES
        Dim katakunci As String
        katakunci = ""
        xc.Key = katakunci
        HasilEnkripsi = xc.Encrypt(input)
    End Sub

    Public Class DES
        Private _key As String = Nothing
        Public Property Key() As String
            Get
                Return _key
            End Get
            Set(value As String)
                _key = Me.formatKey(value)
            End Set
        End Property

        Private Function formatKey(key As String) As String
            If key Is Nothing OrElse key.Length = 0 Then
                Return Nothing
            End If
            Return key.Trim()
        End Function

        Private DefaultKey As String = ""

        Public Sub New()
            DefaultKey = "enkripsi"
        End Sub

        Private _coreSymmetric As New CoreAlgoritmaSymmetric

        Public Function InitCore() As Boolean
            _coreSymmetric = New CoreAlgoritmaSymmetric()
            Return True
        End Function

        Public Function Decrypt(src As String) As String
            Dim hasil As String = ""

            If _key Is Nothing Then
                hasil = _coreSymmetric.ProsesDecrypt(src, DefaultKey)
            Else
                hasil = _coreSymmetric.ProsesDecrypt(src, _key)
            End If

            Return hasil
        End Function

        Public Function Decrypt(src As String, key As String) As String
            Dim hasil As String = ""

            hasil = _coreSymmetric.ProsesDecrypt(src, key)

            Return hasil
        End Function

        Public Function Encrypt(src As String) As String
            Dim hasil As String = ""

            If _key Is Nothing Then
                hasil = _coreSymmetric.ProsesEncrypt(src, DefaultKey)
            Else
                hasil = _coreSymmetric.ProsesEncrypt(src, _key)
            End If

            Return hasil
        End Function

        Public Function Encrypt(src As String, key As String) As String
            Dim hasil As String = ""

            hasil = _coreSymmetric.ProsesEncrypt(src, key)

            Return hasil
        End Function

        Public Class CoreAlgoritmaSymmetric
            Private metodeEncode As System.Security.Cryptography.SymmetricAlgorithm

            Public Sub New()
                metodeEncode = New System.Security.Cryptography.DESCryptoServiceProvider()
            End Sub

            Private Function GetValidKey(Key As String) As Byte()
                Dim sTemp As String
                If metodeEncode.LegalKeySizes.Length > 0 Then
                    Dim lessSize As Integer = 0, moreSize As Integer = metodeEncode.LegalKeySizes(0).MinSize

                    While Key.Length * 8 > moreSize AndAlso metodeEncode.LegalKeySizes(0).SkipSize > 0 AndAlso moreSize < metodeEncode.LegalKeySizes(0).MaxSize
                        lessSize = moreSize
                        moreSize += metodeEncode.LegalKeySizes(0).SkipSize
                    End While

                    If Key.Length * 8 > moreSize Then
                        sTemp = Key.Substring(0, (moreSize / 8))
                    Else
                        sTemp = Key.PadRight(moreSize / 8, " "c)
                    End If
                Else
                    sTemp = Key
                End If

                'Konversi kata kunci menjadi byte array
                Return System.Text.ASCIIEncoding.ASCII.GetBytes(sTemp)
            End Function

            Private Function GetValidIV(InitVector As [String], panjangValid As Integer) As Byte()
                If InitVector.Length > panjangValid Then
                    Return System.Text.ASCIIEncoding.ASCII.GetBytes(InitVector.Substring(0, panjangValid))
                Else
                    Return System.Text.ASCIIEncoding.ASCII.GetBytes(InitVector.PadRight(panjangValid, " "c))
                End If
            End Function

            Public Function ProsesEncrypt(Source As String, Key As String) As String
                If Source Is Nothing OrElse Key Is Nothing OrElse Source.Length = 0 OrElse Key.Length = 0 Then
                    Return Nothing
                End If

                If metodeEncode Is Nothing Then
                    Return Nothing
                End If

                Dim lPanjangStream As Long
                Dim jumlahBufferTerbaca As Integer
                Dim byteBuffer As Byte() = New Byte(2) {}
                Dim srcData As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(Source)
                Dim encData As Byte()
                Dim streamInput As New System.IO.MemoryStream()
                streamInput.Write(srcData, 0, srcData.Length)
                streamInput.Position = 0
                Dim streamOutput As New System.IO.MemoryStream()
                Dim streamEncrypt As System.Security.Cryptography.CryptoStream

                metodeEncode.Key = GetValidKey(Key)
                metodeEncode.IV = GetValidIV(Key, metodeEncode.IV.Length)

                streamEncrypt = New System.Security.Cryptography.CryptoStream(streamOutput, metodeEncode.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write)
                lPanjangStream = streamInput.Length

                Dim totalBufferTerbaca As Integer = 0
                While totalBufferTerbaca < lPanjangStream
                    jumlahBufferTerbaca = streamInput.Read(byteBuffer, 0, byteBuffer.Length)
                    streamEncrypt.Write(byteBuffer, 0, jumlahBufferTerbaca)
                    totalBufferTerbaca += jumlahBufferTerbaca
                End While
                streamEncrypt.Close()

                encData = streamOutput.ToArray()

                'Konversi menjadi base64 agar hasil dapat digunakan dalam xml
                Return Convert.ToBase64String(encData)
            End Function



            Public Function ProsesDecrypt(Source As String, Key As String) As String
                If Source Is Nothing OrElse Key Is Nothing OrElse Source.Length = 0 OrElse Key.Length = 0 Then
                    Return Nothing
                End If

                If metodeEncode Is Nothing Then
                    Return Nothing
                End If

                Dim lPanjangStream As Long
                Dim jumlahBufferTerbaca As Integer
                Dim byteBuffer As Byte() = New Byte(2) {}
                Dim encData As Byte() = Convert.FromBase64String(Source)
                Dim decData As Byte()
                Dim streamInput As New System.IO.MemoryStream(encData)
                Dim streamOutput As New System.IO.MemoryStream()
                Dim streamDecrypt As System.Security.Cryptography.CryptoStream

                metodeEncode.Key = GetValidKey(Key)
                metodeEncode.IV = GetValidIV(Key, metodeEncode.IV.Length)

                streamDecrypt = New System.Security.Cryptography.CryptoStream(streamInput, metodeEncode.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Read)
                lPanjangStream = streamInput.Length

                Dim totalBufferTerbaca As Integer = 0
                While totalBufferTerbaca < lPanjangStream
                    jumlahBufferTerbaca = streamDecrypt.Read(byteBuffer, 0, byteBuffer.Length)
                    If 0 = jumlahBufferTerbaca Then
                        Exit While
                    End If

                    streamOutput.Write(byteBuffer, 0, jumlahBufferTerbaca)
                    totalBufferTerbaca += jumlahBufferTerbaca
                End While
                streamDecrypt.Close()

                decData = streamOutput.ToArray()
                For i As Integer = 0 To decData.Length - 1
                    If decData(i) < 8 Then decData(i) = 0
                Next

                Dim encodeASCII As New System.Text.ASCIIEncoding()
                Return encodeASCII.GetString(decData)
            End Function
        End Class
    End Class


    Private Const StepInitial As Integer = 0
    Private Const StepChooseMenu As Integer = 1
    Private Const StepChooseDivisi As Integer = 2
    Private Const StepEnterSubject As Integer = 3
    Private Const StepEnterDeskripsi As Integer = 4
    Private Const StepSubmitConfirmation As Integer = 5

    Private currentStep As Integer = StepInitial
    Private requestDivisi As String = ""
    Private requestSubject As String = ""
    Private requestDeskripsi As String = ""

    Public Async Function HandleUpdateAsync(botClient As ITelegramBotClient, update As Update, cancellationToken As CancellationToken) As Task
        Try
            If update.Type = UpdateType.CallbackQuery Then
                Dim callbackQuery = update.CallbackQuery
                Dim data = callbackQuery.Data
                Dim chatId = callbackQuery.Message.Chat.Id

                ' Hapus pesan yang mengandung inline keyboard setelah tombol ditekan
                Await botClient.DeleteMessageAsync(chatId, callbackQuery.Message.MessageId, cancellationToken)

                Select Case data
                    Case "getRequest"
                        Dim dataResult_getRequestTele As String = ""
                        Dim Cari_Data_getRequestTele As String = ""

                        Call Koneksi()
                        Cari_Data_getRequestTele = "select r.request_id as request_id, r.request_no as request_no, r.subject as subject, r.description as description, dTo.divisi_name as to_divisi,dTo.divisi_id as to_divisi_id, dFrom.divisi_name as from_divisi, 
                                rp.prioritas_name as prioritas_name, rp.ref_prioritas_id as ref_prioritas_id, rs.status_name as status_name, rs.ref_status_id as ref_status_id, mc.id as cabang_id, mc.nama as cabang_name,
                                r.user_crt as user_crt, r.user_upd as user_upd, r.dtm_crt as dtm_crt, r.dtm_upd as dtm_upd 
                        from request r 
                            left join divisi dTo on dTo.divisi_id = r.to_divisi 
                            left join divisi dFrom on dFrom.divisi_id = r.from_divisi 
                            left join ref_status rs on rs.ref_status_id = r.status
                            left join ref_prioritas rp on rp.ref_prioritas_id = r.prioritas
                            left join user u on u.user_id = r.user_id
                            left join mcabang mc on mc.id = u.id_cabang
                        where dFrom.divisi_id = (SELECT divisi_id FROM user WHERE chat_id_telegram = @chat_id_telegram limit 1 )
                        order by dtm_crt desc limit 12"
                        Cmd = New MySqlCommand(Cari_Data_getRequestTele, Conn)
                        Cmd.Parameters.AddWithValue("@chat_id_telegram", chatId)


                        Rd = Cmd.ExecuteReader
                        Rd.Read()
                        If Rd.HasRows Then
                            Do While Rd.Read
                                dataResult_getRequestTele = dataResult_getRequestTele & Environment.NewLine & "Ke Divisi : " & Rd.Item("to_divisi")
                                dataResult_getRequestTele = dataResult_getRequestTele & Environment.NewLine & "Nomor Request : " & Rd.Item("request_no")
                                dataResult_getRequestTele = dataResult_getRequestTele & Environment.NewLine & "Subjek : " & Rd.Item("subject")
                                dataResult_getRequestTele = dataResult_getRequestTele & Environment.NewLine & "Deskripsi : " & Rd.Item("description")
                                dataResult_getRequestTele = dataResult_getRequestTele & Environment.NewLine & "Status : " & Rd.Item("status_name")
                                dataResult_getRequestTele = dataResult_getRequestTele & Environment.NewLine & "Prioritas : " & Rd.Item("prioritas_name")
                                dataResult_getRequestTele = dataResult_getRequestTele & Environment.NewLine & "Tanggal : " & Rd.Item("dtm_crt")
                                dataResult_getRequestTele = dataResult_getRequestTele & Environment.NewLine & "--------------------------------------------------------" & Environment.NewLine

                            Loop
                        End If
                        ' Mengirim hasil query ke chat
                        Await botClient.SendTextMessageAsync(
                        chatId:=chatId,
                        text:="List Request :" & Environment.NewLine & dataResult_getRequestTele,
                        cancellationToken:=cancellationToken)

                        log = log & Environment.NewLine & "- getRequest"

                    Case "getTask"
                        Await botClient.SendDocumentAsync(chatId:=chatId, document:=InputFile.FromUri("https://static.promediateknologi.id/crop/0x0:0x0/750x500/webp/photo/2023/04/10/InShot_20230410_090633955_1-989862021.jpg"), cancellationToken:=cancellationToken)
                        log = log & Environment.NewLine & "- Send Image"
                    Case "updateStatusRequest"
                        Await botClient.SendVideoAsync(chatId:=chatId, video:=InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/video-bulb.mp4"), cancellationToken:=cancellationToken)
                        log = log & Environment.NewLine & "- Send Video"
                    Case "updateStatusTask"

                        Dim dataResult As String = ""
                        Call Koneksi()

                        Cmd = New MySqlCommand("Select Nama_Pekerjaan from list_pekerjaan", Conn)
                        Rd = Cmd.ExecuteReader
                        Rd.Read()
                        If Rd.HasRows Then
                            Do While Rd.Read
                                dataResult = dataResult & Environment.NewLine & Rd.Item("Nama_Pekerjaan")
                            Loop
                        End If
                        ' Mengirim hasil query ke chat
                        Await botClient.SendTextMessageAsync(
                        chatId:=chatId,
                        text:="Hasil dari query ke database:" & Environment.NewLine & dataResult,
                        cancellationToken:=cancellationToken
                    )
                        log = log & Environment.NewLine & "- Send Database Result"

                    Case "InputRequest"
                        Dim inlineKeyboard As InlineKeyboardMarkup = New InlineKeyboardMarkup(
                        {
                            New InlineKeyboardButton() {
                                InlineKeyboardButton.WithCallbackData("Pilih Divisi", "ChooseDivisi")
                            }
                        }
                    )
                        Await botClient.SendTextMessageAsync(chatId:=chatId, text:="Silakan isi informasi untuk request:", replyMarkup:=inlineKeyboard, cancellationToken:=cancellationToken)
                        currentStep = StepChooseMenu

                    Case "ChooseDivisi"
                        Dim inlineKeyboard As InlineKeyboardMarkup = New InlineKeyboardMarkup(
                        {
                            New InlineKeyboardButton() {
                                InlineKeyboardButton.WithCallbackData("Divisi 1", "PilihDivisi1"),
                                InlineKeyboardButton.WithCallbackData("Divisi 2", "PilihDivisi2")
                            }
                        }
                    )
                        Await botClient.SendTextMessageAsync(chatId:=chatId, text:="Pilih divisi untuk request:", replyMarkup:=inlineKeyboard, cancellationToken:=cancellationToken)
                        currentStep = StepChooseDivisi

                    Case "PilihDivisi1", "PilihDivisi2"
                        requestDivisi = data
                        currentStep = StepEnterSubject
                        Await botClient.SendTextMessageAsync(chatId:=chatId, text:="Masukkan subject untuk request:", cancellationToken:=cancellationToken)

                    Case "SubmitRequest"
                        ' Lakukan proses penyimpanan request ke database
                        ' Misalnya, panggil fungsi untuk menyimpan data
                        Await SimpanRequestKeDatabase(botClient, chatId, cancellationToken)
                        ' Reset langkah dan data request setelah disimpan
                        currentStep = StepInitial
                        requestDivisi = ""
                        requestSubject = ""
                        requestDeskripsi = ""
                        ' Kirim pesan konfirmasi ke pengguna
                        Await botClient.SendTextMessageAsync(chatId:=chatId, text:="Request telah disimpan.", cancellationToken:=cancellationToken)
                        log = log & Environment.NewLine & "- Submit Request"

                    Case "CancelRequest"
                        ' Reset langkah dan data request
                        currentStep = StepInitial
                        requestDivisi = ""
                        requestSubject = ""
                        requestDeskripsi = ""
                        ' Kirim pesan konfirmasi ke pengguna
                        Await botClient.SendTextMessageAsync(chatId:=chatId, text:="Input request dibatalkan.", cancellationToken:=cancellationToken)
                        log = log & Environment.NewLine & "- Cancel Request"
                End Select

            Else
                Dim message = update.Message
                Dim messageText = message.Text
                Dim chatId = message.Chat.Id

                If currentStep = StepEnterSubject Then
                    requestSubject = messageText
                    currentStep = StepEnterDeskripsi
                    Await botClient.SendTextMessageAsync(chatId:=chatId, text:="Masukkan deskripsi untuk request:", cancellationToken:=cancellationToken)

                ElseIf currentStep = StepEnterDeskripsi Then
                    requestDeskripsi = messageText
                    currentStep = StepSubmitConfirmation
                    Dim inlineKeyboard As InlineKeyboardMarkup = New InlineKeyboardMarkup(
                    {
                        New InlineKeyboardButton() {
                            InlineKeyboardButton.WithCallbackData("Submit", "SubmitRequest"),
                            InlineKeyboardButton.WithCallbackData("Cancel", "CancelRequest")
                        }
                    }
                )
                    Await botClient.SendTextMessageAsync(chatId:=chatId, text:="Review request:" & Environment.NewLine &
                                                                            $"Divisi: {requestDivisi}" & Environment.NewLine &
                                                                            $"Subject: {requestSubject}" & Environment.NewLine &
                                                                            $"Deskripsi: {requestDeskripsi}" & Environment.NewLine &
                                                                            "Apakah Anda ingin menyimpan request ini?",
                                                                            replyMarkup:=inlineKeyboard,
                                                                            cancellationToken:=cancellationToken)
                Else
                    Dim inlineKeyboard = New InlineKeyboardMarkup(
                    {
                        New InlineKeyboardButton() {
                            InlineKeyboardButton.WithCallbackData("LIST REQUEST", "getRequest")
                        },
                        New InlineKeyboardButton() {
                            InlineKeyboardButton.WithCallbackData("LIST TASK", "getTask")
                        },
                        New InlineKeyboardButton() {
                            InlineKeyboardButton.WithCallbackData("INPUT REQUEST", "inputRequest")
                        },
                        New InlineKeyboardButton() {
                            InlineKeyboardButton.WithCallbackData("UPDATE STATUS REQUEST", "updateStatusRequest")
                        },
                         New InlineKeyboardButton() {
                            InlineKeyboardButton.WithCallbackData("UPDATE STATUS TASK", "updateStatusTask")
                        }
                    }
                )
                    Call Koneksi()
                    Cmd = New MySqlCommand("SELECT u.user_id as user_id, u.fullname as fullname, u.username as username, u.password as password, d.divisi_name as divisi_name, d.divisi_id as divisi_id, u.is_admin as is_admin, mc.id as id_cabang, mc.nama as nama_cabang FROM user u left join divisi d on u.divisi_id = d.divisi_id left join mcabang mc on u.id_cabang = mc.id where u.chat_id_telegram = @chat_id_telegram", Conn)
                    Cmd.Parameters.AddWithValue("@chat_id_telegram", chatId)

                    Rd = Cmd.ExecuteReader
                    Rd.Read()
                    If Not Rd.HasRows Then
                        Await botClient.SendTextMessageAsync(chatId:=chatId, text:="Mohon maaf anda belum terdaftar sebagai user", cancellationToken:=cancellationToken)
                    Else
                        Await botClient.SendTextMessageAsync(chatId:=chatId, text:="Halo " & Rd.Item("fullname") & " Dari Divisi " & Rd.Item("divisi_name") & " Cabang " & Rd.Item("nama_cabang") & Environment.NewLine & "Pilih Fungsi Yang Ingin Anda Jalankan :", replyMarkup:=inlineKeyboard, cancellationToken:=cancellationToken)
                    End If
                End If

            End If

            'TextBox2.Invoke(Sub() UpdateTextBox(log))

        Catch ex As Exception
            MsgBox(ex.Message)
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            MessageBox.Show("Line: " & st.GetFrame(0).GetFileLineNumber().ToString, "Error")
        End Try
    End Function

    Private Async Function SimpanRequestKeDatabase(botClient As ITelegramBotClient, chatId As Long, cancellationToken As CancellationToken) As Task
        ' Lakukan proses penyimpanan request ke database di sini
        '' Anda dapat menggunakan query INSERT yang sesuai dengan struktur database Anda
        'Try
        '    Call Koneksi()
        '    Cmd = New MySqlCommand("INSERT INTO request(request_no, subject, from_divisi, to_divisi, description, status, prioritas, user_id, user_crt, user_upd, dtm_crt, dtm_upd) values(@request_no, @subject,  @from_divisi, @to_divisi, @description, @status, @prioritas, @user_id, @user_crt, @user_upd, @dtm_crt, @dtm_upd) ", Conn)
        '    Cmd.Parameters.Add("@request_no", MySqlDbType.VarChar).Value = reqNo ' Misalnya Anda punya variable reqNo
        '    Cmd.Parameters.Add("@subject", MySqlDbType.VarChar).Value = requestSubject
        '    Cmd.Parameters.Add("@from_divisi", MySqlDbType.VarChar).Value = activeUserData.getDivisionId
        '    Cmd.Parameters.Add("@to_divisi", MySqlDbType.VarChar).Value = requestDivisi
        '    ' Jika Anda punya ComboBoxPrioritas atau similar
        '    ' Cmd.Parameters.Add("@prioritas", MySqlDbType.VarChar).Value = ComboBoxPrioritas.SelectedValue
        '    Cmd.Parameters.Add("@description", MySqlDbType.VarChar).Value = requestDeskripsi
        '    ' Sisanya sesuaikan dengan kebutuhan
        '    ' ...

        '    ' Eksekusi query
        '    Await Cmd.ExecuteNonQueryAsync(cancellationToken)

        'Catch ex As Exception
        '    ' Tangani kesalahan jika ada
        '    Console.WriteLine(ex.ToString())
        'Finally
        '    ' Tutup koneksi jika sudah selesai
        '    Conn.Close()
        'End Try
    End Function


    Public Function HandlePollingErrorAsync(botClient As ITelegramBotClient, exception As Exception, cancellationToken As CancellationToken) As Task
        Dim ErrorMessage As String = If(TypeOf exception Is ApiRequestException,
                                        $"Telegram API Error:{vbCrLf}[{DirectCast(exception, ApiRequestException).ErrorCode}]{vbCrLf}{DirectCast(exception, ApiRequestException).Message}",
                                        exception.ToString())

        Console.WriteLine(ErrorMessage)
        Return Task.CompletedTask
    End Function
    Public Async Function Start_BotAsync() As Task
        Dim token As String = "6539074641:AAH6ZzbIuzTgL5oNzyOfApTdIYukDaN1SMs"
        botClient = New TelegramBotClient(token)
        cts = New CancellationTokenSource()

        Dim m = Await botClient.GetMeAsync()
        Console.WriteLine($"Hello, World! I am user {m.Id} and my name is {m.FirstName}.")
        'TextBox1.Text = $"Hello, World! I am user {m.Id} and my name is {m.FirstName}"

        botClient.StartReceiving(
            updateHandler:=AddressOf HandleUpdateAsync,
            pollingErrorHandler:=AddressOf HandlePollingErrorAsync,
            cancellationToken:=cts.Token
        )

        Dim mm = Await botClient.GetMeAsync()
        Console.WriteLine($"Start listening for @{mm.Username}")
        Console.ReadLine()
        'Button1.Text = "Stop Bot"
        log = "- Bot Start"
    End Function

    Public Async Function KirimPesanKeOrangLainAsync(botClient As ITelegramBotClient, chatId As Long, pesan As String, cancellationToken As CancellationToken) As Task
        Try
            ' Mengirim pesan ke ID chat yang ditentukan
            Await botClient.SendTextMessageAsync(chatId:=chatId, text:=pesan, cancellationToken:=cancellationToken)
        Catch ex As Exception
            ' Tangani kesalahan jika ada
            Console.WriteLine(ex.ToString())
        End Try
    End Function



End Module
