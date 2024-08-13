sap.ui.define([
	"sap/ui/test/opaQunit",
	"./Estudio"
], (opaTest) => {
	"use strict";

	QUnit.module("Lista Estúdio");

		opaTest("Deve carregar a tela de listagem do Estúdio", function (Given, When, Then) {
			// Arrangements
			Given.iStartMyUIComponent({
				componentConfig: {
					name: "ui5.cod3rsgrowth"
				}
			});
	
			// Assertions
			Then
				.naPaginaListaEstudio
				.aTelaFoiCarregadaCorretamente();

			Then.
				iTeardownMyApp();
		});
});