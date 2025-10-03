using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCore.UC13
{
    public static class Test_UC13
    {
        public static List<Client> ClientList { get; set; } = [
                new Client(1, "M.J. Curie", "user1@mail.com", "IunRhDKa+fWo8+4/Qfj7Pg==.kDxZnUQHCZun6gLIE6d9oeULLRIuRmxmH2QKJv2IM08=", Role.None),
                new Client(2, "H.H. Hermans", "user2@mail.com", "dOk+X+wt+MA9uIniRGKDFg==.QLvy72hdG8nWj1FyL75KoKeu4DUgu5B/HAHqTD2UFLU=", Role.None),
                new Client(3, "A.J. Kwak", "user3@mail.com", "sxnIcZdYt8wC8MYWcQVQjQ==.FKd5Z/jwxPv3a63lX+uvQ0+P7EuNYZybvkmdhbnkIHA=", Role.Admin)
            ];

        private static void Setup()
        {
        }

        // Happy Flow
        [TestCase(3)]
        public static void TestShowBoughtProducts_ReturnsTrue(int clientId)
        {
            Assert.That(Simulated_GroceryListItemsViewModel.ShowBoughtProducts(clientId), Is.True);
        }

        [TestCase(1)]
        [TestCase(7)]
        public static void TestShowBoughtProducts_ReturnsFalse(int clientId)
        {
            Assert.That(Simulated_GroceryListItemsViewModel.ShowBoughtProducts(clientId), Is.False);
        }

    }
    
}

    
