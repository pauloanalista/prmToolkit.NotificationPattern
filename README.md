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

(Opcional) Para setar o idioma, utilize a linhas abaixo:
```sh
Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
```

#### Trabalhando com classes
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
        
        //É possível limpar as notificações de um objeto se for necessário
        _item.ClearNotifications();
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
#### Sobre as mensagens
Cada método abaixo já possui sua mensagem padrão no idioma inglês ou português, ou seja, não sendo necessário o desenvolvedor passar uma mensagem personalizada por parametro.

##### Sem mensagem personalizada

```sh
//É possível passar mensagens personalizadas também
public void Metodo_Sem_Mensagem_Personalizada()
{
    Customer _customer = new Customer();
    _customer.Name = "1234";

    //Adicionando as notificações na sua classe
    new AddNotifications<Customer>(_customer).IfNotGuid(x => x.Name); 
    
    //A aplicação irá imprimir
    //O campo 1234 deve ser um Guid válido.
}
```

##### Com mensagem personalizada
Caso tenha interesse em personalizar a mensagem, basta passar um parametro a mais, como podemos ver abaixo:

```sh
//É possível passar mensagens personalizadas também
public void Metodo_Com_Mensagem_Personalizada()
{
    Customer _customer = new Customer();
    _customer.Name = "1234";

    //Adicionando as notificações na sua classe
    new AddNotifications<Customer>(_customer).IfNotGuid(x => x.Name, "Passe um id do tipo GUID"); 
}
```

Também é possível passar uma mensagem personalizada através de um resource interno de sua aplicação.

```sh
public AdicionarResponse Adicionar(AdicionarRequest request)
{
    if (request == null)
    {
        //Mensagem do resource "Objeto {0} é obrigatório"
        //Utilize o ToFormat ao invés do string.Format para passar o parametro para string, assim seu codigo fica mais limpo
        //Utilize para isso o namespace prmToolkit.NotificationPattern.Extensions

        AddNotification("Adicionar", Message.OBJETO_X_E_OBRIGATORIO.ToFormat("AdicionarRequest"));
        return null;
    }
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
