﻿using MediatR;
using System;
using TrackMyJob.Framework.CommandHandlers;

namespace TrackMyJob.Domain.CommandHandlers.Commands.Assignment
{
    public class AssignmentInsertCommand: IRequest<ICommandResult>
    {
        public string Description { get; set; }

        public string User { get; set; }

        public DateTime DueDate { get; set; }

        public bool Completed { get; set; }

        public int ProjectId { get; set; }
    }
}
