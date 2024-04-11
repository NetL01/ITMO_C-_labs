namespace Lab5.Application.Models.OperationHistory;

public record Operation(int UserId, int BankAccountId, string Action, OperationResult Result);