using System.Runtime.CompilerServices;
using Newtonsoft.Json;

public class PurchaisManager
{

    private List<Purchase> _purchases;
    private int prossimoId;

    public PurchaisManager(List<Purchase> purchase)
    {
        _purchases = purchase;
        prossimoId = 1;
        foreach (var items in _purchases)
        {
            if (items.Id >= prossimoId)
            {
                prossimoId = items.Id + 1;
            }
        }
    }

    public void GeneraPurchase(Purchase purchase)
    {
        purchase.Id = prossimoId;
        prossimoId++;
        _purchases.Add(purchase); // quella private
    }

    public List<Purchase> OttieniPurchases()
    {
        return _purchases;
    }

}
