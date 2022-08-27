namespace Services
{
    public static class PushNotificationService
    {
        public static void Init()
        {
            ServiceResolver.OnServiceInit(true);
        }
        
    }
}