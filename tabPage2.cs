private void comboBox16_SelectedIndexChanged(object sender, EventArgs e) // поиск предметов по выбранной группе и типу контроля, и добавление их в выпадающий список
        {
sqlConnection7.Open();)
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
        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)//Поиск оценок студентов и оценок по выбранным группе, типу контроля и предмету и вывод в dataGridView
        {
            sqlConnection6.Open();

            try
            {
                Console.WriteLine(comboBox10.ValueMember.ToString());
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                SqlCommand command = new SqlCommand("P_Take_Student_Marks", sqlConnection6);
                command.Parameters.Add("@id_group", SqlDbType.Int).Value = comboBox11.SelectedValue;
                command.Parameters.Add("@id_sub", SqlDbType.Int).Value = comboBox10.SelectedValue;
                command.Parameters.Add("@type_control", SqlDbType.Int).Value = comboBox16.SelectedValue;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                dataGridView8.DataSource = table;
                
            }
            catch (Exception ex) { System.Console.WriteLine($" Ошибка: {ex.Message}"); }
            sqlConnection6.Close();


        }
