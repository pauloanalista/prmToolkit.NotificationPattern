namespace prmToolkit.NotificationPattern.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// ToFormat tem a mesma finalidade do string.Format, podendo setar novos valores em uma string de forma dinamica.
        /// </summary>
        /// <param name="mensagem">Mensagem que contém as paravras reservadas {0} para subistituição</param>
        /// <param name="parametros">Parametros que serão usados para sobrescrever a string</param>
        /// <returns></returns>
        public static string ToFormat(this string mensagem, params object[] parametros)
        {
            return string.Format(mensagem, parametros);
        }
    }
}
