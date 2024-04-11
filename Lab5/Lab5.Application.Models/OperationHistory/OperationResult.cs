namespace Lab5.Application.Models.OperationHistory;

public abstract record OperationResult()
{
    public record Success : OperationResult;

    public record Fail : OperationResult;
}