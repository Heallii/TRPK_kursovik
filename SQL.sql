CREATE TABLE [Groupp] (
	Group_id integer NOT NULL,
	Group_code varchar(255) NOT NULL,
	Group_number integer NOT NULL,
	Group_year integer NOT NULL,
  CONSTRAINT [PK_GROUPP] PRIMARY KEY CLUSTERED
  (
  [Group_id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Student] (
	Student_number_of_zach integer NOT NULL,
	Student_fio varchar(255) NOT NULL,
	Student_gender varchar(20) NOT NULL,
	Student_birthday date NOT NULL,
	Group_id integer NOT NULL,
  CONSTRAINT [PK_STUDENT] PRIMARY KEY CLUSTERED
  (
  [Student_number_of_zach] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
)
GO
CREATE TABLE [Subject] (
	Subject_id integer NOT NULL,
	Subject_name varchar(255) NOT NULL,
	Subject_zet integer NOT NULL,
	Group_id integer NOT NULL,
	Subject_kolvo integer NOT NULL,
	Type_control integer NOT NULL,
  CONSTRAINT [PK_SUBJECT] PRIMARY KEY CLUSTERED
  (
  [Subject_id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
)
GO
CREATE TABLE [Students_marks] (
	Student_mark_id integer NOT NULL,
	Student_id integer NOT NULL,
	Subject_id integer NOT NULL,
	mark_student varchar(20) NOT NULL,
	Type_control integer NOT NULL,
	Date date NOT NULL,
  CONSTRAINT [PK_STUDENTS_MARKS] PRIMARY KEY CLUSTERED
  (
  [Student_mark_id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
)
GO
CREATE TABLE [Type_control] (
	Type_control_id integer NOT NULL,
	Type_control_name varchar(15) NOT NULL,
  CONSTRAINT [PK_TYPE_CONTROL] PRIMARY KEY CLUSTERED
  (
  [Type_control_id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
)
GO
ALTER TABLE [Student] WITH CHECK ADD CONSTRAINT [Student_fk0] FOREIGN KEY ([Group_id]) REFERENCES [Groupp]([Group_id])
ON UPDATE CASCADE
GO
ALTER TABLE [Student] CHECK CONSTRAINT [Student_fk0]
GO
ALTER TABLE [Subject] WITH CHECK ADD CONSTRAINT [Subject_fk0] FOREIGN KEY ([Group_id]) REFERENCES [Groupp]([Group_id])
ON UPDATE CASCADE
GO
ALTER TABLE [Subject] CHECK CONSTRAINT [Subject_fk0]
GO
ALTER TABLE [Subject] WITH CHECK ADD CONSTRAINT [Subject_fk1] FOREIGN KEY ([Type_control]) REFERENCES [Type_control]([Type_control_id])
ON UPDATE CASCADE
GO
ALTER TABLE [Subject] CHECK CONSTRAINT [Subject_fk1]
GO
ALTER TABLE [Students_marks] WITH CHECK ADD CONSTRAINT [Students_marks_fk0] FOREIGN KEY ([Student_id]) REFERENCES [Student]([Student_number_of_zach])
ON UPDATE CASCADE
GO
ALTER TABLE [Students_marks] CHECK CONSTRAINT [Students_marks_fk0]
GO
ALTER TABLE [Students_marks] WITH CHECK ADD CONSTRAINT [Students_marks_fk1] FOREIGN KEY ([Subject_id]) REFERENCES [Subject]([Subject_id])
ON UPDATE CASCADE
GO
ALTER TABLE [Students_marks] CHECK CONSTRAINT [Students_marks_fk1]
GO
ALTER TABLE [Students_marks] WITH CHECK ADD CONSTRAINT [Students_marks_fk2] FOREIGN KEY ([Type_control]) REFERENCES [Type_control]([Type_control_id])
ON UPDATE CASCADE
GO
ALTER TABLE [Students_marks] CHECK CONSTRAINT [Students_marks_fk2]
GO
