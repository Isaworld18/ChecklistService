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

    public class AddNewTaskCommandHandler : IRequestHandler<AddNewTaskCommand, AddNewTaskCommandResponse>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger _logger;

        public AddNewTaskCommandHandler(ITaskRepository taskRepository, ILogger logger)
        {
            _taskRepository = taskRepository;
            _logger = logger;
        }

        public async Task<AddNewTaskCommandResponse> Handle(AddNewTaskCommand request, 
                                                      CancellationToken cancellationToken)
        {
            AddNewTaskCommandResponse responseResult;

            try
            {
                if (await _taskRepository.Exists(request.NewWorkDescription))
                {
                    responseResult = new()
                    {
                        ResponseMessage = ServiceMessages.AddNewTask_Validation
                    };
                }
                else
                {
                    Work newEntry = new()
                    {
                        Description = request.NewWorkDescription,
                        Done = false,
                        EndDate = null
                    };

                    newEntry = await _taskRepository.Add(newEntry);

                    responseResult = new(new TaskResponse(newEntry), ServiceMessages.AddNewTask_ValidOperation);
                }
            }
            catch (Exception ex)
            {
                responseResult = new()
                {
                    ResponseMessage = ServiceMessages.AddNewTask_Exception
                };

                _logger.LogError($"{ServiceMessages.CommandHandler_ExceptionLogTitle} {ex.Message}",
                                 DateTime.UtcNow.ToLongTimeString());
            }

            return responseResult;
        }
    }
}
