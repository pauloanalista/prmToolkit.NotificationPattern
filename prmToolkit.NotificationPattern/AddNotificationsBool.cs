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
        /// Dada uma bool, adicione uma notificação se for verdadeira
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma bool, adicione uma notificação se for verdadeira</returns>
        public AddNotifications<T> IfTrue(Expression<Func<T, bool>> selector, string message = "")
        {
            var data = selector.Compile().Invoke(_notifiableObject);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (data == true)
                _notifiableObject.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfTrue.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada uma bool, adicione uma notificação se for falso
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma bool, adicione uma notificação se for falso</returns>
        public AddNotifications<T> IfFalse(Expression<Func<T, bool>> selector, string message = "")
        {
            var data = selector.Compile().Invoke(_notifiableObject);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (data == false)
                _notifiableObject.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfFalse.ToFormat(name) : message);

            return this;
        }
        #endregion

        #region OBJETOS SIMPLES
        /// <summary>
        /// Dada uma bool, adicione uma notificação se for verdadeira
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma bool, adicione uma notificação se for verdadeira</returns>
        public AddNotifications<T> IfTrue(bool val, string objectName, string message = "")
        {
            if (val == true)
                _notifiableObject.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfTrue.ToFormat(objectName) : message);

            return this;
        }

        /// <summary>
        /// Dada uma bool, adicione uma notificação se for falso
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma bool, adicione uma notificação se for falso</returns>
        
        public AddNotifications<T> IfFalse(bool val, string objectName, string message = "")
        {
            
            if (val == false)
                _notifiableObject.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfFalse.ToFormat(objectName) : message);

            return this;
        }
        #endregion
    }
}