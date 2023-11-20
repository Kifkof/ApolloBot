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
        public List<EmbeddedMessageDto> GetAllMessages()
        {
            return new List<EmbeddedMessageDto>();
        }

        [HttpGet("{messageId:guid}")]
        public EmbeddedMessageDto GetMessageById(Guid messageId)
        {
            return new EmbeddedMessageDto();
        }

        [HttpPost]
        public async Task<string> Post([FromBody] EmbeddedMessageDto embeddedMessageDto)
        {
            var embeddedMessageRequest = new EmbeddedMessageRequest()
            {
                Id = embeddedMessageDto.Id
            };
            return await this.workflowHost.StartWorkflow(EmbeddedMessageWorkflow.Identifier, embeddedMessageRequest);
        }
    }
}