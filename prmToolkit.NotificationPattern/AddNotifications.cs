namespace prmToolkit.NotificationPattern
{
    public partial class AddNotifications<T> where T : Notifiable
    {
        /// <summary>
        /// Objeto que receberá as notificações
        /// </summary>
        private readonly T _notifiableObject;

        /// <summary>
        /// Adiciona notificações a qualquer objeto que seja notificável, ou seja, que implemente a classe Notifiable
        /// </summary>
        /// <param name="notifiableObject">Informe o objeto que irá receber as notificações</param>
        public AddNotifications(T notifiableObject)
        {
            _notifiableObject = notifiableObject;
        }

    }
}