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
			
		opaTest("Deve mostrar 25 Estúdios listados na view do Estúdio", function (Given, When, Then) {
			Then
				.naPaginaListaEstudio
				.aListaDeveTerPaginacao()
				.and.oTituloDeveMostrarOTamanhoTotalDeItens();

		});

		opaTest("Deve carregar mais itens", function (Given, When, Then) {
			When
				.naPaginaListaEstudio
				.euClicoEmMaisDados();

			Then
				.naPaginaListaEstudio
				.aPaginaDeveConterTodosOsEstudios();

			Then
				.iTeardownMyApp();
		})
});