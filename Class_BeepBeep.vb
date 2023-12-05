Option Strict On
Imports System.IO
Imports System.Media

Public Class Class_BeepBeep
    Public Shared Function IsValidPath(ByVal path As String) As Boolean
        Try
            Dim f As New System.IO.FileInfo(path)
            Return True
        Catch e As Exception
            Return False
        End Try
    End Function
    'Calling convention : Amplitude (0-1000), Frequency in Hz, Duration in Millisec, Filename if save desired.

    ''' <summary>
    ''' Calling convention
    ''' </summary>
    ''' <param name="Amplitude">Amplitude (0-1000)</param>
    ''' <param name="Frequency">Frequency in Hz</param>
    ''' <param name="Duration">Duration in Millisec</param>
    ''' <param name="StrFilename">Filename if save desired</param>
    Public Shared Sub BeepBeep(ByVal Amplitude As Integer, ByVal Frequency As Integer,
                               ByVal Duration As Integer, Optional ByVal StrFilename As String = "")
        Dim A As Double = ((Amplitude * (System.Math.Pow(2, 15))) / 1000) - 1
        Dim DeltaFT As Double = 2 * Math.PI * Frequency / 44100.0
        Dim Samples As Integer = 441 * Duration \ 10
        Dim Bytes As Integer = Samples * 4
        Dim Hdr() As Integer = {&H46464952, 36 + Bytes, &H45564157, &H20746D66, 16, &H20001, 44100, 176400, &H100004, &H61746164, Bytes}
        Dim MakeFile As Boolean = Class_BeepBeep.IsValidPath(StrFilename)
        Dim FW As BinaryWriter
        Using MS As New MemoryStream(44 + Bytes)
            Using BW As New BinaryWriter(MS)
                If MakeFile = True Then FW = New BinaryWriter(File.Open(StrFilename, FileMode.Create))
                For I As Integer = 0 To Hdr.Length - 1
                    BW.Write(Hdr(I))
                    If MakeFile = True Then FW.Write(Hdr(I))
                Next I
                For T As Integer = 0 To Samples - 1
                    Dim Sample As Short = System.Convert.ToInt16(A * Math.Sin(DeltaFT * T))
                    BW.Write(Sample)
                    BW.Write(Sample)
                    If MakeFile = True Then
                        FW.Write(Sample)
                        FW.Write(Sample)
                    End If
                Next T
                BW.Flush()
                If MakeFile = True Then
                    FW.Flush()
                    FW.Close()
                End If
                MS.Seek(0, SeekOrigin.Begin)
                Using SP As New SoundPlayer(MS)
                    SP.PlaySync()
                End Using
            End Using
        End Using
    End Sub

    Public Shared Sub BeepCube(ByVal Amplitude As Integer, ByVal Frequency As Integer,
                             ByVal Duration As Integer, Optional ByVal StrFilename As String = "")
        Dim A As Double = ((Amplitude * (System.Math.Pow(2, 15))) / 1000) - 1
        Dim DeltaFT As Double = 2 * Math.PI * Frequency / 44100.0
        Dim Samples As Integer = 441 * Duration \ 10
        Dim Bytes As Integer = Samples * 4
        Dim Hdr() As Integer = {&H46464952, 36 + Bytes, &H45564157, &H20746D66, 16, &H20001, 44100, 176400, &H100004, &H61746164, Bytes}
        Dim MakeFile As Boolean = Class_BeepBeep.IsValidPath(StrFilename)
        Dim Cuadro As Double = (1 / Frequency) * (3 * Math.PI) / (4 * (Amplitude / 10))
        Dim FW As BinaryWriter
        Using MS As New MemoryStream(44 + Bytes)
            Using BW As New BinaryWriter(MS)
                If MakeFile = True Then FW = New BinaryWriter(File.Open(StrFilename, FileMode.Create))
                For I As Integer = 0 To Hdr.Length - 1
                    BW.Write(Hdr(I))
                    If MakeFile = True Then FW.Write(Hdr(I))
                Next I
                For T As Integer = 0 To Samples - 1
                    Dim prueba As Double = A * (Math.Sin(DeltaFT * T))
                    Dim Sample As Short = System.Convert.ToInt16(A * (Cuadro * (DeltaFT * T)))
                    BW.Write(prueba)
                    BW.Write(prueba)
                    If MakeFile = True Then
                        FW.Write(prueba)
                        FW.Write(prueba)
                    End If
                Next T
                BW.Flush()
                If MakeFile = True Then
                    FW.Flush()
                    FW.Close()
                End If
                MS.Seek(0, SeekOrigin.Begin)
                Using SP As New SoundPlayer(MS)
                    SP.PlaySync()
                End Using
            End Using
        End Using
    End Sub
End Class