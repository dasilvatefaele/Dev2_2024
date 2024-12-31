using System.Runtime.CompilerServices;
using Newtonsoft.Json;

public class PurchaisManager
{

    private List<Purchase> _purchases;
    private int prossimoId;
    PurchaisRepository repoPurchase;

    public PurchaisManager(List<Purchase> purchase)
    {
        _purchases = purchase;
        prossimoId = 1;
        repoPurchase = new PurchaisRepository();
        foreach (var items in _purchases)
        {
            if (items.IdPurchase >= prossimoId)
            {
                prossimoId = items.IdPurchase + 1;
            }
        }
    }

    public void GeneraPurchase(Purchase purchase)
    {
        purchase.IdPurchase = prossimoId;
        prossimoId++;
        _purchases.Add(purchase); // quella private
        repoPurchase.SalvaPurchaseSingolo(purchase);
    }

    public List<Purchase> OttieniPurchases()
    {
        return _purchases;
    }

}
