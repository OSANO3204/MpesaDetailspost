using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsAppService.BLL.Data;
using WhatsAppService.BLL.Iservices;
using WhatsAppService.BLL.Mapper;
using WhatsAppService.Core.Models;
using WhatsAppService.Core.ViewModel;
using Microsoft.AspNetCore.Http;


namespace WhatsAppService.BLL.Services
{
    public class TransactionActions : ITransactionActions
    {
        private readonly IMapper _imapper;
        private readonly WhatsAppServiceContext _context;
        public TransactionActions(WhatsAppServiceContext context,
            IMapper imapper

            )
        {
            _context = context;
            _imapper = imapper;
        }


        //add transaction 
        public async Task<MpesaTransaction> AddTransactions(MpesaTransactionViewModel vm)
        {
            MpesaTransaction newtransaction = new MpesaTransaction();

            _imapper.Map(vm, newtransaction);
            _context.mpesatransaction.Add(newtransaction);
            await _context.SaveChangesAsync();
            return newtransaction;
        }

        //get all transactions
        public async Task<IEnumerable<MpesaTransaction>> GetTransactions()
        {
            var getAll = await _context.mpesatransaction.ToListAsync();
            return getAll;
        }


        //get single transaction
        public async Task<MpesaTransaction> GetTransaction(int id)
        {
            return await _context.mpesatransaction.FirstOrDefaultAsync(x => x.Id == id);
        }


        //delete transaction
        public async Task RemoveTrasnaction(int id)
        {
            var gettarnsactionid = await _context.mpesatransaction.FirstOrDefaultAsync(x => x.Id == id);
            if (gettarnsactionid != null)
            {
                _context.mpesatransaction.Remove(gettarnsactionid);
                await _context.SaveChangesAsync();
            }
        }
        
        //search Transaction 
        public async Task<IEnumerable<MpesaTransaction>> Search(string name, int id ,string phone)
        {
            IQueryable<MpesaTransaction> query = _context.mpesatransaction;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Name.Contains(name)|| e.PhoneNumber.Contains(phone));
            }

            if (name != null & phone !=null)
            {
                query = query.Where(e => e.Name == name);
            }

            return await query.ToListAsync();
        }
    }
}


      

