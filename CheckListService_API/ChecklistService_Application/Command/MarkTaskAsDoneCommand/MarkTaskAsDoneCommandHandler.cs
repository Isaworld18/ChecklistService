namespace ChecklistService_Application.Command
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using ChecklistService_Domain.Interfaces;
    using ChecklistService_Domain.Models;
    using ChecklistService_Helper.Messages;
    using MediatR;
    using Microsoft.Extensions.Logging;

    public class MarkTaskAsDoneCommandHandler : IRequestHandler<MarkTaskAsDoneCommand,
                                                                MarkTaskAsDoneCommandResponse>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger _logger;

        public MarkTaskAsDoneCommandHandler(ITaskRepository taskRepository, ILogger logger)
        {
            _taskRepository = taskRepository;
            _logger = logger;
        }

        public async Task<MarkTaskAsDoneCommandResponse> Handle(MarkTaskAsDoneCommand request, 
                                                          CancellationToken cancellationToken)
        {
            MarkTaskAsDoneCommandResponse responseResult;

            try
            {
                Work selectedTask = await _taskRepository.Get(request.TaskId);

                if (selectedTask is null)
                {
                    responseResult = new()
                    {
                        ResponseMessage = ServiceMessages.MarkTaskDone_Validation
                    };
                }
                else
                {
                    selectedTask.Done = true;
                    selectedTask.EndDate = DateOnly.Parse(DateTime.UtcNow.ToShortDateString());

                    selectedTask = await _taskRepository.Update(selectedTask);

                    responseResult = new(new TaskResponse(selectedTask),
                                         ServiceMessages.MarkTaskDone_ValidOperation);
                }
            }
            catch (Exception ex)
            {
                responseResult = new()
                {
                    ResponseMessage = ServiceMessages.MarkTaskDone_Exception
                };

                _logger.LogError($"{ServiceMessages.CommandHandler_ExceptionLogTitle} {ex.Message}",
                                    DateTime.UtcNow.ToLongTimeString());
            }

            return responseResult;
        }
    }
}
