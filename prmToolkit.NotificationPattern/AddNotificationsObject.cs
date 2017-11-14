using prmToolkit.NotificationPattern.Extensions;
using prmToolkit.NotificationPattern.Resources;
using System;
using System.Linq.Expressions;

namespace prmToolkit.NotificationPattern
{
    public partial class AddNotifications<T> where T : Notifiable
    {
        #region OBJETOS COMPLEXOS
        /// <summary>
        /// Dada um objeto, adicione uma notificação se for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto, adicione uma notificação se for igual null</returns>
        public AddNotifications<T> IfNull(Expression<Func<T, object>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiableObject);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == null)
                _notifiableObject.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNull.ToFormat(name) : message);

            return this;
        }
        /// <summary>
        /// Dada um objeto, adicione uma notificação se não for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto, adicione uma notificação se não for igual null</returns>
        public AddNotifications<T> IfNotNull(Expression<Func<T, object>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiableObject);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val != null)
                _notifiableObject.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotNull.ToFormat(name) : message);

            return this;
        }
        #endregion

        #region OBJETOS SIMPLES
        /// <summary>
        /// Dada um objeto, adicione uma notificação se for igual null
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto, adicione uma notificação se for igual null</returns>
        public AddNotifications<T> IfNull(object val, string objectName, string message = "")
        {
            if (val == null)
                _notifiableObject.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNull.ToFormat(objectName) : message);

            return this;
        }
        /// <summary>
        /// Dada um objeto, adicione uma notificação se não for igual null
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto, adicione uma notificação se não for igual null</returns>
        public AddNotifications<T> IfNotNull(object val, string objectName, string message = "")
        {
            if (val != null)
                _notifiableObject.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotNull.ToFormat(objectName) : message);

            return this;
        }
        #endregion


    }
}