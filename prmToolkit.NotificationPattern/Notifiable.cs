using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace prmToolkit.NotificationPattern
{
    public abstract class Notifiable : INotifiable
    {
        private readonly List<Notification> _notifications;

        protected Notifiable() { _notifications = new List<Notification>(); }

        public IReadOnlyCollection<Notification> Notifications => _notifications;

        /// <summary>
        /// Adiciona uma notificação
        /// </summary>
        /// <param name="property">Nome da propriedade que está sendo testada</param>
        /// <param name="message">Mensagem personalizada</param>
        public void AddNotification(string property, string message)
        {
            _notifications.Add(new Notification(property, message));
        }

        /// <summary>
        /// Adiciona uma notificação na classe principal
        /// </summary>
        /// <param name="notification">Objeto de notificação que deseja adicionar</param>
        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        /// <summary>
        /// Adiciona uma lista de notificações na classe principal
        /// </summary>
        /// <param name="notifications">Lista de notificações que deseja adicionar</param>
        public void AddNotifications(IReadOnlyCollection<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        /// <summary>
        /// Adiciona notificações de uma coleção de objetos notificaveis na classe principal
        /// </summary>
        /// <param name="objects">Objetos notificáveis</param>
        public void AddNotifications(params Notifiable[] objects)
        {
            objects.ToList().ForEach(x => _notifications.AddRange(x.Notifications));
        }

        /// <summary>
        /// Adiciona notificações de coleções de coleção de objetos notificaveis na classe principal
        /// </summary>
        /// <param name="objects">Objetos notificáveis</param>
        public void AddNotifications(params IEnumerable<Notifiable>[] objects)
        {
            objects.ToList().ForEach(x => x.ToList().ForEach(n => _notifications.AddRange(n.Notifications)));
        }

        /// <summary>
        /// Adiciona uma lista de notificações na classe principal
        /// </summary>
        /// <param name="notifications">Lista de notificações que deseja adicionar</param>
        public void AddNotifications(IList<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        /// <summary>
        /// Adiciona uma lista de notificações na classe principal
        /// </summary>
        /// <param name="notifications">Lista de notificações que deseja adicionar</param>
        public void AddNotifications(ICollection<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        /// <summary>
        /// Limpa todas as notificações do objeto
        /// </summary>
        public void ClearNotifications()
        {
            _notifications.Clear();
        }

        public void Dispose()
        {
            _notifications.Clear();

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Verifica se o objeto notificável é valido
        /// </summary>
        /// <returns>Retornar true quando o objeto é valido, ou seja, não possui notificações.</returns>
        public bool IsValid() => _notifications.Count == 0;
    }
}