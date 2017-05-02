using System;
using System.Collections;
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
        /// <param name="selector">Property</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNullOrEmpty(Expression<Func<T, string>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (string.IsNullOrEmpty(val))
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} is required." : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for nula ou vazia ou com espaços em branco
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNullOrWhiteSpace(Expression<Func<T, string>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val))
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} is required." : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for nula
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotNull(Expression<Func<T, string>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!string.IsNullOrEmpty(val))
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} is not required." : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for nula ou vazia ou com espaços em branco ou seu tamanho seja invalido
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNullOrEmptyOrInvalidLength(Expression<Func<T, string>> selector, int min, int max, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val) || val.Length < min || val.Length > max)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} is required with size min {min} and max {max}." : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se seu comprimento for menor que o parâmetro min
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfLowerThen(Expression<Func<T, string>> selector, int min, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!string.IsNullOrEmpty(val) && val.Length < min)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must have at least {min} characters." : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se seu comprimento for maior que o parâmetro max
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfGreaterThan(Expression<Func<T, string>> selector, int max, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!string.IsNullOrEmpty(val) && val.Length > max)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must have at least {max} characters." : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se seu comprimento for diferente do parâmetro length
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="length">Especific Length</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfLengthNoEqual(Expression<Func<T, string>> selector, int length, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!string.IsNullOrEmpty(val) && val.Length != length)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must have exactly {length} characters." : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for um endereço de e-mail válido
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotEmail(Expression<Func<T, string>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!Regex.IsMatch(val, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"))
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be a valid E-mail address." : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for um URL válida
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotUrl(Expression<Func<T, string>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!Regex.IsMatch(val, @"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$"))
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be a valid URL." : message);

            return this;
        }

        #region IfGreaterOrEqualsThan
        /// <summary>
        /// Dado um int, adicione uma notificação se for maior ou igual ao parametro passado
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfGreaterOrEqualsThan(Expression<Func<T, int>> selector, int number, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val >= number)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"The field {name} must be greater than or equal to {number}." : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for maior ou igual ao parametro passado
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfGreaterOrEqualsThan(Expression<Func<T, decimal>> selector, decimal number, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val >= number)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"The field {name} must be greater than or equal to {number}." : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for maior ou igual ao parametro passado
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfGreaterOrEqualsThan(Expression<Func<T, double>> selector, double number, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val >= number)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"The field {name} must be greater than or equal to {number}." : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for maior ou igual ao parametro passado
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfGreaterOrEqualsThan(Expression<Func<T, float>> selector, float number, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val >= number)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"The field {name} must be greater than or equal to {number}." : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for maior ou igual ao parametro passado
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfGreaterOrEqualsThan(Expression<Func<T, DateTime>> selector, DateTime date, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val >= date)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"The field {name} must be greater than or equal to {date}." : message);

            return this;
        }

        #endregion

        #region IfLowerOrEqualsThan
        /// <summary>
        /// Dado um int, adicione uma notificação se for menor ou igual ao parametro passado
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfLowerOrEqualsThan(Expression<Func<T, int>> selector, int number, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val <= number)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"The field {name} must be Lower than or equal to {number}." : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for menor ou igual ao parametro passado
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfLowerOrEqualsThan(Expression<Func<T, decimal>> selector, decimal number, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val <= number)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"The field {name} must be Lower than or equal to {number}." : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for menor ou igual ao parametro passado
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfLowerOrEqualsThan(Expression<Func<T, double>> selector, double number, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val <= number)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"The field {name} must be Lower than or equal to {number}." : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for menor ou igual ao parametro passado
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfLowerOrEqualsThan(Expression<Func<T, float>> selector, float number, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val <= number)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"The field {name} must be Lower than or equal to {number}." : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for menor ou igual ao parametro passado
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfLowerOrEqualsThan(Expression<Func<T, DateTime>> selector, DateTime date, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val <= date)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"The field {name} must be Lower than or equal to {date}." : message);

            return this;
        }

        #endregion

        #region IfNotRange
        /// <summary>
        /// Dado um int, adicione uma notificação se não estiver entre alguns dois valores
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotRange(Expression<Func<T, int>> selector, int a, int b, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < a || val > b)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be Range {a} and {b}." : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se não estiver entre alguns dois valores
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotRange(Expression<Func<T, decimal>> selector, decimal a, decimal b, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < a || val > b)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be Range {a} and {b}." : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se não estiver entre alguns dois valores
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotRange(Expression<Func<T, double>> selector, double a, double b, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < a || val > b)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be Range {a} and {b}." : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se não estiver entre alguns dois valores
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotRange(Expression<Func<T, float>> selector, float a, float b, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < a || val > b)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be Range {a} and {b}." : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se não estiver entre alguns dois valores
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotRange(Expression<Func<T, DateTime>> selector, DateTime a, DateTime b, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < a || val > b)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be Range {a} and {b}." : message);

            return this;
        }

        #endregion

        #region IfRange
        /// <summary>
        /// Dado um int, adicione uma notificação se estiver entre alguns dois valores
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfRange(Expression<Func<T, int>> selector, int a, int b, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val > a && val < b)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be Range {a} and {b}." : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se estiver entre alguns dois valores
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfRange(Expression<Func<T, decimal>> selector, decimal a, decimal b, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val > a && val < b)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be Range {a} and {b}." : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se estiver entre alguns dois valores
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfRange(Expression<Func<T, double>> selector, double a, double b, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val > a && val < b)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be Range {a} and {b}." : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se estiver entre alguns dois valores
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfRange(Expression<Func<T, float>> selector, float a, float b, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val > a && val < b)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be Range {a} and {b}." : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se estiver entre alguns dois valores
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfRange(Expression<Func<T, DateTime>> selector, DateTime a, DateTime b, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val > a && val < b)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be Range {a} and {b}." : message);

            return this;
        }

        #endregion

        /// <summary>
        /// Dada uma string, adicione uma notificação se ela não contiver um texto
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotContains(Expression<Func<T, string>> selector, string text, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!val.Contains(text))
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be contains {text}." : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se ela contiver um texto
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfContains(Expression<Func<T, string>> selector, string text, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val.Contains(text))
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be not contains {text}." : message);

            return this;
        }

        #region IfNotAreEquals
        /// <summary>
        /// Dada uma string, adicione uma notificação se não for igual a
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotAreEquals(Expression<Func<T, string>> selector, string text, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!val.Equals(text, StringComparison.OrdinalIgnoreCase))
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} should be equals to {text}." : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for igual a
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotAreEquals(Expression<Func<T, int>> selector, int value, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val != value)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} should be equals to {value}." : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for igual a
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotAreEquals(Expression<Func<T, double>> selector, double value, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val != value)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} should be equals to {value}." : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for igual a
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotAreEquals(Expression<Func<T, float>> selector, float value, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val != value)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} should be equals to {value}." : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for igual a
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotAreEquals(Expression<Func<T, decimal>> selector, decimal value, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val != value)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} should be equals to {value}." : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for igual a
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotAreEquals(Expression<Func<T, DateTime>> selector, DateTime value, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val != value)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} should be equals to {value}." : message);

            return this;
        }

        #endregion

        #region IfAreEquals
        /// <summary>
        /// Dada uma string, adicione uma notificação se for igual a
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfAreEquals(Expression<Func<T, string>> selector, string text, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val.Equals(text, StringComparison.OrdinalIgnoreCase))
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} should be not equals to {text}." : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for igual a
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfAreEquals(Expression<Func<T, int>> selector, int value, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == value)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} should be not equals to {value}." : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for igual a
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfAreEquals(Expression<Func<T, double>> selector, double value, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == value)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} should be not equals to {value}." : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for igual a
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfAreEquals(Expression<Func<T, float>> selector, float value, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == value)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} should be not equals to {value}." : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for igual a
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfAreEquals(Expression<Func<T, decimal>> selector, decimal value, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == value)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} should be not equals to {value}." : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for igual a
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfAreEquals(Expression<Func<T, DateTime>> selector, DateTime value, string message = "")
        {
            var val = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == value)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} should be not equals to {value}." : message);

            return this;
        }
        #endregion

        /// <summary>
        /// Dada uma bool, adicione uma notificação se for verdadeira
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfTrue(Expression<Func<T, bool>> selector, string message = "")
        {
            var data = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (data == true)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} should be false." : message);

            return this;
        }

        /// <summary>
        /// Dada uma bool, adicione uma notificação se for falso
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfFalse(Expression<Func<T, bool>> selector, string message = "")
        {
            var data = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (data == false)
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} should be true." : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for um cpf válido
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotCpf(Expression<Func<T, string>> selector, string message = "")
        {
            var cpf = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;




            if (string.IsNullOrWhiteSpace(cpf))
            {
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be a valid Cpf." : message);
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
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be a valid Cpf." : message);
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
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be a valid Cpf." : message);
                return this;
            }

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for um Cnpj válido
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotCnpj(Expression<Func<T, string>> selector, string message = "")
        {
            var cnpj = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (string.IsNullOrEmpty(cnpj))
            {
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be a valid Cnpj." : message);
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
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be a valid Cnpj." : message);
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
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} must be a valid Cnpj." : message);
                return this;
            }

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for Guid
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfNotGuid(Expression<Func<T, string>> selector, string message = "")
        {
            var data = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            Guid x;

            if (Guid.TryParse(data, out x) == false)
            {
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"Field {name} should be false." : message);
            }
            return this;
        }

        /// <summary>
        /// Dada uma coleção, adicione uma notificação se for nula
        /// </summary>
        /// <param name="selector">Property</param>
        /// <param name="message">Error Message (Optional)</param>
        /// <returns></returns>
        public AddNotifications<T> IfCollectionIsNull(Expression<Func<T, IEnumerable>> selector, string message = "")
        {
            IEnumerable colectionValue = selector.Compile().Invoke(_validatable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            
            if (colectionValue == null)
            {
                _validatable.AddNotification(name, string.IsNullOrEmpty(message) ? $"The {name} field must have an instance for IEnumerable." : message);
            }

            return this;
        }
    }
}