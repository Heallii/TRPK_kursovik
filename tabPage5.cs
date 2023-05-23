private void button22_Click(object sender, EventArgs e)// Вывод отчета по неуспевающим студентам в EXCEL
        {
            Excel._Workbook wb;
            Excel._Worksheet ws;
            excelapp = new Excel.Application();
            excelapp.Visible = true;
            wb = (Excel._Workbook)(excelapp.Workbooks.Add(Missing.Value));
            ws = (Excel._Worksheet)wb.ActiveSheet;

            ws.Cells[1, 1] = "Номер зачетки";
            ws.Cells[1, 2] = "ФИО студента";
            ws.Cells[1, 3] = "Оценка";
            ws.Cells[1, 4] = "Дата сдачи";
            ws.Cells[1, 5] = "Название предмета";
            ws.Cells[1, 6] = "Тип контроля";
            sqlConnection6.Open();
            sqlCommand1 = new SqlCommand("P_Otchet3", sqlConnection6);
            sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            int irow = 2;
            SqlDataReader reader = sqlCommand1.ExecuteReader();
            while (reader.Read())
            {
                ws.Cells[irow, 1] = reader[0];
                ws.Cells[irow, 2] = reader[1];
                ws.Cells[irow, 3] = reader[2];
                ws.Cells[irow, 4] = reader[3];
                ws.Cells[irow, 5] = reader[4];
                ws.Cells[irow, 6] = reader[5];                
                irow++;
            }
            ws.Columns.AutoFit();
            excelapp.DisplayAlerts = true;
            MessageBox.Show("Отчет создан!");
            sqlConnection6.Close();
        }
