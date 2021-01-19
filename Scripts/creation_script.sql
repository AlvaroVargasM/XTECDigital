USE [Test]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/******************* STRONG ENTITIES *******************/

/****** Object:  Table [dbo].[Semesters]    Script Date: 12/17/2020 11:08:38 PM ******/
CREATE TABLE [dbo].[Semesters](
	[year] [int] NOT NULL,
	[period] [nchar](1) NOT NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED
(
	[year] ASC,
	[period] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Courses]    Script Date: 12/17/2020 11:14:40 PM ******/
CREATE TABLE [dbo].[Courses](
	[code] [nchar](6) NOT NULL,
	[name] [text] NOT NULL,
	[credits] [int] NOT NULL,
	[school] [text] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Groups]    Script Date: 12/17/2020 11:19:01 PM ******/
CREATE TABLE [dbo].[Groups](
	[number] [int] NOT NULL,
	[year_semester] [int] NOT NULL,
	[period_semester] [nchar](1) NOT NULL,
	[code_course] [nchar](6) NOT NULL,
	[path] [text] NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED
(
	[number] ASC,
	[year_semester] ASC,
	[period_semester] ASC,
	[code_course] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_Groups_Courses] FOREIGN KEY([code_course])
REFERENCES [dbo].[Courses] ([code])
GO

ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_Groups_Courses]
GO

ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_Groups_Semesters] FOREIGN KEY([year_semester], [period_semester])
REFERENCES [dbo].[Semesters] ([year], [period])
GO

ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_Groups_Semesters]
GO

/****** Object:  Table [dbo].[Professors]    Script Date: 12/17/2020 11:25:01 PM ******/
CREATE TABLE [dbo].[Professors](
	[ssn] [nchar](15) NOT NULL,
 CONSTRAINT [PK_Professor] PRIMARY KEY CLUSTERED
(
	[ssn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Students]    Script Date: 12/17/2020 11:26:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Students](
	[collegeId] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED
(
	[collegeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Teams]    Script Date: 12/17/2020 11:29:37 PM ******/
CREATE TABLE [dbo].[Teams](
	[number] [int] NOT NULL,
	[number_group] [int] NOT NULL,
	[year_semester] [int] NOT NULL,
	[period_semester] [nchar](1) NOT NULL,
	[code_course] [nchar](6) NOT NULL,
 CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED
(
	[number] ASC,
	[number_group] ASC,
	[year_semester] ASC,
	[period_semester] ASC,
	[code_course] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Teams]  WITH CHECK ADD  CONSTRAINT [FK_Team_Group] FOREIGN KEY([number_group], [year_semester], [period_semester], [code_course])
REFERENCES [dbo].[Groups] ([number], [year_semester], [period_semester], [code_course])
GO

ALTER TABLE [dbo].[Teams] CHECK CONSTRAINT [FK_Team_Group]
GO

/****** Object:  Table [dbo].[Rubrics]    Script Date: 12/17/2020 11:31:17 PM ******/
CREATE TABLE [dbo].[Rubrics](
	[name] [nchar](25) NOT NULL,
	[number_group] [int] NOT NULL,
	[year_semester] [int] NOT NULL,
	[period_semester] [nchar](1) NOT NULL,
	[code_course] [nchar](6) NOT NULL,
	[porcentage] [int] NOT NULL,
 CONSTRAINT [PK_Rubrics] PRIMARY KEY CLUSTERED
(
	[name] ASC,
	[number_group] ASC,
	[year_semester] ASC,
	[period_semester] ASC,
	[code_course] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Rubrics]  WITH CHECK ADD  CONSTRAINT [FK_Rubrics_Group] FOREIGN KEY([number_group], [year_semester], [period_semester], [code_course])
REFERENCES [dbo].[Groups] ([number], [year_semester], [period_semester], [code_course])
GO

ALTER TABLE [dbo].[Rubrics] CHECK CONSTRAINT [FK_Rubrics_Group]
GO

/****** Object:  Table [dbo].[Evaluations]    Script Date: 12/17/2020 11:33:21 PM ******/
CREATE TABLE [dbo].[Evaluations](
	[id] [nchar](38) NOT NULL,
	[deadline] [datetime] NOT NULL,
	[value] [decimal](5, 2) NOT NULL,
	[specification] [text] NOT NULL,
	[name_rubric] [nchar](25) NOT NULL,
	[number_group] [int] NOT NULL,
	[year_semester] [int] NOT NULL,
	[period_semester] [nchar](1) NOT NULL,
	[code_course] [nchar](6) NOT NULL,
 CONSTRAINT [PK_Evaluation] PRIMARY KEY CLUSTERED
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Evaluations]  WITH CHECK ADD  CONSTRAINT [FK_Evaluation_Rubrics] FOREIGN KEY([name_rubric], [number_group], [year_semester], [period_semester], [code_course])
REFERENCES [dbo].[Rubrics] ([name], [number_group], [year_semester], [period_semester], [code_course])
GO

ALTER TABLE [dbo].[Evaluations] CHECK CONSTRAINT [FK_Evaluation_Rubrics]
GO

/******************* WEAK ENTITIES *******************/

/****** Object:  Table [dbo].[News]    Script Date: 12/17/2020 11:44:52 PM ******/
CREATE TABLE [dbo].[News](
	[number_group] [int] NOT NULL,
	[year_semester] [int] NOT NULL,
	[period_semester] [nchar](1) NOT NULL,
	[code_course] [nchar](6) NOT NULL,
	[ssn_professor] [nchar](15) NOT NULL,
	[title] [text] NOT NULL,
	[message] [text] NOT NULL,
	[date] [date] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_Group] FOREIGN KEY([number_group], [year_semester], [period_semester], [code_course])
REFERENCES [dbo].[Groups] ([number], [year_semester], [period_semester], [code_course])
GO

ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_Group]
GO

ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_Professors] FOREIGN KEY([ssn_professor])
REFERENCES [dbo].[Professors] ([ssn])
GO

ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_Professors]
GO

/****** Object:  Table [dbo].[Documents]    Script Date: 12/17/2020 11:47:33 PM ******/
CREATE TABLE [dbo].[Documents](
	[number_group] [int] NOT NULL,
	[year_semester] [int] NOT NULL,
	[period_semester] [nchar](1) NOT NULL,
	[code_course] [nchar](6) NOT NULL,
	[path] [text] NOT NULL,
	[date] [date] NOT NULL,
	[size] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Documents]  WITH CHECK ADD  CONSTRAINT [FK_Documents_Group] FOREIGN KEY([number_group], [year_semester], [period_semester], [code_course])
REFERENCES [dbo].[Groups] ([number], [year_semester], [period_semester], [code_course])
GO

ALTER TABLE [dbo].[Documents] CHECK CONSTRAINT [FK_Documents_Group]
GO

/****** Object:  Table [dbo].[Submissions]    Script Date: 12/17/2020 11:52:33 PM ******/
CREATE TABLE [dbo].[Submissions](
	[number_team] [int] NOT NULL,
	[number_group] [int] NOT NULL,
	[year_semester] [int] NOT NULL,
	[period_semester] [nchar](1) NOT NULL,
	[code_course] [nchar](6) NOT NULL,
	[ssn_professor] [nchar](15) NOT NULL,
	[id_evaluation] [nchar](38) NOT NULL,
	[score] [int] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Submissions]  WITH CHECK ADD  CONSTRAINT [FK_Submissions_Evaluations] FOREIGN KEY([id_evaluation])
REFERENCES [dbo].[Evaluations] ([id])
GO

ALTER TABLE [dbo].[Submissions] CHECK CONSTRAINT [FK_Submissions_Evaluations]
GO

ALTER TABLE [dbo].[Submissions]  WITH CHECK ADD  CONSTRAINT [FK_Submissions_Professors] FOREIGN KEY([ssn_professor])
REFERENCES [dbo].[Professors] ([ssn])
GO

ALTER TABLE [dbo].[Submissions] CHECK CONSTRAINT [FK_Submissions_Professors]
GO

ALTER TABLE [dbo].[Submissions]  WITH CHECK ADD  CONSTRAINT [FK_Submissions_Teams] FOREIGN KEY([number_team], [number_group], [year_semester], [period_semester], [code_course])
REFERENCES [dbo].[Teams] ([number], [number_group], [year_semester], [period_semester], [code_course])
GO

ALTER TABLE [dbo].[Submissions] CHECK CONSTRAINT [FK_Submissions_Teams]
GO

/******************* NxM Relationships *******************/

/****** Object:  Table [dbo].[IsAvailable]    Script Date: 12/18/2020 12:07:26 AM ******/
CREATE TABLE [dbo].[IsAvailable](
	[year_semester] [int] NOT NULL,
	[period_semester] [nchar](1) NOT NULL,
	[code_course] [nchar](6) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[IsAvailable]  WITH CHECK ADD  CONSTRAINT [FK_IsAvailable_Courses] FOREIGN KEY([code_course])
REFERENCES [dbo].[Courses] ([code])
GO

ALTER TABLE [dbo].[IsAvailable] CHECK CONSTRAINT [FK_IsAvailable_Courses]
GO

ALTER TABLE [dbo].[IsAvailable]  WITH CHECK ADD  CONSTRAINT [FK_IsAvailable_Semesters] FOREIGN KEY([year_semester], [period_semester])
REFERENCES [dbo].[Semesters] ([year], [period])
GO

ALTER TABLE [dbo].[IsAvailable] CHECK CONSTRAINT [FK_IsAvailable_Semesters]
GO

/****** Object:  Table [dbo].[Enrolls]    Script Date: 12/18/2020 12:08:20 AM ******/
CREATE TABLE [dbo].[Enrolls](
	[number_group] [int] NOT NULL,
	[year_semester] [int] NOT NULL,
	[period_semester] [nchar](1) NOT NULL,
	[code_course] [nchar](6) NOT NULL,
	[college_id_student] [nchar](10) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Enrolls]  WITH CHECK ADD  CONSTRAINT [FK_Enrolls_Groups] FOREIGN KEY([number_group], [year_semester], [period_semester], [code_course])
REFERENCES [dbo].[Groups] ([number], [year_semester], [period_semester], [code_course])
GO

ALTER TABLE [dbo].[Enrolls] CHECK CONSTRAINT [FK_Enrolls_Groups]
GO

ALTER TABLE [dbo].[Enrolls]  WITH CHECK ADD  CONSTRAINT [FK_Enrolls_Students] FOREIGN KEY([college_id_student])
REFERENCES [dbo].[Students] ([collegeId])
GO

ALTER TABLE [dbo].[Enrolls] CHECK CONSTRAINT [FK_Enrolls_Students]
GO

/****** Object:  Table [dbo].[Teaches]    Script Date: 12/18/2020 12:09:37 AM ******/
CREATE TABLE [dbo].[Teaches](
	[number_group] [int] NOT NULL,
	[year_semester] [int] NOT NULL,
	[period_semester] [nchar](1) NOT NULL,
	[code_course] [nchar](6) NOT NULL,
	[ssn_professor] [nchar](15) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Teaches]  WITH CHECK ADD  CONSTRAINT [FK_Teaches_Groups] FOREIGN KEY([number_group], [year_semester], [period_semester], [code_course])
REFERENCES [dbo].[Groups] ([number], [year_semester], [period_semester], [code_course])
GO

ALTER TABLE [dbo].[Teaches] CHECK CONSTRAINT [FK_Teaches_Groups]
GO

ALTER TABLE [dbo].[Teaches]  WITH CHECK ADD  CONSTRAINT [FK_Teaches_Professors] FOREIGN KEY([ssn_professor])
REFERENCES [dbo].[Professors] ([ssn])
GO

ALTER TABLE [dbo].[Teaches] CHECK CONSTRAINT [FK_Teaches_Professors]
GO

/****** Object:  Table [dbo].[Member]    Script Date: 12/18/2020 12:10:29 AM ******/
CREATE TABLE [dbo].[Member](
	[number_team] [int] NOT NULL,
	[number_group] [int] NOT NULL,
	[year_semester] [int] NOT NULL,
	[period_semester] [nchar](1) NOT NULL,
	[code_course] [nchar](6) NOT NULL,
	[college_id_student] [nchar](10) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Member]  WITH CHECK ADD  CONSTRAINT [FK_Member_Students] FOREIGN KEY([college_id_student])
REFERENCES [dbo].[Students] ([collegeId])
GO

ALTER TABLE [dbo].[Member] CHECK CONSTRAINT [FK_Member_Students]
GO

ALTER TABLE [dbo].[Member]  WITH CHECK ADD  CONSTRAINT [FK_Member_Teams] FOREIGN KEY([number_team], [number_group], [year_semester], [period_semester], [code_course])
REFERENCES [dbo].[Teams] ([number], [number_group], [year_semester], [period_semester], [code_course])
GO

ALTER TABLE [dbo].[Member] CHECK CONSTRAINT [FK_Member_Teams]
GO
