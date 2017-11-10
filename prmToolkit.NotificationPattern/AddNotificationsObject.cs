using prmToolkit.NotificationPattern.Extensions;
using prmToolkit.NotificationPattern.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace prmToolkit.NotificationPattern
{
    public partial class AddNotifications<T> where T : Notifiable
    {
        /// <summary>
        /// Dada um objeto, adicione uma notificação se for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto, adicione uma notificação se for igual null</returns>
        public AddNotifications<T> IfNull(Expression<Func<T, object>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == null)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNull.ToFormat(name) : message);

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
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val != null)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotNull.ToFormat(name) : message);

            return this;
        }

        #region VALIDANDO OBJETOS QUE NAO SÃO NOTIFICAVEIS
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="objectName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public AddNotifications<T> IfNull(object obj, string objectName, string message)
        {
            if (obj == null)
            {
                _validatable.AddNotification(objectName, message);
            }
            return this;
        }


        #endregion
    }
}