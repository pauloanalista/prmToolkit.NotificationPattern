using prmToolkit.NotificationPattern.Extensions;
using prmToolkit.NotificationPattern.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace prmToolkit.NotificationPattern
{
    public partial class AddNotifications<T> where T : Notifiable
    {
        #region OBJETOS COMPLEXOS
        /// <summary>
        /// Dada uma coleção, adicione uma notificação se for nula
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma coleção, adicione uma notificação se for nula</returns>
        public AddNotifications<T> IfCollectionIsNull(Expression<Func<T, IEnumerable>> selector, string message = "")
        {
            IEnumerable colectionValue = selector.Compile().Invoke(_notifiableObject);
            var name = ((MemberExpression)selector.Body).Member.Name;


            if (colectionValue == null)
            {
                _notifiableObject.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfCollectionIsNull.ToFormat(name) : message);
            }

            return this;
        }

        /// <summary>
        /// Dada uma coleção, adicione uma notificação se for nula ou não tenha itens
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma coleção, adicione uma notificação se for nula ou não tenha itens</returns>
        public AddNotifications<T> IfCollectionIsNullOrEmpty(Expression<Func<T, IEnumerable<T>>> selector, string message = "")
        {
            IEnumerable<T> colectionValue = selector.Compile().Invoke(_notifiableObject);
            var name = ((MemberExpression)selector.Body).Member.Name;


            if (colectionValue == null || colectionValue.ToList().Count <= 0)
            {
                _notifiableObject.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfCollectionIsNullOrEmpty.ToFormat(name) : message);
            }

            return this;
        }
        #endregion

        #region OBJETOS SIMPLES
        /// <summary>
        /// Dada uma coleção, adicione uma notificação se for nula
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma coleção, adicione uma notificação se for nula</returns>
        public AddNotifications<T> IfCollectionIsNull(IEnumerable val, string objectName, string message = "")
        {
            if (val == null)
            {
                _notifiableObject.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfCollectionIsNull.ToFormat(objectName) : message);
            }

            return this;
        }

        /// <summary>
        /// Dada uma coleção, adicione uma notificação se for nula ou não tenha itens
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma coleção, adicione uma notificação se for nula ou não tenha itens</returns>
        public AddNotifications<T> IfCollectionIsNullOrEmpty(IEnumerable<T> val, string objectName, string message = "")
        {
            if (val == null || val.ToList().Count <= 0)
            {
                _notifiableObject.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfCollectionIsNullOrEmpty.ToFormat(objectName) : message);
            }

            return this;
        }
        #endregion
    }
}