Module Tamaño_automatico_de_datatables
    Public Sub Multilinea(ByRef List As DataGridView)
        'List.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        'List.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        List.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        List.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        List.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        List.EnableHeadersVisualStyles = False
        Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
        styCabeceras.BackColor = Color.FromArgb(39, 39, 39)
        styCabeceras.ForeColor = Color.White
        styCabeceras.Font = New Font("Segoe UI", 13, FontStyle.Regular Or
        FontStyle.Bold)
        List.ColumnHeadersDefaultCellStyle = styCabeceras
    End Sub
End Module
