<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Morse
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Morse))
        Me.Button_Grabar = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button_Reproducir = New System.Windows.Forms.Button()
        Me.Button_Grabar2 = New System.Windows.Forms.Button()
        Me.Button_SonidoPlay = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Button_Beep = New System.Windows.Forms.Button()
        Me.Button_BeepCube = New System.Windows.Forms.Button()
        Me.TrackBar_Velocidad = New System.Windows.Forms.TrackBar()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.TrackBar_TiempoLargas = New System.Windows.Forms.TrackBar()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TrackBar_LetrasEspacio = New System.Windows.Forms.TrackBar()
        Me.TrackBar_EspacioSigno = New System.Windows.Forms.TrackBar()
        Me.TrackBar_TiempoCortas = New System.Windows.Forms.TrackBar()
        Me.Label_Velocidad = New System.Windows.Forms.Label()
        Me.Label_TiempoCortas = New System.Windows.Forms.Label()
        Me.Label_TiempoLargas = New System.Windows.Forms.Label()
        Me.Label_EspacioSigno = New System.Windows.Forms.Label()
        Me.Label_LetrasEspacio = New System.Windows.Forms.Label()
        Me.Button_Morse = New System.Windows.Forms.Button()
        Me.Label_Volumen = New System.Windows.Forms.Label()
        Me.TrackBar_Volumen = New System.Windows.Forms.TrackBar()
        CType(Me.TrackBar_Velocidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar_TiempoLargas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar_LetrasEspacio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar_EspacioSigno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar_TiempoCortas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar_Volumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button_Grabar
        '
        Me.Button_Grabar.Location = New System.Drawing.Point(539, 13)
        Me.Button_Grabar.Name = "Button_Grabar"
        Me.Button_Grabar.Size = New System.Drawing.Size(123, 23)
        Me.Button_Grabar.TabIndex = 0
        Me.Button_Grabar.Text = "Grabar"
        Me.Button_Grabar.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.HideSelection = False
        Me.TextBox1.Location = New System.Drawing.Point(12, 13)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(521, 579)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = resources.GetString("TextBox1.Text")
        '
        'Button_Reproducir
        '
        Me.Button_Reproducir.Location = New System.Drawing.Point(539, 42)
        Me.Button_Reproducir.Name = "Button_Reproducir"
        Me.Button_Reproducir.Size = New System.Drawing.Size(123, 23)
        Me.Button_Reproducir.TabIndex = 2
        Me.Button_Reproducir.Text = "Reproducir"
        Me.Button_Reproducir.UseVisualStyleBackColor = True
        '
        'Button_Grabar2
        '
        Me.Button_Grabar2.Location = New System.Drawing.Point(539, 71)
        Me.Button_Grabar2.Name = "Button_Grabar2"
        Me.Button_Grabar2.Size = New System.Drawing.Size(123, 23)
        Me.Button_Grabar2.TabIndex = 3
        Me.Button_Grabar2.Text = "Grabar2"
        Me.Button_Grabar2.UseVisualStyleBackColor = True
        '
        'Button_SonidoPlay
        '
        Me.Button_SonidoPlay.Location = New System.Drawing.Point(539, 100)
        Me.Button_SonidoPlay.Name = "Button_SonidoPlay"
        Me.Button_SonidoPlay.Size = New System.Drawing.Size(123, 23)
        Me.Button_SonidoPlay.TabIndex = 4
        Me.Button_SonidoPlay.Text = "SonidoPlay"
        Me.Button_SonidoPlay.UseVisualStyleBackColor = True
        '
        'Button_Beep
        '
        Me.Button_Beep.Location = New System.Drawing.Point(539, 129)
        Me.Button_Beep.Name = "Button_Beep"
        Me.Button_Beep.Size = New System.Drawing.Size(249, 23)
        Me.Button_Beep.TabIndex = 5
        Me.Button_Beep.Text = "Beep sen"
        Me.Button_Beep.UseVisualStyleBackColor = True
        '
        'Button_BeepCube
        '
        Me.Button_BeepCube.Location = New System.Drawing.Point(539, 158)
        Me.Button_BeepCube.Name = "Button_BeepCube"
        Me.Button_BeepCube.Size = New System.Drawing.Size(249, 23)
        Me.Button_BeepCube.TabIndex = 6
        Me.Button_BeepCube.Text = "Beep acuare"
        Me.Button_BeepCube.UseVisualStyleBackColor = True
        '
        'TrackBar_Velocidad
        '
        Me.TrackBar_Velocidad.Location = New System.Drawing.Point(539, 336)
        Me.TrackBar_Velocidad.Maximum = 1000
        Me.TrackBar_Velocidad.Minimum = 1
        Me.TrackBar_Velocidad.Name = "TrackBar_Velocidad"
        Me.TrackBar_Velocidad.Size = New System.Drawing.Size(249, 45)
        Me.TrackBar_Velocidad.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.TrackBar_Velocidad, "Velocidad general")
        Me.TrackBar_Velocidad.Value = 200
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(541, 187)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(248, 143)
        Me.RichTextBox1.TabIndex = 8
        Me.RichTextBox1.Text = ""
        '
        'TrackBar_TiempoLargas
        '
        Me.TrackBar_TiempoLargas.Location = New System.Drawing.Point(539, 438)
        Me.TrackBar_TiempoLargas.Maximum = 1000
        Me.TrackBar_TiempoLargas.Minimum = 1
        Me.TrackBar_TiempoLargas.Name = "TrackBar_TiempoLargas"
        Me.TrackBar_TiempoLargas.Size = New System.Drawing.Size(249, 45)
        Me.TrackBar_TiempoLargas.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.TrackBar_TiempoLargas, "Tiempo lagas")
        Me.TrackBar_TiempoLargas.Value = 500
        '
        'TrackBar_LetrasEspacio
        '
        Me.TrackBar_LetrasEspacio.Location = New System.Drawing.Point(539, 540)
        Me.TrackBar_LetrasEspacio.Maximum = 1000
        Me.TrackBar_LetrasEspacio.Minimum = 1
        Me.TrackBar_LetrasEspacio.Name = "TrackBar_LetrasEspacio"
        Me.TrackBar_LetrasEspacio.Size = New System.Drawing.Size(249, 45)
        Me.TrackBar_LetrasEspacio.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.TrackBar_LetrasEspacio, "Tiempo Entre letras")
        Me.TrackBar_LetrasEspacio.Value = 500
        '
        'TrackBar_EspacioSigno
        '
        Me.TrackBar_EspacioSigno.Location = New System.Drawing.Point(539, 489)
        Me.TrackBar_EspacioSigno.Maximum = 1000
        Me.TrackBar_EspacioSigno.Minimum = 1
        Me.TrackBar_EspacioSigno.Name = "TrackBar_EspacioSigno"
        Me.TrackBar_EspacioSigno.Size = New System.Drawing.Size(249, 45)
        Me.TrackBar_EspacioSigno.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.TrackBar_EspacioSigno, "Tiempo Entre signo")
        Me.TrackBar_EspacioSigno.Value = 500
        '
        'TrackBar_TiempoCortas
        '
        Me.TrackBar_TiempoCortas.Location = New System.Drawing.Point(539, 387)
        Me.TrackBar_TiempoCortas.Maximum = 1000
        Me.TrackBar_TiempoCortas.Minimum = 1
        Me.TrackBar_TiempoCortas.Name = "TrackBar_TiempoCortas"
        Me.TrackBar_TiempoCortas.Size = New System.Drawing.Size(249, 45)
        Me.TrackBar_TiempoCortas.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.TrackBar_TiempoCortas, "Tiempo cortas")
        Me.TrackBar_TiempoCortas.Value = 500
        '
        'Label_Velocidad
        '
        Me.Label_Velocidad.AutoSize = True
        Me.Label_Velocidad.Location = New System.Drawing.Point(794, 336)
        Me.Label_Velocidad.Name = "Label_Velocidad"
        Me.Label_Velocidad.Size = New System.Drawing.Size(54, 13)
        Me.Label_Velocidad.TabIndex = 13
        Me.Label_Velocidad.Text = "Velocidad"
        '
        'Label_TiempoCortas
        '
        Me.Label_TiempoCortas.AutoSize = True
        Me.Label_TiempoCortas.Location = New System.Drawing.Point(794, 387)
        Me.Label_TiempoCortas.Name = "Label_TiempoCortas"
        Me.Label_TiempoCortas.Size = New System.Drawing.Size(37, 13)
        Me.Label_TiempoCortas.TabIndex = 14
        Me.Label_TiempoCortas.Text = "Cortas"
        '
        'Label_TiempoLargas
        '
        Me.Label_TiempoLargas.AutoSize = True
        Me.Label_TiempoLargas.Location = New System.Drawing.Point(794, 438)
        Me.Label_TiempoLargas.Name = "Label_TiempoLargas"
        Me.Label_TiempoLargas.Size = New System.Drawing.Size(39, 13)
        Me.Label_TiempoLargas.TabIndex = 15
        Me.Label_TiempoLargas.Text = "Largas"
        '
        'Label_EspacioSigno
        '
        Me.Label_EspacioSigno.AutoSize = True
        Me.Label_EspacioSigno.Location = New System.Drawing.Point(794, 489)
        Me.Label_EspacioSigno.Name = "Label_EspacioSigno"
        Me.Label_EspacioSigno.Size = New System.Drawing.Size(75, 13)
        Me.Label_EspacioSigno.TabIndex = 16
        Me.Label_EspacioSigno.Text = "Espacio Signo"
        '
        'Label_LetrasEspacio
        '
        Me.Label_LetrasEspacio.AutoSize = True
        Me.Label_LetrasEspacio.Location = New System.Drawing.Point(794, 540)
        Me.Label_LetrasEspacio.Name = "Label_LetrasEspacio"
        Me.Label_LetrasEspacio.Size = New System.Drawing.Size(77, 13)
        Me.Label_LetrasEspacio.TabIndex = 17
        Me.Label_LetrasEspacio.Text = "Letras Espacio"
        '
        'Button_Morse
        '
        Me.Button_Morse.Location = New System.Drawing.Point(668, 100)
        Me.Button_Morse.Name = "Button_Morse"
        Me.Button_Morse.Size = New System.Drawing.Size(120, 23)
        Me.Button_Morse.TabIndex = 18
        Me.Button_Morse.Text = "Morse"
        Me.Button_Morse.UseVisualStyleBackColor = True
        '
        'Label_Volumen
        '
        Me.Label_Volumen.AutoSize = True
        Me.Label_Volumen.Location = New System.Drawing.Point(779, 23)
        Me.Label_Volumen.Name = "Label_Volumen"
        Me.Label_Volumen.Size = New System.Drawing.Size(48, 13)
        Me.Label_Volumen.TabIndex = 20
        Me.Label_Volumen.Text = "Volumen"
        '
        'TrackBar_Volumen
        '
        Me.TrackBar_Volumen.Location = New System.Drawing.Point(661, 16)
        Me.TrackBar_Volumen.Maximum = 1000
        Me.TrackBar_Volumen.Minimum = 1
        Me.TrackBar_Volumen.Name = "TrackBar_Volumen"
        Me.TrackBar_Volumen.Size = New System.Drawing.Size(107, 45)
        Me.TrackBar_Volumen.TabIndex = 19
        Me.ToolTip1.SetToolTip(Me.TrackBar_Volumen, "Velocidad general")
        Me.TrackBar_Volumen.Value = 500
        '
        'Form_Morse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(943, 604)
        Me.Controls.Add(Me.Label_Volumen)
        Me.Controls.Add(Me.TrackBar_Volumen)
        Me.Controls.Add(Me.Button_Morse)
        Me.Controls.Add(Me.Label_LetrasEspacio)
        Me.Controls.Add(Me.Label_EspacioSigno)
        Me.Controls.Add(Me.Label_TiempoLargas)
        Me.Controls.Add(Me.Label_TiempoCortas)
        Me.Controls.Add(Me.Label_Velocidad)
        Me.Controls.Add(Me.TrackBar_TiempoCortas)
        Me.Controls.Add(Me.TrackBar_EspacioSigno)
        Me.Controls.Add(Me.TrackBar_LetrasEspacio)
        Me.Controls.Add(Me.TrackBar_TiempoLargas)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.TrackBar_Velocidad)
        Me.Controls.Add(Me.Button_BeepCube)
        Me.Controls.Add(Me.Button_Beep)
        Me.Controls.Add(Me.Button_SonidoPlay)
        Me.Controls.Add(Me.Button_Grabar2)
        Me.Controls.Add(Me.Button_Reproducir)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button_Grabar)
        Me.Name = "Form_Morse"
        Me.Text = "Form_Morse"
        CType(Me.TrackBar_Velocidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar_TiempoLargas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar_LetrasEspacio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar_EspacioSigno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar_TiempoCortas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar_Volumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button_Grabar As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button_Reproducir As Button
    Friend WithEvents Button_Grabar2 As Button
    Friend WithEvents Button_SonidoPlay As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Button_Beep As Button
    Friend WithEvents Button_BeepCube As Button
    Friend WithEvents TrackBar_Velocidad As TrackBar
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents TrackBar_TiempoLargas As TrackBar
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents TrackBar_LetrasEspacio As TrackBar
    Friend WithEvents TrackBar_EspacioSigno As TrackBar
    Friend WithEvents TrackBar_TiempoCortas As TrackBar
    Friend WithEvents Label_Velocidad As Label
    Friend WithEvents Label_TiempoCortas As Label
    Friend WithEvents Label_TiempoLargas As Label
    Friend WithEvents Label_EspacioSigno As Label
    Friend WithEvents Label_LetrasEspacio As Label
    Friend WithEvents Button_Morse As Button
    Friend WithEvents Label_Volumen As Label
    Friend WithEvents TrackBar_Volumen As TrackBar
End Class
