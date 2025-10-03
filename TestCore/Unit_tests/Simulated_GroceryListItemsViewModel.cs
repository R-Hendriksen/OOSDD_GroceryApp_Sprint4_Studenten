using Grocery.Core.Models;
using static TestCore.UC13.Test_UC13;

namespace TestCore.UC13
{
    public static class Simulated_GroceryListItemsViewModel
    {
        public static bool ShowBoughtProducts(int clientId)
        {
            Client? client = ClientList.FirstOrDefault(c => c.Id == clientId);
            if (client?.Role != Role.Admin) return false;
            return true;

            //await Shell.Current.GoToAsync(nameof(Views.BoughtProductsView));
        }
    }
}
