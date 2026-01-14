using MyRecipeBook.Domain.Dtos.Requests;

namespace MyRecipeBook.Infrastructure.Services.OpenAI;

public static class PromptReportGenerator
{
    public static string Generate(GenerateReportDto request)
    {
        return $@"Faça um recado para os responsáveis dos meus alunos, a mensagem precisa ser formatada 
        para o whatsapp (se atente aos negritos, o whatsapp é um * em cada extremidade), precisa ser clara, 
        resumida e separada por tópicos, vou te passar os dados necessários para a mensagem ser enviada. 

        Nome da Turma: {request.LessonName}
        Data e Horário da Aula : {request.LessonDate}
        Nome do Professor: {request.Teacher}

        Explicacao do Nome da Turma: 
        #id_turma(pode ignorar) - #Nome_Turma(MUITO IMPORTANTE, JÁ IREI PASSAR A LEGENDA) / #Mes_Inicio(pode ignorar) 
        / #Dia_semana(pode ignorar) / #horario_aula(pode ignorar) / #Nome_Professor(Pode Ignorar)

        LEGENDA DA VÁRIAVEL #Nome_Turma:
        C = Ctrl;
        K = Kids;
        T = Teens;
        Y = Young;
        Numero = Módulo que a turma está;

        Exemplo 1: Ao se deparar com CK1 eu quero a turma como Ctrl+Kids 1;
        Exemplo 2: Ao se deparar com CY3 eu quero a turma como Ctrl+Young 3;

        A Data da aula eu quero no formato DD/MM/YYYY

        O Horário eu quero no formato HHhMM

        Modelo a Ser Seguido:

        📣 *Recado para os Responsáveis*
        📕 *Turma: #Nome_Turma*
        📅 *Data: DD/MM/YYYY, às HHhMM*

        Olá, tudo bem?
        Sou o Professor Nome_Professor | Ctrl+Play

        Hoje tivemos mais uma aula com a Turma *#Nome_Turma*, onde aprofundamos nossos conhecimentos em *HTML* com foco na criação de páginas mais completas e interativas. 💻🌐
        
        Confira abaixo os principais destaques da nossa aula:

        ✅ *Objetivo da aula*:
        • Avançar na estruturação de páginas web com HTML, aprendendo a criar *links*, *iframes*, *listas*, *tabelas* e utilizar *caracteres especiais*.

        🛠️ *O que fizemos hoje*:
        • Aprendemos a criar *links* entre páginas com a tag `<a>` e seus atributos `href` e `target`.
        • Inserimos outras páginas dentro da principal usando a tag `<iframe>`.
        • Criamos *listas ordenadas* (`<ol>`) e *não ordenadas* (`<ul>`) com diferentes estilos.
        • Estruturamos *tabelas* com `<table>`, `<tr>`, `<td>` e `<th>`, além de aplicar os atributos `border`, `colspan`, `rowspan`, `align`, `width`, `height` e `bgcolor`.
        • Utilizamos a tag `<hr>` para dividir seções da página com uma linha horizontal.
        • Estudamos como lidar com *caracteres especiais* usando entidades HTML, como `&lt;`, `&gt;` e `&amp;`.
        • Reforçamos a importância da tag `<meta charset=utf-8 />` para garantir a exibição correta dos acentos.

        💡 *Habilidades trabalhadas*:
        • Estruturação de páginas HTML com elementos mais complexos.
        • Navegação entre múltiplas páginas e organização de conteúdo.
        • Interpretação e depuração de códigos HTML.
        • Uso correto de entidades para exibir caracteres especiais.

        ✨ *Destaques da aula*:
        • A turma demonstrou bastante interesse na criação de tabelas e iframes.
        • Muitos alunos conseguiram criar suas próprias páginas com links funcionais e conteúdo organizado em listas e tabelas.
        • Introduzimos práticas importantes para a organização e manutenção de projetos com múltiplos arquivos HTML.

        🚀 *Próximos passos no módulo*:
        Na próxima aula, vamos conhecer as principais *novidades do HTML5* e começar a aplicar esses conhecimentos em projetos mais completos e visuais, integrando HTML com CSS!

        Qualquer dúvida, fico à disposição! 😊  

        Certifique se que sua resposta contenha apenas o modelo que passei, não quero nenhum comentário antes e nem depois!
        Conteudo para o recado: {request.LessonContent}";
    }
}