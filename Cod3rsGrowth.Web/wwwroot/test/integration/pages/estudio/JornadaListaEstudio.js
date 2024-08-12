sap.ui.define([
    "sap/ui/test/opaQunit",
    "./Lista"
], function (opaQunit,
    Lista) {
        "use strict";
    opaQunit.module("ListaEstudio", () => {

        opaTest("Deve exibir a tela de listagm do Estúdio", function (Given, When, Then) {
            Given.iStartMyApp({
                hash: "/#/estudio"
            });

            Then
                .naPaginaDeListaEstudio
                .aTelaFoiCarregadaCorretamente();
        });
    });
});