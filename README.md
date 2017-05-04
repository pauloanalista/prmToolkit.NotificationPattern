# prmToolkit

# NotificationPattern
NotificationPattern é uma classe que nos permite adicionar notificações para qualquer objeto. Ex: Entidades, objetos de valor e etc.

### Installation - ArgumentsValidator

Para instalar, abra o prompt de comando Package Manager Console do seu Visual Studio e digite o comando abaixo:

Para adicionar somente a referencia a dll
```sh
Install-Package prmToolkit.NotificationPattern
```

### Exemplo de como usar
Atualmente as mensagens das notificações tem suporte aos idiomas pt-BR e en-US.
Caso não defina o idioma que quer usar ele irá se basear no idioma local, caso não exista suporte ele assumira o pt-BR.

Para setar o idioma, utilize a linhas abaixo:
```sh
Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
```

Trabalhando com classes
```sh
//Crie uma classe que herde de Notifiable para que seja notificavél
public class Customer : Notifiable
{
    public string Name { get; set; }

    public int Age { get; set; }

    public DateTime CreationDate { get; set; }

    public bool Active { get; set; }

    public string   Cpf { get; set; }

    public string   Cnpj { get; set; }

    public IEnumerable<Customer> Customers { get; set; }
}



//Dentro de algum método ou construtor qualquer
public void Metodo_Xpto()
{
    Customer _customer = new Customer();
    _customer.Name = "1234";

    //Adicionando as notificações na sua classe
    new AddNotifications<Customer>(_customer)
        .IfNotContains(x => x.Name, "567") //Se não contém a palavra 567 adicione uma notificação
        .IfNotGuid(x => x.Name); //Se não for um Guid valido adicione uma notificação
}

//Também é possível obter as notificações de uma classe filha para uma classe pai.
public class Pedido : Notifiable
{
    public void AddItem(ItemDoPedido item)
    {
        //Adiciona as notificações de ItemDoPedido no Pedido
        AddNotifications(item.Notifications);
        
        //ou
        AddNotifications(item);
        
        //Também é possível adicionar varios objetos notificaveis de uma so vez.
        //Ex:        
        //AddNotifications(objetoNotificavel1, objetoNotificavel2, objetoNotificavel3);
        
        if(item.IsValid()) //Se o item não tem notificações deixa continuar
        _items.Add(item);
    }
}

//É possível adicionar notificações manualmente
public bool AutenticarUsuario(string username, string password)
{
    if (Username == username && Password == EncryptPassword(password))
        return true;

    //Adicionando notificações manualmente
    AddNotification("User", "Usuário ou senha inválidos");

    return false;
}
```

### Metodos de validação:

- IfNullOrEmpty

- IfNullOrWhiteSpace

- IfNotNull

- IfNullOrEmptyOrInvalidLength

- IfLowerThen

- IfGreaterThan

- IfLengthNoEqual

- IfNotEmail

- IfNotUrl

- IfGreaterOrEqualsThan

- IfLowerOrEqualsThan

- IfNotRange

- IfRange

- IfNotContains

- IfContains

- IfNotAreEquals

- IfAreEquals

- IfTrue

- IfFalse

- IfNotCpf

- IfNotCnpj

- IfNotGuid

- IfCollectionIsNull
