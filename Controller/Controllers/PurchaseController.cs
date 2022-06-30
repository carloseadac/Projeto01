using Microsoft.AspNetCore.Mvc;
using DTO;
using DAO;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;

namespace Controller.Controllers;

[ApiController]
[Route("purchase")]
public class PurchaseController : ControllerBase
{
    [HttpGet]
    [Route("get/client")]
    public List<object> getClientPurchase()
    {
        var ClientId = Lib.GetIdFromRequest( Request.Headers["Authorization"].ToString());
        var clientPurchase = Model.Purchase.getClientPurchases(ClientId);
        return clientPurchase;
    }

    [HttpGet]
    [Route("get/store/{CNPJ}")]
    public object getStorePurchase(string CNPJ){
        var storePurchase = Model.Purchase.getStorePurchases(CNPJ);
        return storePurchase;
    }

    
    // public Object makePurchase(PurchaseDTO purchaseDTO, int clientID, int storeID, int productID){
    //     var purchase = Model.Purchase.convertDTOToModel(purchaseDTO);
    //     var id = purchase.save();
    //     return new{
    //         date_purchase = purchaseDTO.date_purchase,
    //         purchase_value = purchaseDTO.purchase_value,
    //         payment_type = purchaseDTO.payment_type,
    //         purchase_status = purchaseDTO.purchase_status,
    //         number_comfirmation = purchaseDTO.number_confirmation,
    //         number_nf = purchaseDTO.number_nf,
    //         products = purchaseDTO.products,
    //         store = purchaseDTO.store,
    //         client = purchaseDTO.client,
    //         id = id
    //     };
    // }
    [HttpPost]
    [Route("make")]
     public IActionResult makePurchase(RequestPurchaseDTO purchase)
    {

        var ClientId = Lib.GetIdFromRequest(Request.Headers["Authorization"].ToString());
        var purchaseModel = new Model.Purchase();
        var ai = purchaseModel.save(ClientId, purchase.idProduct, purchase.idStore, purchase.date_purchase, purchase.payment_type, purchase.purchase_status, purchase.number_confirmation, purchase.number_nf);
        Console.WriteLine(purchaseModel);
        Console.WriteLine(ai);

        var result = new ObjectResult(ai);
        return result;
    }
}