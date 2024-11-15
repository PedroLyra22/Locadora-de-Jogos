# Relatório do Projeto - Sistema de Locadora de Jogos

## 1. Introdução

Este projeto tem como objetivo o desenvolvimento de um sistema para gerenciar a locação de jogos em uma locadora. Ele foi implementado usando C# com Windows Forms, utilizando o banco de dados MariaDB e o padrão de projeto Singleton para gerenciamento da conexão com o banco de dados. A aplicação permite realizar operações de CRUD (Create, Read, Update, Delete) em entidades principais, como `Clientes`, `Jogos` e `Locações`, garantindo uma interface amigável e funcional para o usuário.

## 2. Objetivos

1. Consolidar o conhecimento em integração de banco de dados usando C# e Windows Forms.
2. Implementar CRUD para um banco de dados MariaDB.
3. Utilizar o padrão Singleton para gerenciar a conexão com o banco de dados, garantindo que apenas uma conexão ativa seja mantida durante o ciclo de vida da aplicação.
4. Criar uma aplicação intuitiva e fácil de usar para a gestão de locações de jogos.

## 3. Requisitos

### Requisitos Funcionais

- CRUD completo para as entidades:
  - **Clientes**: adicionar, visualizar, atualizar e excluir clientes.
  - **Jogos**: adicionar, visualizar, atualizar e excluir jogos.
  - **Locações**: adicionar, visualizar, atualizar e excluir locações.

### Requisitos Não Funcionais

- A aplicação deve ser implementada em **Windows Forms** com uma interface intuitiva e amigável.
- O banco de dados **MariaDB** deve ser utilizado para armazenar as informações de clientes, jogos e locações.
- O padrão de projeto **Singleton** deve ser aplicado para gerenciar a conexão com o banco de dados, garantindo uma única instância ativa de conexão.

## 4. Modelo de Dados

### Estrutura do Banco de Dados

O banco de dados é composto por três tabelas principais: `Clientes`, `Jogos` e `Locacoes`. Abaixo está uma breve descrição de cada uma delas.

#### 4.1 Tabela `Clientes`

| Coluna            | Tipo        | Descrição                          |
|-------------------|-------------|------------------------------------|
| id                | INT         | Identificador único do cliente     |
| nome              | VARCHAR(100)| Nome do cliente                    |
| email             | VARCHAR(100)| E-mail do cliente                  |
| telefone          | VARCHAR(15) | Telefone do cliente                |
| data_nascimento   | DATE        | Data de nascimento do cliente      |

#### 4.2 Tabela `Jogos`

| Coluna            | Tipo        | Descrição                           |
|-------------------|-------------|-------------------------------------|
| id                | INT         | Identificador único do jogo         |
| titulo            | VARCHAR(100)| Título do jogo                      |
| genero            | VARCHAR(50) | Gênero do jogo (Ação, Aventura, etc)|
| plataforma        | VARCHAR(50) | Plataforma do jogo (PC, Xbox, etc)  |
| ano_lancamento    | INT         | Ano de lançamento do jogo           |
| preco_diaria      | DECIMAL(10,2)| Preço da diária de locação do jogo |

#### 4.3 Tabela `Locacoes`

| Coluna            | Tipo        | Descrição                               |
|-------------------|-------------|-----------------------------------------|
| id                | INT         | Identificador único da locação          |
| id_cliente        | INT         | Identificador do cliente (chave estrangeira) |
| id_jogo           | INT         | Identificador do jogo (chave estrangeira) |
| data_locacao      | DATE        | Data da locação                         |
| data_devolucao    | DATE        | Data de devolução (pode ser nulo)       |
| valor_total       | DECIMAL(10,2)| Valor total da locação                  |

### Relacionamentos

1. **Cliente - Locação**: Um cliente pode ter várias locações, mas cada locação pertence a um único cliente (relação um-para-muitos).
2. **Jogo - Locação**: Um jogo pode estar em várias locações, mas cada locação se refere a um único jogo (relação um-para-muitos).

## 5. Estrutura do Código

### 5.1 Classe `DatabaseConnection`

A classe `DatabaseConnection` utiliza o padrão Singleton para garantir uma única instância de conexão ativa com o banco de dados MariaDB durante o ciclo de vida da aplicação. Esse design otimiza o uso de recursos e evita problemas de conexão.

```csharp
public class DatabaseConnection
{
    private static DatabaseConnection instance;
    private MySqlConnection connection;

    private DatabaseConnection()
    {
        string connectionString = "server=localhost;database=locadora;user=root;password=senha;";
        connection = new MySqlConnection(connectionString);
    }

    public static DatabaseConnection GetInstance()
    {
        if (instance == null)
            instance = new DatabaseConnection();
        return instance;
    }

    public MySqlConnection GetConnection()
    {
        return connection;
    }
}
```

### 5.2 Classes Modelo

#### Classe `Cliente`

Representa a entidade `Cliente` com as seguintes propriedades: `Id`, `Nome`, `Email`, `Telefone`, `DataNascimento`.

```csharp
public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public DateTime DataNascimento { get; set; }
}
```

#### Classe `Jogo`

Representa a entidade `Jogo` com as seguintes propriedades: `Id`, `Titulo`, `Genero`, `Plataforma`, `AnoLancamento`, `PrecoDiaria`.

```csharp
public class Jogo
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public string Plataforma { get; set; }
    public int AnoLancamento { get; set; }
    public decimal PrecoDiaria { get; set; }
}
```

#### Classe `Locacao`

Representa a entidade `Locacao` com as seguintes propriedades: `Id`, `IdCliente`, `IdJogo`, `DataLocacao`, `DataDevolucao`, `ValorTotal`.

```csharp
public class Locacao
{
    public int Id { get; set; }
    public int IdCliente { get; set; }
    public int IdJogo { get; set; }
    public DateTime DataLocacao { get; set; }
    public DateTime? DataDevolucao { get; set; }
    public decimal ValorTotal { get; set; }
}
```

### 5.3 Interface de Usuário (Windows Forms)

- **Formulário ClientesForm**: Exibe uma lista de clientes em um `DataGridView`, com funcionalidades para adicionar, editar e remover clientes.
- **Formulário JogosForm**: Exibe uma lista de jogos com opções de edição.
- **Formulário LocacoesForm**: Gerencia as locações, permitindo registrar e finalizar locações.

## 6. Conclusão

O sistema de locadora de jogos implementado atende aos requisitos propostos, consolidando o uso de C#, MariaDB e o padrão Singleton para conexão de banco de dados. Com uma interface amigável e funcionalidades completas de CRUD para cada entidade, o sistema é eficiente para gerenciar dados da locadora, possibilitando futuras expansões e otimizações.
Este projeto fortalece a compreensão sobre integração de banco de dados e padrões de design, além de preparar a base para sistemas de gerenciamento robustos.
