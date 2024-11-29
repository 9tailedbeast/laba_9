using System;
using System.Collections.Generic;

namespace OOP_LABA9
{
    // Базовый класс для всех уведомлений
    public class Notification : IComparable<Notification>
    {
        private static int _idCounter = 0; // Счётчик для генерации уникальных ID
        public int NotificationId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public Notification(string content, DateTime createdAt)
        {
            NotificationId = ++_idCounter; // Увеличение счётчика и присвоение ID
            Content = content;
            CreatedAt = createdAt;
        }

        // Реализация интерфейса IComparable для сортировки уведомлений по времени
        public int CompareTo(Notification? other)
        {
            if (other is null) throw new ArgumentException("Некорректное значение параметра");
            return CreatedAt.CompareTo(other.CreatedAt);
        }

        public override string ToString()
        {
            return $"ID уведомления: {NotificationId}\nСообщение: {Content}\nДата создания: {CreatedAt}";
        }
    }


    public class EmailNotification : Notification
    {
        public string RecipientEmail { get; set; }

        public EmailNotification(string content, DateTime createdAt, string recipientEmail)
            : base(content, createdAt)
        {
            RecipientEmail = recipientEmail;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nEmail получателя: {RecipientEmail}\n";
        }
    }


    public class SMSNotification : Notification
    {
        public string Phone { get; set; }

        public SMSNotification(string content, DateTime createdAt, string phone)
            : base(content, createdAt)
        {
            Phone = phone;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nНомер телефона: {Phone}\n";
        }
    }


    public class PushNotification : Notification
    {
        public string Application { get; set; }

        public PushNotification(string content, DateTime createdAt, string application)
            : base(content, createdAt)
        {
            Application = application;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nПриложение: {Application}\n";
        }
    }
}


