using AsyncReqReplyAPI.Models;

namespace AsyncReqReplyAPI.Utils;

public static class EstimateProductInsert
{
    public static DateTime Calculate(List<Product> products)
    {
        return DateTime.Now.AddMinutes(products.Count);
    }

}