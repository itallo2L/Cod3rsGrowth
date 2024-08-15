sap.ui.define([
	'sap/ui/test/Opa5',
	'sap/ui/test/matchers/AggregationLengthEquals',
	'sap/ui/test/matchers/I18NText',
	'sap/ui/test/matchers/Properties',
	'sap/ui/test/actions/Press',
	'sap/ui/test/actions/EnterText'
],
	function (Opa5, AggregationLengthEquals, I18NText, Properties, Press, EnterText) {
		"use strict";

		const viewName = "ui5.cod3rsgrowth.app.estudio.Estudio";
		const idListaEstudio = "idListaEstudio";

		Opa5.createPageObjects({
			naPaginaListaEstudio: {
				actions: {
					aoClicarEmCarregarMaisEstudios: function () {
						return this.waitFor({
							viewName: viewName,
							actions: new Press(),
							success: () => Opa5.assert.ok(true, "O botão de carregar mais foi acionado."),
							errorMessage: "A página não tem um botão para mostrar mais itens."
						});
					},

					metodoPesquisarPor: function (nomeDoEstudio) {
						return this.waitFor({
							id: "idBarraDePesquisa",
							viewName: viewName,
							actions: new EnterText({
								text: nomeDoEstudio
							}),
							success: () => Opa5.assert.ok(true, "Pesquisa efetuada na barra de pesquisa."),
							errorMessage: "Nenhuma pesquisa foi efetuada na barra de pesquisa."
						});
					},

					aoPesquisarPor: function (nomeDoEstudio) {
						this.metodoPesquisarPor(nomeDoEstudio);
					},

					aoPesquisarEstudioInexistente: function (nomeDoEstudio) {
						this.metodoPesquisarPor(nomeDoEstudio);
					},

					aoLimparFiltroDePesquisa: function (nomeDoEstudio) {
						this.metodoPesquisarPor(nomeDoEstudio);
					},

					metodoSelecionar: function (statusDoEstudio) {
						return this.waitFor({
							id: "idSelecionarEstaAbertoOuFechado",
							viewName: viewName,
							actions: new Press(),
							success: function () {
								this.waitFor({
									controlType: "sap.ui.core.Item",
									matchers: [
										new Properties({
											key: statusDoEstudio,
											enabled: true
										})
									],
									actions: new Press(),
									success: () => Opa5.assert.ok(true, `A opção "${statusDoEstudio}" foi selecionada.`),
									errorMessage: "Nenhuma opção foi selecionada."
								})
							},
						});
					},

					aoSelecionarEstudiosAbertos: function (statusDoEstudio) {
						this.metodoSelecionar(statusDoEstudio);
					},

					aoSelecionarEstudiosFechados: function (statusDoEstudio) {
						this.metodoSelecionar(statusDoEstudio);
					},

					aoSelecionarTodosOsEstudios(statusDoEstudio) {
						this.metodoSelecionar(statusDoEstudio);
					}
				},
				assertions: {
					aTelaDeveCarregarCorretamente: function () {
						return this.waitFor({
							viewName: viewName,
							success: () => Opa5.assert.ok(true, "A tela de listagem carregou corretamente."),
							errorMessage: "A tela de listagem não carregou corretamente"
						});
					},

					aListaDeveConterVinteEstudios: function (quantidadeDeEstudios) {
						this.metodoQuantidadeDeEstudiosNaLista(quantidadeDeEstudios);
					},

					aListaDeveConterVinteECincoEstudios: function (quantidadeDeEstudios) {
						this.metodoQuantidadeDeEstudiosNaLista(quantidadeDeEstudios);
					},

					aListaDeveConterTrezeEstudios: function (quantidadeDeEstudios) {
						this.metodoQuantidadeDeEstudiosNoTitulo(quantidadeDeEstudios);
					},

					aListaDeveConterDozeEstudios: function (quantidadeDeEstudios) {
						this.metodoQuantidadeDeEstudiosNoTitulo(quantidadeDeEstudios);
					},

					aListaDeveConterZeroEstudios: function (quantidadeDeEstudios) {
						this.metodoQuantidadeDeEstudiosNoTitulo(quantidadeDeEstudios);
					},

					aListaDeveConterDozeEstudios(quantidadeDeEstudios) {
						this.metodoQuantidadeDeEstudiosNoTitulo(quantidadeDeEstudios);
					},

					aListaDeveConterTodosOsEstudios(quantidadeDeEstudios) {
						this.metodoQuantidadeDeEstudiosNoTitulo(quantidadeDeEstudios);
					},

					aListaDeveConterTresEstudios: function () {
						return this.waitFor({
							id: idListaEstudio,
							viewName: viewName,
							matchers: new AggregationLengthEquals({
								name: "items",
								length: 3
							}),
							success: function () {
								Opa5.assert.ok(true, "A lista contém três estúdios.")
							},
							errorMessage: "A lista não contém três estúdios."
						});
					},

					metodoQuantidadeDeEstudiosNoTitulo: function (quantidadeDeEstudios) {
						return this.waitFor({
							id: "idTituloBarraDeFerramentas",
							viewName: viewName,
							matchers: new I18NText({
								key: "tituloContadorDaBarraDeFerramentasEstudio",
								propertyName: "text",
								parameters: [quantidadeDeEstudios]
							}),
							success: () => Opa5.assert.ok(true, `O título da lista contém ${quantidadeDeEstudios} Estúdios.`),
							errorMessage: `O título da lista não contém ${quantidadeDeEstudios} Estúdios.`
						});
					},

					metodoQuantidadeDeEstudiosNaLista: function (quantidadeDeEstudios) {
						return this.waitFor({
							id: idListaEstudio,
							viewName: viewName,
							matchers: new AggregationLengthEquals({
								name: "items",
								length: quantidadeDeEstudios
							}),
							success: function () {
								Opa5.assert.ok(true, `A lista contém ${quantidadeDeEstudios} estúdios.`);
							},
							errorMessage: `A lista não contém todos os ${quantidadeDeEstudios} estúdios.`
						});
					}
				}
			}
		});
	});