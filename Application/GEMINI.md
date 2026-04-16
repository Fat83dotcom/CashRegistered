# Application Layer - Use Cases & Services

Esta camada contém a lógica de negócio principal do sistema, implementada através de Use Cases.

## Mandatos da Camada de Aplicação
1. **Relação com Repositórios**: Cada Use Case só pode injetar o repositório que pertence ao seu domínio (ex: `UserUseCase` só injeta `IUserRepository`).
2. **Uso de Interfaces**: Se um Use Case precisar de dados de outro domínio, ele deve injetar a **interface do Use Case** correspondente, e não o repositório (ex: `UserUseCase` injeta `IPersonUseCase`).
3. **Validação de Unicidade**: Use dados do repositório para verificar a unicidade, mas as regras de validação finais devem ser delegadas para as entidades de domínio através do mecanismo `GeneralValidator`.
4. **Respostas e DTOs (Padrão de Nomenclatura)**: 
    - **Consultas (Queries)**: Respostas destinadas à API (expostas via Controller) devem seguir o padrão `Get[Nome]Response`.
    - **Operações CRUD**: Respostas destinadas à API devem ser específicas: `CreateResponse`, `UpdateResponse`, `DeleteResponse`.
    - **Circulação Interna**: É permitido que Use Cases retornem entidades de domínio (`Entities`) ou objetos `Result` para outros Use Cases ou para o Controller (desde que o Controller não as exponha), mas a **boa prática** exige que o Use Case forneça o DTO final para a API.
    - **Proibição de Exposição**: Em nenhuma hipótese uma entidade de domínio deve ser incluída no corpo da resposta HTTP (JSON/XML) enviada ao cliente.
    - **Responsabilidade de Mapeamento**: O Use Case é o responsável final por transformar entidades em DTOs de resposta antes que os dados saiam da camada de Application para a Web/API.

## Dicas para o Gemini
- Utilize `IUnitOfWork` para garantir atomicidade em operações complexas.
- Mantenha os Use Cases focados em orquestrar a lógica, delegando as regras de validação intrínsecas para as entidades.
