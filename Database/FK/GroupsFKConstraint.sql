ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Groups_dbo.GroupSpecialties_GroupSpecialtyId] FOREIGN KEY([GroupSpecialtyId])
REFERENCES [dbo].[GroupSpecialties] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_dbo.Groups_dbo.GroupSpecialties_GroupSpecialtyId]
GO