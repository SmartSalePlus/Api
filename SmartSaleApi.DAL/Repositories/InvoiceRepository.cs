using Microsoft.EntityFrameworkCore;
using SmartSaleApi.Core.InputParameters;
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
        _context.Invoices
            .Where(x => x.Id == id)
            .ExecuteDelete();
    }

    public Invoice Get(int id) {
        var invoice = _context.Invoices
            .AsNoTracking()
            .Include(x => x.Buyer)
            .Include(x => x.InvoiceDetails.OrderBy(d => d.Product.Name))
            .ThenInclude(x => x.Product)
            .Include(x => x.InvoicePayments.OrderBy(p => p.Date))
            .FirstOrDefault(x => x.Id == id);

        ArgumentNullException.ThrowIfNull(invoice);

        return invoice;
    }

    public IEnumerable<Invoice> Get() {
        return _context.Invoices
            .AsNoTracking()
            .Include(x => x.Buyer)
            .Include(x => x.InvoiceDetails.OrderBy(d => d.Product.Name))
            .ThenInclude(x => x.Product);
    }

    public IEnumerable<Invoice> Get(InvoiceInputParameter parameter) {
        return _context.Invoices
            .AsNoTracking()
            .Include(x => x.Buyer)
            .Include(x => x.InvoiceDetails.OrderBy(d => d.Product.Name))
            .ThenInclude(x => x.Product)
            .Where(x => x.Date >= parameter.DateBegin && x.Date <= parameter.DateEnd
                && x.IsPaid == parameter.IsPaid
                && (parameter.BuyerId == 0 || x.BuyerId == parameter.BuyerId));
    }

    public void Update(Invoice invoice) {
        _context.Invoices
            .Where(x => x.Id == invoice.Id)
            .ExecuteUpdate(u => u
                .SetProperty(p => p.IsPaid, invoice.IsPaid)
            );
    }
}