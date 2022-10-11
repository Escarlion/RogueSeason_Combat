# RogueSeason_Combat
Alguns teste para o sistema de combate de Rogue Season

Versão do editor da Unity recomendado: 2020.3.27f1

Nota: é muito provavel que ao abrir o projeto, ocorra um bug envolvendo os materiais, é recomendado que instale o URP dentro do projeto da unity.

Como instalar o URP:

1- Ja dentro do projeto da Unity, vá em Window > Package Manager

2- Após abrir a aba do Package Manager, há uma pequena aba no canto superior esquerdo escrito "Packages: In Project", clique nela e mude para "Packages: Unity Registry"

3- Usando a ferramenta de busca, pesquise "Universal RP", e clique no botão "instalar"

4- Após completar a instalação, va em Edit > Project Settings > Graphics

5- Dentro dos Assets da Unity, há uma pasta chamada "Pipeline", dentro desta pasta há um arquivo nomeado como "Universal Render Pipeline Asset", segure-o e arreste-o para

a aba de Graphics, em um espaço chamado "Scriptable Render Pipeline Assets", no qual deve estar como "none"

6- Após isso, a maior parte dos problemas deve estar resolvido, mas, talvez seja necessario abrir o GameObject do player e mudar seu material para "Sprite-Lit-Default"

