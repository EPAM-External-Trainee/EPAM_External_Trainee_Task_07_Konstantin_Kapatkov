USE [ResultSession]
GO

ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Students_dbo.Genders_GenderId] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Genders] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_dbo.Students_dbo.Genders_GenderId]
GO

ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Students_dbo.Groups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_dbo.Students_dbo.Groups_GroupId]
GO

ALTER TABLE [dbo].[SessionSchedules]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SessionSchedules_dbo.Examiners_ExaminerId] FOREIGN KEY([ExaminerId])
REFERENCES [dbo].[Examiners] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SessionSchedules] CHECK CONSTRAINT [FK_dbo.SessionSchedules_dbo.Examiners_ExaminerId]
GO

ALTER TABLE [dbo].[SessionSchedules]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SessionSchedules_dbo.Groups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SessionSchedules] CHECK CONSTRAINT [FK_dbo.SessionSchedules_dbo.Groups_GroupId]
GO

ALTER TABLE [dbo].[SessionSchedules]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SessionSchedules_dbo.KnowledgeAssessmentForms_KnowledgeAssessmentFormId] FOREIGN KEY([KnowledgeAssessmentFormId])
REFERENCES [dbo].[KnowledgeAssessmentForms] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SessionSchedules] CHECK CONSTRAINT [FK_dbo.SessionSchedules_dbo.KnowledgeAssessmentForms_KnowledgeAssessmentFormId]
GO

ALTER TABLE [dbo].[SessionSchedules]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SessionSchedules_dbo.Sessions_SessionId] FOREIGN KEY([SessionId])
REFERENCES [dbo].[Sessions] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SessionSchedules] CHECK CONSTRAINT [FK_dbo.SessionSchedules_dbo.Sessions_SessionId]
GO

ALTER TABLE [dbo].[SessionSchedules]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SessionSchedules_dbo.Subjects_SubjectId] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SessionSchedules] CHECK CONSTRAINT [FK_dbo.SessionSchedules_dbo.Subjects_SubjectId]
GO

ALTER TABLE [dbo].[SessionResults]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SessionResults_dbo.Sessions_SessionId] FOREIGN KEY([SessionId])
REFERENCES [dbo].[Sessions] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SessionResults] CHECK CONSTRAINT [FK_dbo.SessionResults_dbo.Sessions_SessionId]
GO

ALTER TABLE [dbo].[SessionResults]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SessionResults_dbo.Students_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SessionResults] CHECK CONSTRAINT [FK_dbo.SessionResults_dbo.Students_StudentId]
GO

ALTER TABLE [dbo].[SessionResults]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SessionResults_dbo.Subjects_SubjectId] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SessionResults] CHECK CONSTRAINT [FK_dbo.SessionResults_dbo.Subjects_SubjectId]
GO

ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Groups_dbo.GroupSpecialties_GroupSpecialtyId] FOREIGN KEY([GroupSpecialtyId])
REFERENCES [dbo].[GroupSpecialties] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_dbo.Groups_dbo.GroupSpecialties_GroupSpecialtyId]
GO