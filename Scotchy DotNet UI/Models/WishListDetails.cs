using Scotch.Model;
using WishList.Model;

namespace WishListDetails.Model
{
    public class WishListDetailsDTO
    {
        public WishListDTO wishlist { get; set; }
        public ScotchDTO[] scotches { get; set; }
    }
}
