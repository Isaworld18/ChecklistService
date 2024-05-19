namespace ChecklistService_Application.Query
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using ChecklistService_Domain.Interfaces;
    using ChecklistService_Helper.Messages;
    using MediatR;
    using Microsoft.Extensions.Logging;

    public class OrderTaskByQueryHandler : IRequestHandler<OrderTaskByQuery, OrderTaskByQueryResponse>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger _logger;

        public OrderTaskByQueryHandler(ITaskRepository taskRepository, ILogger logger)
        {
            _taskRepository = taskRepository;
            _logger = logger;
        }

        public async Task<OrderTaskByQueryResponse> Handle(OrderTaskByQuery request, 
                                                     CancellationToken cancellationToken)
        {
            OrderTaskByQueryResponse responseResult;

            try
            {
                responseResult = new(await _taskRepository.Order(request.OrderBy), 
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
