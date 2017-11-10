namespace prmToolkit.NotificationPattern.Extensions
{
    public static class EnumExtension
    {
        /// <summary>
        /// Validar se o valor que está no Enum foi definido corretamente
        /// </summary>
        /// <param name="value">Valor setado no Enum</param>
        /// <returns>Retorna se o Enum possuí valor válido.</returns>
        public static bool IsEnumValid(this System.Enum value)
        {
            if (System.Enum.IsDefined(value.GetType(), value))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Validar se o valor pertence a um Enum
        /// </summary>
        /// <typeparam name="TEnum">Tipo genérico que representa o Enum</typeparam>
        /// <param name="enumValue">Valor do inteiro</param>
        /// <returns>Retorna se o valor do inteiro informado, existe dentro do Enum.</returns>
        public static bool IsEnumValid<TEnum>(this int enumValue)
        {
            if (System.Enum.IsDefined(typeof(TEnum), enumValue))
            {
                return true;
            }

            return false;
        }
    }
}