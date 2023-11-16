using BookHaven.Domain.Enums;

namespace BookHaven.Domain.ResponseDTO
{
    public class Notification
    {
        public string Message { get; set; }

        public NotificationType Type { get; set; }
    }
}
