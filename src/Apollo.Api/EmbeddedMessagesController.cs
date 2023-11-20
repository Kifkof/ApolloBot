using Microsoft.AspNetCore.Mvc;
using WorkflowCore.Interface;

namespace Apollo.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmbeddedMessagesController : ControllerBase
    {
        private readonly IWorkflowHost workflowHost;

        public EmbeddedMessagesController(IWorkflowHost workflowHost)
        {
            this.workflowHost = workflowHost;
        }

        [HttpGet]
        public List<EmbeddedMessageDto> GetAllMessages(CancellationToken cancellationToken)
        {
            return new List<EmbeddedMessageDto>();
        }

        [HttpGet("{messageId:guid}")]
        public EmbeddedMessageDto GetMessageById(Guid messageId, CancellationToken cancellationToken)
        {
            return new EmbeddedMessageDto();
        }

        [HttpPost]
        public async Task<ActivityResult> Post([FromBody] EmbeddedMessageDto embeddedMessageDto, CancellationToken cancellationToken)
        {
            var embeddedMessageRequest = new EmbeddedMessageRequest()
            {
                Id = embeddedMessageDto.Id
            };
            var correlationId = Guid.NewGuid();
            await this.workflowHost.StartWorkflow(EmbeddedMessageWorkflow.Identifier, embeddedMessageRequest, correlationId.ToString());
            return new ActivityResult { CorrelationId = correlationId };
        }
    }

    public class ActivityResult
    {
        public required Guid CorrelationId { get; init; }
    }
}