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
        /// Dado um Enum, adiciona notificação caso seu valor não esteja definido dentro do próprio Enum
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um Enum, adiciona notificação caso seu valor não esteja definido dentro do próprio Enum</returns>
        public AddNotifications<T> IfEnumInvalid(Expression<Func<T, System.Enum>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiableObject);
            var name = string.Empty;

            var op = ((UnaryExpression)selector.Body).Operand;
            name = ((MemberExpression)op).Member.Name;

            if (!val.IsEnumValid())
                _notifiableObject.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfEnumInvalid.ToFormat(name) : message);

            return this;
        }
        #endregion

        #region OBJETOS SIMPLES
        /// <summary>
        /// Dado um Enum, adiciona notificação caso seu valor não esteja definido dentro do próprio Enum
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um Enum, adiciona notificação caso seu valor não esteja definido dentro do próprio Enum</returns>
        public AddNotifications<T> IfEnumInvalid(System.Enum val, string objectName, string message = "")
        {
            if (!val.IsEnumValid())
                _notifiableObject.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfEnumInvalid.ToFormat(objectName) : message);

            return this;
        }
        #endregion

    }
}