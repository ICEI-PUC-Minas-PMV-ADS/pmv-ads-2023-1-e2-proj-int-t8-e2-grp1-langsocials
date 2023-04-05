
# Metodologia

## Controle de Versão

A ferramenta de controle de versão adotada no projeto foi o
[Git](https://git-scm.com/), sendo que o [Github](https://github.com)
foi utilizado para hospedagem do repositório.

O projeto segue a seguinte convenção para o nome de branches:

`x3
- `main` : mais recente versão estável e testada do software.
- `dev` : mais recente versão estável e com recursos completos mais recente.
- `feat/(nome do issue)` : versão instável para trabalho numa feature, deve ser mergeada na dev após teste, via Pull Request.
- `work/(nome do issue)/(nome do desenvolvedor)` : versão instável para trabalho numa feature por um desenvolvedor em especifico, deve ser mergeada na feat/(nome da isssue) após teste, via Pull Request.
- `release/(etapa 1, etapa 2, .., etapa 6)` : copia da versão mais recente da main no momento da entrega da etapa.

Quanto à gerência de issues, o projeto adota a seguinte convenção para
etiquetas:

- `doc` : Criar, melhorar ou corrigir documentação
- `bug` : Correção de um erro ou falha
- `feat` : Nova feature ou melhoria em existentes
- `spike` : Dúvida, levantamento, ou descoberta

## Gerenciamento de Projeto

### Divisão de Papéis

 - Scrum Master: Luiz Eduardo de Jesus Santana
 - Product Owner: Alessandra Thevenard Freire
 - Equipe de Desenvolvimento
    - Adeilton Rodrigues Farias Junior
    - Carlos Alberto Mendonça Vasconcelos
    - Gustavo Henrique De Jesus Almeida
    - Luiz Eduardo de Jesus Santana 
    - Pedro Rafael da Cruz Almeida
    - Alessandra Thevenard Freire

### Processo

Para a divisão de tarefas em projetos de desenvolvimento de software, é utilizado as "issues" do Github, já que esse recurso se integra facilmente ao fluxo de trabalho do Git que é seguido pela aplicação. Cada issue criada no Github é associada a uma branch específica, o que possibilita que, ao mesclar (merge) essa branch em outra, a issue seja concluída automaticamente. Essa abordagem simplifica e agiliza o processo de gerenciamento de tarefas e facilita a colaboração entre membros da equipe.

![Tela de issues](./Tela%20de%20issues.png)

### Ferramentas

|   **Ferramenta**   | **Link**                                                                                                   |
|:------------------:|------------------------------------------------------------------------------------------------------------|
|    Visual Studio   | [https://visualstudio.microsoft.com/pt-br/downloads/](https://visualstudio.microsoft.com/pt-br/downloads/) |
| Visual Studio Code | [https://code.visualstudio.com/downloa](https://code.visualstudio.com/download)                            |
|     InvisionAPP    | [https://www.invisionapp.com](https://www.invisionapp.com)                                                 |
|       Draw.io      | [https://app.diagrams.net/](https://app.diagrams.net/)                                                     |
|        Figma       | [https://www.figma.com/](https://www.figma.com/)                                                           |
|         Git        | [https://git-scm.com/](https://git-scm.com/)                                                               |
|       GitHub       | [https://github.com/](https://github.com/)                                                                 |
