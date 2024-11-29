namespace OOP_LABA9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int timerMinus = 0;
            // Создание контейнеров для разных типов уведомлений
            var emailRepository = new NotificationRepository<EmailNotification>();
            var smsRepository = new NotificationRepository<SMSNotification>();
            var pushRepository = new NotificationRepository<PushNotification>();
            // Добавление email-уведомлений
            emailRepository.Add(new EmailNotification("Email 1", DateTime.Now.AddMinutes(timerMinus--), "polikarpov.iva@gmail.com"));
            emailRepository.Add(new EmailNotification("Email 2", DateTime.Now.AddMinutes(timerMinus--), "minulbaev@gmail.com"));
            // Добавление SMS-уведомлений
            smsRepository.Add(new SMSNotification("SMS 1", DateTime.Now.AddMinutes(timerMinus--), "+799495598"));
            smsRepository.Add(new SMSNotification("SMS 2", DateTime.Now.AddMinutes(timerMinus--), "+724356324"));
            // Добавление push-уведомлений
            pushRepository.Add(new PushNotification("Push 1", DateTime.Now.AddMinutes(timerMinus--), "Приложение 1"));
            pushRepository.Add(new PushNotification("Push 2", DateTime.Now.AddMinutes(timerMinus--), "Приложение 2"));
            Console.WriteLine("\nПолучение уведомления по ID:");
            var emailNotification = emailRepository.FindById(1);
            Console.WriteLine(emailNotification != null ? emailNotification.ToString() : "Уведомление не найдено");
            Console.WriteLine("+++");
            // Проверка наличия уведомления
            var testNotification = new EmailNotification("Test Email", DateTime.Now, "test@example.com");
            Console.WriteLine("\nПроверка наличия уведомления:");
            Console.WriteLine(emailRepository.Exists(testNotification) ? "Уведомление найдено" : "Уведомление отсутствует");
            Console.WriteLine("+++");
            // Отображение всех email-уведомлений
            Console.WriteLine("\nEmail-уведомления:");
            foreach (var notification in emailRepository.GetAllNotifications())
            {
                Console.WriteLine(notification);
            }
            Console.WriteLine("+++");
            // Сортировка email-уведомлений по времени и их отображение
            Console.WriteLine("\nСортировка email-уведомлений:");
            emailRepository.OrderByTimestamp();
            foreach (var notification in emailRepository.GetAllNotifications())
            {
                Console.WriteLine(notification);
            }
            Console.WriteLine("+++");
            // Демонстрация ковариантности
            Console.WriteLine("\nДемонстрация ковариантности:");
            INotificationProvider<Notification> notificationProvider = new
            NotificationProvider<EmailNotification>(
            new EmailNotification("Ковариантное Email-уведомление", DateTime.Now, "covariant@example.com")
            );
            Console.WriteLine(notificationProvider.CreateNotification());
        }
    }
}

