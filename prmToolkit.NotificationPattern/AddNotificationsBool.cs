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
        /// Dada uma bool, adicione uma notificação se for verdadeira
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma bool, adicione uma notificação se for verdadeira</returns>
        public AddNotifications<T> IfTrue(Expression<Func<T, bool>> selector, string message = "")
        {
            var data = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (data == true)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfTrue.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada uma bool, adicione uma notificação se for falso
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma bool, adicione uma notificação se for falso</returns>
        public AddNotifications<T> IfFalse(Expression<Func<T, bool>> selector, string message = "")
        {
            var data = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (data == false)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfFalse.ToFormat(name) : message);

            return this;
        }


    }
}