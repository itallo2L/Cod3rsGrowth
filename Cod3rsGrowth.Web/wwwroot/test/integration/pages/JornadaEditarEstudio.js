sap.ui.define([
    "sap/ui/test/opaQunit",
    "./DetalhesEstudio",
    "./EditarEstudio",
], (opaTest) => {
    "use strict";

    QUnit.module("Editar Estúdio");

    opaTest("Deve carregar a tela de Editar Estúdio", function (Given, When, Then) {
        Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5.cod3rsgrowth"
			}
		});

        When
            .naPaginaListaEstudio
            .aoClicarEmEstudioUm();

        When
            .naPaginaDetalhesEstudio
            .aoClicarEmEditar("sap.m.Button", "Editar", "Sucesso", "Fracasso");

        Then
            .naPaginaEditarEstudio
            .aPaginaDeEditarDeveCarregarCorretamente();
    });
});