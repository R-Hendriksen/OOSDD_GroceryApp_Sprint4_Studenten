
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class BoughtProductsService : IBoughtProductsService
    {
        private readonly IGroceryListItemsRepository _groceryListItemsRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IProductRepository _productRepository;
        private readonly IGroceryListRepository _groceryListRepository;
        public BoughtProductsService(IGroceryListItemsRepository groceryListItemsRepository, IGroceryListRepository groceryListRepository, IClientRepository clientRepository, IProductRepository productRepository)
        {
            _groceryListItemsRepository=groceryListItemsRepository;
            _groceryListRepository=groceryListRepository;
            _clientRepository=clientRepository;
            _productRepository=productRepository;
        }
        public List<BoughtProducts> Get(int? productId)
        {
            List<BoughtProducts> productList = new();
            if (productId == null) return productList;

            var allGroceryLists = _groceryListRepository.GetAll();
            foreach (GroceryList groceryList in allGroceryLists)
            {
                GroceryListItem? groceryItem = _groceryListItemsRepository.GetAllOnGroceryListId(groceryList.Id).Find(g => g.ProductId == productId);
                if (groceryItem == null) continue;

                BoughtProducts data = new(_clientRepository.Get(groceryList.ClientId)!, groceryList, groceryItem.Product);
                productList.Add(data);
            }

            return productList;
        }
    }
}
