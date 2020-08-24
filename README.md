# TesteImposto

Exercício 1 - Gravar XML no Path configurado no app.config

Exercício 2 - Gravar no Banco de dados

Exercício 3 - Imposto IPI

Exercício 4 - Procedure P_VALORES_CFOP

Exercício 5 - CFOP SP e RO para 6.006

Exercício 6 - Corrigir os bugs da tela

Exercício 7 - Regra de desconto para região sudeste

Exercício 8 - Melhoria da complexidade ciclomática

Exercício 9 - Melhoria técnica testes unitários

Exercício 10 - Analise
	Manutenção de uma tela de pedidos para geração de notas fiscais de clientes com geração de XML e gravação em banco de dados. 

	Exercício 1: Como o diretório onde o XML seria gravado seria controlado pela equipe de infra, foi adicionado no App.config a chave pathXML;
	Exercício 2: Criação do banco de dados teste ne servidor local/SQLExpress utilizando os scripts fornecidos para o teste;
	Exercício 3: Regra de IPI criada e persistida na base de dados junto com a alteração dos scripts;
	Exercício 4: Criada procedure P_VALORES_CFOP.sql;
	Exercício 5: Bug corrigido com o refactory da classe arrumando a ordem de chamada dos estados de destino e origem no momento da geração da nota fiscal.
	Exercício 6: Campos de Estado foram alterados para combos impedindo falhas de digitação a foram incluídas algumas validações de campos obrigatórios, ajuste na validação do checkbox de 'brinde', onde apresentava erro quando não estava flegado, limpeza dos campos ao salvar;
	Exercício 7: Criada a variável de desconto com persistencia no XML e na base de dados;
	Exercício 8: Código refatorado e reestruturado para aplicar os padrões DDD e SOLID;
	Exercício 9: Foi criado um projeto para a implementação de testes unitários para o projeto Imposto.core.

Questão 2 - Console app com a busca da stream e testes unitários no projeto de teste;
