using Microsoft.EntityFrameworkCore;
using SmartSaleApi.Core.Interfaces.Repositories;
using SmartSaleApi.Core.Models;
using SmartSaleApi.DAL.Contexts;
using SmartSaleApi.DAL.Extensions;

namespace SmartSaleApi.DAL.Repositories;

public sealed class InvoiceRepository(
    SmartSaleDbContext context
) : IInvoiceRepository {
    public int Add(Invoice invoice) {
        var buyerEntity = invoice.Buyer.ToEntity();
        var entity = invoice.ToEntity(buyerEntity);
        context.Attach(buyerEntity);
        context.Invoices.Add(entity);
        context.SaveChanges();

        return entity.Id;
    }

    public void Delete(int id) {
        context.Invoices
            .Where(x => x.Id == id)
            .ExecuteDelete();
    }

    public Invoice Get(int id) {
        return context.Invoices
            .AsNoTracking()
            .Include(x => x.Buyer)
            .Include(x => x.InvoiceDetails)
            .FirstOrDefault(x => x.Id == id)?
            .ToModel() ?? throw new ArgumentException($"Не найдена накладная по данному Id = {id}");

    }

    public IEnumerable<Invoice> Get() {
        return context.Invoices
            .AsNoTracking()
            .Include(x => x.Buyer)
            .Include(x => x.InvoiceDetails)
            .ToModel();
    }

    public IEnumerable<Invoice> GetByBuyer(int buyerId) {
        return context.Invoices
            .AsNoTracking()
            .Include(x => x.Buyer)
            .Include(x => x.InvoiceDetails)
            .Where(x => x.BuyerId == buyerId)
            .ToModel();
    }

    public IEnumerable<Invoice> GetByDate(DateTime date) {
        return context.Invoices
            .AsNoTracking()
            .Include(x => x.Buyer)
            .Include(x => x.InvoiceDetails)
            .Where(x => x.Date == date)
            .ToModel();
    }

    public void Update(Invoice invoice) {
        context.Invoices
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
