using System;
using System.Collections.Generic;

namespace OOP_LABA9
{
    public class NotificationRepository<T> where T : Notification, IComparable<T>
    {
        private List<T> _notifications = new(); // Список уведомлений

        // Добавление уведомления в контейнер
        public void Add(T notification)
        {
            _notifications.Add(notification);
        }

        // Поиск уведомления по ID
        public Notification? FindById(int id)
        {
            return _notifications.Find(n => n.NotificationId == id);
        }

        // Проверка наличия конкретного уведомления
        public bool Exists(Notification notification)
        {
            return _notifications.Contains(notification);
        }

        // Сортировка уведомлений по времени
        public void OrderByTimestamp()
        {
            _notifications.Sort();
        }

        // Получение всех уведомлений
        public IEnumerable<T> GetAllNotifications()
        {
            return _notifications;
        }
    }

    // Интерфейс для источника уведомлений с ковариантностью
    public interface INotificationProvider<out T> where T : Notification
    {
        T CreateNotification(); // Метод для создания уведомления
    }

    // Реализация источника уведомлений
    public class NotificationProvider<T> : INotificationProvider<T> where T : Notification
    {
        private readonly T _notification; // Сохранённое уведомление

        public NotificationProvider(T notification)
        {
            _notification = notification;
        }

        public T CreateNotification()
        {
            return _notification; // Возврат уведомления
        }
    }
}


