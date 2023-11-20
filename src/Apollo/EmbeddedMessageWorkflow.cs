using WorkflowCore.Interface;

namespace Apollo;

public class EmbeddedMessageWorkflow : IWorkflow<EmbeddedMessageRequest>
{
    public const string Identifier = "EmbeddedMessageWorkflow";

    public void Build(IWorkflowBuilder<EmbeddedMessageRequest> builder)
    {
        
    }

    public string Id => Identifier;
    public int Version => 1;


}