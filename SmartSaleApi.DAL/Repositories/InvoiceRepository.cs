using Microsoft.EntityFrameworkCore;
using SmartSaleApi.Core.InputParameters;
using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Models;
using SmartSaleApi.DAL.Contexts;
using SmartSaleApi.DAL.Extensions;

namespace SmartSaleApi.DAL.Repositories;

public sealed class InvoiceRepository : IInvoiceRepository {
    private readonly SmartSaleDbContext _context;

    public InvoiceRepository(SmartSaleDbContext context) {
        _context = context;
    }

    public void Add(Invoice invoice) {
        _context.Invoices.Add(invoice.ToEntity());
        _context.SaveChanges();
    }

    public void Delete(int id) {
        _context.Invoices
            .Where(x => x.Id == id)
            .ExecuteDelete();
    }

    public Invoice Get(int id) {
        var invoice = _context.Invoices
            .AsNoTracking()
            .Include(x => x.Buyer)
            .Include(x => x.InvoiceDetails)
            .ThenInclude(x => x.Product)
            .FirstOrDefault(x => x.Id == id);

        ArgumentNullException.ThrowIfNull(invoice);

        return invoice.OrderInvoiceDetailsByProductName().ToModel();
    }

    public IEnumerable<Invoice> Get() {
        return _context.Invoices
            .AsNoTracking()
            .Include(x => x.Buyer)
            .Include(x => x.InvoiceDetails)
            .ThenInclude(x => x.Product)
            .Select(x => x.OrderInvoiceDetailsByProductName())
            .ToModel();
    }

    public IEnumerable<Invoice> Get(InvoiceInputParameter parameter) {
        return _context.Invoices
            .AsNoTracking()
            .Include(x => x.Buyer)
            .Include(x => x.InvoiceDetails)
            .ThenInclude(x => x.Product)
            .Select(x => x.OrderInvoiceDetailsByProductName())
            .Where(x => x.Date >= parameter.DateBegin && x.Date <= parameter.DateEnd
                && x.IsPaid == parameter.IsPaid
                && (parameter.BuyerId == null || x.BuyerId == parameter.BuyerId))
            .ToModel();
    }

    public void Update(Invoice invoice) {
        _context.Invoices
            .Where(x => x.Id == invoice.Id)
            .ExecuteUpdate(u => u
                .SetProperty(p => p.Date, invoice.Date)
                .SetProperty(p => p.Total, invoice.Total)
                .SetProperty(p => p.Discount, invoice.Discount)
                .SetProperty(p => p.TotalWithDiscount, invoice.TotalWithDiscount)
                .SetProperty(p => p.IsPaid, invoice.IsPaid)
            );
    }
}
