﻿namespace TrackMyJob.Domain.CommandHandlers.Commands.Assignment
{
    public class AssignmentUpdateCommand: AssignmentInsertCommand
    {
        public int Id { get; set; }
    }
}
