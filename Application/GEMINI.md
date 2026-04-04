# Application Layer - Use Cases & Services

Esta camada contém a lógica de negócio principal do sistema, implementada através de Use Cases.

## Mandatos da Camada de Aplicação
1. **Relação com Repositórios**: Cada Use Case só pode injetar o repositório que pertence ao seu domínio (ex: `UserUseCase` só injeta `IUserRepository`).
2. **Uso de Interfaces**: Se um Use Case precisar de dados de outro domínio, ele deve injetar a **interface do Use Case** correspondente, e não o repositório (ex: `UserUseCase` injeta `IPersonUseCase`).
3. **Validação de Unicidade**: Use dados do repositório para verificar a unicidade, mas as regras de validação finais devem ser delegadas para as entidades de domínio através do mecanismo `GeneralValidator`.
4. **Respostas**: Sempre retorne objetos de resposta (`Response`) ou DTOs, nunca retorne as entidades de domínio diretamente para a API.

## Dicas para o Gemini
- Utilize `IUnitOfWork` para garantir atomicidade em operações complexas.
- Mantenha os Use Cases focados em orquestrar a lógica, delegando as regras de validação intrínsecas para as entidades.
