using prmToolkit.NotificationPattern.Extensions;
using prmToolkit.NotificationPattern.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace prmToolkit.NotificationPattern
{
    public class AddNotifications<T> where T : Notifiable
    {
        private readonly T _validatable;

        public AddNotifications(T validatable)
        {
            _validatable = validatable;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for nula ou vazia
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNullOrEmpty(Expression<Func<T, string>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (string.IsNullOrEmpty(val))
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNullOrEmpty.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for nula ou vazia ou com espaços em branco
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNullOrWhiteSpace(Expression<Func<T, string>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val))
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNullOrWhiteSpace.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for nula
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotNullOrEmpty(Expression<Func<T, string>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!string.IsNullOrEmpty(val))
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotNullOrEmpty.ToFormat(name) : message);

            return this;
        }

        #region IfNullOrInvalidLength
        /// <summary>
        /// Dada uma string, adicione uma notificação se for nula ou vazia ou com espaços em branco ou seu tamanho seja invalido
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        [Obsolete("Método obsoleto, por favor utilize o método IfNullOrInvalidLength")]
        public AddNotifications<T> IfNullOrEmptyOrInvalidLength(Expression<Func<T, string>> selector, int min, int max, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val) || val.Length < min || val.Length > max)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNullOrInvalidLength.ToFormat(name, min, max) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for nula ou vazia ou com espaços em branco ou seu tamanho seja invalido
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNullOrInvalidLength(Expression<Func<T, string>> selector, int min, int max, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val) || val.Length < min || val.Length > max)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNullOrInvalidLength.ToFormat(name, min, max) : message);

            return this;
        }
        #endregion

        /// <summary>
        /// Dada uma string, adicione uma notificação se seu comprimento for menor que o parâmetro min
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfLengthLowerThan(Expression<Func<T, string>> selector, int min, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!string.IsNullOrEmpty(val) && val.Length < min)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLengthLowerThan.ToFormat(name, min) : message);

            return this;
        }

        #region IfLowerThan
        /// <summary>
        /// Dado um int, adicione uma notificação se seu valor for menor que o parâmetro min
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfLowerThan(Expression<Func<T, int>> selector, int min, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < min)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLowerThan.ToFormat(name, min) : message);

            return this;
        }

        /// <summary>
        /// Dado um float, adicione uma notificação se seu valor for menor que o parâmetro min
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfLowerThan(Expression<Func<T, float>> selector, float min, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < min)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLowerThan.ToFormat(name, min) : message);

            return this;
        }

        /// <summary>
        /// Dado um double, adicione uma notificação se seu valor for menor que o parâmetro min
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfLowerThan(Expression<Func<T, double>> selector, double min, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < min)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLowerThan.ToFormat(name, min) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se seu valor for menor que o parâmetro min
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfLowerThan(Expression<Func<T, decimal>> selector, decimal min, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < min)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLowerThan.ToFormat(name, min) : message);

            return this;
        }

        /// <summary>
        /// Dado um DateTime, adicione uma notificação se seu valor for menor que o parâmetro min
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfLowerThan(Expression<Func<T, DateTime>> selector, DateTime min, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < min)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLowerThan.ToFormat(name, min) : message);

            return this;
        }
        #endregion

        #region IfGreaterThan
        /// <summary>
        /// Dada um int, adicione uma notificação se seu valor for maior que o parâmetro max
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfGreaterThan(Expression<Func<T, int>> selector, int max, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val > max)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfGreaterThan.ToFormat(name, max) : message);

            return this;
        }

        /// <summary>
        /// Dada um double, adicione uma notificação se seu valor for maior que o parâmetro max
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfGreaterThan(Expression<Func<T, double>> selector, double max, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val > max)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfGreaterThan.ToFormat(name, max) : message);

            return this;
        }

        /// <summary>
        /// Dada um float, adicione uma notificação se seu valor for maior que o parâmetro max
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfGreaterThan(Expression<Func<T, float>> selector, float max, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val > max)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfGreaterThan.ToFormat(name, max) : message);

            return this;
        }

        /// <summary>
        /// Dada um decimal, adicione uma notificação se seu valor for maior que o parâmetro max
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfGreaterThan(Expression<Func<T, decimal>> selector, decimal max, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val > max)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfGreaterThan.ToFormat(name, max) : message);

            return this;
        }

        /// <summary>
        /// Dada um DateTime, adicione uma notificação se seu valor for maior que o parâmetro max
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfGreaterThan(Expression<Func<T, DateTime>> selector, DateTime max, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val > max)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfGreaterThan.ToFormat(name, max) : message);

            return this;
        }
        #endregion

        /// <summary>
        /// Dada uma string, adicione uma notificação se seu comprimento for maior que o parâmetro max
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfLengthGreaterThan(Expression<Func<T, string>> selector, int max, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!string.IsNullOrEmpty(val) && val.Length > max)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLengthGreaterThan.ToFormat(name, max) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se seu comprimento for diferente do parâmetro length
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="length">Especific Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfLengthNoEqual(Expression<Func<T, string>> selector, int length, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!string.IsNullOrEmpty(val) && val.Length != length)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLengthNoEqual.ToFormat(name, length) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for um endereço de e-mail válido
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotEmail(Expression<Func<T, string>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!Regex.IsMatch(val, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"))
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotEmail.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for um URL válida
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotUrl(Expression<Func<T, string>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!Regex.IsMatch(val, @"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$"))
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotUrl.ToFormat(name) : message);

            return this;
        }

        #region IfGreaterOrEqualsThan
        /// <summary>
        /// Dado um int, adicione uma notificação se for maior ou igual ao parametro passado
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfGreaterOrEqualsThan(Expression<Func<T, int>> selector, int number, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val >= number)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfGreaterOrEqualsThan.ToFormat(name, number) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for maior ou igual ao parametro passado
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfGreaterOrEqualsThan(Expression<Func<T, decimal>> selector, decimal number, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val >= number)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfGreaterOrEqualsThan.ToFormat(name, number) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for maior ou igual ao parametro passado
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfGreaterOrEqualsThan(Expression<Func<T, double>> selector, double number, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val >= number)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfGreaterOrEqualsThan.ToFormat(name, number) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for maior ou igual ao parametro passado
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfGreaterOrEqualsThan(Expression<Func<T, float>> selector, float number, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val >= number)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfGreaterOrEqualsThan.ToFormat(name, number) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for maior ou igual ao parametro passado
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfGreaterOrEqualsThan(Expression<Func<T, DateTime>> selector, DateTime date, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val >= date)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfGreaterOrEqualsThan.ToFormat(name, date) : message);

            return this;
        }

        #endregion

        #region IfLowerOrEqualsThan
        /// <summary>
        /// Dado um int, adicione uma notificação se for menor ou igual ao parametro passado
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfLowerOrEqualsThan(Expression<Func<T, int>> selector, int number, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val <= number)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLowerOrEqualsThan.ToFormat(name, number) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for menor ou igual ao parametro passado
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfLowerOrEqualsThan(Expression<Func<T, decimal>> selector, decimal number, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val <= number)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLowerOrEqualsThan.ToFormat(name, number) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for menor ou igual ao parametro passado
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfLowerOrEqualsThan(Expression<Func<T, double>> selector, double number, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val <= number)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLowerOrEqualsThan.ToFormat(name, number) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for menor ou igual ao parametro passado
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfLowerOrEqualsThan(Expression<Func<T, float>> selector, float number, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val <= number)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLowerOrEqualsThan.ToFormat(name, number) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for menor ou igual ao parametro passado
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfLowerOrEqualsThan(Expression<Func<T, DateTime>> selector, DateTime date, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val <= date)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLowerOrEqualsThan.ToFormat(name, date) : message);

            return this;
        }

        #endregion

        #region IfNotRange
        /// <summary>
        /// Dado um int, adicione uma notificação se não estiver entre alguns dois valores
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotRange(Expression<Func<T, int>> selector, int a, int b, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < a || val > b)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotRange.ToFormat(name, a, b) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se não estiver entre alguns dois valores
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotRange(Expression<Func<T, decimal>> selector, decimal a, decimal b, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < a || val > b)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotRange.ToFormat(name, a, b) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se não estiver entre alguns dois valores
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotRange(Expression<Func<T, double>> selector, double a, double b, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < a || val > b)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotRange.ToFormat(name, a, b) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se não estiver entre alguns dois valores
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotRange(Expression<Func<T, float>> selector, float a, float b, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < a || val > b)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotRange.ToFormat(name, a, b) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se não estiver entre alguns dois valores
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotRange(Expression<Func<T, DateTime>> selector, DateTime a, DateTime b, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < a || val > b)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotRange.ToFormat(name, a, b) : message);

            return this;
        }

        #endregion

        #region IfRange
        /// <summary>
        /// Dado um int, adicione uma notificação se estiver entre alguns dois valores
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfRange(Expression<Func<T, int>> selector, int a, int b, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val > a && val < b)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfRange.ToFormat(name, a, b) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se estiver entre alguns dois valores
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfRange(Expression<Func<T, decimal>> selector, decimal a, decimal b, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val > a && val < b)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfRange.ToFormat(name, a, b) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se estiver entre alguns dois valores
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfRange(Expression<Func<T, double>> selector, double a, double b, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val > a && val < b)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfRange.ToFormat(name, a, b) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se estiver entre alguns dois valores
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfRange(Expression<Func<T, float>> selector, float a, float b, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val > a && val < b)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfRange.ToFormat(name, a, b) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se estiver entre alguns dois valores
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfRange(Expression<Func<T, DateTime>> selector, DateTime a, DateTime b, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val > a && val < b)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfRange.ToFormat(name, a, b) : message);

            return this;
        }

        #endregion

        /// <summary>
        /// Dada uma string, adicione uma notificação se ela não contiver um texto
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotContains(Expression<Func<T, string>> selector, string text, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!val.Contains(text))
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotContains.ToFormat(name, text) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se ela contiver um texto
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfContains(Expression<Func<T, string>> selector, string text, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val.Contains(text))
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfContains.ToFormat(name, text) : message);

            return this;
        }

        #region IfNotAreEquals
        /// <summary>
        /// Dada uma string, adicione uma notificação se não for igual a
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotAreEquals(Expression<Func<T, string>> selector, string text, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!val.Equals(text, StringComparison.OrdinalIgnoreCase))
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotAreEquals.ToFormat(name, text) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for igual a
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotAreEquals(Expression<Func<T, int>> selector, int value, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val != value)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotAreEquals.ToFormat(name, value) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for igual a
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotAreEquals(Expression<Func<T, double>> selector, double value, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val != value)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotAreEquals.ToFormat(name, value) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for igual a
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotAreEquals(Expression<Func<T, float>> selector, float value, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val != value)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotAreEquals.ToFormat(name, value) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for igual a
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotAreEquals(Expression<Func<T, decimal>> selector, decimal value, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val != value)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotAreEquals.ToFormat(name, value) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for igual a
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotAreEquals(Expression<Func<T, DateTime>> selector, DateTime value, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val != value)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotAreEquals.ToFormat(name, value) : message);

            return this;
        }

        #endregion

        #region IfAreEquals
        /// <summary>
        /// Dada uma string, adicione uma notificação se for igual a
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfAreEquals(Expression<Func<T, string>> selector, string text, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val.Equals(text, StringComparison.OrdinalIgnoreCase))
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfAreEquals.ToFormat(name, text) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for igual a
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfAreEquals(Expression<Func<T, int>> selector, int value, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == value)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfAreEquals.ToFormat(name, value) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for igual a
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfAreEquals(Expression<Func<T, double>> selector, double value, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == value)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfAreEquals.ToFormat(name, value) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for igual a
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfAreEquals(Expression<Func<T, float>> selector, float value, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == value)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfAreEquals.ToFormat(name, value) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for igual a
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfAreEquals(Expression<Func<T, decimal>> selector, decimal value, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == value)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfAreEquals.ToFormat(name, value) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for igual a
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfAreEquals(Expression<Func<T, DateTime>> selector, DateTime value, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == value)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfAreEquals.ToFormat(name, value) : message);

            return this;
        }
        #endregion

        /// <summary>
        /// Dada uma bool, adicione uma notificação se for verdadeira
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
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
        /// <returns></returns>
        public AddNotifications<T> IfFalse(Expression<Func<T, bool>> selector, string message = "")
        {
            var data = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (data == false)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfFalse.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for um cpf válido
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotCpf(Expression<Func<T, string>> selector, string message = "")
        {
            var cpf = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;




            if (string.IsNullOrWhiteSpace(cpf))
            {
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotCpf.ToFormat(name) : message);
                return this;
            }

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
            {
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotCpf.ToFormat(name) : message);
                return this;
            }

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            bool isValid = cpf.EndsWith(digito);

            if (isValid == false)
            {
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotCpf.ToFormat(name) : message);
                return this;
            }

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for um Cnpj válido
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotCnpj(Expression<Func<T, string>> selector, string message = "")
        {
            var cnpj = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (string.IsNullOrEmpty(cnpj))
            {
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotCnpj.ToFormat(name) : message);
                return this;
            }

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
            {
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotCnpj.ToFormat(name) : message);
                return this;
            }
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            bool isValid = cnpj.EndsWith(digito);

            if (isValid == false)
            {
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotCnpj.ToFormat(name) : message);
                return this;
            }

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for Guid
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotGuid(Expression<Func<T, string>> selector, string message = "")
        {
            var data = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            Guid x;

            if (Guid.TryParse(data, out x) == false)
            {
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotGuid.ToFormat(name) : message);
            }
            return this;
        }

        /// <summary>
        /// Dada uma coleção, adicione uma notificação se for nula
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfCollectionIsNull(Expression<Func<T, IEnumerable>> selector, string message = "")
        {
            IEnumerable colectionValue = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;


            if (colectionValue == null)
            {
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfCollectionIsNull.ToFormat(name) : message);
            }

            return this;
        }

        /// <summary>
        /// Dada uma coleção, adicione uma notificação se for nula ou não tenha itens
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfCollectionIsNullOrEmpty(Expression<Func<T, IEnumerable<T>>> selector, string message = "")
        {
            IEnumerable<T> colectionValue = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;


            if (colectionValue == null || colectionValue.ToList().Count <= 0)
            {
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfCollectionIsNullOrEmpty.ToFormat(name) : message);
            }

            return this;
        }

        /// <summary>
        /// Dada um int, adicione uma notificação se for igual a zero
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfEqualsZero(Expression<Func<T, int>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == 0)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfEqualsZero.ToFormat(name) : message);

            return this;
        }

        #region IfNull
        /// <summary>
        /// Dada um objeto, adicione uma notificação se for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNull(Expression<Func<T, object>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == null)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNull.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada um objeto int, adicione uma notificação se for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNull(Expression<Func<T, int?>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == null)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNull.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada um objeto double, adicione uma notificação se for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNull(Expression<Func<T, double?>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == null)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNull.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada um objeto float, adicione uma notificação se for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNull(Expression<Func<T, float?>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == null)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNull.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada um objeto decimal, adicione uma notificação se for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNull(Expression<Func<T, decimal?>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == null)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNull.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada um objeto de data, adicione uma notificação se for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNull(Expression<Func<T, DateTime>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == null)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNull.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada um objeto de data, adicione uma notificação se for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNull(Expression<Func<T, DateTime?>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == null)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNull.ToFormat(name) : message);

            return this;
        }
        #endregion

        #region IfNotNull
        /// <summary>
        /// Dada um objeto, adicione uma notificação se não for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotNull(Expression<Func<T, object>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val != null)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotNull.ToFormat(name) : message);

            return this;
        }
        /// <summary>
        /// Dada um objeto int, adicione uma notificação se não for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotNull(Expression<Func<T, int?>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val != null)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotNull.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada um objeto float, adicione uma notificação se não for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotNull(Expression<Func<T, float?>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val != null)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotNull.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada um objeto double, adicione uma notificação se não for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotNull(Expression<Func<T, double?>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val != null)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotNull.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada um objeto decimal, adicione uma notificação se não for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotNull(Expression<Func<T, decimal?>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val != null)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotNull.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada um objeto de data, adicione uma notificação se não for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotNull(Expression<Func<T, DateTime>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val != null)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotNull.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada um objeto de data, adicione uma notificação se não for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotNull(Expression<Func<T, DateTime?>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val != null)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotNull.ToFormat(name) : message);

            return this;
        }
        #endregion

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for uma data válida
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotDate(Expression<Func<T, string>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            try
            {
                DateTime dt = DateTime.Parse(val);
            }
            catch
            {
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotDate.ToFormat(name) : message);
            }

            return this;
        }
    }
}