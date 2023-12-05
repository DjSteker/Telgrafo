Public Class Form_Morse

    Structure MorseTrama
        Public text As String
        Public Volumen As Integer
        Public Velocity As Double
        Public VelocityShort As Double
        Public VelocityLong As Double
        Public VelocityEntreSigno As Double
        Public VelocityEntreLetra As Double
    End Structure

    Dim datosMT As MorseTrama


    Dim ctThread As Threading.Thread
    Event Event_Mensage(ByVal EventNumber As String)

    Delegate Sub DelegateMensaje(ByVal MSG As String)
    Private Sub msg(ByVal Mensaje As String)
        If Me.RichTextBox1.InvokeRequired Then
            Dim d As New DelegateMensaje(AddressOf msg)
            Call RichTextBox1.Invoke(d, New Object() {Mensaje})
        Else

            'RichTextBox1.Lines.Last
            'RichTextBox1.SelectedText = RichTextBox1.Lines.Last
            If RichTextBox1.TextLength > 250000 Then
                RichTextBox1.Text = String.Empty
            End If
            RichTextBox1.Text &= Environment.NewLine & Mensaje
            'RichTextBox1.Select(RichTextBox1.TextLength - 2, RichTextBox1.TextLength - 1)
            RichTextBox1.Select(RichTextBox1.TextLength - 1, RichTextBox1.TextLength)

            RichTextBox1.ScrollToCaret()
            'RichTextBox1.Height = 212

        End If
    End Sub


    Delegate Sub DelegateSelect(ByVal MSG As Integer)
    Private Sub TextBoxSelecChat(ByVal CaracterNum As Integer)
        If Me.RichTextBox1.InvokeRequired Then
            Dim d As New DelegateSelect(AddressOf TextBoxSelecChat)
            Call TextBox1.Invoke(d, New Object() {CaracterNum})
        Else
            If (Not String.IsNullOrEmpty(TextBox1.Text)) Then
                TextBox1.SelectionStart = CaracterNum
                If CaracterNum <= TextBox1.Text.Length Then
                    TextBox1.SelectionLength = 1
                End If
            End If

        End If
    End Sub


    Private Sub Form_Morse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Encabezado del archivo WAV 
        'El encabezado de un archivo WAV (RIFF) tiene una longitud de 44 bytes y tiene el siguiente formato
        'Posiciones  Valor de muestra	Descripción
        '1 - 4	“RIFF”	Marca el archivo como archivo riff. Los caracteres tienen 1 byte de longitud cada uno.
        '5 - 8	Tamaño del archivo (entero)	Tamaño del archivo total: 8 bytes, en bytes (entero de 32 bits). Por lo general, completará esto después de la creación.
        '9 -12	“WAVE”	Encabezado de tipo de archivo. Para nuestros propósitos, siempre es igual a “ONDA”.
        '13-16	“fmt "	Marcador de fragmento de formato. Incluye cero final
        '17-20	16	Longitud de los datos de formato como se indica arriba
        '21-22	1	Tipo de formato (1 es PCM) - entero de 2 bytes
        '23-24	2	Número de canales: entero de 2 bytes
        '25-28	44100	Frecuencia de muestreo: entero de 32 bytes. Los valores comunes son 44100 (CD), 48000 (DAT). Frecuencia de muestreo = Número de muestras por segundo, o Hertz.
        '29-32	176400	(Frecuencia de muestreo * Bits por muestra * Canales) / 8.
        '33-34	4	(BitsPerSample * Canales) / 8.1 - mono de 8 bits2 - estéreo de 8 bits/mono de 16 bits4 - estéreo de 16 bits
        '35-36	16	Bits por muestra
        '37-40	“datos”	encabezado de fragmento de “datos”. Marca el comienzo de la sección de datos.
        '41-44	Tamaño del archivo (datos)	Tamaño de la sección de datos.
        'Los valores de muestra se dan arriba para una fuente estéreo de 16 bits.		
    End Sub

    Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer

    Dim ARCHIVO As String
    Private Sub Button_Grabar_Click(sender As Object, e As EventArgs) Handles Button_Grabar.Click
        If Button_Grabar.Text = "GRABAR" Then
            Dim BITS As Integer = 16
            Dim CANALES As Integer = 2
            Dim MUESTRAS As Integer = 44100
            Dim PROMEDIO As Integer = BITS * CANALES * MUESTRAS / 8
            Dim ALINEACION As Integer = BITS * CANALES / 8
            Dim COMANDO As String
            Try
                COMANDO = "set capture bitspersample " & BITS & " channels " & CANALES & " alignment " & ALINEACION & " samplespersec " &
                          MUESTRAS & " bytespersec " & PROMEDIO & " format tag pcm wait"
                mciSendString("close capture", "", 0, 0)
                mciSendString("open new type waveaudio alias capture", "", 0, 0)
                mciSendString(COMANDO, "", 0, 0)
                mciSendString("record capture", "", 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Button_Grabar.Text = "PARAR"
        Else
            Try
                mciSendString("stop capture", "", 0, 0)
                SaveFileDialog1.DefaultExt = "wav"
                If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                    ARCHIVO = SaveFileDialog1.FileName
                    mciSendString("save capture " & ARCHIVO, "", 0, 0)
                    mciSendString("close capture", "", 0, 0)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Button_Grabar.Text = "GRABAR"
        End If
    End Sub

    Private Declare Function mciSendString2 Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer


    Private Sub Button_Reproducir_Click(sender As Object, e As EventArgs) Handles Button_Reproducir.Click
        Try

            mciSendString2("close myWAV", Nothing, 0, 0)
            'Dim fileName1 As String = mciSendString2("open " & fileName1 & " type mpegvideo alias myWAV", Nothing, 0, 0)
            Dim fileName1 As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Correct.wav")

            mciSendString2(String.Format("open ""{0}"" type mpegvideo alias myWAV", fileName1), Nothing, 0, 0)
            mciSendString2("play myWAV", Nothing, 0, 0)

            Dim SFXVolume As Int16 = 500
            'min Volume is 1, max Volume is 1000
            Dim Volume As Integer = (SFXVolume * 100)
            mciSendString2("setaudio myWAV volume to " & Volume, Nothing, 0, 0)





        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_Grabar2_Click(sender As Object, e As EventArgs) Handles Button_Grabar2.Click
        Try
            My.Computer.Audio.Play(My.Application.Info.DirectoryPath & "\record.wav", AudioPlayMode.Background)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_SonidoPlay_Click(sender As Object, e As EventArgs) Handles Button_SonidoPlay.Click
        Try
            Dim Parametros As String()
            Class_GeneradorMIDI.Main(Parametros)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button_Beep.Click
     
    End Sub

    Friend Sub ReadTextToMorse() '(ByVal datosMT As MorseTrama)

     
    End Sub


    Private Sub Button_BeepCube_Click(sender As Object, e As EventArgs) Handles Button_BeepCube.Click

        Dim datosMorseTrama As New MorseTrama
        Try
            Dim inputText As String = TextBox1.Text.ToUpper()

            If Button_Beep.Text <> "Stop" Then
                ctThread = New Threading.Thread(AddressOf ReadTextToMorse)
                AddHandler Event_Mensage, AddressOf msg
                Button_Beep.Text = "Stop"
                datosMorseTrama.text = inputText
                datosMorseTrama.Velocity = (TrackBar_Velocidad.Value / 500)
                datosMorseTrama.VelocityShort = (TrackBar_TiempoCortas.Value / 500)
                datosMorseTrama.VelocityLong = (TrackBar_TiempoLargas.Value / 500)
                datosMorseTrama.VelocityEntreSigno = (TrackBar_EspacioSigno.Value / 500)
                datosMorseTrama.VelocityEntreLetra = (TrackBar_LetrasEspacio.Value / 500)

                datosMT = datosMorseTrama

                ctThread.Start()
                                    
                Threading.Thread.Sleep(300)
            Else
                Button_Beep.Text = "-"
                ctThread.Abort()

                Button_Beep.Text = "Beep sen"

            End If

            'GetDNS()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub EnviarMorse()


    End Sub

    Private Sub TrackBar_Largas_Scroll(sender As Object, e As EventArgs) Handles TrackBar_TiempoLargas.Scroll
        Try
                                
            datosMT.VelocityLong = (TrackBar_TiempoLargas.Value / 500)
            Label_TiempoLargas.Text = (TrackBar_TiempoLargas.Value / 500)
                                
        Catch ex As Exception
            msg(ex.Message)
        End Try
    End Sub

    Private Sub TrackBar_EspacioSigno_Scroll(sender As Object, e As EventArgs) Handles TrackBar_EspacioSigno.Scroll
        Try
                                
            datosMT.VelocityEntreSigno = (TrackBar_EspacioSigno.Value / 500)
            Label_EspacioSigno.Text = (TrackBar_EspacioSigno.Value / 500)
                                
        Catch ex As Exception
            msg(ex.Message)
        End Try
    End Sub

    Private Sub TrackBar_LetrasEspacio_Scroll(sender As Object, e As EventArgs) Handles TrackBar_LetrasEspacio.Scroll
        Try
                                
            datosMT.VelocityEntreLetra = (TrackBar_LetrasEspacio.Value / 500)
            Label_LetrasEspacio.Text = (TrackBar_LetrasEspacio.Value / 500)
                                
        Catch ex As Exception
            msg(ex.Message)
        End Try
    End Sub

    Private Sub TrackBar_TiempoCortas_Scroll(sender As Object, e As EventArgs) Handles TrackBar_TiempoCortas.Scroll
        Try
                                
            datosMT.VelocityShort = (TrackBar_TiempoCortas.Value / 500)
            Label_TiempoCortas.Text = (TrackBar_TiempoCortas.Value / 500)
                                
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TrackBar_Volumen_Scroll(sender As Object, e As EventArgs) Handles TrackBar_Volumen.Scroll
        Try
                                
            datosMT.Volumen = (TrackBar_Volumen.Value)
            Label_Volumen.Text = (TrackBar_Volumen.Value)

        Catch ex As Exception

        End Try
    End Sub
#End Region

    Private Sub Button_Morse_Click(sender As Object, e As EventArgs) Handles Button_Morse.Click

        Dim datosMorseTrama As New MorseTrama
        Try
            Dim inputText As String = TextBox1.Text.ToUpper()

            If Button_Morse.Text <> "Stop" Then
                ctThread = New Threading.Thread(AddressOf EnviarMorseRirmico)
                AddHandler Event_Mensage, AddressOf msg
                Button_Morse.Text = "Stop"
                datosMorseTrama.text = inputText
                datosMorseTrama.Volumen = (TrackBar_Volumen.Value)
                datosMorseTrama.Velocity = (TrackBar_Velocidad.Value / 500)
                datosMorseTrama.VelocityShort = (TrackBar_TiempoCortas.Value / 500)
                datosMorseTrama.VelocityLong = (TrackBar_TiempoLargas.Value / 500)
                datosMorseTrama.VelocityEntreSigno = (TrackBar_EspacioSigno.Value / 500)
                datosMorseTrama.VelocityEntreLetra = (TrackBar_LetrasEspacio.Value / 500)

                datosMT = datosMorseTrama

                ctThread.Start()

                Threading.Thread.Sleep(300)
                                    
            Else
                Button_Morse.Text = "-"
                ctThread.Abort()
                Button_Morse.Text = "Morse"

            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub EnviarMorseRirmico()


        Try

            mciSendString2("close myWAV", Nothing, 0, 0)
            'Dim fileName1 As String = mciSendString2("open " & fileName1 & " type mpegvideo alias myWAV", Nothing, 0, 0)
            Dim fileName1 As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Correct.wav")

            mciSendString2(String.Format("open ""{0}"" type mpegvideo alias myWAV", fileName1), Nothing, 0, 0)
            mciSendString2("play myWAV", Nothing, 0, 0)

            Dim SFXVolume As Int16 = 500
            'min Volume is 1, max Volume is 1000
            Dim Volume As Integer = (SFXVolume * 100)
            mciSendString2("setaudio myWAV volume to " & Volume, Nothing, 0, 0)




            Dim morseCodes1 As New Dictionary(Of Char, String) From {
             {" "c, " "}, {"A"c, ".-"}, {"B"c, "-..."}, {"C"c, "-.-."}, {"D"c, "-.."}, {"E"c, "."}, {"F"c, "..-."}, {"G"c, "--."}, {"H"c, "...."}, {"I"c, ".."},
            {"J"c, ".---"}, {"K"c, "-.-"}, {"L"c, ".-.."}, {"M"c, "--"}, {"N"c, "-."}, {"Ñ"c, "--.--"}, {"O"c, "---"}, {"P"c, ".--."}, {"Q"c, "--.-"},
            {"R"c, ".-."}, {"S"c, "..."}, {"T"c, "-"}, {"U"c, "..-"}, {"V"c, "...-"}, {"W"c, ".--"}, {"X"c, "-..-"}, {"Y"c, "-.--"}, {"Z"c, "--.."},
            {"0"c, "-----"}, {"1"c, "·----"}, {"2"c, "··---"}, {"3"c, "···--"}, {"4"c, "····-"}, {"5"c, "·····"}, {"6"c, "-····"}, {"7"c, "--···"}, {"8"c, "---··"}, {"9"c, "----·"},
            {"."c, "·—·—·—"}, {","c, "——··——"}, {"?"c, "··——··"}, {""""c, "·—··—·"}, {"/"c, "—··—·"}, {"+"c, ".-.-."}, {"("c, "-.--.-"}, {")"c, "-.--.-"},
            {"="c, "-...-"}, {";"c, "-.-.-."}, {":"c, "---..."}, {"-"c, "-....-"}, {"_"c, "--..."},
            {"Á"c, ".- .----."}, {"É"c, ". .----."}, {"Í"c, ".. .----."}, {"Ó"c, "--- .----."}, {"Ú"c, "..- .----."}, {"´"c, ".----."},
            {"Ä"c, ".-.-"}, {"Ö"c, "---."}, {"Ü"c, "..--"}}
            ' {"Buenos días"c, "--.--"} 'Buenos días"
            ' {"Buenos tardes"c, "--..-"} 'Buenos tardes
            ' {"Buenos noches"c, "--.."} 'Buenos noches
            '{"Fin QSO"c, "...-.-"} '
            '{"Recivido"c, "-.-"} ' Recivido o cambio
            '{"ERROR"c, "......"} '
            '{"()"c, "-.--.-"} '
            '{"="c, "-...-"} '
            '{"-"c, "-....-"} '
            '{":"c, "---..."} '
            '{"_"c, "--..."} '
            '{";"c, "-.-.-."} '
            '{"´"c, ".----."} ' Acento
            '{""c, ""} '
            Dim Indice As Integer = 0
            ' Recorre cada letra en el texto y emite una señal de audio Morse correspondiente.
            For Each c As Char In datosMT.text
                TextBoxSelecChat(Indice)
                Indice += 1


                'Dim TiempoPulsacion As Integer = datosMT.Velocity * 500
                'Dim TiempoPitidoCorto As Integer = CInt(100 * datosMT.VelocityShort * datosMT.Velocity)
                'Dim TiempoPitidoLargo As Integer = CInt(400 * datosMT.VelocityLong * datosMT.Velocity)
                'Dim TiempoEntreletras As Integer = CInt((TiempoPulsacion * datosMT.VelocityEntreLetra))
                'Dim TeompoEntreSignos As Integer = CInt(100 * datosMT.Velocity * datosMT.VelocityEntreSigno)
                'Dim TiempoFarnsworthCorto As Integer = (TiempoPulsacion - TiempoPitidoCorto) / 50
                'Dim TiempoFarnsworthLargo As Integer = (TiempoPulsacion - TiempoPitidoLargo) / 50

                'Dim TeompoEntreSignos As Integer = CInt(10 * datosMT.Velocity * datosMT.VelocityEntreSigno)

                Dim TiempoPulsacion As Integer = datosMT.Velocity * 500

                Dim TiempoPitidoCorto As Integer = CInt(100 * datosMT.VelocityShort * datosMT.Velocity)
                Dim TiempoPitidoLargo As Integer = CInt(400 * datosMT.VelocityLong * datosMT.Velocity)

                'Dim TiempoEntreletras As Integer = CInt((TiempoPulsacion * datosMT.VelocityEntreLetra))
                Dim TiempoEntreletras As Integer = CInt(400 * (datosMT.Velocity * datosMT.VelocityEntreLetra))
                Dim TeompoEntreSignos As Integer = CInt(100 * datosMT.Velocity * datosMT.VelocityEntreSigno)

                Dim TiempoFarnsworthCorto As Integer = (TiempoPulsacion - TiempoPitidoCorto) / 50
                Dim TiempoFarnsworthLargo As Integer = (TiempoPulsacion - TiempoPitidoLargo) / 50



                                
                If TiempoPulsacion <= 0 Then
                    TiempoPulsacion = 0
                End If
                If TiempoPitidoCorto <= 0 Then
                    TiempoPitidoCorto = 0
                End If
                If TiempoPitidoLargo <= 0 Then
                    TiempoPitidoLargo = 0
                End If
                If TiempoEntreletras <= 0 Then
                    TiempoEntreletras = 0
                End If
                If TeompoEntreSignos <= 0 Then
                    TeompoEntreSignos = 0
                End If
                If TiempoFarnsworthCorto <= 0 Then
                    TiempoFarnsworthCorto = 0
                End If
                If TiempoFarnsworthLargo <= 0 Then
                    TiempoFarnsworthLargo = 0
                End If





                If morseCodes1.ContainsKey(c) Then
                    Dim morseCode1 As String = morseCodes1(c)
                    For Each symbol As Char In morseCode1
                        If symbol = "."c Then ' ................

                            Class_BeepBeep.BeepBeep(datosMT.Volumen, 936, TiempoPitidoCorto, "") ' Emitir un pitido corto.
                            Threading.Thread.Sleep(TiempoFarnsworthCorto)

                        ElseIf symbol = "·"c Then ' ................

                            Class_BeepBeep.BeepBeep(datosMT.Volumen, 936, TiempoPitidoCorto, "") ' Emitir un pitido corto.
                            Threading.Thread.Sleep(TiempoFarnsworthCorto)

                        ElseIf symbol = "-"c Then ' ---------------

                            Class_BeepBeep.BeepBeep(datosMT.Volumen, 936, TiempoPitidoLargo, "") ' Emitir un pitido largo.
                            Threading.Thread.Sleep(TiempoFarnsworthLargo)
                                        
                        ElseIf symbol = "—" Then ' ---------------

                            Class_BeepBeep.BeepBeep(datosMT.Volumen, 936, TiempoPitidoLargo, "") ' Emitir un pitido largo.
                            Threading.Thread.Sleep(TiempoFarnsworthLargo)
                                        
                        ElseIf symbol = " " Then
                                        
                            Threading.Thread.Sleep(TiempoEntreletras) ' Pausa entre letras.

                        End If

                        ' Pausa entre símbolos.
                        Threading.Thread.Sleep(TeompoEntreSignos)

                    Next
                                
                    ' Pausa entre letras.
                    Threading.Thread.Sleep(CInt(TiempoEntreletras))
                                
                End If
            Next
        Catch ex As Exception
            msg(ex.Message)
        End Try
    End Sub


End Class
