# prmToolkit

# NotificationPattern
NotificationPattern é uma classe que nos permite adicionar notificações para qualquer objeto. Ex: Entidades, objetos de valor, serviços  e etc.

### Installation - ArgumentsValidator

Para instalar, abra o prompt de comando Package Manager Console do seu Visual Studio e digite o comando abaixo:

Para adicionar somente a referencia a dll
```sh
Install-Package prmToolkit.NotificationPattern
```
| Package |  Version | Downloads |
| ------- | ----- | ----- |
| `Flunt.Extensions.AspNet` | [![NuGet](https://img.shields.io/nuget/v/prmToolkit.NotificationPattern.svg)](https://nuget.org/packages/prmToolkit.NotificationPattern) | [![Nuget](https://img.shields.io/nuget/dt/prmToolkit.NotificationPattern.svg)](https://nuget.org/packages/prmToolkit.NotificationPattern) |

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
```


##### Levando as notificações para camada superior
Também é possível obter as notificações de uma classe filha para uma classe pai, ou seja, você pode pegar as notificações de objetos filhos e atribuir no pai. Isso é necessário caso você tenha o interesse de pegar as mensagens de uma entidade por exemplo e passar para seu serviço que por sua vez passa para sua api onde irá exibi-las para o usuário.

É o mesmo conceito da Exception, sendo que para ela chegar no topo é necessário fazer uso do método AddNotifications.

```sh
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
```

##### É possível adicionar notificações manualmente

```sh
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

- IfCollectionIsNullOrEmpty 

- IfEqualsZero 

- IfNull 

- IfNotNull 

- IfNotNullOrEmpty 

- IfNotDate 

- IfNullOrOrInvalidLength 

- IfLengthGreaterThan 

- IfLengthLowerThan 

- IsValid 

- IsInvalid 

- IfEnumInvalid


# VEJA TAMBÉM
## Grupo de Estudo no Telegram
- [Participe gratuitamente do grupo de estudo](https://t.me/blogilovecode)

## Cursos baratos!
- [Meus cursos](https://olha.la/udemy)

## Fique ligado, acesse!
- [Blog ILoveCode](https://ilovecode.com.br)

## Novidades, cupons de descontos e cursos gratuitos
https://olha.la/ilovecode-receber-cupons-novidades
