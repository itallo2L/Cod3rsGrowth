sap.ui.define([
	"sap/ui/test/opaQunit",
	"./Estudio"
], (opaTest) => {
	"use strict";

	QUnit.module("Lista Estúdio");

		opaTest("Deve carregar a tela de listagem do Estúdio", function (Given, When, Then) {
			Given.iStartMyUIComponent({
				componentConfig: {
					name: "ui5.cod3rsgrowth"
				}
			});
	
			Then
				.naPaginaListaEstudio
				.aTelaFoiCarregadaCorretamente();
		});
			
		opaTest("Deve mostrar 20 Estúdios listados na view do Estúdio", function (Given, When, Then) {
			Then
				.naPaginaListaEstudio
				.aListaDeveTerPaginacao();
		});

		opaTest("Deve carregar mais Estúdios", function (Given, When, Then) {
			When
				.naPaginaListaEstudio
				.aoClicarEmCarregarMaisEstudios();

			Then
				.naPaginaListaEstudio
				.aListaDeveConterVinteECincoEstudios(25);
		});

		opaTest("Deve filtrar por Estúdios abertos", function (Given, When, Then) {
			When
				.naPaginaListaEstudio
				.aoSelecionarEstudiosAbertos("aberto");

			Then
				.naPaginaListaEstudio
				.aListaDeveConterTrezeEstudios(13);
		});

		opaTest("Deve filtrar por Estúdios fechados", function (Given, When, Then) {
			When
				.naPaginaListaEstudio
				.aoSelecionarEstudiosFechados("fechado");

			Then
				.naPaginaListaEstudio
				.aListaDeveConterDozeEstudios(12);
		});

		opaTest("Deve pesquisar por três Estúdios", function (Given, When, Then) {
			When
				.naPaginaListaEstudio
				.aoPesquisarPor("Estudio Vinte");

			Then
				.naPaginaListaEstudio
				.aTabelaTemUmEstudio();
		});

		opaTest("Deve pesquisar por um Estúdio inexistente", function (Given, When, Then) {
			When
				.naPaginaListaEstudio
				.aoPesquisarNomeInexistente("Inexistente");

			Then
				.naPaginaListaEstudio
				.aListaDeveConterZeroEstudios(0);
		});

		opaTest("Deve limpar o filtro de pesquisa", function (Given, When, Then) {
			When
				.naPaginaListaEstudio
				.aoLimparFiltroDePesquisa("");

			Then
				.naPaginaListaEstudio
				.aListaDeveConterDozeEstudios(12);
		});

		opaTest("Deve limpar o filtro de está aberto", function (Given, When, Then) {
			When
				.naPaginaListaEstudio
				.aoSelecionarTodosOsEstudios("todos");

			Then
				.naPaginaListaEstudio
				.aListaDeveConterTodosOsEstudios(25);
			
			Then
				.iTeardownMyApp();
		});
});