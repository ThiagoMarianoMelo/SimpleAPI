Esse projeto contempla alguns padrões utilizados em novos projetos .Net para consulta futura
-

Uso de Mediator para abstração de comunicação entre camadas:
- Possibilita chamada dinâmica de um handler através do command (DTO)
- Deve possuir um objeto de resposta, podendo ou não conter dados
- Exemplo em: TestProject\TestProject\Configuration\MediatorConfiguration.cs

Configuração de DBContext usando EntityFramework:
- DbContext é a conexão do banco com a aplicação
- Usado para mapeamento de entidade e tabelas, necessário definir PrimaryKey, ForeignKey e outros através do metodo onModelCreating
- Utiliza DBSet<TEntity> para definir quais tabelas serão consideradas dentro do banco
- Exemplo em: TestProject.Data\Context\TestContext.cs

Injenção de dependência:
- Configuração feita para definir instanciação de classes em construtores
- Utilizado nesse exemplo com Scoped para que crie uma instância por escopo e seja apagado da memória ao fim do mesmo
- Scoped: por escopo, Transient: sempre que requisitar injenção criará nova instância, Singleton: Uma instância por Runtime
- Exemplo em: TestProject\Configuration\ServicesConfiguration.cs

Uso de Mapper para mapeamento de DTO to EntityObject:
- Mapeamento simplificado para facilitar codificação
- Pode ser usado para manipulação complexa e alteração de dados durante mapeamento
- Exemplo em: TestProject\Configuration\MapperConfiguration.cs

Uso de Autenticação com JWT Token e IdentityRoles:
- Geração de Token a partir de uma secret key para garantir segurança
- Adição de Claims e Roles ao Token para permitir acesso a rotas e envio de informações
- Exemplo de geração de token: TestProject.Application\Services\TokenService.cs
- Exemplo de AuhtorizationAttribute: TestProject\Authorizations\AdminAuthorization.cs
- Exemplo de configuração: TestProject\Configuration\IdentityConfiguration.cs + Program

Uso de CodeFirst/Migrations para criação e atualização do banco: 
- Migrations utilizadas junto ao EnttiyFramework para posibiitar criação e edição de tabelas
- Para criação de uma migration basta usar Add-Migration "Nome da Migration" + Update Database
- Importante adicionar a migração automática para que caso haja vários ambientes os bancos fiquem atualizados
- Exemplo de configuração de migration Automática no Program*
- Exemplo de Migrations geradas pela lib em: TestProject.Data\Migrations\


