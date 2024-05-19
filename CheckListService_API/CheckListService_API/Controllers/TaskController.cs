namespace CheckListService_API.Controllers
{
    using System.Net;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using ChecklistService_Application.Command;
    using ChecklistService_Application.Query;
    using ChecklistService_Helper.Messages;
    using ChecklistService_Helper.Enum;

    [ApiController]
    [Route("api/Tasks")]
    public class TaskController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public TaskController(IMediator mediator, ILogger logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(AddNewTaskCommandResponse), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddNewTask([FromBody] string desc)
        {
            try
            {
                return Ok(await _mediator.Send(new AddNewTaskCommand(desc)));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ServiceMessages.Api_ExceptionLogTitle} {ex.Message}",
                                 DateTime.UtcNow.ToLongTimeString());

                return BadRequest(ServiceMessages.Api_Exception);
            }
        }

        [HttpGet]
        [Route("list/{done}")]
        [ProducesResponseType(typeof(ListTasksQueryResponse), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> ListTasks([FromRoute] bool areDone)
        {
            try
            {
                return Ok(await _mediator.Send(new ListTasksQuery(areDone)));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ServiceMessages.Api_ExceptionLogTitle} {ex.Message}",
                                 DateTime.UtcNow.ToLongTimeString());

                return BadRequest(ServiceMessages.Api_Exception);
            }
        }

        [HttpGet]
        [Route("order/{orderBy}")]
        [ProducesResponseType(typeof(OrderTaskByQueryResponse), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> OrderTaskBy(int orderBy)
        {
            try
            {
                if (!Enum.IsDefined(typeof(TasksOrder), orderBy))
                {
                    return BadRequest(ServiceMessages.OrderTaskBy_Validation);
                }
                else
                {
                    return Ok(await _mediator.Send(new OrderTaskByQuery((TasksOrder)orderBy)));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ServiceMessages.Api_ExceptionLogTitle} {ex.Message}",
                                 DateTime.UtcNow.ToLongTimeString());

                return BadRequest(ServiceMessages.Api_Exception);
            }
        }

        [HttpPost]
        [Route("{taskID}/done")]
        [ProducesResponseType(typeof(MarkTaskAsDoneCommandResponse), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> MarkTaskAsDone([FromRoute] int taskId)
        {
            try
            {
                return Ok(await _mediator.Send(new MarkTaskAsDoneCommand(taskId)));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ServiceMessages.Api_ExceptionLogTitle} {ex.Message}",
                                 DateTime.UtcNow.ToLongTimeString());

                return BadRequest(ServiceMessages.Api_Exception);
            }
        }
    }
}
