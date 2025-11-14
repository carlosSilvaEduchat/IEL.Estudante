# IEL.Estudantes - Teste Prático para Estágio

##  Sobre o Projeto

Este projeto foi desenvolvido como parte do processo seletivo para estágio no IEL. O objetivo era criar um sistema web para gerenciamento de estudantes, demonstrando conhecimentos em:

- ASP.NET Core MVC
- Entity Framework Core
- SQLite
- Frontend responsivo
- Boas práticas de desenvolvimento

##  Objetivos do Teste

O teste prático tinha como objetivo avaliar:

1. **Habilidades Técnicas**:
   - Desenvolvimento backend com .NET Core
   - Manipulação de banco de dados
   - Validação de formulários
   - Tratamento de erros

2. **Qualidades Profissionais**:
   - Organização do código
   - Documentação
   - Atenção aos requisitos
   - Qualidade do produto final

##  Estrutura do Projeto

```
IEL.Estudantes/
├── Controllers/        # Controladores da aplicação
├── Data/              # Contexto do banco de dados
├── Models/            # Modelos de dados
├── Services/          # Serviços de negócio
├── Validations/       # Validações personalizadas
├── Views/             # Views da aplicação
├── wwwroot/           # Arquivos estáticos
│   ├── css/           # Estilos personalizados
│   └── js/            # Scripts JavaScript
└── README.md          # Documentação do projeto
```

## Requisitos Atendidos

- [x] CRUD completo de estudantes
- [x] Validação de CPF (formato e dígitos verificadores)
- [x] Verificação de CPF único
- [x] Interface responsiva
- [x] Tema claro/escuro
- [x] Mensagens de feedback
- [x] Confirmação de exclusão
- [x] Busca por nome/CPF
- [x] Documentação completa

##  Como Executar

1. Clone o repositório
2. Execute `dotnet restore`
3. Execute `dotnet ef database update`
4. Inicie com `dotnet run`

##  Observações do Candidato

- Implementei validação completa de CPF, incluindo verificação de dígitos
- Adicionei um sistema de temas claro/escuro com persistência
- Criei uma interface responsiva que se adapta a diferentes tamanhos de tela
- Implementei mensagens de feedback para melhor experiência do usuário
- Documentei todo o código e criei um README completo

##  Contato

- **Nome**: Carlos Henrique soares da Silva 
- **E-mail**: c4henrique07@gmail.com
- **Telefone** +55 71 99411-1622
- **GitHub**: c4henrique, carlosSilvaEduchat
