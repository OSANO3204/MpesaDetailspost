using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsAppService.BLL.Iservices;
using WhatsAppService.Core.Models;
using WhatsAppService.Core.ViewModel;

namespace WhasAppService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MpesaTransactionController : ControllerBase
    {

        private readonly ITransactionActions _itansactionActions;
        public MpesaTransactionController(ITransactionActions itansactionActions)
        {
            _itansactionActions = itansactionActions;
        }

        //add transactions

        [HttpPost]
        [Route("AddUsers")]

        public async Task<MpesaTransaction> Addtransaction(MpesaTransactionViewModel getvm)
        {
            return await _itansactionActions.AddTransactions(getvm);

        }


        //get all details
        [HttpGet]
        [Route("GetallTransactions")]

        public async Task<IEnumerable<MpesaTransaction>> GetAlltransaction()
        {
            return await _itansactionActions.GetTransactions();
        }


        //get transaction detail
        [HttpGet]
        [Route("GetTransaction")]

        public async Task<MpesaTransaction> Gettransaction(int id )
        { 
            return await _itansactionActions.GetTransaction(id);
        }



        //remove transaction 
        [HttpDelete]
        [Route("DeleteTransaction")]
        public async Task<ActionResult> RemoveTransaction(int id)
        {
            try
            {
                var transactiontodelete = await _itansactionActions.GetTransaction(id);
                if (transactiontodelete == null)
                {
                    return NotFound($"Transaction with Id = {id} not found");
                }
                await _itansactionActions.RemoveTrasnaction(id);
                return Ok(" Transaction deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                      "Error deleting transaction  record");
            }
        }


        //search transactions
        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<MpesaTransaction>>> Search(string name, int id, string phone)
        {
            try
            {
                var result = await _itansactionActions.Search(name, id, phone);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");
            }
        }

        

    }
    }
