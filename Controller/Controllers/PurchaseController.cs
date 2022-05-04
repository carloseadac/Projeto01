using Microsoft.AspNetCore.Mvc;
using Model;
using DTO;
namespace Controller.Controllers;

[ApiController]
[Route("purchase")]
public class PurchaseController : ControllerBase
{
    [HttpGet]
    [Route("getClient/{clientID}")]
    public object getClientPurchase(int clientID){
        var clientPurchase = Model.Purchase.getClientPurchases(clientID);
        return clientPurchase;
    }

    [HttpGet]
    [Route("getStore/{storeID}")]
    public object getStorePurchase(int storeID){
        var storePurchase = Model.Purchase.getStorePurchases(storeID);
        return storePurchase;
    }

    [HttpPost]
    [Route("make")]
    public Object makePurchase(PurchaseDTO purchaseDTO, int clientID, int storeID, int productID){
        var purchase = Purchase.convertDTOToModel(purchaseDTO);
        var id = purchase.save();
        return new{
            date_purchase = purchaseDTO.date_purchase,
            purchase_value = purchaseDTO.purchase_value,
            payment_type = purchaseDTO.payment_type,
            purchase_status = purchaseDTO.purchase_status,
            number_comfirmation = purchaseDTO.number_confirmation,
            number_nf = purchaseDTO.number_nf,
            products = purchaseDTO.products,
            store = purchaseDTO.store,
            client = purchaseDTO.client,
            id = id
        };
    }
}