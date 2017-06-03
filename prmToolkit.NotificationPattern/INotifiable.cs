using System.Collections.Generic;
using System.Linq;

namespace prmToolkit.NotificationPattern
{
    public interface INotifiable
    {
        IReadOnlyCollection<Notification> Notifications { get; }

        /// <summary>
        /// Adiciona uma notificação
        /// </summary>
        /// <param name="property">Nome da propriedade que está sendo testada</param>
        /// <param name="message">Mensagem personalizada</param>
        void AddNotification(string property, string message);

        /// <summary>
        /// Adiciona uma notificação
        /// </summary>
        /// <param name="notification">Objeto de notificação que deseja adicionar</param>
        void AddNotification(Notification notification);
        /// <summary>
        /// Adiciona uma lista de notificações
        /// </summary>
        /// <param name="notifications">Lista de notificações que deseja adicionar</param>
        void AddNotifications(IReadOnlyCollection<Notification> notifications);

        /// <summary>
        /// Adiciona uma coleção de objetos notificaveis na classe principal
        /// </summary>
        /// <param name="objects">Objetos notificáveis</param>
        void AddNotifications(params Notifiable[] objects);
        /// <summary>
        /// Adiciona uma lista de notificações
        /// </summary>
        /// <param name="notifications">Lista de notificações que deseja adicionar</param>
        void AddNotifications(IList<Notification> notifications);

        /// <summary>
        /// Adiciona uma lista de notificações
        /// </summary>
        /// <param name="notifications">Lista de notificações que deseja adicionar</param>
        void AddNotifications(ICollection<Notification> notifications);
        /// <summary>
        /// Verifica se o objeto notificável é valido
        /// </summary>
        /// <returns>Retornar true quando o objeto é valido, ou seja, não possui notificações.</returns>
        bool IsValid();

        /// <summary>
        /// Limpa todas as notificações do objeto
        /// </summary>
        void ClearNotifications();
    }
}