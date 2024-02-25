namespace Yummy.Server.Application.Orders;

public static class OrderConstants
{
    public static class Status
    {
        public const string Pending = "PENDING";

        public const string Processing = "PROCESSING";

        public const string Shipped = "SHIPPED";

        public const string Delivered = "DELIVERED";

        public const string Cancelled = "CANCELLED";

        public static bool IsValidStatus(string status)
        {
            return status.ToUpper() switch
            {
                Pending => true,
                Processing => true,
                Shipped => true,
                Delivered => true,
                Cancelled => true,
                _ => false,
            };
        }
    }
}