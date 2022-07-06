using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WhatsAppService.BLL.Iservices;
using WhatsAppService.Core.Models;
using WhatsAppService.Core.ViewModel;

namespace WhasAppService.Api.Controllers
{
    [Route("api/[controller]",Name ="Transaction")]
    [ApiController]
    [Authorize]
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
        [Authorize]
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

        public async Task<IActionResult> Gettransaction(int id)
        {
            var getSingleTransaction = await _itansactionActions.GetTransaction(id);

            if (getSingleTransaction == null)
            {
                return StatusCode(1200, " This record does not  exist");
            }
            return Ok(getSingleTransaction);


        }

        //Remove transaction  by id
        [HttpDelete]
        [Route("DeleteTransaction")]
        public async Task<IActionResult> RemoveTransaction(int id)
        {
            try
            {
                var transactiontodelete = await _itansactionActions.GetTransaction(id);
                if (transactiontodelete == null)
                {
                    return NotFound($"The transaction with id '{id}' is not found");
                }
                var deletedtransaction = _itansactionActions.RemoveTrasnaction(id);
                return Ok(" Transaction deleted ");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                      "Error deleting transaction  record");
            }

        }


        //search transactions
        [HttpGet]
        [Route("getTransactionByPaybill")]

        public async Task<IActionResult> GetTxnByPaybill(string PaybillNumber = "Paybill Number ")
        {

            var txnbypaybil = Ok(await _itansactionActions.GetTxnByPaybill(PaybillNumber));
            if (txnbypaybil == null)
                return BadRequest(new { Message = "This paybill number does not exist" });
            return Ok(txnbypaybil);
        }


        //Get transaction by name
        [HttpGet]
        [Route("GetTransactionByName")]
        public async Task<IActionResult> SearchName(string name)
        {
            var serachnames = await _itansactionActions.SearchName(name);
            return Ok(serachnames);


        }
    }
}
 