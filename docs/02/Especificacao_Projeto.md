# Especificações do Projeto

A definição exata do problema e os pontos mais relevantes a serem tratados neste projeto foi consolidada com a participação dos usuários em um trabalho de imersão feita pelos membros da equipe a partir da observação dos usuários em seu local natural e por meio de entrevistas. Os detalhes levantados nesse processo foram consolidados na forma de personas e histórias de usuários.

## Personas

As personas levantadas durante o processo de entendimento do problema são apresentadas na Figuras que se seguem.

<table class="tg">
<thead>
  <tr>
    <th class="tg-0pky" rowspan="2">
      <img src="./Persona1_Juca_Tavares.jpg" width="272" height="275">
    </th>
    <th class="tg-pie6" colspan="2"><span style="font-weight:bold">Juca Tavares</span></th>
  </tr>
  <tr>
    <th class="tg-0pky">●Idade: 25 anos<br><br> ●Ocupação: Estudante de biologia e músico <br> Tem uma banda de rock que compõe em inglês</th>
    <th class="tg-0pky">●Interessado em Música, Cultura japonesa <br> ●Usuário dos aplicativos Telegram e Instagram</th>
  </tr>
</thead>
<tbody>
  <tr>
    <td class="tg-0pky">●Motivação:<br> 
        &emsp; ●Consumir conteúdo em japonês, sem legendas ou dublagem<br>
        &emsp; ●Melhorar composição de músicas em inglês</td>
    <td class="tg-0pky">●Objetivo: Encontrar um grupo para praticar línguas</td>
    <td class="tg-0pky">●Frustração: Canais sem um foco específico <br> dificultam a busca por grupos para praticar línguas
  </tr>
</tbody>
</table>

<table class="tg">
<thead>
  <tr>
    <th class="tg-0pky" rowspan="2">
      <img src="./Persona2_Cibele_Monteiro.jpg" width="272" height="275">
    </th>
    <th class="tg-pie6" colspan="2"><span style="font-weight:bold">Cibele Monteiro</span></th>
  </tr>
  <tr>
    <th class="tg-0pky">●Idade: 28 anos<br><br> ●Ocupação: professora de inglês.</th>
    <th class="tg-0pky">●Entra no Omegle para conversar com pessoas estrangeiras <br> ●Encontros com amigos e turmas <br>●Estadunidense que precisa praticar o português </th>
  </tr>
</thead>
<tbody>
  <tr>
    <td class="tg-0pky">●Motivação:<br> 
        &emsp; ●	Ajudar pessoas a aprender inglês
    <td class="tg-0pky">●Objetivo: <br>&emsp;●Formar grupos de conversação de inglês <br>&emsp;●Encontrar pessoas para conversar em inglês presencial</td>
    <td class="tg-0pky">●Frustração: <br>&emsp;●Dificuldade de administrar o grupo de línguas. <br>&emsp;●Não conseguir ampliar os grupos no qual participa
  </tr>
</tbody>
</table>

<table class="tg">
<thead>
  <tr>
    <th class="tg-0pky" rowspan="2">
      <img src="./Persona3_Renato_Bernardes.jpg" width="272" height="275">
    </th>
    <th class="tg-pie6" colspan="2"><span style="font-weight:bold">Renato Bernardes</span></th>
  </tr>
  <tr>
    <th class="tg-0pky">●Idade: 45 anos<br><br> ●Ocupação: Empresário, dono de um café, com uma proposta cultural, recém aberto em Brasília.</th>
    <th class="tg-0pky">●Após uma viagem para a Holanda começou a se interessar por diversas culturas.</th>
  </tr>
</thead>
<tbody>
  <tr>
    <td class="tg-0pky">●Motivação: Criar um ambiente descolado e mais atrativo
    <td class="tg-0pky">●Objetivo: Atrair mais clientes para seu estabelecimento.</td>
    <td class="tg-0pky">●Frustração: <br>&emsp;●O espaço é grande, mas o movimento ainda é menor que o esperado pela falta de atratividade; <br>&emsp;●As pessoas conhecem pouco esse tipo de proposta de cafeteria cultural
  </tr>
</tbody>
</table>

## Histórias de usuários

| Eu como ... [PERSONA] | ...quero/desejo ... [O QUE]                                                                                                | ...para ... [POR QUE]                                                                                                                       |
|-----------------------|----------------------------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------|
| Juca Tavares          | poder procurar por eventos de poliglotas por data, localização e idioma                                                    | se programar para comparecer aos eventos                                                                                                    |
| Juca Tavares          | salvar meus dados e preferências                                                                                           |     não precisar digitá-los sempre que fizer uma busca                                                                                      |
| Juca Tavares          | poder alterar meus dados e preferências                                                                                    | fazer buscas com critérios diferentes quando necessário                                                                                     |
| Cibele Monteiro       | deixar disponível para consulta online os eventos de práticas poliglotas organizados por mim                               | pode indicar aos meus alunos e deixar acessível a outros interessados                                                                       |
| Cibele Monteiro       | encontrar com facilidade locais para a realização do encontro                                                              | facilitar a organização                                                                                                                     |
| Cibele Monteiro       | um local onde os participantes possam consultar as bandeiras que representam as línguas faldas no encontro por cada grupo. | para que eles possam identificar com facilidade os grupos formados nos locais, já que os identificamos colocando uma bandeira sobre a mesa. |
| Renato Bernardes      | oferecer meu espaço para os encontros de prática                                                                           | aumentar o movimento de meu estabelecimento                                                                                                 |
| Renato Bernardes      | poder estabelecer regras e horários para a utilização do espaço                                                            | evitar a lotação em horários de movimento elevado.                                                                                          |
| Renato Bernardes      | divulgar o contato e redes sociais de meu estabelecimento                                                                  | para facilitar o contato com os organizadores                                                                                               |

## Requisitos funcionais

<table class="tg">
<thead>
  <tr>
    <th class="tg-99c3"><span style="font-weight:bold">ID</span></th>
    <th class="tg-99c3"><span style="font-weight:bold">Descrição</span></th>
    <th class="tg-99c3"><span style="font-weight:bold">Prioridade</span></th>
  </tr>
</thead>
<tbody>
  <tr>
    <td class="tg-0lax">RF-1</td>
    <td class="tg-0lax">O site deverá permitir o cadastro de dois tipos de conta(estabelecimento/participante)</td>
    <td class="tg-0lax">Alta</td>
  </tr>
  <tr>
    <td class="tg-0lax">RF-2</td>
    <td class="tg-0lax">O site deverá permitir a criação de eventos</td>
    <td class="tg-0lax">Alta</td>
  </tr>
  <tr>
    <td class="tg-0lax">RF-3</td>
    <td class="tg-0lax">O site deverá permitir a busca filtrada por eventos</td>
    <td class="tg-0lax">Alta</td>
  </tr>
  <tr>
    <td class="tg-0lax">RF-4</td>
    <td class="tg-0lax">O site deverá permitir o login do usuário cadastrado</td>
    <td class="tg-0lax">Alta</td>
  </tr>
  <tr>
    <td class="tg-0lax">RF-5</td>
    <td class="tg-0lax">O site deverá permitir que o usuário logado edite as informações da conta</td>
    <td class="tg-0lax">Média</td>
  </tr>
  <tr>
    <td class="tg-0lax">RF-6</td>
    <td class="tg-0lax">O site deverá permitir que o usuário possa deletar a conta</td>
    <td class="tg-0lax">Baixa</td>
  </tr>
</tbody>
</table>

## Requisitos não funcionais

<table class="tg">
<thead>
  <tr>
    <th class="tg-99c3"><span style="font-weight:bold">ID</span></th>
    <th class="tg-99c3"><span style="font-weight:bold">Descrição</span></th>
    <th class="tg-99c3"><span style="font-weight:bold">Prioridade</span></th>
  </tr>
</thead>
<tbody>
  <tr>
    <td class="tg-0lax">RNF-1</td>
    <td class="tg-0lax">O site deverá fazer uso do JWToken para autenticação dos usuários</td>
    <td class="tg-0lax">Alta</td>
  </tr>
  <tr>
    <td class="tg-0lax">RNF-2</td>
    <td class="tg-0lax">O site deverá ser compatível com os principais navegadores do mercado como: (Chrome,Firefox,Edge)</td>
    <td class="tg-0lax">Alta</td>
  </tr>
  <tr>
    <td class="tg-0lax">RNF-3</td>
    <td class="tg-0lax">O site deverá ser de facil manutenção</td>
    <td class="tg-0lax">Alta</td>
  </tr>
  <tr>
    <td class="tg-0lax">RNF-4</td>
    <td class="tg-0lax">O site deverá ser facil de utilizar e entender</td>
    <td class="tg-0lax">Alta</td>
  </tr>
  <tr>
    <td class="tg-0lax">RNF-5</td>
    <td class="tg-0lax">O site deverá ser seguro e protegido contra acessos não autorizados</td>
    <td class="tg-0lax">Alta</td>
  </tr>
  <tr>
    <td class="tg-0lax">RNF-6</td>
    <td class="tg-0lax">O site deverá estar disponivél quando necessário</td>
    <td class="tg-0lax">Alta</td>
  </tr>
</tbody>
</table>

## Restrições

<table class="tg">
<thead>
  <tr>
    <th class="tg-99c3"><span style="font-weight:bold">ID</span></th>
    <th class="tg-99c3"><span style="font-weight:bold">Descrição</span></th>
  </tr>
</thead>
<tbody>
  <tr>
    <td class="tg-0lax">RE-1</td>
    <td class="tg-0lax">O projeto deverá ser entregue no final do semestre letivo, não podendo extrapolar a data de 19/03/2023</td>
  </tr>
  <tr>
    <td class="tg-0lax">RE-2</td>
    <td class="tg-0lax">O aplicativo deve se restringir às tecnologias básicas da Web no Frontend e Backend</td>
  </tr>
  <tr>
    <td class="tg-0lax">RE-3</td>
    <td class="tg-0lax">A equipe não pode subcontratar o desenvolvimento do trabalho</td>
  </tr>
</tbody>
</table>