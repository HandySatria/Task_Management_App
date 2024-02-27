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
    Public Nama_User, Divisi_Name, Divisi_Id_User, HasilEnkripsi As String
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

    'Private Async Function KirimPesanKeOrangLainAsync(botClient As ITelegramBotClient, chatId As Long, pesan As String, cancellationToken As CancellationToken) As Task
    '    Try
    '        ' Mengirim pesan ke ID chat yang ditentukan
    '        Await botClient.SendTextMessageAsync(chatId:=chatId, text:=pesan, cancellationToken:=cancellationToken)
    '    Catch ex As Exception
    '        ' Tangani kesalahan jika ada
    '        Console.WriteLine(ex.ToString())
    '    End Try
    'End Function
    Public Async Function HandleUpdateAsync(botClient As ITelegramBotClient, update As Update, cancellationToken As CancellationToken) As Task
        Try
            If update.Type = UpdateType.CallbackQuery Then
                Dim callbackQuery = update.CallbackQuery
                Dim data = callbackQuery.Data
                Dim chatId = callbackQuery.Message.Chat.Id

                ' Hapus pesan yang mengandung inline keyboard setelah tombol ditekan
                Await botClient.DeleteMessageAsync(chatId, callbackQuery.Message.MessageId, cancellationToken)

                Select Case data
                    Case "Sticker"
                        Await botClient.SendStickerAsync(chatId:=chatId, sticker:=InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/sticker-dali.webp"), cancellationToken:=cancellationToken)
                        log = log & Environment.NewLine & "- Send Sticker"
                    Case "Gambar"
                        Await botClient.SendDocumentAsync(chatId:=chatId, document:=InputFile.FromUri("https://static.promediateknologi.id/crop/0x0:0x0/750x500/webp/photo/2023/04/10/InShot_20230410_090633955_1-989862021.jpg"), cancellationToken:=cancellationToken)
                        log = log & Environment.NewLine & "- Send Image"
                    Case "Vidio"
                        Await botClient.SendVideoAsync(chatId:=chatId, video:=InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/video-bulb.mp4"), cancellationToken:=cancellationToken)
                        log = log & Environment.NewLine & "- Send Video"
                    Case "GetData"
                        ' Memanggil fungsi untuk mengambil data dari database
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
                    Case "ReplyKeyboard"
                        Dim replyKeyboard = New ReplyKeyboardMarkup(New List(Of List(Of KeyboardButton))() From
                       {
                           New List(Of KeyboardButton)() From
                           {
                               New KeyboardButton("Sticker"),
                               New KeyboardButton("Vidio")
                           },
                           New List(Of KeyboardButton)() From
                           {
                               New KeyboardButton("Gambar")
                           }
                       })

                        Await botClient.SendTextMessageAsync(
                            chatId:=chatId,
                            text:="Pilih fungsi yang ingin Anda jalankan :",
                            replyMarkup:=replyKeyboard,
                            cancellationToken:=cancellationToken
                        )
                        log = log & Environment.NewLine & "- Send ReplyKeyboard"
                End Select

            Else
                Dim message = update.Message
                Dim messageText = message.Text
                Dim chatId = message.Chat.Id

                Select Case messageText
                    Case "Sticker"
                        Await botClient.SendStickerAsync(chatId:=chatId, sticker:=InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/sticker-dali.webp"), cancellationToken:=cancellationToken)
                        log = log & Environment.NewLine & "- Send Sticker"
                    Case "Vidio"
                        Await botClient.SendVideoAsync(chatId:=chatId, video:=InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/video-bulb.mp4"), cancellationToken:=cancellationToken)
                        log = log & Environment.NewLine & "- Send Video"
                    Case "Gambar"
                        Await botClient.SendDocumentAsync(chatId:=chatId, document:=InputFile.FromUri("https://static.promediateknologi.id/crop/0x0:0x0/750x500/webp/photo/2023/04/10/InShot_20230410_090633955_1-989862021.jpg"), cancellationToken:=cancellationToken)
                        log = log & Environment.NewLine & "- Send Image"
                    Case Else

                        Dim inlineKeyboard = New InlineKeyboardMarkup(
                            {
                                New InlineKeyboardButton() {
                                    InlineKeyboardButton.WithCallbackData("Klik untuk Sticker", "Sticker"),
                                    InlineKeyboardButton.WithCallbackData("Klik untuk Gambar", "Gambar"),
                                    InlineKeyboardButton.WithCallbackData("Klik untuk Vidio", "Vidio")
                                },
                                New InlineKeyboardButton() {
                                    InlineKeyboardButton.WithCallbackData("Klik untuk ReplyKeyboard", "ReplyKeyboard")
                                },
                                New InlineKeyboardButton() {
                                    InlineKeyboardButton.WithCallbackData("Klik untuk Get Data", "GetData")
                                }
                            }
                        )


                        Await botClient.SendTextMessageAsync(
                            chatId:=chatId,
                            text:="Pilih fungsi yang ingin Anda jalankan:",
                            replyMarkup:=inlineKeyboard,
                            cancellationToken:=cancellationToken
                        )
                End Select
                'Dim replyKeyboard = New ReplyKeyboardMarkup(New List(Of List(Of KeyboardButton))() From
                '        {
                '            New List(Of KeyboardButton)() From
                '            {
                '                New KeyboardButton("Sticker"),
                '                New KeyboardButton("Vidio")
                '            },
                '            New List(Of KeyboardButton)() From
                '            {
                '                New KeyboardButton("Gambar")
                '            }
                '        })

                'Await botClient.SendTextMessageAsync(
                '    chatId:=chatId,
                '    text:="Pilih Fungsi Dibawah Keyboard :",
                '    replyMarkup:=replyKeyboard,
                '    cancellationToken:=cancellationToken
                ')
            End If

            'TextBox2.Invoke(Sub() UpdateTextBox(log))

        Catch ex As Exception
            MsgBox(ex.Message)
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            MessageBox.Show("Line: " & st.GetFrame(0).GetFileLineNumber().ToString, "Error")
        End Try
    End Function

    Public Function HandlePollingErrorAsync(botClient As ITelegramBotClient, exception As Exception, cancellationToken As CancellationToken) As Task
        Dim ErrorMessage As String = If(TypeOf exception Is ApiRequestException,
                                        $"Telegram API Error:{vbCrLf}[{DirectCast(exception, ApiRequestException).ErrorCode}]{vbCrLf}{DirectCast(exception, ApiRequestException).Message}",
                                        exception.ToString())

        Console.WriteLine(ErrorMessage)
        Return Task.CompletedTask
    End Function
    Public Async Function Start_BotAsync() As Task
        Dim token As String = "6872091136:AAEW2qt4w9vcKFwxCzDzX5-_ecBBKcIc0p0"
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
