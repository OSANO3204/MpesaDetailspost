using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsAppService.Core.Models;
using WhatsAppService.Core.ViewModel;

namespace WhatsAppService.BLL.Iservices
{
    public interface ITransactionActions
    {   //addtransactions
        public Task<MpesaTransaction> AddTransactions(MpesaTransactionViewModel vm);

        //get transactions
        public Task<IEnumerable<MpesaTransaction>> GetTransactions();

        //get transactions by id
        public Task<MpesaTransaction> GetTransaction(int id);

        //delete a transaction
        public Task RemoveTrasnaction(int id);

        //search transactions
        public Task<IEnumerable<MpesaTransaction>> Search(string name, int id, string phone);
    }
}

