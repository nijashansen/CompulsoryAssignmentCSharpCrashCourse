using PetShop.Infrastructure.SQL;

namespace PetShop.UI.restAPI.Data
{
    public interface IDbInitializer
    {
        void Initialize(PetShopContext context);
    }
}