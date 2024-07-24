using ReadyGo.Domain.Entities;
using ReadyGo.Domain.Entities.ViewModels;
using System.IO;

namespace ReadyGo.Service.Interfaces
{
    public interface IInvoiceService
    {
        public MemoryStream OrderInvoice(OrderDetailsViewModel order, string terms);
        public MemoryStream PaymentInvoice(Payment payment, string terms);
        public MemoryStream DeliveryReportyInvoice(DeliveryReportViewModel report, string terms);
        public MemoryStream SettlementSheetInvoice(DeliveryReportViewModel model, string terms);
    }
}
