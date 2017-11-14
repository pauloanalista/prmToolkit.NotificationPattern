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
        /// Dado um int, adicione uma notificação se seu valor for menor que o parâmetro min
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se seu valor for menor que o parâmetro min</returns>
        public AddNotifications<T> IfLowerThan(Expression<Func<T, int>> selector, int min, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiableObject);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < min)
                _notifiableObject.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLowerThan.ToFormat(name, min) : message);

            return this;
        }

        /// <summary>
        /// Dada um int, adicione uma notificação se seu valor for maior que o parâmetro max
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um int, adicione uma notificação se seu valor for maior que o parâmetro max</returns>
        public AddNotifications<T> IfGreaterThan(Expression<Func<T, int>> selector, int max, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiableObject);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val > max)
                _notifiableObject.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfGreaterThan.ToFormat(name, max) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for maior ou igual ao parametro passado
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se for maior ou igual ao parametro passado</returns>
        public AddNotifications<T> IfGreaterOrEqualsThan(Expression<Func<T, int>> selector, int number, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiableObject);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val >= number)
                _notifiableObject.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfGreaterOrEqualsThan.ToFormat(name, number) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for menor ou igual ao parametro passado
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se for menor ou igual ao parametro passado</returns>
        public AddNotifications<T> IfLowerOrEqualsThan(Expression<Func<T, int>> selector, int number, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiableObject);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val <= number)
                _notifiableObject.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLowerOrEqualsThan.ToFormat(name, number) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se não estiver entre alguns dois valores
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se não estiver entre alguns dois valores</returns>
        public AddNotifications<T> IfNotRange(Expression<Func<T, int>> selector, int a, int b, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiableObject);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < a || val > b)
                _notifiableObject.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotRange.ToFormat(name, a, b) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se estiver entre alguns dois valores
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se estiver entre alguns dois valores</returns>
        public AddNotifications<T> IfRange(Expression<Func<T, int>> selector, int a, int b, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiableObject);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val > a && val < b)
                _notifiableObject.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfRange.ToFormat(name, a, b) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for igual a
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for igual a</returns>
        public AddNotifications<T> IfNotAreEquals(Expression<Func<T, int>> selector, int value, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiableObject);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val != value)
                _notifiableObject.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotAreEquals.ToFormat(name, value) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for igual a
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se for igual a</returns>
        public AddNotifications<T> IfAreEquals(Expression<Func<T, int>> selector, int value, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiableObject);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == value)
                _notifiableObject.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfAreEquals.ToFormat(name, value) : message);

            return this;
        }

        /// <summary>
        /// Dada um int, adicione uma notificação se for igual a zero
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um int, adicione uma notificação se for igual a zero</returns>
        public AddNotifications<T> IfEqualsZero(Expression<Func<T, int>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiableObject);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == 0)
                _notifiableObject.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfEqualsZero.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada um objeto int, adicione uma notificação se for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto int, adicione uma notificação se for igual null</returns>
        public AddNotifications<T> IfNull(Expression<Func<T, int?>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiableObject);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == null)
                _notifiableObject.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNull.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada um objeto int, adicione uma notificação se não for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto int, adicione uma notificação se não for igual null</returns>
        public AddNotifications<T> IfNotNull(Expression<Func<T, int?>> selector, string message = "")
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
        /// Dado um int, adicione uma notificação se seu valor for menor que o parâmetro min
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="min">Informe o menor valor</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se seu valor for menor que o parâmetro min</returns>
        public AddNotifications<T> IfLowerThan(int val, int min, string objectName, string message = "")
        {
            if (val < min)
                _notifiableObject.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfLowerThan.ToFormat(objectName, min) : message);

            return this;
        }

        /// <summary>
        /// Dada um int, adicione uma notificação se seu valor for maior que o parâmetro max
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="max">Informe o valor máximo</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um int, adicione uma notificação se seu valor for maior que o parâmetro max</returns>
        public AddNotifications<T> IfGreaterThan(int val, int max, string objectName, string message = "")
        {
            if (val > max)
                _notifiableObject.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfGreaterThan.ToFormat(objectName, max) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for maior ou igual ao parametro passado
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="number">Valor a ser comparado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se for maior ou igual ao parametro passado</returns>
        public AddNotifications<T> IfGreaterOrEqualsThan(int val, int number, string objectName, string message = "")
        {
            if (val >= number)
                _notifiableObject.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfGreaterOrEqualsThan.ToFormat(objectName, number) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for menor ou igual ao parametro passado
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="number">Valor a ser comparado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se for menor ou igual ao parametro passado</returns>
        public AddNotifications<T> IfLowerOrEqualsThan(int val, int number, string objectName, string message = "")
        {
            if (val <= number)
                _notifiableObject.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfLowerOrEqualsThan.ToFormat(objectName, number) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se não estiver entre alguns dois valores
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="a">Menor valor</param>
        /// <param name="b">Maior valor</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se não estiver entre alguns dois valores</returns>
        public AddNotifications<T> IfNotRange(int val, int a, int b, string objectName, string message = "")
        {
            if (val < a || val > b)
                _notifiableObject.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotRange.ToFormat(objectName, a, b) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se estiver entre alguns dois valores
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="a">Menor valor</param>
        /// <param name="b">Maior valor</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se estiver entre alguns dois valores</returns>
        public AddNotifications<T> IfRange(int val, int a, int b, string objectName, string message = "")
        {
            if (val > a && val < b)
                _notifiableObject.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfRange.ToFormat(objectName, a, b) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for igual a
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="val">Valor a ser comparado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for igual a</returns>
        public AddNotifications<T> IfNotAreEquals(int val, int value, string objectName, string message = "")
        {
            if (val != value)
                _notifiableObject.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotAreEquals.ToFormat(objectName, value) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for igual a
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="val">Valor a ser comparado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se for igual a</returns>
        public AddNotifications<T> IfAreEquals(int val, int value, string objectName, string message = "")
        {
            if (val == value)
                _notifiableObject.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfAreEquals.ToFormat(objectName, value) : message);

            return this;
        }

        /// <summary>
        /// Dada um int, adicione uma notificação se for igual a zero
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um int, adicione uma notificação se for igual a zero</returns>
        public AddNotifications<T> IfEqualsZero(int val, string objectName, string message = "")
        {
            if (val == 0)
                _notifiableObject.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfEqualsZero.ToFormat(objectName) : message);

            return this;
        }

        /// <summary>
        /// Dada um objeto int, adicione uma notificação se for igual null
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto int, adicione uma notificação se for igual null</returns>
        public AddNotifications<T> IfNull(int? val, string objectName, string message = "")
        {
            
            if (val == null)
                _notifiableObject.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNull.ToFormat(objectName) : message);

            return this;
        }

        /// <summary>
        /// Dada um objeto int, adicione uma notificação se não for igual null
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto int, adicione uma notificação se não for igual null</returns>
        public AddNotifications<T> IfNotNull(int? val, string objectName, string message = "")
        {
            if (val != null)
                _notifiableObject.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotNull.ToFormat(objectName) : message);

            return this;
        }
        #endregion
    }
}