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
        /// Dado um double, adicione uma notificação se seu valor for menor que o parâmetro min
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um double, adicione uma notificação se seu valor for menor que o parâmetro min</returns>
        public AddNotifications<T> IfLowerThan(Expression<Func<T, double>> selector, double min, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiableObject);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < min)
                _notifiableObject.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLowerThan.ToFormat(name, min) : message);

            return this;
        }

        /// <summary>
        /// Dada um double, adicione uma notificação se seu valor for maior que o parâmetro max
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um double, adicione uma notificação se seu valor for maior que o parâmetro max</returns>
        public AddNotifications<T> IfGreaterThan(Expression<Func<T, double>> selector, double max, string message = "")
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
        public AddNotifications<T> IfGreaterOrEqualsThan(Expression<Func<T, double>> selector, double number, string message = "")
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
        public AddNotifications<T> IfLowerOrEqualsThan(Expression<Func<T, double>> selector, double number, string message = "")
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
        public AddNotifications<T> IfNotRange(Expression<Func<T, double>> selector, double a, double b, string message = "")
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
        public AddNotifications<T> IfRange(Expression<Func<T, double>> selector, double a, double b, string message = "")
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
        public AddNotifications<T> IfNotAreEquals(Expression<Func<T, double>> selector, double value, string message = "")
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
        public AddNotifications<T> IfAreEquals(Expression<Func<T, double>> selector, double value, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiableObject);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == value)
                _notifiableObject.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfAreEquals.ToFormat(name, value) : message);

            return this;
        }

        /// <summary>
        /// Dada um objeto double, adicione uma notificação se for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto double, adicione uma notificação se for igual null</returns>
        public AddNotifications<T> IfNull(Expression<Func<T, double?>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiableObject);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == null)
                _notifiableObject.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNull.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada um objeto double, adicione uma notificação se não for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto double, adicione uma notificação se não for igual null</returns>
        public AddNotifications<T> IfNotNull(Expression<Func<T, double?>> selector, string message = "")
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
        /// Dado um double, adicione uma notificação se seu valor for menor que o parâmetro min
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um double, adicione uma notificação se seu valor for menor que o parâmetro min</returns>
        public AddNotifications<T> IfLowerThan(double val, double min, string objectName, string message = "")
        {
            if (val < min)
                _notifiableObject.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfLowerThan.ToFormat(objectName, min) : message);

            return this;
        }

        /// <summary>
        /// Dada um double, adicione uma notificação se seu valor for maior que o parâmetro max
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um double, adicione uma notificação se seu valor for maior que o parâmetro max</returns>
        public AddNotifications<T> IfGreaterThan(double val, double max, string objectName, string message = "")
        {
            if (val > max)
                _notifiableObject.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfGreaterThan.ToFormat(objectName, max) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for maior ou igual ao parametro passado
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se for maior ou igual ao parametro passado</returns>
        public AddNotifications<T> IfGreaterOrEqualsThan(double val, double number, string objectName, string message = "")
        {
            if (val >= number)
                _notifiableObject.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfGreaterOrEqualsThan.ToFormat(objectName, number) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for menor ou igual ao parametro passado
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se for menor ou igual ao parametro passado</returns>
        public AddNotifications<T> IfLowerOrEqualsThan(double val, double number, string objectName, string message = "")
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
        public AddNotifications<T> IfNotRange(double val, double a, double b, string objectName, string message = "")
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
        public AddNotifications<T> IfRange(double val, double a, double b, string objectName, string message = "")
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
        public AddNotifications<T> IfNotAreEquals(double val, double value, string objectName, string message = "")
        {
            if (val != value)
                _notifiableObject.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotAreEquals.ToFormat(objectName, value) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for igual a
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="value">Valor a ser comparado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se for igual a</returns>
        public AddNotifications<T> IfAreEquals(double val, double value, string objectName, string message = "")
        {
            if (val == value)
                _notifiableObject.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfAreEquals.ToFormat(objectName, value) : message);

            return this;
        }

        /// <summary>
        /// Dada um objeto double, adicione uma notificação se for igual null
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto double, adicione uma notificação se for igual null</returns>
        public AddNotifications<T> IfNull(double? val, string objectName, string message = "")
        {
            if (val == null)
                _notifiableObject.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNull.ToFormat(objectName) : message);

            return this;
        }

        /// <summary>
        /// Dada um objeto double, adicione uma notificação se não for igual null
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto double, adicione uma notificação se não for igual null</returns>
        public AddNotifications<T> IfNotNull(double? val, string objectName, string message = "")
        {
            if (val != null)
                _notifiableObject.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotNull.ToFormat(objectName) : message);

            return this;
        }
        #endregion
    }
}