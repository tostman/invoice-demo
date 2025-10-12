namespace InvoiceManagement.Domain.Entities;

/// <summary>
/// Represents the status of an invoice
/// </summary>
public enum InvoiceStatus
{
    /// <summary>
    /// Invoice is in draft state and not yet sent
    /// </summary>
    Draft = 0,
    
    /// <summary>
    /// Invoice has been sent to the customer
    /// </summary>
    Sent = 1,
    
    /// <summary>
    /// Invoice has been paid by the customer
    /// </summary>
    Paid = 2,
    
    /// <summary>
    /// Invoice is past its due date and remains unpaid
    /// </summary>
    Overdue = 3
}
