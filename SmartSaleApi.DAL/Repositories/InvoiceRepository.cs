using Microsoft.EntityFrameworkCore;
using SmartSaleApi.Core.Enums;
using SmartSaleApi.Core.Filters;
using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Models;
using SmartSaleApi.DAL.Contexts;

namespace SmartSaleApi.DAL.Repositories;

public sealed class InvoiceRepository : IInvoiceRepository {
    private readonly SmartSaleDbContext _context;

    public InvoiceRepository(SmartSaleDbContext context) {
        _context = context;
    }

    public void Add(Invoice invoice) {
        _context.Invoices.Add(invoice);
    }

    public void Delete(int id) {
        var invoice = _context.Invoices.FirstOrDefault(x => x.Id == id);
        ArgumentNullException.ThrowIfNull(invoice);
        invoice.EntityStatus = EntityStatus.Archived;
    }

    public void Update(Invoice invoice) {
        var existingInvoice = _context.Invoices
            .Include(x => x.InvoiceDetails)
            .Include(x => x.InvoicePayments)
            .FirstOrDefault(x => x.Id == invoice.Id);
        ArgumentNullException.ThrowIfNull(existingInvoice);

        existingInvoice.Total = invoice.Total;
        existingInvoice.Discount = invoice.Discount;
        existingInvoice.TotalWithDiscount = invoice.TotalWithDiscount;
        existingInvoice.PaidAmount = invoice.PaidAmount;
        existingInvoice.PaymentStatus = invoice.PaymentStatus;
        existingInvoice.InvoiceDetails = invoice.InvoiceDetails;
        existingInvoice.InvoicePayments = invoice.InvoicePayments;
    }

    public Invoice Get(int id) {
        var invoice = BuildBaseQuery()
            .FirstOrDefault(x => x.Id == id);

        ArgumentNullException.ThrowIfNull(invoice);

        return invoice;
    }

    public IEnumerable<Invoice> Get() {
        return BuildBaseQuery();
    }

    public IEnumerable<Invoice> Get(InvoiceFilter parameter) {
        var query = BuildBaseQuery()
            .Where(x => x.Date >= parameter.DateBegin
                && x.Date <= parameter.DateEnd
                && (parameter.BuyerId == 0 || x.BuyerId == parameter.BuyerId));

        if (parameter.PaymentStatus.HasValue) {
            query = query.Where(x => x.PaymentStatus == parameter.PaymentStatus.Value);
        }

        return query;
    }

    private IQueryable<Invoice> BuildBaseQuery() {
        return _context.Invoices
            .AsNoTracking()
            .Where(x => x.EntityStatus == EntityStatus.Active)
            .Include(x => x.Buyer)
            .Include(x => x.InvoiceDetails.OrderBy(d => d.Product.Name))
            .ThenInclude(x => x.Product)
            .Include(x => x.InvoicePayments.OrderBy(p => p.Date))
            .OrderByDescending(x => x.Date)
            .ThenByDescending(x => x.Buyer.Name);
    }
}
