private void comboBox17_SelectedIndexChanged(object sender, EventArgs e)// поиск предметов по выбранной группе и типу контроля, и добавление их в выпадающий список
        {
            sqlConnection7.Open();
            try
            {

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                
                SqlCommand command = new SqlCommand("P_Take_Studied_Subjects", sqlConnection7);
                command.Parameters.Add("@id_group", SqlDbType.Int).Value = comboBox8.SelectedValue;
                command.Parameters.Add("@type_control_id", SqlDbType.Int).Value = comboBox17.SelectedValue;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                comboBox9.DataSource = table;
                comboBox9.DisplayMember = "Название предмета";
                comboBox9.ValueMember = "id";
            }

            catch (Exception ex) { System.Console.WriteLine($" Ошибка: {ex.Message}"); }
            sqlConnection7.Close();
        }
public void button17_Click(object sender, EventArgs e)// Загрузка файла ведомости с ПК, и запись информации из него в dataGridView
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "MS Excel | *.xlsx";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                OleDbConnection connection = new OleDbConnection(string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml; HDR = YES\"; ", dialog.FileName));
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [Лист1$]", connection);
                DataTable table = new DataTable();
                adapter.Fill(table);                
                dataGridView7.DataSource = table;
            }

        }
private void button18_Click(object sender, EventArgs e)// Запись оценок и даты из dataGridView в БД
        {
            
            sqlConnection6.Open();
            sqlCommand1 = new SqlCommand("P_Add_Students_marks", sqlConnection6);
            sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand1.Parameters.Add("@mark_student", SqlDbType.VarChar);            
            sqlCommand1.Parameters["@mark_student "].Value = dataGridView7.Columns[0];
            sqlCommand1.Parameters.Add("@date", SqlDbType.Date);            
            sqlCommand1.Parameters["@date"].Value = dataGridView7.Columns[1];

            SqlDataReader reader = sqlCommand1.ExecuteReader();

            sqlConnection6.Close();
           
            MessageBox.Show("Успешно!");
        }
