namespace ChecklistService_Application.Query
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using ChecklistService_Domain.Interfaces;
    using ChecklistService_Helper.Messages;
    using MediatR;
    using Microsoft.Extensions.Logging;

    public class ListTasksQueryHandler : IRequestHandler<ListTasksQuery, ListTasksQueryResponse>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger _logger;

        public ListTasksQueryHandler(ITaskRepository taskRepository, ILogger logger)
        { 
            _taskRepository = taskRepository;
            _logger = logger;
        }

        public async Task<ListTasksQueryResponse> Handle(ListTasksQuery request, 
                                                   CancellationToken cancellationToken)
        {
            ListTasksQueryResponse responseResult;

            try
            {
                responseResult = new(await _taskRepository.Get(request.AreDone), 
                                     ServiceMessages.ListTask_ValidOperation);
            }
            catch (Exception ex)
            {
                responseResult = new()
                {
                    ResponseMessage = ServiceMessages.ListTask_Exception
                };

                _logger.LogError($"{ServiceMessages.QueryHandler_ExceptionLogTitle} {ex.Message}",
                                    DateTime.UtcNow.ToLongTimeString());
            }

            return responseResult;
        }
    }
}
