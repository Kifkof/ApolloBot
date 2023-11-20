using Microsoft.Extensions.Logging;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Apollo;

public class EmbeddedMessageWorkflow : IWorkflow<EmbeddedMessageRequest>
{
    public const string Identifier = "EmbeddedMessageWorkflow";

    public void Build(IWorkflowBuilder<EmbeddedMessageRequest> builder)
    {
        builder
            .StartWith<StartStep>()
            .Input(step => step.Request, request => request);
    }

    public string Id => Identifier;
    public int Version => 1;


}

public class StartStep : StepBody
{
    public required EmbeddedMessageRequest Request { get; set; }

    private readonly ILogger<StartStep> logger;

    public StartStep(ILogger<StartStep> logger)
    {
        this.logger = logger;
    }

    public override ExecutionResult Run(IStepExecutionContext context)
    {
        this.logger.LogInformation(context.Workflow.Reference);

        return ExecutionResult.Next();
    }
}