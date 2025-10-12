namespace InvoiceManagement.Domain.Entities;

/// <summary>
/// Represents an invoice in the system
/// </summary>
public class Invoice
{
    /// <summary>
    /// Unique identifier for the invoice
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Unique invoice number (e.g., "INV-2024-001")
    /// </summary>
    public string InvoiceNumber { get; set; } = string.Empty;

    /// <summary>
    /// Identifier of the customer this invoice belongs to
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Date when the invoice was issued
    /// </summary>
    public DateTime IssueDate { get; set; }

    /// <summary>
    /// Date when the invoice payment is due
    /// </summary>
    public DateTime DueDate { get; set; }

    /// <summary>
    /// Total amount of the invoice
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Current status of the invoice
    /// </summary>
    public InvoiceStatus Status { get; set; } = InvoiceStatus.Draft;

    /// <summary>
    /// Date and time when the invoice was created
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Date and time when the invoice was last modified
    /// </summary>
    public DateTime ModifiedAt { get; set; }

    /// <summary>
    /// User who created the invoice
    /// </summary>
    public string CreatedBy { get; set; } = string.Empty;

    /// <summary>
    /// User who last modified the invoice
    /// </summary>
    public string ModifiedBy { get; set; } = string.Empty;

    /// <summary>
    /// Default constructor
    /// </summary>
    public Invoice()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        ModifiedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Constructor with required parameters
    /// </summary>
    /// <param name="invoiceNumber">Unique invoice number</param>
    /// <param name="customerId">Customer identifier</param>
    /// <param name="issueDate">Issue date</param>
    /// <param name="dueDate">Due date</param>
    /// <param name="totalAmount">Total amount</param>
    /// <param name="createdBy">User who created the invoice</param>
    public Invoice(string invoiceNumber, Guid customerId, DateTime issueDate, DateTime dueDate, decimal totalAmount, string createdBy)
        : this()
    {
        InvoiceNumber = invoiceNumber;
        CustomerId = customerId;
        IssueDate = issueDate;
        DueDate = dueDate;
        TotalAmount = totalAmount;
        CreatedBy = createdBy;
        ModifiedBy = createdBy;
    }

    /// <summary>
    /// Updates the invoice status and audit information
    /// </summary>
    /// <param name="newStatus">New status to set</param>
    /// <param name="modifiedBy">User making the change</param>
    public void UpdateStatus(InvoiceStatus newStatus, string modifiedBy)
    {
        Status = newStatus;
        ModifiedAt = DateTime.UtcNow;
        ModifiedBy = modifiedBy;
    }

    /// <summary>
    /// Updates the total amount and audit information
    /// </summary>
    /// <param name="newAmount">New total amount</param>
    /// <param name="modifiedBy">User making the change</param>
    public void UpdateAmount(decimal newAmount, string modifiedBy)
    {
        TotalAmount = newAmount;
        ModifiedAt = DateTime.UtcNow;
        ModifiedBy = modifiedBy;
    }

    /// <summary>
    /// Checks if the invoice is overdue
    /// </summary>
    /// <returns>True if the invoice is overdue, false otherwise</returns>
    public bool IsOverdue()
    {
        return Status != InvoiceStatus.Paid && DateTime.UtcNow > DueDate;
    }

    /// <summary>
    /// Marks the invoice as paid
    /// </summary>
    /// <param name="modifiedBy">User marking the invoice as paid</param>
    public void MarkAsPaid(string modifiedBy)
    {
        UpdateStatus(InvoiceStatus.Paid, modifiedBy);
    }
}
